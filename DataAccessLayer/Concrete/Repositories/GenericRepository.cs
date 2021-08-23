using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        Context context = new Context();
        DbSet<TEntity> _entity;
        public GenericRepository()
        {
            _entity = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _entity.Add(entity);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _entity.Remove(entity);
            context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
          return  _entity.Where(filter).SingleOrDefault();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? _entity.ToList() : _entity.Where(filter).ToList();

        }

        public void Update(TEntity entity)
        {
            context.SaveChanges();
        }
    }
}
