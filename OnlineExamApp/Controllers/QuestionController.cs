using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnlineExamApp.Entities;
using OnlineExamApp.Helpers;
using OnlineExamApp.Services;
using System;
using System.Linq;

namespace OnlineQuestionApp.Controllers
{
    public class QuestionController : Controller
    {
        private IQuestionService questionService;
        private IExamService examService;

        public QuestionController(IQuestionService questionService, IExamService examService)
        {
            this.questionService = questionService;
            this.examService = examService;
        }

        public IActionResult List()
        {
            var list = questionService.ListQuestion();

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
        public JsonResult Add(string title, string content, string answers, string correctAnswer, int examId)
        {
            ReturnValue retVal = new ReturnValue();
            //var splittedAnswers = answers.Split('\n');

            if (!string.IsNullOrEmpty(title))
            {
                questionService.InsertQuestion(new Question
                {
                    Title = title,
                    Content = content,
                    Answers = answers,
                    CorrectAnswer = correctAnswer,
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
            var data = questionService.GetQuestion(id);
            if (data != null)
            {
                return View(data);
            }

            return Redirect(nameof(List));
        }

        [HttpPost]
        public JsonResult Update(int id, string title, string content, string answers, string correctAnswer, int examId)
        {
            ReturnValue retVal = new ReturnValue();

            if (!string.IsNullOrEmpty(title))
            {
                questionService.UpdateQuestion(new Question
                {
                    Id = id,
                    Title = title,
                    Content = content,
                    Answers = answers,
                    CorrectAnswer = correctAnswer,
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
                questionService.DeleteQuestion(id);
            }

            return Json(true);
        }
    }
}
