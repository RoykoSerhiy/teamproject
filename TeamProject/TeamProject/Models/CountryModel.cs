using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Models
{
    public class CountryModel
    {
        #region Ctor
        public CountryModel(int id, string name)
        {
            this.Id = id;
            this.Name = name;
            
        }
        #endregion Ctor
        #region Data
        public int Id { get; set; }
        public string Name { get; set; }
        #endregion Data
    }
}
