﻿using Microsoft.AspNetCore.Mvc;
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
using Microsoft.AspNetCore.Http;

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
            Userr x = _DbContext.Userr.Where(x => x.Email == user.Email).FirstOrDefault();
            //var x = _DbContext.Userr.FirstOrDefault((System.Linq.Expressions.Expression<Func<Userr, bool>>)(p => (bool)p.Email.Equals((string)user.Email)));
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
            var x = _DbContext.Userr.FirstOrDefault(p => p.Email.Equals(userr.Email));
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

        

        [HttpPost]
        public IActionResult LoginAdd(Userr userr)
        {

            Userr u = new Userr(); 
            var ue = _DbContext.Userr.FirstOrDefault((System.Linq.Expressions.Expression<Func<Userr, bool>>)(u => (bool)(u.Email.Equals((string)userr.Email) && u.Password.Equals((string)userr.Password))));
            if(ue.UserTypeId == 1)
            {
                ViewBag.Message = String.Format("No matching email");
                //Session["FirstName"] = ue.UserId.ToString();
                HttpContext.Session.SetInt32("userid", ue.UserId);
                HttpContext.Session.SetString("username", ue.FirstName + " " + ue.LastName);
                return RedirectToAction("Index");
            }
            
            else if(ue.UserTypeId == 2)
            {
                ViewBag.Message = String.Format("No matching email");
                HttpContext.Session.SetInt32("userid", ue.UserId);
                HttpContext.Session.SetString("username", ue.FirstName + " " + ue.LastName);
                return RedirectToAction("Faqs");
            }
            else
            {
                return RedirectToAction("About");
            }
        }

        public IActionResult logout()
        {
            HttpContext.Session.Remove("userid");
            return RedirectToAction("Index");
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
                ms.From = new MailAddress("rough.java@gmail.com");
                ms.Subject = "Forgot Password reset link";
                ms.Body = activationUrl;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.Port = 587;


                NetworkCredential NetworkCred = new NetworkCredential("rough.java@gmail.com", "Sandwich#");
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
            var xyz = HttpContext.Session.GetInt32("userid");
            if(xyz != null)
            {
                return View();
            }
            else
            {
                TempData["abc"] = "You need to Login first!";
                return RedirectToAction("Index");
            }
              
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
            add.UserId = (int)HttpContext.Session.GetInt32("userid");
            //add.UserId = 2;
            add.ServiceId = 12345;
            //add.ServiceHours = 2;
            _DbContext.ServiceRequest.Add(add);
            _DbContext.SaveChanges();
            var ab = _DbContext.UserAddress.Where(x => x.AddressId == add.AddressId).FirstOrDefault();
            ServiceRequestAddress sa = new ServiceRequestAddress();
            sa.ServiceRequestId = add.ServiceRequestId;
            sa.AddressLine1 = ab.AddressLine1;
            sa.AddressLine2 = ab.AddressLine2;
            sa.City = ab.City;
            sa.Mobile = ab.Mobile;
            sa.State = ab.State;
            sa.PostalCode = ab.PostalCode;
            _DbContext.ServiceRequestAddress.Add(sa);
            _DbContext.SaveChanges();
            string message = "true";
            return message;

        }

        public IActionResult yourDetail()
        {
            var ty = (int)HttpContext.Session.GetInt32("userid");
            List<UserAddress> u = _DbContext.UserAddress.Where(x => x.UserId == ty).ToList();
            System.Threading.Thread.Sleep(2000);
            return View(u);
        }


        [HttpPost]
        public string yourDetail([FromBody] UserAddress address)
        {
            address.UserId = (int)HttpContext.Session.GetInt32("userid");
            _DbContext.UserAddress.Add(address);
            _DbContext.SaveChanges();
            return "true";
        }

        public IActionResult UpcomingSeventh()
        {
            var ty = (int)HttpContext.Session.GetInt32("userid");
            List<ServiceRequest> wt = _DbContext.ServiceRequest.Where(x => x.UserId == ty && x.Status ==null).ToList();

            return View(wt);
        }

        public IActionResult settingsSeven()
        {
            var ty = (int)HttpContext.Session.GetInt32("userid");
            Userr u = _DbContext.Userr.Where(x => x.UserId == ty).FirstOrDefault();
            return View(u);
        }

        public IActionResult shistorySeven()
        {
            var ty = (int)HttpContext.Session.GetInt32("userid");
            List<ServiceRequest> u = _DbContext.ServiceRequest.Where(x => x.UserId == ty && x.Status != null).ToList();
            return View(u);
        }

        public IActionResult favSeven()
        {
            return View();
        }

        public IActionResult notifySeven()
        {
            return View();
        }

        public IActionResult divOpen(int valuess)
        {
            var query = (from ServiceRequest in _DbContext.ServiceRequest
                         join ServiceRequestAddress in _DbContext.ServiceRequestAddress on ServiceRequest.ServiceRequestId equals ServiceRequestAddress.ServiceRequestId
                         where ServiceRequest.ServiceRequestId == valuess
                         select new Popup
                         {
                             ServiceRequestId = ServiceRequest.ServiceRequestId,
                             ServiceStartDate = ServiceRequest.ServiceStartDate,
                             SubTotal = ServiceRequest.SubTotal,
                             AddressLine1 = ServiceRequestAddress.AddressLine1,
                         }).Single();


            return View(query);
        }

        public string btnOpen ([FromBody] ServiceRequest test)
        {
            ServiceRequest abc = _DbContext.ServiceRequest.Where(x => x.ServiceRequestId == test.ServiceRequestId).FirstOrDefault();
            abc.Status = 0;
            abc.Comments = test.Comments;
            _DbContext.ServiceRequest.Update(abc);
            _DbContext.SaveChanges();
            return "true";
        }

        public string detailsTab([FromBody] Userr test)
        {
            var ty = (int)HttpContext.Session.GetInt32("userid");
            Userr u = _DbContext.Userr.Where(x => x.UserId == ty).FirstOrDefault();
            u.FirstName = test.FirstName;
            u.LastName = test.LastName;
            u.Mobile = test.Mobile;
            _DbContext.Userr.Update(u);
            _DbContext.SaveChanges();
            return "true";
        }

        public string NewPwd([FromBody] Userr pass)
        {
            var ty = (int)HttpContext.Session.GetInt32("userid");
            Userr u = _DbContext.Userr.Where(x => x.UserId == ty).FirstOrDefault();
            if(u.Password == pass.Password)
            {
                u.Password = pass.NewPassword;
                _DbContext.Userr.Update(u);
                _DbContext.SaveChanges();
                return "true";
            }
            return "false";
        }
         
        public IActionResult addressMenu()
        {
            var ty = (int)HttpContext.Session.GetInt32("userid");
            List<UserAddress> tu = _DbContext.UserAddress.Where(x => x.UserId == ty).ToList();
            return View(tu);
        }

        public string deleteTab(int i)
        {
            UserAddress u = _DbContext.UserAddress.Where(x => x.AddressId == i).FirstOrDefault();
            _DbContext.UserAddress.Remove(u);
            _DbContext.SaveChanges();
            return "true";
        }

        public IActionResult editAddress(int edit)
        {
            UserAddress u = _DbContext.UserAddress.Where(x => x.AddressId == edit).FirstOrDefault();
            return View(u);
        }

        public string editPopup([FromBody] UserAddress change)
        {
            UserAddress getaddress = _DbContext.UserAddress.Where(x => x.AddressId == change.AddressId).FirstOrDefault();

            getaddress.AddressLine1 = change.AddressLine1;
            getaddress.AddressLine2 = change.AddressLine2;
            getaddress.PostalCode = change.PostalCode;
            getaddress.City = change.City;
            getaddress.Mobile = change.Mobile;
            _DbContext.UserAddress.Update(getaddress);
            _DbContext.SaveChanges();
            return "true";

        }
    }
}
