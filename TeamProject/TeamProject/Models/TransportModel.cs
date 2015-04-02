using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Models
{
    public class TransportModel
    {
        #region Ctor
        public TransportModel(int id, int cityId , decimal taxiprice , decimal busprice , decimal metroprice)
        {
            this.Id = id;
            this.CityId = cityId;
            this.TaxiPrice = taxiprice;
            this.BusPrice = busprice;
            this.MetroPrice = metroprice;
        }
        #endregion Ctor
        #region Data
        public int Id { get; set; }
        public int CityId { get; set; }
        public decimal TaxiPrice { get; set; }
        public decimal BusPrice { get; set; }
        public decimal MetroPrice { get; set; }
        #endregion Data
    }
}
