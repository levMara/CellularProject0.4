using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IPackageOperation
    {
        ICollection<Package> GetAllTemplatePackages();

        void AddTemplatePackageToLine(Line line, Package package);

        void AddCustomPackageToLine(Line line, Package customPackage);
    }
}
