using AgileHW.DataAccess.Context;
using AgileHW.DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileHW.DataAccess.Repositories
{
    public class BaseRepository<T> where T:BaseEntity
    {
        private readonly DBContext _context;
        private readonly IDbSet<T> _dbSet;
        public BaseRepository(DBContext context)
        {
            this._context = context;
            this._dbSet = this._context.Set<T>();
            
        }
        public ICollection<T> getAll()
        {
            return this._dbSet.ToList();
        }
        public void Add (T entity)
        {
            this._dbSet.Add(entity);
        }
    }
}
