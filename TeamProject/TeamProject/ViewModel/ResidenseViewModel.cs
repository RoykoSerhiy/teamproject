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
        

        List<ResidenceModel> _items = null;
        //List<Residence> _residenses = null;
       

        public List<ResidenceModel> CreateResidenseModel(IEnumerable<Residence> residenses)
        {
            List<ResidenceModel> listCatalogModel = new List<ResidenceModel>();

            var _res = from resid in residenses
                       select new
                       {
                           Id = resid.Id,
                           CityId = resid.CityId,
                           Name = resid.name,
                           Adress = resid.adress,
                           Raiting = resid.stars,
                           Phone = resid.phone,
                           Price = resid.price
                       };
            foreach (var r in _res)
            {
                listCatalogModel.Add(new ResidenceModel(r.Id , r.CityId , r.Name , r.Adress , r.Raiting , r.Phone ,r.Price));
            }
            return listCatalogModel;
        }
        public IEnumerable<ResidenceModel> Catalog
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
        //public IEnumerable<Residence> Residenses
        //{
        //    get
        //    {
        //        if (_residenses == null)
        //        {
        //            return _residenseManager.GetAll();
        //        }
        //        return _residenses;
        //    }
        //}
      
       
        public ResidenseViewModel(
                IResidenseManager residenseManager
                
            )
        {
            _residenseManager = residenseManager;
            
        }

    }
}
