using OnlineExamApp.Entities;
using System.Collections.Generic;

namespace OnlineExamApp.Services
{
    public interface IExamService
    {
        Exam GetExam(int id);
        Exam InsertExam(Exam Exam);
        Exam UpdateExam(Exam Exam);
        List<Exam> ListExam();
        void DeleteExam(int id);
    }
}
