using Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common
{
    public class Package
    {
        [Key]
        public int PackageID { get; set; }
        [Required]
        public Enum.PackageType PackageType { get; set; }
        [Required, MaxLength(20)]
        public string PackageName { get; set; }

        //For tokman
        public int MinutesAmount { get; set; }
        public int SmsAmount { get; set; }
        public double? MinutePrice { get; set; }
        public double? SmsPrice { get; set; }

        //For other package types
        public double? MonthlyPrice { get; set; }
        public Decimal? DiscountPrecentage { get; set; }

        //Except template
        public DateTime? PackageJoinDate { get; set; }
        public DateTime? PackageEndDate { get; set; }
  
        public ICollection<Line> Line { get; set; }
    }
}