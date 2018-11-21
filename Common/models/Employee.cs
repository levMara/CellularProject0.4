using System.Collections.Generic;

namespace Common
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<Client> Student { get; set; }
    }
}