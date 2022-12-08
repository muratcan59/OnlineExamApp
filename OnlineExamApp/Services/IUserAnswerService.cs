using OnlineExamApp.Entities;
using System.Collections.Generic;

namespace OnlineExamApp.Services
{
    public interface IUserAnswerService
    {
        UserAnswer GetUserAnswer(int id);
        UserAnswer InsertUserAnswer(UserAnswer UserAnswer);
        UserAnswer UpdateUserAnswer(UserAnswer UserAnswer);
        List<UserAnswer> ListUserAnswer();
        void DeleteUserAnswer(int id);
    }
}
