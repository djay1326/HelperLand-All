using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelperlandProject.Models;
using HelperlandProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Session;
using System.Net.Mail;
using System.Net;

namespace HelperlandProject.Controllers
{
   
    public class StartingController : Controller 
    {
        private readonly HelperlanddContext _DbContext;

        public StartingController(HelperlanddContext DbContext)
        {
            _DbContext = DbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Faqs()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactAdd(Contactu contactu)
        {
            _DbContext.Contactus.Add(contactu);
            _DbContext.SaveChanges();
            return RedirectToAction("Contact");
        }
        public IActionResult Prices()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult NewAccount()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AccountAdd(Userr userr)
        {
            userr.UserTypeId = 1;
            _DbContext.Userr.Add(userr);
            _DbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ServiceProvider()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HelperAccountAdd(Userr userr)
        {
            userr.UserTypeId = 2;
            _DbContext.Userr.Add(userr);
            _DbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpcomingSeventh()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginAdd(Userr userr)
        {

            Userr u = new Userr(); 
            var ue = _DbContext.Userr.FirstOrDefault(u => u.Email.Equals(userr.Email) && u.Password.Equals(userr.Password));
            if(ue.UserTypeId == 1)
            {
                ViewBag.Message = String.Format("No matching email");
                //Session["FirstName"] = ue.UserId.ToString();
                return RedirectToAction("UpcomingSeventh");
            }
            
            else if(ue.UserTypeId == 2)
            {
                ViewBag.Message = String.Format("No matching email");
                return RedirectToAction("Faqs");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        //[HttpPost]
        //public IActionResult ForgotPassword(Userr model)
        //{
        //    MailMessage ms = new MailMessage();
        //    ms.To.Add(model.Email);
        //    ms.From = new MailAddress("180320107503.ce.jay@gmail.com");
        //    ms.Subject = "Reset Password";

        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = "smtp.gmail.com";
        //    smtp.EnableSsl = true;
        //    smtp.Port = 587;


        //    NetworkCredential NetworkCred = new NetworkCredential("180320107503.ce.jay@gmail.com", "Sandwich#");
        //    smtp.UseDefaultCredentials = true;
        //    smtp.Credentials = NetworkCred;
        //    smtp.Send(ms);
        //    ViewBag.Message = "mail has been sent successfully ";

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public IActionResult ForgotPassword(Userr model)
        {

            string resetCode = Guid.NewGuid().ToString();
            var verifyUrl = "/Account/ResetPassword/" + resetCode;
            // var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            //var X = _DbContext.Userr.FirstOrDefault(p => p.Email.Equals(model.Email)).UserId;
            string baseUrl = string.Format("{0}://{1}", HttpContext.Request.Scheme, HttpContext.Request.Host);
            var activationUrl = $"{baseUrl}/Starting/ForgotPwd";

            var get_user = _DbContext.Userr.FirstOrDefault(p => p.Email.Equals(model.Email));
            if (get_user != null)
            {
                MailMessage ms = new MailMessage();
                ms.To.Add(model.Email);
                ms.From = new MailAddress("ravi.smith.1326@gmail.com");
                ms.Subject = "hello";
                ms.Body = activationUrl;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.Port = 587;


                NetworkCredential NetworkCred = new NetworkCredential("ravi.smith.1326@gmail.com", "Sandwich#");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Send(ms);
                ViewBag.Message = "mail has been sent successfully ";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "verify your email";
                return RedirectToAction("Faqs");
            }

        }

        public IActionResult ForgotPwd()
        {
            return View();
        }

    }
}
