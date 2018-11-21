using Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class DBSeedInitalizer : DropCreateDatabaseAlways<CellularModelDB>
    {
        protected override void Seed(CellularModelDB context)
        {
            //base.Seed(context);

            UserLogin a = new UserLogin() { Password = "123", RemmberMe = true, UserName = "lll" };
            context.UserLoginsTable.Add(a);
            context.SaveChanges();
        }







        //protected override void Seed(ShopContextDB context)
        //{
        //    User a = new User() { FirstName = "levi", LastName = "marantz", BirthDate = DateTime.Now, Email = "a@a.a", IsActive = true, Password = "123", UserName = "aaa" };
        //    User b = new User() { FirstName = "ron", LastName = "adler", BirthDate = DateTime.Now, Email = "b@b.b", IsActive = true, Password = "456", UserName = "bbb" };
        //    User c = new User() { FirstName = "asi", LastName = "ozery", BirthDate = DateTime.Now, Email = "c@c.c", IsActive = true, Password = "789", UserName = "ccc" };

        //    context.Users.Add(a);
        //    context.Users.Add(b);
        //    context.Users.Add(c);

        //    context.SaveChanges();

        //    Product p1 = new Product() { OwnerID = a.ID, Date = DateTime.Now, Price = 100, State = State.available, Titel = "Shoes", ShortDescription = "nice shose", LongDescription = "shose long description" };
        //    Product p2 = new Product() { OwnerID = a.ID, Date = DateTime.Now, Price = 200, State = State.available, Titel = "ball", ShortDescription = "small ball", LongDescription = "ball long description" };
        //    Product p3 = new Product() { OwnerID = b.ID, Date = DateTime.Now, Price = 300, State = State.available, Titel = "bicycle", ShortDescription = "grin bicycle", LongDescription = "bicycle long description" };
        //    Product p4 = new Product() { OwnerID = c.ID, Date = DateTime.Now, Price = 400, State = State.available, Titel = "computer", ShortDescription = "good computer", LongDescription = "computer long description" };

        //    context.Products.Add(p1);
        //    context.Products.Add(p2);
        //    context.Products.Add(p3);
        //    context.Products.Add(p4);

        //    context.SaveChanges();

        //}
    }
}
