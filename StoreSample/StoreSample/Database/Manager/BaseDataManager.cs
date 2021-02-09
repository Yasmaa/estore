using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreSample.Database
{
    public class BaseDataManager<TModel> where TModel : Models.BaseModel
    {
        protected Database Database => Database.Instance;

        public virtual IQueryable<TModel> GetAll()
        {
            return GetIncludes(Database.Set<TModel>());
        }

        public virtual void Add(TModel entity)
        {
            Database.Add(entity);
            Database.SaveChanges();
        }

        public virtual void AddRange(IEnumerable<TModel> entities)
        {
            Database.AddRange(entities);
            Database.SaveChanges();
        }

        public virtual void Update(TModel entity)
        {
            Database.Update(entity);
            Database.SaveChanges();
        }

        public virtual void UpdateRange(IEnumerable<TModel> entities)
        {
            Database.UpdateRange(entities);
            Database.SaveChanges();
        }

        public virtual void Remove(TModel entity)
        {
            Database.Remove(entity);
            Database.SaveChanges();
        }

        public virtual void RemoveRange(List<TModel> entities)
        {
            Database.RemoveRange(entities);
            Database.SaveChanges();
        }

        public virtual Task Refresh(TModel entity) => null;

        public virtual Task RefreshRange(List<TModel> entities) => null;

        public virtual IQueryable<TModel> GetIncludes(IQueryable<TModel> entities)
        {
            return entities;
        }

        public virtual TModel GetOriginal(TModel entity)
        {
            Database.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            return entity;
        }
    }
}
