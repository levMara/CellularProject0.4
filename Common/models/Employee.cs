using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        [Required, MaxLength(10, ErrorMessage = "Your input is too long")]
        public string FirstName { get; set; }

        [Required, MaxLength(10, ErrorMessage = "Your input is too long")]
        public string LastName { get; set; }

        public bool IsAdmin { get; set; }


        public ICollection<Client> Client { get; set; }
    }
}