using OnlineExamApp.Data;
using OnlineExamApp.Entities;
using OnlineExamApp.Repository;
using System.Collections.Generic;

namespace OnlineExamApp.Services
{
    public class QuestionService : IQuestionService
    {
        private IGenericRepository<Question> _questionRepository;
        private AppDbContext _context;

        public QuestionService(IGenericRepository<Question> questionRepository, AppDbContext context)
        {
            _questionRepository = questionRepository;
            _context = context;
        }

        public void DeleteQuestion(int id)
        {
            if (id != 0)
            {
                _questionRepository.Delete(id);
            }
        }

        public Question GetQuestion(int id)
        {
            if (id != 0)
            {
                return _questionRepository.Get(x => x.Id == id);
            }
            return null;
        }

        public Question InsertQuestion(Question question)
        {
            if (question != null)
            {
                _questionRepository.Add(question);
                return question;
            }
            return null;
        }

        public List<Question> ListQuestion()
        {
            var data = _questionRepository.GetList();
            if (data != null)
            {
                return (List<Question>)data;
            }
            return null;
        }

        public Question UpdateQuestion(Question question)
        {
            if (question != null)
            {
                _questionRepository.Update(question);
                return question;
            }
            return null;
        }
    }
}
