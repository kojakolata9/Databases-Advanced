namespace CodeFirstSudentSystem.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstSudentSystem.StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CodeFirstSudentSystem.StudentSystemContext";
        }

        protected override void Seed(CodeFirstSudentSystem.StudentSystemContext context)
        {
            var student1 = new Student()
            {
                Name="Pesho",
                BirthDay= DateTime.Now,
                PhoneNumber="034503450",
                RegiseredOn = DateTime.Now
            };
            var student2 = new Student()
            {
                Name = "Gosho",
                BirthDay = DateTime.Now,
                PhoneNumber = "0345234450",
                RegiseredOn = DateTime.Now
            };
            var student3 = new Student()
            {
                Name = "Tosho",
                BirthDay = DateTime.Now,
                PhoneNumber = "4543353350",
                RegiseredOn = DateTime.Now
            };
            var student4 = new Student()
            {
                Name = "Misho",
                BirthDay = DateTime.Now,
                PhoneNumber = "3456543423",
                RegiseredOn = DateTime.Now
            };
            var student5 = new Student()
            {
                Name = "Sasho",
                BirthDay = DateTime.Now,
                PhoneNumber = "87997897",
                RegiseredOn = DateTime.Now
            };
            context.Students.AddOrUpdate(p => p.Name, student1, student2, student3, student4, student5);
                
            var course1 = new Course()
            {
                Name = "Math",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Price = 23.23m,
                Students = new HashSet<Student>() { student1,student2,student3,student4,student5}            
            };
            var course2 = new Course()
            {
                Name = "History",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Price = 27.29m,
                Students = new HashSet<Student>() { student1, student3, student5 }
            };
            var course3 = new Course()
            {
                Name = "Geography",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Price = 34.53m,
                Students = new HashSet<Student>() { student1, student2, student3, student4, student5 }
            };
            var course4 = new Course()
            {
                Name = "English",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Price = 243.57m,
                Students = new HashSet<Student>() { student5 }
            };
            var course5 = new Course()
            {
                Name = "German",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Price = 98.33m,
                Students = new HashSet<Student>() { student1, student2, student3, student4, student5 }
            };
            context.Courses.AddOrUpdate(p => p.Name, course1, course2, course3, course4, course5);

            var resource1 = new Resource()
            {
                Name="Softuni",
                ResourceType="sdfsdf",
                Url="dasffgfdfg",
                Course=course1
            };
            var resource2 = new Resource()
            {
                Name = "yuiuiouio",
                ResourceType = "uioyoiu",
                Url = "iuopoippo",
                Course = course2
            };
            var resource3 = new Resource()
            {
                Name = "vcnvncvnc",
                ResourceType = "vbcvcvvn",
                Url = "vcnbbvn",
                Course = course3
            };
            var resource4 = new Resource()
            {
                Name = "jhhjhhhhlk",
                ResourceType = "khjlkjhkl",
                Url = "hjlhjljkj",
                Course = course4
            };
            var resource5 = new Resource()
            {
                Name = "eeeytrrt",
                ResourceType = "rerreyty",
                Url = "treyyry",
                Course = course5
            };
            context.Resources.AddOrUpdate(p => p.Name, resource1, resource2, resource3, resource4, resource5);

            var homework1 = new Homework()
            {
                Content="nmbmbnm",
                ContentType="mbbnmbn",
                SubmissionDate= DateTime.Now,
                Course=course1,
                Student=student1

            };
            var homework2 = new Homework()
            {
                Content = "asasassasasaas",
                ContentType = "asasasasasas",
                SubmissionDate = new DateTime(1943,4,4),
                Course = course2,
                Student = student2

            };
            var homework3 = new Homework()
            {
                Content = "qwqwqwwqqw",
                ContentType = "qwqwqwqwwq",
                SubmissionDate = DateTime.Now,
                Course = course3,
                Student = student3

            };
            var homework4 = new Homework()
            {
                Content = "sdfsadfsdf",
                ContentType = "sdfafdsf",
                SubmissionDate = DateTime.Now,
                Course = course4,
                Student = student4

            };
            var homework5 = new Homework()
            {
                Content = "fggffgfgfgfg",
                ContentType = "fgfgfgfgfg",
                SubmissionDate = DateTime.Now,
                Course = course5,
                Student = student5

            };
            context.Homeworks.AddOrUpdate(p => p.Content, homework1, homework2, homework3, homework4, homework5);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
