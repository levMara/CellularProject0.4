using Common;
using Common.Enum;
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
    public class CrmPackageManager : IPackageOperation
    {
        CellularModelDB _context = new CellularModelDB();

        public ICollection<Package> GetAllTemplatePackages()
        {
            try
            {
                using (_context)
                {
                    List<Package> packages = _context.PackagesTable.Where((p) => p.PackageType != PackageType.custom).ToList();
                    return packages;
                }
            }
            catch (Exception e)
            {
                Log(e);
                throw new DbFaildConnncetException("Failed connect to data base");
            }
        }

        public Package AddTemplatePackageToLine(int lineId, Package package)
        {
            try
            {
                using (_context)
                {
                    Line tmpLine = _context.LinesTable.SingleOrDefault((l) => l.LineID == lineId);
                    if (tmpLine == null)
                    {
                        throw new EntityNotExistsException("This line not exists");
                    }

                    Package tmpPackage = _context.PackagesTable.SingleOrDefault((p) => p.PackageID == package.PackageID && package.PackageType != PackageType.custom);
                    if (tmpPackage == null)
                    {
                        throw new EntityNotExistsException("This package not exists or his type is custom package");
                    }

                    tmpLine.Package = package;
                    _context.SaveChanges();
                    return package;
                }
            }
            catch (Exception e)
            {
                Log(e);
                throw new DbFaildConnncetException("Failed connect to data base");
            }
        }

        public Package AddCustomPackageToLine(int lineId, Package customPackage)
        {
            try
            {
                using (_context)
                {
                    Line tmpLine = _context.LinesTable.SingleOrDefault((l) => l.LineID == lineId);
                    if (tmpLine == null)
                    {
                        throw new EntityNotExistsException("This line not exists");
                    }

                    Package tmpPackage = _context.PackagesTable.SingleOrDefault((p) => p.PackageID == customPackage.PackageID && customPackage.PackageType == PackageType.custom);
                    if (tmpPackage == null)
                    {
                        throw new EntityNotExistsException("This package not exists or his type is template package");
                    }

                    tmpLine.Package = customPackage;
                    _context.PackagesTable.Add(customPackage);
                    _context.SaveChanges();
                    return customPackage;
                }
            }
            catch (Exception e)
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
