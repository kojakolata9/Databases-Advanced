using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _05_photographers.Models;

namespace _05_photographers
{
    public class DbSeed : DropCreateDatabaseAlways<PhotographersContext>
    {


        protected override void Seed(PhotographersContext context)
        {
            var photographer1 = new Photographer() { Username = "user1", Password = "pass1", Email = "user1@gmail.com", BirthDate = new DateTime(1992, 5, 3), RegisterdOn = new DateTime(2016, 5, 13) };
            var photographer2 = new Photographer() { Username = "user2", Password = "pass2", Email = "user2@gmail.com", BirthDate = new DateTime(1983, 12, 12), RegisterdOn = new DateTime(2015, 2, 9) };
            var photographer3 = new Photographer() { Username = "user3", Password = "pass3", Email = "user3@gmail.com", BirthDate = new DateTime(1998, 7, 8), RegisterdOn = new DateTime(2014, 6, 17) };
            var photographer4 = new Photographer() { Username = "user4", Password = "pass4", Email = "user4@gmail.com", BirthDate = new DateTime(1986, 1, 4), RegisterdOn = new DateTime(2013, 8, 23) };
            var photographer5 = new Photographer() { Username = "user5", Password = "pass5", Email = "user5@gmail.com", BirthDate = new DateTime(1992, 3, 30), RegisterdOn = new DateTime(2012, 11, 12) };
            context.Photographers.Add(photographer1);
            context.Photographers.Add(photographer2);
            context.Photographers.Add(photographer3);
            context.Photographers.Add(photographer4);
            context.Photographers.Add(photographer5);

            var picture1 = new Picture() { Title = "Sea" };
            var picture2 = new Picture() { Title = "Me" };
            var picture3 = new Picture() { Title = "Lola" };
            var picture4 = new Picture() { Title = "Pesho" };
            var picture5 = new Picture() { Title = "Ski" };
            var picture6 = new Picture() { Title = "Trees" };
            var picture7 = new Picture() { Title = "Mountain" };
            var picture8 = new Picture() { Title = "Lake" };

            context.Pictures.Add(picture1);
            context.Pictures.Add(picture2);
            context.Pictures.Add(picture3);
            context.Pictures.Add(picture4);
            context.Pictures.Add(picture5);
            context.Pictures.Add(picture6);
            context.Pictures.Add(picture7);
            context.Pictures.Add(picture8);

            var album1 = new Album() { Name = "Summer", Photographers = new HashSet<Photographer> { photographer1 }, Pictures = new HashSet<Picture> { picture1, picture2, picture6 } };
            var album2 = new Album() { Name = "Winter", Photographers = new HashSet<Photographer> { photographer3 }, Pictures = new HashSet<Picture> { picture4, picture7, picture3, picture5 } };
            var album3 = new Album() { Name = "Autumn", Photographers = new HashSet<Photographer> { photographer4 }, Pictures = new HashSet<Picture> { picture5, picture8 } };
            var album4 = new Album() { Name = "Spring", Photographers = new HashSet<Photographer> { photographer2 }, Pictures = new HashSet<Picture> { picture2, picture4, picture6, picture8 } };
            var album5 = new Album() { Name = "Summer", Photographers = new HashSet<Photographer> { photographer5 }, Pictures = new HashSet<Picture> { picture1, picture3, picture5, picture7 } };

            context.Albums.Add(album1);
            context.Albums.Add(album2);
            context.Albums.Add(album3);
            context.Albums.Add(album4);
            context.Albums.Add(album5);

            base.Seed(context);
        }
    }
}
