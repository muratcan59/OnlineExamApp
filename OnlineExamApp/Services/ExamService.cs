using OnlineExamApp.Entities;
using OnlineExamApp.Repository;
using System.Collections.Generic;

namespace OnlineExamApp.Services
{
    public class ExamService : IExamService
    {
        private IGenericRepository<Exam> _examRepository;

        public ExamService(IGenericRepository<Exam> examRepository)
        {
            _examRepository = examRepository;
        }

        public void DeleteExam(int id)
        {
            if (id != 0)
            {
                _examRepository.Delete(id);
            }
        }

        public Exam GetExam(int id)
        {
            if (id != 0)
            {
                return _examRepository.Get(x => x.Id == id);
            }
            return null;
        }

        public Exam InsertExam(Exam exam)
        {
            if (exam != null)
            {
                _examRepository.Add(exam);
                return exam;
            }
            return null;
        }

        public List<Exam> ListExam()
        {
            var data = _examRepository.GetList();
            if (data != null)
            {
                return (List<Exam>)data;
            }
            return null;
        }

        public Exam UpdateExam(Exam exam)
        {
            if (exam != null)
            {
                _examRepository.Update(exam);
                return exam;
            }
            return null;
        }
    }
}
