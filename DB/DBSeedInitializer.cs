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

            //PackageInclude pi1 = new PackageInclude { MinutesAmount = 100, MinutePrice = 20, SmsAmount = 100, SmsPrice = 20 };
            //PackageInclude pi2 = new PackageInclude { MonthlyPrice = 10};
            //PackageInclude pi3 = new PackageInclude { MonthlyPrice = 10};
            //PackageInclude pi4 = new PackageInclude { MonthlyPrice = 10};
            //PackageInclude pi5 = new PackageInclude { MonthlyPrice = 10};
            //PackageInclude pi6 = new PackageInclude { };


           // Package p1 = new Package { PackageType = PackageType.tokman, PackageName = "tokman100",  };
            //Package p3 = new Package { PackageType = PackageType.maxDestination };
            //Package p4 = new Package { PackageType = PackageType.friends,  };
            //Package p5 = new Package { PackageType = PackageType.family };
            //Package p6 = new Package { PackageType = PackageType.custom };

            

        }

    }
}
