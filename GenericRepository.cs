using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace KFP.DATA
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal KFG_Db context;
        internal IDbSet<T> dbSet;
        public GenericRepository(KFG_Db context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }
        public T SelectByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Update(T obj)
        {
            dbSet.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T entityToDelete = dbSet.Find(id);
            dbSet.Remove(entityToDelete);
        }
        public virtual void Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public void Insert(T obj)
        {
            dbSet.Add(obj);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }

}

