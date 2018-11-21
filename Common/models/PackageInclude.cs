using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class PackageInclude
    {
        public int PackageIncludeID { get; set; }
        public int MinutesAmount { get; set; }
        public int SmsAmount { get; set; }
        public Decimal DiscountPrecentage { get; set; }
        public double MinutePrice { get; set; }
        public double SmsPrice { get; set; }

        public virtual SelectedNumbers SelectedNumbersID { get; set; }
        [ForeignKey("Package")]
        public virtual Package PackageID { get; set; }

    }
}
