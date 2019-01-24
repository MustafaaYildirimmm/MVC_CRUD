using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace mvcCRUD.Models
{
    public class OkulDb:DbContext
    {
        public OkulDb()
        {
            base.Database.Connection.ConnectionString = "server=.;database=DogaCollege;uid=sa;pwd=123";
        }

        public DbSet<Ogrenci> Ogrenci { get; set; }

    }
}