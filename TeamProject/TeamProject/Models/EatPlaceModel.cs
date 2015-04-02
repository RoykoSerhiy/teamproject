using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Models
{
    public class EatPlaceModel
    {
         #region Ctor
        public EatPlaceModel(int id, int cityId , string name , string phone , string description ,int raiting ,string address)
        {
            this.Id = id;
            this.CityId = cityId;
            this.Name = name;
            this.Phone = phone;
            this.Description = description;
            this.Raiting = raiting;
            this.Address = address;
        }
        #endregion Ctor
        #region Data
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public int Raiting { get; set; }
        public string Address { get; set; }
        #endregion Data
    }
}
