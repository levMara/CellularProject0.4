using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Line
    {
        public Line()
        {
            Calls = new List<Call>();
            Sms = new List<Sms>();
            Payments = new List<Payment>();
        }
        [Key]
        public int LineID { get; set; }

        [Required(AllowEmptyStrings = false), MinLength(10), MaxLength(10)]
        public string LineNumber { get; set; }
        public DateTime JoinDate { get; set; }
        public bool IsActive { get; set; }

        public Package Package { get; set; }

        [Required]
        public Client Client { get; set; }

        public ICollection<Call> Calls { get; set; }
        public ICollection<Sms> Sms { get; set; }
        public ICollection<Payment> Payments { get; set; }

    }
}
