using System.Collections.Generic;

namespace OnlineExamApp.Entities
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuestionCount { get; set; }
        public List<Question> Questions { get; set; }
    }
}
