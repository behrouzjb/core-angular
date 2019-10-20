using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CoreAngular.API.DAL.Models;
using CoreAngular.API.DAL.Repositories;

namespace CoreAngular.API.BLL.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public Message Get(params object[] values)
        {
            return _messageRepository.Get(values);
        }

        public Message GetById(int id)
        {
            return _messageRepository.Get(id);
        }

        public IEnumerable<Message> GetAll()
        {
            return _messageRepository.GetAll().ToList();
        }

        public IEnumerable<Message> Find(Expression<Func<Message, bool>> predicate)
        {
            return _messageRepository.Find(predicate).ToList();
        }

        public void Add(Message entity)
        {
            _messageRepository.Add(entity);
        }

        public void Update(Message entity)
        {
            _messageRepository.Update(entity);
        }

        public void Delete(Message entity)
        {
            _messageRepository.Delete(entity);
        }
    }
}
