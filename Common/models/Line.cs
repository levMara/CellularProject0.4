using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Line
    {
        public int LineID { get; set; }
        public string LineNumber { get; set; }
        public DateTime JoinDate { get; set; }

        public virtual Package Package { get; set; }
        public Client ClientID { get; set; }
        public ICollection<Call> Calls { get; set; }
        public ICollection<Sms> Sms { get; set; }
        public ICollection<Payment> payments { get; set; }

    }
}
