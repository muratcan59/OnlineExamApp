using OnlineExam.Helpers;
using OnlineExamApp.Data;
using OnlineExamApp.Entities;
using OnlineExamApp.Repository;
using System.Collections.Generic;
using System.Linq;

namespace OnlineExamApp.Services
{
    public class UserService : IUserService
    {
        private IGenericRepository<User> _userRepository;
        private AppDbContext context;

        public UserService(IGenericRepository<User> userRepository, AppDbContext context)
        {
            _userRepository = userRepository;
            this.context = context;
        }

        public void DeleteUser(int id)
        {
            if (id != 0)
            {
                _userRepository.Delete(id);
            }
        }

        public User GetUser(int id)
        {
            if (id != 0)
            {
                return _userRepository.Get(x => x.Id == id);
            }
            return null;
        }

        public User LoginUser(string mail, string password)
        {
            return _userRepository.Get(x => x.Mail == mail && x.Password == password);
        }

        public User InsertUser(User user)
        {
            if (user != null)
            {
                _userRepository.Add(user);
                return user;
            }
            return null;
        }

        public List<User> ListUser()
        {
            var data = _userRepository.GetList();
            if (data != null)
            {
                return (List<User>)data;
            }
            return null;
        }

        public List<User> ListCandidate()
        {
            var data = context.Set<User>().Where(x => x.Type == (int)UserType.Candidate).ToList();
            if (data != null)
            {
                return (List<User>)data;
            }
            return null;
        }

        public User UpdateUser(User user)
        {
            if (user != null)
            {
                _userRepository.Update(user);
                return user;
            }
            return null;
        }
    }
}
