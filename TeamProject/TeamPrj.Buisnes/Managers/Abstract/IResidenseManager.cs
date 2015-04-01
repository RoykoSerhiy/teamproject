using EDModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPrj.Buisnes.Managers.Abstract
{
    public interface IResidenseManager : IManager
    {
        IEnumerable<Residense> GetAll();
    }
}
