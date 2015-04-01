using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Models
{
    public class ResidenseModel
    {
        #region Ctor
        public ResidenseModel(int id, int cityId ,string name, string adress, int raiting,string phone, decimal price)
        {
            this.Id = id;
            this.Name = name;
            this.CityId = cityId;
            this.Adress = adress;
            this.Raiting = raiting;
            this.Phone = phone;
            this.Price = price;
        }
        #endregion Ctor
        #region Data
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public int Raiting { get; set; }
        public string Phone { get; set; }
        public decimal Price { get; set; }
        #endregion Data
    }
}
