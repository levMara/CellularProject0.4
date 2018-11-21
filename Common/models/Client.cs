using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Client
    {
        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public int CallsToCenter { get; set; }

        public virtual ClientType ClientType { get; set; }

        public ICollection<Line> Lines { get; set; }
        public int EmployeeID { get; set; }
        public Employee WhoSold { get; set; }
    }
}
