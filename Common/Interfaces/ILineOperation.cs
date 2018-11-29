using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ILineOperatoin
    {
        void AddLine(int clientId);

        ICollection<Line> GetAllLines();

        void DeleteLine(string lineNumber);
    }
}
