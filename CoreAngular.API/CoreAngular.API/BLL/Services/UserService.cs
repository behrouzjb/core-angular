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

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll().ToList();
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            return _userRepository.Find(predicate).ToList();
        }

        public void Add(User entity)
        {
            _userRepository.Add(entity);
        }

        public void Update(User entity)
        {
            _userRepository.Update(entity);
        }

        public void Delete(User entity)
        {
            _userRepository.Delete(entity);
        }
    }
}
