using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookshopSystemProblems
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context= new BookshopSystemContext();
            using (context)
            {
                Console.WriteLine("----------------- Problem.1 -----------------");
                //1. Books Titles by Age Restriction
                BooksByAgeRestriction(context);

                Console.WriteLine("----------------- Problem.2 -----------------");
                //2. Golden Books
                GoldenBooks(context);

                Console.WriteLine("----------------- Problem.3 -----------------");
                //3. Books by Price
                BooksByPrice(context);

                Console.WriteLine("----------------- Problem.4 -----------------");
                //4. Not Released Books
                NotReleasedBooks(context);

                Console.WriteLine("----------------- Problem.5 -----------------");
                //5. Book Titles by Category
                BooksByCategory(context);

                Console.WriteLine("----------------- Problem.6 -----------------");
                //6. Books Released Before Date
                BooksReleasedBeforeDate(context);

                Console.WriteLine("----------------- Problem.7 -----------------");
                //7. Authors Search
                AuthorsSearch(context);

                Console.WriteLine("----------------- Problem.8 -----------------");
                //8. Books Search
                BooksSearch(context);

                Console.WriteLine("----------------- Problem.9 -----------------");
                //9. Book Titles Search
                BookTitlesSearch(context);

                Console.WriteLine("----------------- Problem.10 -----------------");
                //10. Count Books
                CountBooks(context);

                Console.WriteLine("----------------- Problem.11 -----------------");
                //11. Total Book Copies
                TotalBookCopies(context);

                Console.WriteLine("----------------- Problem.12 -----------------");
                //12. Find Profit
                FindProfit(context);

                Console.WriteLine("----------------- Problem.13 -----------------");
                //13. Most Recent Books
                MostRecentBooks(context);

                Console.WriteLine("----------------- Problem.14 -----------------");
                //14. Increase Book Copies
                IncreaseBookCopies(context);

                Console.WriteLine("----------------- Problem.15 -----------------");
                //15. Remove Books
                RemoveBooks(context);

                Console.WriteLine("----------------- Problem.16 -----------------");
                //16. Stored Procedure
                StoredProcedure(context);

            }
        }
        public enum AgeRestriction
        {
            minor = 0,
            teen = 1,
            adult = 2
        };

        public enum EditionType
        {
            normal,
            promo,
            gold
        };
        private static void BooksByAgeRestriction(BookshopSystemContext context)
        {
            string line = Console.ReadLine();
            var books = context.Books;
            List<Book> list = new List<Book>();
            foreach (var book in books)
            {
                AgeRestriction x = (AgeRestriction)book.Restriction;
                if (x.ToString() == line.ToLower())
                {
                    Console.WriteLine(book.Title);
                }

            }
        }
        private static void GoldenBooks(BookshopSystemContext context)
        {
            var books = context.Books.Where(b=>(((EditionType)b.Edition).ToString()=="gold") && b.Copies<5000).OrderBy(b=>b.Id);
            foreach (var book in books)
            {                
                Console.WriteLine(book.Title);               
            }
        }
        private static void BooksByPrice(BookshopSystemContext context)
        {
            var books = context.Books.Where(b => b.Price<5.00m || b.Price>45.00m).OrderBy(b => b.Id);
            foreach (var book in books)
            {
                Console.WriteLine("{0} - ${1}",book.Title,book.Price);
            }
        }
        private static void NotReleasedBooks(BookshopSystemContext context)
        {
            int year = int.Parse(Console.ReadLine());
            var books = context.Books.Where(b => b.ReleaseDate.Year !=year).OrderBy(b => b.Id);
            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
            }
        }
        private static void BooksByCategory(BookshopSystemContext context)
        {
            string[] categories = Console.ReadLine().ToLower().Split(' ');
            var books = context.Books.Where(b => b.Categories.Any(c=>categories.Contains(c.Name.ToLower()))).OrderBy(b => b.Id);
            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
            }
        }
        private static void BooksReleasedBeforeDate(BookshopSystemContext context)
        {
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy",null);
            var books = context.Books.Where(b => b.ReleaseDate<date).Select(b=>new {b.Title,b.Edition,b.Price});
            foreach (var book in books)
            {
                Console.WriteLine("{0} - {1} - {2}",book.Title, ((EditionType)book.Edition).ToString().First().ToString().ToUpper()+ ((EditionType)book.Edition).ToString().Substring(1), book.Price);
                
            }
        }
        private static void AuthorsSearch(BookshopSystemContext context)
        {
            string line = Console.ReadLine();
            var authors = context.Authors.Where(a => a.FirstName.EndsWith(line)).Select(a => new { a.FirstName,a.LastName});
            foreach (var author in authors)
            {
                Console.WriteLine($"{author.FirstName} {author.LastName}");

            }
        }
        private static void BooksSearch(BookshopSystemContext context)
        {
            string line = Console.ReadLine();
            var books = context.Books.Where(b => b.Title.ToLower().Contains(line.ToLower())).Select(b=>b.Title);
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
        private static void BookTitlesSearch(BookshopSystemContext context)
        {
            string line = Console.ReadLine();
            var books = context.Books.Where(b => b.Author.LastName.ToLower().StartsWith(line.ToLower())).OrderBy(b=>b.Id);
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} ({book.Author.FirstName} {book.Author.LastName})");
            }
        }
        private static void CountBooks(BookshopSystemContext context)
        {
            int line = int.Parse(Console.ReadLine());
            int books = context.Books.Where(b =>b.Title.ToString().Length>line ).Count();
            
                Console.WriteLine(books);            
        }
        private static void TotalBookCopies(BookshopSystemContext context)
        {
            var authors = context.Authors.OrderByDescending(a => a.Books.Sum(b => b.Copies)).Select(a=>new {Name= a.FirstName + " " + a.LastName, Count=a.Books.Sum(b=>b.Copies)});
            foreach (var author in authors)
            {
                Console.WriteLine($"{author.Name} - {author.Count}");
            }
        }
        private static void FindProfit(BookshopSystemContext context)
        {
            var categories =
                context.Categories.OrderByDescending(c=> c.Books.Sum(b => b.Copies * b.Price)).ThenBy(c=>c.Name).Select(c => new {Name = c.Name, Profit = c.Books.Sum(b => b.Copies * b.Price)});
            foreach (var c in categories)
            {
                Console.WriteLine($"{c.Name} - ${c.Profit}");
            }
        }
        private static void MostRecentBooks(BookshopSystemContext context)
        {
            var categories = context.Categories.Where(c=>c.Books.Count>35).OrderByDescending(c=>c.Books.Count);
            foreach (var category in categories)
            {
                Console.WriteLine($"--{category.Name}: {category.Books.Count} books");
                foreach (var book in category.Books.OrderByDescending(b=>b.ReleaseDate).ThenBy(b=>b.Title).Take(3))
                {
                    Console.WriteLine($"{book.Title} ({book.ReleaseDate.Year})");
                }
            }
        }
        private static void IncreaseBookCopies(BookshopSystemContext context)
        {
            DateTime date = DateTime.ParseExact("06-06-2013", "dd-MM-yyyy", null);
            int addedCopies = 0;
            var books = context.Books.Where(b => b.ReleaseDate>date);
            foreach (var book in books)
            {
                //book.Copies += 44; to update uncomment             
                addedCopies += 44;
            }
            Console.WriteLine(addedCopies);
            //context.SaveChanges(); to update uncomment
        }
        private static void RemoveBooks(BookshopSystemContext context)
        {
            
            int deletedBooks = 0;
            var books = context.Books.Where(b => b.Copies<4200);
            foreach (var book in books)
            {
                context.Books.Remove(book);
                deletedBooks += 1;
            }
            context.SaveChanges();
            Console.WriteLine($"{deletedBooks} books were deleted");
            
        }
        private static void StoredProcedure(BookshopSystemContext context)
        {
            string[] name = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
           

            SqlParameter firstName = new SqlParameter("@firstName", name[0]);
            SqlParameter secondName = new SqlParameter("@lastName", name[1]);
            SqlParameter result = new SqlParameter();
            result.ParameterName = "@result";
            result.Direction = ParameterDirection.Output;
            result.SqlDbType = SqlDbType.Int;

            context.Database.ExecuteSqlCommand($"execute Author_Books  @firstName, @lastName ,@result output", result, firstName, secondName);
            Console.WriteLine($"{firstName.Value} {secondName.Value} has written {result.Value} books");
            //-------Procedure-------
            //create PROCEDURE Author_Books @FirstName nvarchar(max), @LastName nvarchar(max),@result int out  
            //AS   
            //BEGIN
            //	SET @result=(SELECT COUNT(b.Id) FROM Authors AS a
            //	JOIN Books AS b
            //	ON a.Id=b.AuthorId
            //	WHERE a.FirstName=@FirstName AND a.LastName=@LastName
            //	GROUP BY AuthorId)
            //END 
            //GO  

        }
    }
}
