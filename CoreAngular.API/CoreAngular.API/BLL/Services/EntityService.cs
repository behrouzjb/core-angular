using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CoreAngular.API.DAL.Models;
using CoreAngular.API.DAL.Repositories;

namespace CoreAngular.API.BLL.Services
{
    public class EntityService<T> : IEntityService<T> where T : Entity
    {
        private readonly IRepository<T> _repo;

        public EntityService(IRepository<T> repo)
        {
            _repo = repo;
        }

        public T Get(params object[] values)
        {
            return _repo.Get(values);
        }

        public IEnumerable<T> GetAll()
        {
            return _repo.GetAll().ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _repo.Find(predicate).ToList();
        }

        public void Add(T entity)
        {
            _repo.Add(entity);
        }

        public void Update(T entity)
        {
            _repo.Update(entity);
        }

        public void Delete(T entity)
        {
            _repo.Delete(entity);
        }
    }
}
