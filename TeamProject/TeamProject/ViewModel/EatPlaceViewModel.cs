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
    public class EatPlaceViewModel
    {
        private readonly IEatPlaceManager _eatPlaceManager;
        List<EatPlaceModel> _items = null;
       

        public List<EatPlaceModel> CreateEatPlaceModel(IEnumerable<EatPlace> eatPlace)
        {
            List<EatPlaceModel> listCatalogModel = new List<EatPlaceModel>();

            var _res = from e in eatPlace
                       select new
                       {
                           Id = e.Id,
                           CityId = e.CityId,
                           Name = e.name,
                           Phone = e.phone,
                           Description = e.desccription,
                           Raiting = e.raiting,
                           Address = e.adress
                       };
            foreach (var r in _res)
            {
                listCatalogModel.Add(new EatPlaceModel(r.Id , r.CityId , r.Name , r.Phone , r.Description ,r.Raiting, r.Address));
            }
            return listCatalogModel;

        }
        public IEnumerable<EatPlaceModel> Catalog
        {
            get
            {
                if (_items == null)
                {
                    _items = CreateEatPlaceModel(
                           _eatPlaceManager.GetAll()
                        );
                }
                return _items;
            }
        }
         public EatPlaceViewModel(
                IEatPlaceManager eatPlaceManager
                
            )
        {
            _eatPlaceManager = eatPlaceManager;
            
        }
    }
}
