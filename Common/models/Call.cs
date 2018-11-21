using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Call
    {
        public int CallID { get; set; }
        public int Duration { get; set; }  //by seconds
        public DateTime CallDate { get; set; }
        public string DestinationNumber { get; set; }

        public Line LineSourceID { get; set; }
    }
}
