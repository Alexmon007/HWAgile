using AgileHW.DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileHW.DataAccess.Context
{
    public class DBContext:DbContext
    {
        public DBContext():base()
        {

        }
        public virtual DbSet<Product> Products { get; set; }
    }
}
