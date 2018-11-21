using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Sms
    {
        public int SmsID { get; set; }
        public DateTime SendDate { get; set; }
        public string DestinationNumber { get; set; }

        public Line LineSourceID { get; set; }
    }
}
