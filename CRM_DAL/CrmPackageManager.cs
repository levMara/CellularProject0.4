using Common;
using Common.Enum;
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
                using (var context = new CellularModelDB())
                {
                    List<Package> packages = context.PackagesTable.Where((p) => p.PackageType != PackageType.custom).ToList();
                    return packages;
                }              
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddTemplatePackageToLine(Line line, Package package)
        {
            try
            {
                using (_context)
                {
                    line.Package = package;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //save the new values?
        public void AddCustomPackageToLine(Line line, Package customPackage)
        {
            try
            {
                using (_context)
                {
                    customPackage.PackageType = PackageType.custom;
                    line.Package = customPackage;
                    _context.PackagesTable.Add(customPackage);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
