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
        public MessageRepository()
        {

        }

        public void Add(Message entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Message entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> Find(Expression<Func<Message, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Message Get(params object[] values)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Message entity)
        {
            throw new NotImplementedException();
        }
    }
}
