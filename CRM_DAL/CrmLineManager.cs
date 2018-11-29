using Common;
using Common.Interfaces;
using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm_Dal
{
    public class CrmLineManager : ILineOperatoin
    {
        CellularModelDB _context = new CellularModelDB();
        readonly string _lineNumber = "0520000000";
        int _count = 1;

        private string GenerateLineNumber()
        {
            int.TryParse(_lineNumber, out int newNumber);
            newNumber += _count;
            _count++;
            string stringNumber = "0" + newNumber.ToString();
            if (!(CheckLineNumber(stringNumber)))
                GenerateLineNumber();
            return stringNumber;
        }

        private bool CheckLineNumber(string lineNumber)
        {
            using (var context = new CellularModelDB())
            {
                Line tmp = context.LinesTable.FirstOrDefault((l) => l.LineNumber == lineNumber);
                return tmp == null ? true : false;
            }
        }

        public void AddLine(int clientId)
        {
            try
            {
                using (var context = new CellularModelDB())
                {
                    Client tmp = context.ClientsTable.FirstOrDefault((c) => c.ClientID == clientId);

                    Line line = new Line { Client = tmp, IsActive = true, JoinDate = DateTime.Now, LineNumber = GenerateLineNumber()};
                    tmp.Lines.Add(line);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ICollection<Line> GetAllLines()
        {
            try
            {
                using (_context)
                {
                    List<Line> lines = _context.LinesTable.Where((l) => l.IsActive).ToList();
                    return lines;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteLine(string lineNumber)
        {
            try
            {
               using (var context = new CellularModelDB())
                {
                    Line tmp = context.LinesTable.FirstOrDefault((l) => l.LineNumber == lineNumber);
                    tmp.IsActive = false;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}
