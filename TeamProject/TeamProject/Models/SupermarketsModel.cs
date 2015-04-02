using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Models
{
    public class SupermarketsModel
    {
         #region Ctor
        public SupermarketsModel(int id, int cityId , string name , string address , string phone)
        {
            this.Id = id;
            this.CityId = cityId;
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
        }
        #endregion Ctor
        #region Data
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        #endregion Data
    }
}
