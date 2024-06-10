using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WexAssessmentApi.Interfaces;

namespace WexAssessmentApi.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly Dictionary<int, T> _data = new Dictionary<int, T>();

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(_data.Values.AsEnumerable());
        }

        public Task<T> GetByIdAsync(int id)
        {
            _data.TryGetValue(id, out var entity);
            return Task.FromResult(entity);
        }

        public Task AddAsync(T entity)
        {
            var id = _data.Count > 0 ? _data.Keys.Max() + 1 : 1;
            var propertyInfo = typeof(T).GetProperty("Id");
            propertyInfo.SetValue(entity, id);
            _data.Add(id, entity);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(T entity)
        {
            var propertyInfo = typeof(T).GetProperty("Id");
            var id = (int)propertyInfo.GetValue(entity);
            _data[id] = entity;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            _data.Remove(id);
            return Task.CompletedTask;
        }
    }
}
