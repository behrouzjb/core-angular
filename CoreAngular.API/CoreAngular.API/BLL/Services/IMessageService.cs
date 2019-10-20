﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAngular.API.DAL.Models;

namespace CoreAngular.API.BLL.Services
{
    public interface IMessageService : IEntityService<Message>
    {
        Task<Message> GetMessage(int id);
        Task<IEnumerable<Message>> GetMessagesForUser(int userId);
        Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId);
    }
}
