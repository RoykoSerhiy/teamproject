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
    public class TransportViewModel
    {
        private readonly ITransportManager _transportManager;
        List<TransportModel> _items = null;
       

        public List<TransportModel> CreateTransportModel(IEnumerable<Transport> transport)
        {
            List<TransportModel> listCatalogModel = new List<TransportModel>();

            var _res = from t in transport
                       select new
                       {
                           Id = t.Id,
                           CityId = t.CityId,
                           TaxiPrice = t.Taxi_price,
                           BusPrice = t.Bus_price,
                           MetroPrice = t.Metro_price
                       };
            foreach (var r in _res)
            {
                listCatalogModel.Add(new TransportModel(r.Id , r.CityId ,r.TaxiPrice , r.BusPrice , r.MetroPrice));
            }
            return listCatalogModel;

        }
        public IEnumerable<TransportModel> Catalog
        {
            get
            {
                if (_items == null)
                {
                    _items = CreateTransportModel(
                           _transportManager.GetAll()
                        );
                }
                return _items;
            }
        }
         public TransportViewModel(
                ITransportManager transportManager
                
            )
        {
            _transportManager = transportManager;
            
        }
    }
}

