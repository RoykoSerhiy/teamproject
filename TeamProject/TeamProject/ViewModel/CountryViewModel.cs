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
    public class CountryViewModel
    {
         private readonly ICountryManager _countryManager;

       // List<CountryModel> _items = null;
        List<Country> _countries = null;

        public List<CountryModel> CreateCountryModel(IEnumerable<Country> countries)
        {
            List<CountryModel> listCatalogModel = new List<CountryModel>();

            var _res = from c in countries
                       select new
                       {
                           Id = c.Id,
                           Name = c.name,
                           
                       };
            foreach (var r in _res)
            {
                listCatalogModel.Add(new CountryModel(r.Id , r.Name ));
            }
            return listCatalogModel;
        }
        //public IEnumerable<CountryModel> Countries
        //{
        //    get
        //    {
        //        if (_items == null)
        //        {
        //            _items = CreateCountryModel(
        //                   _countryManager.GetAll()
        //                );
        //        }
        //        return _items;
        //    }
        //}
        public IEnumerable<Country> Countries
        {
            get
            {
                if (_countries == null)
                {
                    return _countryManager.GetAll(); ;
                }
                return _countries;
            }
        }
        public CountryViewModel(
                ICountryManager countryManager
            )
        {
            _countryManager = countryManager;
        }

    }
}

