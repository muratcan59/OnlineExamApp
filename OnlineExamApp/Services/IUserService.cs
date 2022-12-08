using OnlineExamApp.Entities;
using System.Collections.Generic;

namespace OnlineExamApp.Services
{
    public interface IUserService
    {
        User GetUser(int id);
        User LoginUser(string mail, string password);
        User InsertUser(User User);
        User UpdateUser(User User);
        List<User> ListUser();
        List<User> ListCandidate();
        void DeleteUser(int id);
    }
}
