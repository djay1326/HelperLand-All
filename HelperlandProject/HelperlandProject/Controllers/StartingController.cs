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
        private readonly HelperLand1Context _DbContext;

        public StartingController(HelperLand1Context DbContext)
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
        public IActionResult ContactAdd(Contactus contactu)
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
        //[HttpPost]
        //public IActionResult AccountAdd(Userr userr)
        //{
        //    userr.UserTypeId = 1;
        //    _DbContext.Userr.Add(userr);
        //    _DbContext.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        public IActionResult NewAccount(Userr user)
        {
            var x = _DbContext.Userr.FirstOrDefault((System.Linq.Expressions.Expression<Func<Userr, bool>>)(p => (bool)p.Email.Equals((string)user.Email)));
            if (ModelState.IsValid && x == null)
            {
                Userr u = new Userr();
                u.FirstName = user.FirstName;
                u.LastName = user.LastName;
                u.Email = user.Email;
                u.Password = user.Password;
                u.Mobile = user.Mobile;
                u.UserTypeId = 1;
                u.CreatedDate = user.CreatedDate;
                _DbContext.Userr.Add(u);
                _DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = TempData["error"];
                return View();
            }
        }
            public IActionResult ServiceProvider()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HelperAccountAdd(Userr userr)
        {
            var x = _DbContext.Userr.FirstOrDefault((System.Linq.Expressions.Expression<Func<Userr, bool>>)(p => (bool)p.Email.Equals((string)userr.Email)));
            if (ModelState.IsValid && x == null)
            {
                Userr u = new Userr();
                u.FirstName = userr.FirstName;
                u.LastName = userr.LastName;
                u.Email = userr.Email;
                u.Password = userr.Password;
                u.Mobile = userr.Mobile;
                u.UserTypeId = 2;
                u.CreatedDate = userr.CreatedDate;
                _DbContext.Userr.Add(u);
                _DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = TempData["error"];
                return View();
            }
        }

        public IActionResult UpcomingSeventh()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginAdd(Userr userr)
        {

            Userr u = new Userr(); 
            var ue = _DbContext.Userr.FirstOrDefault((System.Linq.Expressions.Expression<Func<Userr, bool>>)(u => (bool)(u.Email.Equals((string)userr.Email) && u.Password.Equals((string)userr.Password))));
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


        [HttpPost]
        public IActionResult ForgotPassword(Userr model)
        {

            string resetCode = Guid.NewGuid().ToString();
            var verifyUrl = "/Account/ResetPassword/" + resetCode;
            // var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            var X = _DbContext.Userr.FirstOrDefault((System.Linq.Expressions.Expression<Func<Userr, bool>>)((Userr p) => (bool)p.Email.Equals((string)model.Email))).UserId;
            string baseUrl = string.Format("{0}://{1}", HttpContext.Request.Scheme, HttpContext.Request.Host);
            var activationUrl = $"{baseUrl}/Starting/ForgotPwd?UserId={X}";

            var get_user = _DbContext.Userr.FirstOrDefault((System.Linq.Expressions.Expression<Func<Userr, bool>>)(p => (bool)p.Email.Equals((string)model.Email)));
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
        public IActionResult ForgotPwd(int UserId)
        {
            Userr user = _DbContext.Userr.Where(x => x.UserId == UserId).FirstOrDefault();

            return View(user);
        }

        [HttpPost]
        public IActionResult resetpassword(Userr user)
        {
            Userr userData = _DbContext.Userr.Where(x => x.UserId == user.UserId).FirstOrDefault();

            userData.Password = user.Password;
            _DbContext.Userr.Update(userData);
            _DbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult bookService()
        {
            return View();
        }


        [HttpPost]
        public string Zipcode(string zip)
        {
            var isvalid = _DbContext.Userr.Where(x => x.ZipCode == zip).FirstOrDefault();
            string a;
            if (isvalid != null)
            {
                a = "true";
            }
            else
            {
                a = "false";
            }
            return a;
        }

        public string savebooking([FromBody] ServiceRequest add)
        {
            add.UserId = 2;
            add.ServiceId = 12345;
            add.ServiceHours = 2;
            _DbContext.ServiceRequest.Add(add);
            _DbContext.SaveChanges();
            string message = "true";
            return message;

        }

        public IActionResult yourDetail()
        {
            List<UserAddress> u = _DbContext.UserAddress.Where(x => x.UserId == 2).ToList();
            System.Threading.Thread.Sleep(2000);
            return View(u);
        }


        //public IActionResult address()
        //{

        //    List<UserAddress> u = _DbContext.UserAddress.Where(x => x.UserId == 2).ToList();
        //    System.Threading.Thread.Sleep(2000);
        //    return View(u);
        //}

        [HttpPost]
        public string yourDetail([FromBody] UserAddress address)
        {
            address.UserId = 2;
            _DbContext.UserAddress.Add(address);
            _DbContext.SaveChanges();
            return "true";
        }


    }
}
