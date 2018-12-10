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

        Package AddTemplatePackageToLine(int lineId, Package package);

        Package AddCustomPackageToLine(int lineId, Package customPackage);
    }
}
