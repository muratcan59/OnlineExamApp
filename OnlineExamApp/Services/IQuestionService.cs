using OnlineExamApp.Entities;
using System.Collections.Generic;

namespace OnlineExamApp.Services
{
    public interface IQuestionService
    {
        Question GetQuestion(int id);
        Question InsertQuestion(Question Question);
        Question UpdateQuestion(Question Question);
        List<Question> ListQuestion();
        void DeleteQuestion(int id);
    }
}
