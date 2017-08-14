using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_MVC5.Models;


namespace Project_MVC5.Controllers
{
    public class SendMailController : Controller
    {
        // GET: SendMail
        public ActionResult Index()
        {
            var model = new ContactModel();
            return View();
        }
        [HttpPost]
        public ActionResult Index(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                string smtpUserName = "creedsadun94@gmail.com";
                string smtpPassword = ""; // enter email password
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 25;
                
                string emailTo = "creedsadun@live.com";
                string subject = model.Subject;
                string body = string.Format("ting tong tiong: <b>{0}</b><br/>Email: {1}<br/> tiong: <br/>{2}", model.UserName, model.Email, model.Message);
               
                Project_MVC5.Models.EmailService newService = new Models.EmailService();
                
                bool kq = newService.Send(smtpUserName, smtpPassword, smtpHost, smtpPort, emailTo, subject, body);

                if (kq) ModelState.AddModelError("", "sdfsdf");
                else ModelState.AddModelError("", "454635");
                
            }
            return View(model);
        }
    }
}