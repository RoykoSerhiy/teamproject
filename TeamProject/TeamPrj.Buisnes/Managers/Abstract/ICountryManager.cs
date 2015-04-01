using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDModel;

namespace TeamPrj.Buisnes.Managers.Abstract
{
    public interface ICountryManager : IManager
    {
        IEnumerable<Country> GetAll();
    }
}
