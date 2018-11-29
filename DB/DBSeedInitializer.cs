using Common;
using Common.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class DBSeedInitalizer : DropCreateDatabaseIfModelChanges<CellularModelDB>
    {
        protected override void Seed(CellularModelDB context)
        {
            Employee e1 = new Employee { FirstName = "emp1", LastName = "seler1", IsAdmin = false};
            Employee e2 = new Employee { FirstName = "emp2", LastName = "seler2", IsAdmin = true};

            context.EmployeesTable.Add(e1);
            context.EmployeesTable.Add(e2);
            context.SaveChanges();

            Client client1 = new Client { FirstName = "levi", LastName = "marantz", Address = "k.g", ClientType = ClientTypeName.regular, WhoSold = e1 };
            Client client2 = new Client { FirstName = "ariel", LastName = "halevi", Address = "e.e", ClientType = ClientTypeName.regular, WhoSold = e1 };
            Client client3 = new Client { FirstName = "tal", LastName = "dan", Address = "r.g", ClientType = ClientTypeName.business, WhoSold = e1 }; 
            Client client4 = new Client { FirstName = "yosi", LastName = "hen", Address = "t.l.v", ClientType = ClientTypeName.VIP, WhoSold = e2 };

            context.ClientsTable.Add(client1);
            context.ClientsTable.Add(client2);
            context.ClientsTable.Add(client3);
            context.ClientsTable.Add(client4);
            context.SaveChanges();

            Package p1 = new Package { PackageType = PackageType.templatePlan, PackageName = "family", MonthlyPrice = 10, DiscountPrecentage = 1 };
            Package p2 = new Package { PackageType = PackageType.templatePlan, PackageName = "friends", MonthlyPrice = 10, DiscountPrecentage = 0.5 };
            Package p3 = new Package { PackageType = PackageType.templatePlan, PackageName = "maxDestination", MonthlyPrice = 10, DiscountPrecentage = 1 };
            Package p4 = new Package { PackageType = PackageType.templatePlan, PackageName = "allInclusive", MonthlyPrice = 100, DiscountPrecentage = 1 };
            Package p5 = new Package { PackageType = PackageType.templateTokman, PackageName = "students", MinutesAmount = 100, MinutePrice = 10, SmsAmount = 100, SmsPrice = 10 };
            Package p6 = new Package { PackageType = PackageType.templateTokman, PackageName = "soldiers", MinutesAmount = 200, MinutePrice = 10, SmsAmount = 200, SmsPrice = 10 };

            context.PackagesTable.Add(p1);
            context.PackagesTable.Add(p2);
            context.PackagesTable.Add(p3);
            context.PackagesTable.Add(p4);
            context.PackagesTable.Add(p5);
            context.PackagesTable.Add(p6);
            context.SaveChanges();

            Line l1 = new Line { LineNumber = "0509999999", Client = client1, IsActive = true, JoinDate = DateTime.Now };
            Line l2 = new Line { LineNumber = "0509999998", Client = client2, IsActive = true, JoinDate = DateTime.Now };
            Line l3 = new Line { LineNumber = "0509999997", Client = client3, IsActive = true, JoinDate = DateTime.Now, Package = p1 };
            Line l4 = new Line { LineNumber = "0509999996", Client = client4, IsActive = true, JoinDate = DateTime.Now, Package = p2 };
            Line l5 = new Line { LineNumber = "0509999995", Client = client4, IsActive = true, JoinDate = DateTime.Now, Package = p5 };

            context.LinesTable.Add(l1);
            context.LinesTable.Add(l2);
            context.LinesTable.Add(l3);
            context.LinesTable.Add(l4);
            context.LinesTable.Add(l5);
            context.SaveChanges();
        }

    }
}
