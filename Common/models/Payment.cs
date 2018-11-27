using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public DateTime Month { get; set; }  //??
        public double TotalPayment { get; set; }


        public Line Line { get; set; }

    }
}
