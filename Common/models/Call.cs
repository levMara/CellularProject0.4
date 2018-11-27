using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required, MaxLength(13)]
        public string DestinationNumber { get; set; }

        [Required]
        public Line LineSourceID { get; set; }
    }
}
