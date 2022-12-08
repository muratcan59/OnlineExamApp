namespace OnlineExamApp.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }
        public string Link { get; set; }
        public double Score { get; set; } = 0;
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}
