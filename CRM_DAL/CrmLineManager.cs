using Common;
using Common.Exceptiones;
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

        

        public Line AddLine(int clientId)
        {
            try
            {
                using (_context)
                {
                    Client tmp = _context.ClientsTable.FirstOrDefault((c) => c.ClientID == clientId);

                    if (tmp == null)
                    {
                        throw new EntityNotExistsException("Client id worng");
                    }

                    string newLineNumber = GenerateLineNumber();
                    Line line = new Line { Client = tmp, IsActive = true, JoinDate = DateTime.Now,LineNumber = newLineNumber };
                    tmp.Lines.Add(line);
                    _context.SaveChanges();

                    Line newLine = _context.LinesTable.SingleOrDefault((l) => l.LineNumber == newLineNumber);
                    
                    if(newLine == null)
                    {
                        throw new EntityNotExistsException("Failed to add line");
                    }

                    return newLine; 
                }
            }
            catch (Exception e)
            {
                Log(e);
                throw new DbFaildConnncetException("Failed connect to data base");
            }
        }

        public Line DeleteLine(string lineNumber)
        {
            try
            {
               using (var context = new CellularModelDB())
                {
                    Line tmp = context.LinesTable.FirstOrDefault((l) => l.LineNumber == lineNumber);
                    if (tmp == null)
                    {
                        throw new EntityNotExistsException("Line number not exists");
                    }

                    tmp.IsActive = false;
                    context.SaveChanges();
                    return tmp;
                }
            }
            catch (Exception e)
            {
                Log(e);
                throw new DbFaildConnncetException("Failed connect to data base");
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
            catch (Exception e)
            {
                Log(e);
                throw new DbFaildConnncetException("Failed connect to data base");
            }
        }

        public ICollection<Line> GetAllClientLines(int clientId)
        {
            try
            {
                List<Line> liens;
                using (_context)
                {
                    Client tmp = _context.ClientsTable.SingleOrDefault((c) => c.ClientID == clientId);
                    if (tmp == null)
                    {
                        throw new EntityNotExistsException("Id Of the client is incorrect");
                    }

                    liens = _context.LinesTable.Where((l) => l.Client.ClientID == clientId && l.IsActive == true).ToList();
                    return liens;                  
                }
            }
            catch (Exception e)
            {
                Log(e);
                throw new DbFaildConnncetException("Failed connect to data base");
            }
        }


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
            try
            {
                using (var context = new CellularModelDB())
                {
                    Line tmp = context.LinesTable.FirstOrDefault((l) => l.LineNumber == lineNumber);
                    return tmp == null ? true : false;
                }
            }

            catch(Exception e)
            {
                Log(e);
                throw new DbFaildConnncetException("Failed connect to data base");
            }
        }

        private void Log(Exception e)
        {
            Logger.Log.WriteToLog("" + Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + "Exception details: " + e.ToString());
        }

    }
}
