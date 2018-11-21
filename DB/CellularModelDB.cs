namespace DB
{
    using Common;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CellularModelDB : DbContext
    {
        NewSeed seed = new NewSeed();
        public void CheckDB()
        {
            if (!Database.Exists())
            {
                seed.InitDB();
            }
        
        }
    
        public CellularModelDB()
            : base("name=CellularModelDB")
        {
            CheckDB();

            // Database.SetInitializer(new DBSeedInitalizer());         
        }

        public virtual DbSet<Call> CallsTable { get; set; }
        public virtual DbSet<Client> ClientsTable { get; set; }
        public virtual DbSet<ClientType> ClientTypesTable { get; set; }
        public virtual DbSet<Employee> EmployeesTable { get; set; }
        public virtual DbSet<Line> LinesTable { get; set; }
        public virtual DbSet<Package> PackagesTable { get; set; }
        public virtual DbSet<PackageInclude> PackageIncludesTable { get; set; }
        public virtual DbSet<Payment> PaymentsTable { get; set; }
        public virtual DbSet<SelectedNumbers> SelectedNumbersTable { get; set; }
        public virtual DbSet<Sms> SmsTable { get; set; }
        public virtual DbSet<UserLogin> UserLoginsTable { get; set; }

    }

}