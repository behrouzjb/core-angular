using CoreAngular.API.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAngular.API.DAL.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Login(string username, string password);
        Task<User> Register(User user, string password);
        Task<bool> UserExists(string username);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
    }
}
