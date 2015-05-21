using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllEars.Models;
using Newtonsoft.Json;

namespace AllEars.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Show()
        {
            return View();
        }

        [Authorize]
        public ActionResult List()
        {
            List<QuestionModel> questions = JsonConvert.DeserializeObject<List<QuestionModel>>(System.IO.File.ReadAllText(@Server.MapPath("~/App_Data/storage.json")));
            return View(questions);
        }

        public ActionResult AskQuestion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AskQuestion(QuestionModel question)
        {
            question.timestamp = DateTime.Now;
            question.content = HttpUtility.HtmlEncode(question.content);
            List<QuestionModel> questions = JsonConvert.DeserializeObject<List<QuestionModel>>(System.IO.File.ReadAllText(@Server.MapPath("~/App_Data/storage.json")));
            questions.Add(question);
            JsonSerializer js = new JsonSerializer();
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@Server.MapPath("~/App_Data/storage.json")))
            {
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    js.Serialize(jw, questions);
                }
            }
            return RedirectToAction("Index");
        }

    }
}
