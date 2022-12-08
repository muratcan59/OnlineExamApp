using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineExamApp.Entities;
using OnlineExamApp.Helpers;
using OnlineExamApp.Services;
using System;
using System.Linq;

namespace OnlineExamApp.Controllers
{
    public class ExamController : Controller
    {
        private IExamService examService;
        private IUserService userService;
        private IQuestionService questionService;

        public ExamController(IExamService examService, IQuestionService questionService, IUserService userService)
        {
            this.examService = examService;
            this.questionService = questionService;
            this.userService = userService;
        }

        public IActionResult List()
        {
            var list = examService.ListExam();
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
            return View();
        }

        [HttpPost]
        public JsonResult Add(string name, int questionCount)
        {
            ReturnValue retVal = new ReturnValue();

            if (!string.IsNullOrEmpty(name))
            {
                examService.InsertExam(new Exam
                {
                    Name = name,
                    QuestionCount = questionCount
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
            var data = examService.GetExam(id);
            if (data != null)
            {
                return View(data);
            }

            return Redirect(nameof(List));
        }

        [HttpPost]
        public JsonResult Update(int id, string name, int questionCount)
        {
            ReturnValue retVal = new ReturnValue();

            if (!string.IsNullOrEmpty(name))
            {
                examService.UpdateExam(new Exam
                {
                    Id = id,
                    Name = name,
                    QuestionCount = questionCount
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
                examService.DeleteExam(id);
            }

            return Json(true);
        }        

        public IActionResult MyExam()
        {
            var user = OnlineExamConfig.User;
            user.Exam = examService.GetExam(user.ExamId);

            return View(user);
        }

        public IActionResult EnterExam(int e)
        {
            var user = OnlineExamConfig.User;
            var exam = examService.GetExam(e);
            
            exam.Questions = questionService.ListQuestion().Where(c => c.ExamId == e).ToList();

            return View(exam.Questions);
        }

        [HttpPost]
        public JsonResult EnterExam(string score)
        {
            ReturnValue retVal = new ReturnValue();
            var user = OnlineExamConfig.User;

            user.Score = Convert.ToInt32(score);
            userService.UpdateUser(user);

            retVal.isSuccess = true;
            retVal.message = "Sınavınız başarılı bir şekilde tamamlandı.";
            return Json(retVal);
        }
    }
}
