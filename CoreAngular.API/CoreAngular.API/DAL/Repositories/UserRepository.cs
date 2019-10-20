using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CoreAngular.API.DAL.Models;

namespace CoreAngular.API.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = _unitOfWork.Context.Set<User>().FirstOrDefault<User>(x => x.UserName == username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _unitOfWork.Context.Set<User>().AddAsync(user);

            await _unitOfWork.Context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExists(string username)
        {
            if (_unitOfWork.Context.Set<User>().Any(x => x.UserName == username))
                return true;

            return false;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
                return true;
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public User Get(params object[] values)
        {
            return _unitOfWork.Context.Set<User>().Find(values);
        }

        public User GetById(int id)
        {
            return _unitOfWork.Context.Set<User>().SingleOrDefault(t => t.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _unitOfWork.Context.Set<User>().AsEnumerable<User>();
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            return _unitOfWork.Context.Set<User>().Where(predicate).AsEnumerable<User>();
        }

        public void Add(User user)
        {
            _unitOfWork.Context.Set<User>().Add(user);
            _unitOfWork.SaveChanges();
        }

        public void Update(User user)
        {
            _unitOfWork.Context.Set<User>().Attach(user);
            _unitOfWork.SaveChanges();
        }

        public void Delete(User user)
        {
            User existing = _unitOfWork.Context.Set<User>().Find(user);
            if (existing != null) _unitOfWork.Context.Set<User>().Remove(existing);
            _unitOfWork.SaveChanges();
        }
    }
}
