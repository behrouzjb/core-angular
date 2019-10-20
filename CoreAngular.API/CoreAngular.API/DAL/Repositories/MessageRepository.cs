using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CoreAngular.API.DAL.Models;

namespace CoreAngular.API.DAL.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public MessageRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Message Get(params object[] values)
        {
            return _unitOfWork.Context.Set<Message>().Find(values);
        }

        public Message GetById(int id)
        {
            return _unitOfWork.Context.Set<Message>().SingleOrDefault(t => t.Id == id);
        }

        public IEnumerable<Message> GetAll()
        {
            return _unitOfWork.Context.Set<Message>().AsEnumerable<Message>();
        }

        public IEnumerable<Message> Find(Expression<Func<Message, bool>> predicate)
        {
            return _unitOfWork.Context.Set<Message>().Where(predicate).AsEnumerable<Message>();
        }

        public void Add(Message message)
        {
            _unitOfWork.Context.Set<Message>().Add(message);
            _unitOfWork.SaveChanges();
        }

        public void Update(Message message)
        {
            _unitOfWork.Context.Set<Message>().Attach(message);
            _unitOfWork.SaveChanges();
        }

        public void Delete(Message message)
        {
            Message existing = _unitOfWork.Context.Set<Message>().Find(message);
            if (existing != null) _unitOfWork.Context.Set<Message>().Remove(existing);
            _unitOfWork.SaveChanges();
        }
    }
}
