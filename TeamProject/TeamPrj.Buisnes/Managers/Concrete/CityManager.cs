﻿using EDModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamPrj.Buisnes.Managers.Abstract;

namespace TeamPrj.Buisnes.Managers.Concrete
{
    public class CityManager : AbstractManager , ICityManager
    {
         public CityManager(string connStr) : base(connStr) { }

        public IEnumerable<City> GetAll()
        {
            using(DbContext ctx = this.CreateDbContext())
            {
                return ctx.Set<City>().ToList();
            }
        }
    }
}
