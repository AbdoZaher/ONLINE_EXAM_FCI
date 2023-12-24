using Microsoft.AspNetCore.Mvc;
using ONLINE_EXAM_FCI.Data;
using ONLINE_EXAM_FCI.Models;

namespace ONLINE_EXAM_FCI.Controllers
{
    public class ExamsController : Controller
    {
        private readonly ApplicationDbContext _database;
        public ExamsController(ApplicationDbContext database)
        {
            _database = database;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Exams()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Exams(Exam ex)
        //{
        //    return View();
        //}
        [HttpPost]
        public IActionResult Exams(Exam ex)
        {
            // Assume you have a list of exams to be stored in the database
          //  var examsToStore =
       // new Exam { ExSubject = "ddd", ExamName = "Math Exam", EXDuration = DateTime.Now.TimeOfDay, NumQuestions = 1, Questions = new List<ExamQuestion> { new ExamQuestion { Question = "kk", Choices = new List<string> { "nhhj", "jj", "jj", "kk" }, CorrectChoice = 4 } } };
        // Add more exams as needed

            // Store exams in the database
            _database.Exams.Add(ex);
            _database.SaveChanges();

            // You may redirect to another action or return a view as needed
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Quizzes()
        {
            return View();
        }
    }
}





