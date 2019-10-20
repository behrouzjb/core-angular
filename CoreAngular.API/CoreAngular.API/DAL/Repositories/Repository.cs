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
            return _unitOfWork.Context.Set<T>().Find(values);
        }

        public T GetById(int id)
        {
            return _unitOfWork.Context.Set<T>().SingleOrDefault(t => t.Id == id);
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
            _unitOfWork.SaveChanges();
        }

        public void Update(T entity)
        {
            // _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Context.Set<T>().Attach(entity);
            _unitOfWork.SaveChanges();
        }

        public void Delete(T entity)
        {
            T existing = _unitOfWork.Context.Set<T>().Find(entity);
            if (existing != null) _unitOfWork.Context.Set<T>().Remove(existing);
            _unitOfWork.SaveChanges();
        }

        //public void SaveChanges()
        //{
        //    _unitOfWork.SaveChanges();
        //}
    }
}
