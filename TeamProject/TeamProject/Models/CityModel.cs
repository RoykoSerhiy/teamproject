using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Models
{
    public class CityModel
    {
         #region Ctor
        public CityModel(int id, int countryId ,string name)
        {
            this.Id = id;
            this.CountryId = countryId;
            this.Name = name;
            
        }
        #endregion Ctor
        #region Data
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        #endregion Data
    }
}
