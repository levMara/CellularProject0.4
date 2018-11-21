using System;

namespace Common
{
    public class Package
    {
        public int PackageID { get; set; }
        public string PackageName { get; set; }
        public string Description { get; set; }
        public DateTime PackageJoinDate { get; set; }
        public DateTime? EndDate { get; set; } //???
        public double MonthlyPrice { get; set; }
        public int MyProperty { get; set; }

        public Line LineID { get; set; }
        public virtual Line Line { get; set; }
        public virtual PackageInclude PackageInclude { get; set; }

    }
}