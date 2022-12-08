using OnlineExamApp.Entities;
using OnlineExamApp.Repository;
using System.Collections.Generic;

namespace OnlineExamApp.Services
{
    public class UserAnswerService : IUserAnswerService
    {
        private IGenericRepository<UserAnswer> _userAnswerRepository;

        public UserAnswerService(IGenericRepository<UserAnswer> userAnswerRepository)
        {
            _userAnswerRepository = userAnswerRepository;
        }

        public void DeleteUserAnswer(int id)
        {
            if (id != 0)
            {
                _userAnswerRepository.Delete(id);
            }
        }

        public UserAnswer GetUserAnswer(int id)
        {
            if (id != 0)
            {
                return _userAnswerRepository.Get(x => x.Id == id);
            }
            return null;
        }

        public UserAnswer InsertUserAnswer(UserAnswer userAnswer)
        {
            if (userAnswer != null)
            {
                _userAnswerRepository.Add(userAnswer);
                return userAnswer;
            }
            return null;
        }

        public List<UserAnswer> ListUserAnswer()
        {
            var data = _userAnswerRepository.GetList();
            if (data != null)
            {
                return (List<UserAnswer>)data;
            }
            return null;
        }

        public UserAnswer UpdateUserAnswer(UserAnswer userAnswer)
        {
            if (userAnswer != null)
            {
                _userAnswerRepository.Update(userAnswer);
                return userAnswer;
            }
            return null;
        }
    }
}
