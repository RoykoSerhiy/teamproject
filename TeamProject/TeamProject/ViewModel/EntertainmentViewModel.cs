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
    public class EntertainmentViewModel
    {
         private readonly IEntertainmentManager _entertainmentManager;
        List<EntertainmentModel> _items = null;
       

        public List<EntertainmentModel> CreateEntertainmentModel(IEnumerable<Entertainment> entertainment)
        {
            List<EntertainmentModel> listCatalogModel = new List<EntertainmentModel>();

            var _res = from en in entertainment
                       select new
                       {
                           Id = en.Id,
                           CityId = en.CityId,
                           Name = en.Name,
                           Address = en.Adress,
                           Link = en.Link,
                           Phone = en.Phone
                       };
            foreach (var r in _res)
            {
                listCatalogModel.Add(new EntertainmentModel(r.Id , r.CityId , r.Name , r.Address ,r.Link , r.Phone));
            }
            return listCatalogModel;

        }
        public IEnumerable<EntertainmentModel> Catalog
        {
            get
            {
                if (_items == null)
                {
                    _items = CreateEntertainmentModel(
                           _entertainmentManager.GetAll()
                        );
                }
                return _items;
            }
        }
        public EntertainmentViewModel(
                IEntertainmentManager entertainmentManager
                
            )
        {
            _entertainmentManager = entertainmentManager;
            
        }
    }
}
