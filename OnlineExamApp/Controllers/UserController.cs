using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineExamApp.Data;
using OnlineExamApp.Entities;
using OnlineExamApp.Helpers;
using OnlineExamApp.Services;

namespace OnlineExamApp.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;
        private IExamService examService;
        private AppDbContext _context;

        public UserController(IUserService userService, AppDbContext context, IExamService examService)
        {
            this.userService = userService;
            this.examService = examService;
            _context = context;
        }

        public IActionResult List()
        {
            var list = userService.ListUser();
            if (list != null)
            {
                return View(list);
            }
            else
            {
                return View();
            }
        }

        public IActionResult ListCandidate()
        {
            var list = userService.ListCandidate();
            foreach (var item in list)
            {
                item.Exam = examService.GetExam(item.ExamId);
            }
            if (list != null)
            {
                return View(list);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Add()
        {
            ViewData["items"] = examService.ListExam().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return View();
        }

        [HttpPost]
        public JsonResult Add(string name, string surname, string mail, string password, string userType, int examId)
        {
            ReturnValue retVal = new ReturnValue();

            if (!string.IsNullOrEmpty(mail) && !string.IsNullOrEmpty(password))
            {
                userService.InsertUser(new User
                {
                    Name = name,
                    Surname = surname,
                    Mail = mail,
                    Password = password,
                    Link = $"https://localhost:44302/Exam/EnterExam?e={examId}",
                    Type = Convert.ToInt32(userType),
                    ExamId = examId
                });
                retVal.isSuccess = true;
                retVal.message = "Ekleme başarılı.";
                return Json(retVal);
            }


            retVal.isSuccess = false;
            retVal.message = "Ekleme işlemi sırasında hata oluştu.";
            return Json(retVal);
        }

        public IActionResult Update(int id)
        {
            ViewData["items"] = examService.ListExam().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            var data = userService.GetUser(id);
            if (data != null)
            {
                return View(data);
            }

            return Redirect(nameof(List));
        }

        [HttpPost]
        public JsonResult Update(int id, string name, string surname, string mail, string password, string userType, int examId)
        {
            ReturnValue retVal = new ReturnValue();

            if (!string.IsNullOrEmpty(mail) && !string.IsNullOrEmpty(password))
            {
                userService.InsertUser(new User
                {
                    Id = Convert.ToInt32(id),
                    Name = name,
                    Surname = surname,
                    Mail = mail,
                    Password = password,
                    Link = $"https://localhost:44302/Exam/EnterExam?e={examId}",
                    Type = Convert.ToInt32(userType),
                    ExamId = examId
                });
                retVal.isSuccess = true;
                retVal.message = "Güncelleme başarılı.";
                return Json(retVal);
            }

            retVal.isSuccess = false;
            retVal.message = "Güncelleme işlemi sırasında hata oluştu.";
            return Json(retVal);
        }

        public JsonResult Delete(int id)
        {
            if (id != 0)
            {
                userService.DeleteUser(id);
            }

            return Json(true);
        }

        public IActionResult Login()
        {
            //Bir tane admin manuel sisteme eklendi.
            User user = new User();
            user.Id = 1;
            user.Name = "Murat Can";
            user.Surname = "Döngel";
            user.Mail = "muratcan_dongel@hotmail.com";
            user.Password = "mcTR5957..";
            user.Type = 2;
            var data = userService.GetUser(user.Id);
            if (data == null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(string mail, string password)
        {
            var user = userService.LoginUser(mail, password);

            if (user != null)
            {
                OnlineExamConfig.User = user;
                return Redirect("/Home/Index");
            }
            return View();
        }      
    }
}
