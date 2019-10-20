using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CoreAngular.API.DAL.Models;
using CoreAngular.API.DAL.Repositories;

namespace CoreAngular.API.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _userRepository.Login(username, password);
            return user;
        }

        public async Task<User> Register(User user, string password)
        {
            var userRegister = await _userRepository.Register(user, password);
            return userRegister;
        }

        public async Task<bool> UserExists(string username)
        {
            var exists = await _userRepository.UserExists(username);
            return exists;
        }

        public User Get(params object[] values)
        {
            return _userRepository.Get(values);
        }

        public User GetById(int id)
        {
            return _userRepository.Get(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll().ToList();
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            return _userRepository.Find(predicate).ToList();
        }

        public void Add(User user)
        {
            _userRepository.Add(user);
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }

        public void Delete(User user)
        {
            _userRepository.Delete(user);
        }
    }
}
