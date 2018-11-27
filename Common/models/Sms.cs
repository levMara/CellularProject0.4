using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Sms
    {
        public int SmsID { get; set; }

        public DateTime SendDate { get; set; }

        [Required, MaxLength(13)]
        public string DestinationNumber { get; set; }

        [Required]
        public Line LineSourceID { get; set; }
    }
}
