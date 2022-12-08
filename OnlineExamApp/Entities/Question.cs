namespace OnlineExamApp.Entities
{
    public class Question
    {
        public Question()
        {
            Exam = new Exam();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Answers { get; set; }
        public string CorrectAnswer { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}
