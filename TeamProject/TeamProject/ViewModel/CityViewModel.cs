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
    public class CityViewModel
    {
        private readonly ICityManager _cityManager;

      
        List<City> _cities = null;

        public List<CityModel> CreateCityModel(IEnumerable<City> cities)
        {
            List<CityModel> listCityModel = new List<CityModel>();

            var _res = from c in cities
                       select new
                       {
                           Id = c.Id,
                           CountryId = c.CountryId,
                           Name = c.name,
                           
                       };
            foreach (var r in _res)
            {
                listCityModel.Add(new CityModel(r.Id , r.CountryId ,r.Name));
            }
            return listCityModel;
        }
      
        public IEnumerable<City> Cities
        {
            get
            {
                if (_cities == null)
                {
                    return _cityManager.GetAll(); ;
                }
                return _cities;
            }
        }
        public CityViewModel(
                ICityManager cityManager
            )
        {
            _cityManager = cityManager;
        }

    }
}

