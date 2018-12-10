using Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Client
    {

        public Client()
        {
            Lines = new List<Line>();
                 
        }
        [Key]
        [Range(1, 1000000000)]
        public int ClientID { get; set; }

        [Required, MaxLength(10, ErrorMessage = "Your input is too long")]
        public string FirstName { get; set; }

        [Required, MaxLength(10, ErrorMessage = "Your input is too long")]
        public string LastName { get; set; }

        [Required, MaxLength(30, ErrorMessage = "Your input is too long")]
        public string Address { get; set; }

        public int CallsToCenter { get; set; }

        [Required]
        public virtual Enum.ClientTypeName ClientType { get; set; }

        [Required]
        public Employee WhoSold { get; set; }

        public ICollection<Line> Lines { get; set; }

        //[Required, MaxLength(13, ErrorMessage = "Your input is too long"), MinLength(3, ErrorMessage = "Your input is too short")]
        //public string ContactNumber { get; set; }

    }
}
