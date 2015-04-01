using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamPrj.Buisnes.Managers.Abstract;
using EDModel;
using TeamProject.Models;


namespace TeamProject.ViewModel
{
    public class ResidenseViewModel
    {
        private readonly IResidenseManager _residenseManager;

        List<ResidenseModel> _items = null;
        List<Residense> _residenses = null;

        public List<ResidenseModel> CreateResidenseModel(IEnumerable<Residense> residenses)
        {
            List<ResidenseModel> listCatalogModel = new List<ResidenseModel>();

            var _res = from resid in residenses
                       select new
                       {
                           Id = resid.ID,
                           CityId = resid.CityId,
                           Name = resid.Name,
                           Adress = resid.Address,
                           Raiting = resid.Raiting,
                           Phone = resid.Phone,
                           Price = resid.Price
                       };
            foreach (var r in _res)
            {
                listCatalogModel.Add(new ResidenseModel(r.Id , r.CityId , r.Name , r.Adress , r.Raiting , r.Phone ,r.Price));
            }
            return listCatalogModel;
        }
        public IEnumerable<ResidenseModel> Catalog
        {
            get
            {
                if (_items == null)
                {
                    _items = CreateResidenseModel(
                           _residenseManager.GetAll()
                        );
                }
                return _items;
            }
        }
        public IEnumerable<Residense> Residenses
        {
            get
            {
                if (_residenses == null)
                {
                    return _residenseManager.GetAll();
                }
                return _residenses;
            }
        }
        public ResidenseViewModel(
                IResidenseManager residenseManager
            )
        {
            _residenseManager = residenseManager;
        }

    }
}
