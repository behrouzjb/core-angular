using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoreAngular.API.DAL.Models;
using System.Linq.Expressions;

namespace CoreAngular.API.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly IUnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public T Get(params object[] values)
        {
            return _unitOfWork.Context.Set<T>().SingleOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return _unitOfWork.Context.Set<T>().AsEnumerable<T>();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _unitOfWork.Context.Set<T>().Where(predicate).AsEnumerable<T>();
        }

        public void Add(T entity)
        {
            _unitOfWork.Context.Set<T>().Add(entity);
            SaveChanges();
        }

        public void Update(T entity)
        {
            // _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Context.Set<T>().Attach(entity);
            SaveChanges();
        }

        public void Delete(T entity)
        {
            T existing = _unitOfWork.Context.Set<T>().Find(entity);
            if (existing != null) _unitOfWork.Context.Set<T>().Remove(existing);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
}
