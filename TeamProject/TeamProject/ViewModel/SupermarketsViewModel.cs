using EDModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamPrj.Buisnes.Managers.Abstract;
using TeamProject.Models;

namespace TeamProject.ViewModel
{
    public class SupermarketsViewModel
    {
        private readonly ISupermarketManager _supermarketManager;
        List<SupermarketsModel> _items = null;
       

        public List<SupermarketsModel> CreateSupermarketsModel(IEnumerable<Supermarkets> supermarkets)
        {
            List<SupermarketsModel> listCatalogModel = new List<SupermarketsModel>();

            var _res = from s in supermarkets
                       select new
                       {
                           Id = s.Id,
                           CityId = s.CityId,
                           Name = s.name,
                           Address = s.adress,
                           Phone = s.phone
                       };
            foreach (var r in _res)
            {
                listCatalogModel.Add(new SupermarketsModel(r.Id , r.CityId , r.Name , r.Address , r.Phone));
            }
            return listCatalogModel;

        }
        public IEnumerable<SupermarketsModel> Catalog
        {
            get
            {
                if (_items == null)
                {
                    _items = CreateSupermarketsModel(
                           _supermarketManager.GetAll()
                        );
                }
                return _items;
            }
        }
         public SupermarketsViewModel(
                ISupermarketManager supermarketManager
                
            )
        {
            _supermarketManager = supermarketManager;
            
        }
    }
}
