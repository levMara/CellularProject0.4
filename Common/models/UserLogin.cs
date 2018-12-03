using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class UserLogin
    {
        public int UserLoginID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RemmberMe { get; set; }

        [Required]
        public Enum.UserType UserType { get; set; }

        public ICollection<Client> Client { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}
