using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Call
    {
        [Key]
        public int CallID { get; set; }
        public int Duration { get; set; }  //by seconds
        public DateTime CallDate { get; set; }

        [Required, MaxLength(10)]
        public string DestinationNumber { get; set; }

       // [Required]
        public int LineID { get; set; }
        public virtual Line Line { get; set; }
    }
}
