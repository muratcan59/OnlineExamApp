using System.ComponentModel;

namespace OnlineExam.Helpers
{
    public enum UserType
    {
        [Description("Öğrenci")]
        Candidate = 1,

        [Description("Yönetici")]
        Admin = 2
    }
}
