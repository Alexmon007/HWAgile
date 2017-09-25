using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgileHW.DataAccess.DBModels;
using AgileHW.DataAccess.Context;

namespace AgileHW.DataAccess.Repositories
{
    public class ProductRepository :BaseRepository<Product>
    {
        public ProductRepository(DBContext context):base(context)
        {
        }
    }
}
