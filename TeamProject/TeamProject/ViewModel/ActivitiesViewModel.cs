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
    public class ActivitiesViewModel
    {
         private readonly IActivitiesManager _activitiesManager;
        List<ActivitiesModel> _items = null;
       

        public List<ActivitiesModel> CreateActivitiesModel(IEnumerable<Activities> activities)
        {
            List<ActivitiesModel> listCatalogModel = new List<ActivitiesModel>();

            var _res = from a in activities
                       select new
                       {
                           Id = a.Id,
                           CityId = a.CityId,
                           Name = a.Name,
                           Address = a.Adress,
                           Link = a.Link,
                           Phone = a.Phone
                       };
            foreach (var r in _res)
            {
                listCatalogModel.Add(new ActivitiesModel(r.Id , r.CityId , r.Name , r.Address ,r.Link , r.Phone));
            }
            return listCatalogModel;

        }
        public IEnumerable<ActivitiesModel> Catalog
        {
            get
            {
                if (_items == null)
                {
                    _items = CreateActivitiesModel(
                           _activitiesManager.GetAll()
                        );
                }
                return _items;
            }
        }
        public ActivitiesViewModel(
                IActivitiesManager activitiesManager
                
            )
        {
            _activitiesManager = activitiesManager;
            
        }
    }
}
