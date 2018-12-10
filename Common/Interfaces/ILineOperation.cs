using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ILineOperatoin
    {
        Line AddLine(int clientId);

        ICollection<Line> GetAllLines();

        ICollection<Line> GetAllClientLines(int clientId);

        Line DeleteLine(string lineNumber);
    }
}
