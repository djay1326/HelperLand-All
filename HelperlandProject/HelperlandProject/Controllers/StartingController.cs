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
        public IActionResult ServiceProvider(Userr userr)
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

            //Userr u = new Userr();
            // var ue = _DbContext.Userr.FirstOrDefault((System.Linq.Expressions.Expression<Func<Userr, bool>>)(u => (bool)(u.Email.Equals((string)userr.Email) && u.Password.Equals((string)userr.Password))));
            var ue = _DbContext.Userr.Where(x => x.Email == userr.Email && x.Password == userr.Password).FirstOrDefault();
            if (ue != null)
            {
                if (ue.UserTypeId == 1 && ue.IsActive == true)
                {
                    ViewBag.Message = String.Format("No matching email");
                    //Session["FirstName"] = ue.UserId.ToString();
                    HttpContext.Session.SetInt32("userid", ue.UserId);
                    HttpContext.Session.SetString("username", ue.FirstName + " " + ue.LastName);
                    return RedirectToAction("Index");
                }

                else if (ue.UserTypeId == 2 && ue.IsActive == true)
                {
                    ViewBag.Message = String.Format("No matching email");
                    HttpContext.Session.SetInt32("userid", ue.UserId);
                    HttpContext.Session.SetString("username", ue.FirstName + " " + ue.LastName);
                    return RedirectToAction("eightMain");
                }
                else if (ue.UserTypeId == 3)
                {
                    
                    return RedirectToAction("userManagement");
                }
                else
                {
                    TempData["abc"] = "Your id is deactivated!";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["abc"] = "Wrong Id or Password!";
                return RedirectToAction("Index");
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
            add.ServiceId = 1000 + add.ServiceRequestId;
            _DbContext.ServiceRequest.Update(add);
            _DbContext.SaveChanges();
            return add.ServiceId.ToString();

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
            //List<ServiceRequest> wt = _DbContext.ServiceRequest.Where(x => x.UserId == ty && x.Status ==null).ToList();
            var query = from ServiceRequest in _DbContext.ServiceRequest
                        join User in _DbContext.Userr
                        on ServiceRequest.ServiceProviderId equals User.UserId into abc
                        from rate in abc.DefaultIfEmpty()
                        where ServiceRequest.UserId == ty && (ServiceRequest.Status == null || ServiceRequest.Status == 2) && ServiceRequest.ServiceStartDate > DateTime.Now
                        select new Popup
                        {
                            FirstName = rate.FirstName,
                            LastName = rate.LastName,
                            ServiceId = ServiceRequest.ServiceId,
                            ServiceStartDate = ServiceRequest.ServiceStartDate,
                            SubTotal = ServiceRequest.SubTotal,
                            ServiceRequestId = ServiceRequest.ServiceRequestId,
                            ServiceProviderId = ServiceRequest.ServiceProviderId
                        };

            return View(query);
            
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
            var a = HttpContext.Session.GetInt32("userid");
            if (a != null)
            {
                var query = (from user in _DbContext.Userr
                             join FavoriteAndBlocked in _DbContext.FavoriteAndBlocked
                             on user.UserId equals FavoriteAndBlocked.UserId
                             where FavoriteAndBlocked.TargetUserId == a
                             select new Popup
                             {
                                 Id = FavoriteAndBlocked.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 IsBlocked = FavoriteAndBlocked.IsBlocked,
                                 UserId = user.UserId,
                                 Ratings = (from Rating in _DbContext.Rating where Rating.RatingTo.Equals(user.UserId) select Rating.Ratings).Average(),
                                 //totalconunt = (from Rating in _DbContext.Rating where Rating.RatingTo.Equals(user.UserId) select Rating.Ratings).Count()
                             }).ToList();
                return View(query);

            }
            else
            {
                TempData["error"] = "please login first";
                return RedirectToAction("Index");
            }
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
                             ServiceHours = ServiceRequest.ServiceHours,
                             ServiceId = ServiceRequest.ServiceId,
                             Mobile = ServiceRequestAddress.Mobile,
                             AddressLine1 = ServiceRequestAddress.AddressLine1
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
            u.DateOfBirth = test.DateOfBirth;
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

        public IActionResult eightMain()
        {
            return View();
        }

        public IActionResult settingsEight()
        {
            var ty = (int)HttpContext.Session.GetInt32("userid");
            SettingsModelEight st = new SettingsModelEight();
            st.Userr = _DbContext.Userr.Where(x => x.UserId == ty).FirstOrDefault();
            st.UserAddress = _DbContext.UserAddress.Where(x => x.UserId == ty).FirstOrDefault();
            return View(st);
        }

        public IActionResult notifyEight()
        {
            return View();
        }

        [HttpPost]
        public IActionResult settingsEight(SettingsModelEight sme)
        {
            var ty = (int)HttpContext.Session.GetInt32("userid");
            Userr u = _DbContext.Userr.Where(x => x.UserId == ty).FirstOrDefault();
            u.FirstName = sme.Userr.FirstName;
            u.LastName = sme.Userr.LastName;
            u.Mobile = sme.Userr.Mobile;
            u.DateOfBirth = sme.Userr.DateOfBirth;
            u.Gender = sme.Userr.Gender;
            u.ZipCode = sme.Userr.ZipCode;
            _DbContext.Userr.Update(u);
            _DbContext.SaveChanges();
            UserAddress ua = _DbContext.UserAddress.Where(x => x.UserId == ty).FirstOrDefault();
            if (ua!= null) 
            { 
            ua.AddressLine1 = sme.UserAddress.AddressLine1;
            ua.AddressLine2 = sme.UserAddress.AddressLine2;
            ua.PostalCode = sme.UserAddress.PostalCode;
            ua.Mobile = sme.Userr.Mobile;
            ua.City = sme.UserAddress.City;
                ua.PostalCode = sme.Userr.ZipCode;
                _DbContext.UserAddress.Update(ua);
            _DbContext.SaveChanges();
            }
            else
            {
                UserAddress usa = new UserAddress();
                usa.UserId = ty;
                usa.AddressLine1 = sme.UserAddress.AddressLine1;
                usa.AddressLine2 = sme.UserAddress.AddressLine2;
                usa.PostalCode = sme.UserAddress.PostalCode;
                usa.Mobile = sme.Userr.Mobile;
                usa.City = sme.UserAddress.City;
                _DbContext.UserAddress.Add(usa);
                _DbContext.SaveChanges();
            }
            TempData["abc"] = "Data has been updated!";
            return View();
        }

        public string NewPwdEight([FromBody] Userr pass)
        {
            var ty = (int)HttpContext.Session.GetInt32("userid");
            Userr u = _DbContext.Userr.Where(x => x.UserId == ty).FirstOrDefault();
            if (u.Password == pass.Password)
            {
                u.Password = pass.NewPassword;
                _DbContext.Userr.Update(u);
                _DbContext.SaveChanges();
                return "true";
            }
            return "false";
        }

        public IActionResult blockCust()
        {
            var ty = (int)HttpContext.Session.GetInt32("userid");
            var query = (from user in _DbContext.Userr
                         join FavoriteAndBlocked in _DbContext.FavoriteAndBlocked
                         on user.UserId equals FavoriteAndBlocked.TargetUserId
                         where FavoriteAndBlocked.UserId == ty
                         select new Popup
                         {
                             Id = FavoriteAndBlocked.Id,
                             FirstName = user.FirstName,
                             LastName = user.LastName,
                             IsBlocked = FavoriteAndBlocked.IsBlocked,
                             UserId = user.UserId
                         }).ToList();

            return View(query);
            
        }
        public IActionResult eightNewService()
        {
            var ty = (int)HttpContext.Session.GetInt32("userid");
            Userr u = _DbContext.Userr.Where(x => x.UserId == ty).FirstOrDefault();
            var query = (from ServiceRequest in _DbContext.ServiceRequest
                         join ServiceRequestAddress in _DbContext.ServiceRequestAddress
                         on ServiceRequest.ServiceRequestId equals ServiceRequestAddress.ServiceRequestId
                         join user in _DbContext.Userr on ServiceRequest.UserId equals user.UserId
                         where ServiceRequest.ZipCode == u.ZipCode && ServiceRequest.ServiceProviderId == null
                         select new NewServiceRequest
                         {
                             ServiceRequestId = ServiceRequest.ServiceRequestId,
                             ServiceId = ServiceRequest.ServiceId,
                             ServiceStartDate = ServiceRequest.ServiceStartDate,
                             FirstName = user.FirstName,
                             LastName = user.LastName,
                             AddressLine1 = ServiceRequestAddress.AddressLine1,
                             AddressLine2 = ServiceRequestAddress.AddressLine2,
                             ZipCode = ServiceRequest.ZipCode,
                             SubTotal = ServiceRequest.SubTotal,
                             City = ServiceRequestAddress.City
                         }).ToList();
            return View(query);
        }

        public IActionResult eightUpcoming()
        {
            var ty = (int)HttpContext.Session.GetInt32("userid");
            Userr u = _DbContext.Userr.Where(x => x.UserId == ty).FirstOrDefault();
            var query = (from ServiceRequest in _DbContext.ServiceRequest
                         join ServiceRequestAddress in _DbContext.ServiceRequestAddress
                         on ServiceRequest.ServiceRequestId equals ServiceRequestAddress.ServiceRequestId
                         join user in _DbContext.Userr on ServiceRequest.UserId equals user.UserId
                         where ServiceRequest.ServiceProviderId == ty && ServiceRequest.Status == 2
                         select new NewServiceRequest
                         {
                             ServiceRequestId = ServiceRequest.ServiceRequestId,
                             ServiceId = ServiceRequest.ServiceId,
                             ServiceStartDate = ServiceRequest.ServiceStartDate,
                             FirstName = user.FirstName,
                             LastName = user.LastName,
                             AddressLine1 = ServiceRequestAddress.AddressLine1,
                             AddressLine2 = ServiceRequestAddress.AddressLine2,
                             ZipCode = ServiceRequest.ZipCode,
                             SubTotal = ServiceRequest.SubTotal,
                             City = ServiceRequestAddress.City
                         }).ToList();
            return View(query);
        }
        
        public string eightAccept(int i)
        {
            var ty = (int)HttpContext.Session.GetInt32("userid");
            //Userr u = _DbContext.Userr.Where(x => x.UserId == ty).FirstOrDefault(); 
            ServiceRequest srt = _DbContext.ServiceRequest.Where(x => x.ServiceRequestId == i).FirstOrDefault();
            srt.ServiceProviderId = ty;
            srt.SpacceptedDate = DateTime.Now;
            srt.Status = 2;
            _DbContext.ServiceRequest.Update(srt);
            _DbContext.SaveChanges();
            return "true";
        }

        public string eightCancel(int i)
        {
            ServiceRequest srt = _DbContext.ServiceRequest.Where(x => x.ServiceRequestId == i).FirstOrDefault();
            srt.ServiceProviderId = null;
            srt.SpacceptedDate = null;
            srt.Status = null;
            _DbContext.ServiceRequest.Update(srt);
            _DbContext.SaveChanges();
            return "true";
        }

        public IActionResult eightHistory()
        {
            var ty = (int)HttpContext.Session.GetInt32("userid");
            var query = from ServiceRequest in _DbContext.ServiceRequest
                        join ServiceRequestAddress in _DbContext.ServiceRequestAddress
                        on ServiceRequest.ServiceRequestId equals ServiceRequestAddress.ServiceRequestId
                        join user in _DbContext.Userr on ServiceRequest.UserId equals user.UserId
                        where ServiceRequest.ServiceProviderId == ty && ServiceRequest.Status == 1
                        select new Popup
                        {
                            ServiceRequestId = ServiceRequest.ServiceRequestId,
                            ServiceId = ServiceRequest.ServiceId,
                            ServiceHours = ServiceRequest.ServiceHours,
                            ServiceStartDate = ServiceRequest.ServiceStartDate,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Comments = ServiceRequest.Comments,
                            AddressLine1 = ServiceRequestAddress.AddressLine1,
                            AddressLine2 = ServiceRequestAddress.AddressLine2,
                            ZipCode = ServiceRequest.ZipCode,
                            SubTotal = ServiceRequest.SubTotal,
                            City = ServiceRequestAddress.City
                        };
            return View(query);
        }

        public IActionResult _upcomingPop(int i)
        {
            var query = (from ServiceRequest in _DbContext.ServiceRequest
                         join ServiceRequestAddress in _DbContext.ServiceRequestAddress
                         on ServiceRequest.ServiceRequestId equals ServiceRequestAddress.ServiceRequestId
                         join user in _DbContext.Userr on ServiceRequest.UserId equals user.UserId
                         where ServiceRequest.ServiceRequestId == i
                         select new Popup
                         {
                             ServiceRequestId = ServiceRequest.ServiceRequestId,
                             ServiceId = ServiceRequest.ServiceId,
                             ServiceHours = ServiceRequest.ServiceHours,
                             ServiceStartDate = ServiceRequest.ServiceStartDate,
                             FirstName = user.FirstName,
                             LastName = user.LastName,
                             Comments = ServiceRequest.Comments,
                             AddressLine1 = ServiceRequestAddress.AddressLine1,
                             AddressLine2 = ServiceRequestAddress.AddressLine2,
                             ZipCode = ServiceRequest.ZipCode,
                             SubTotal = ServiceRequest.SubTotal,
                             City = ServiceRequestAddress.City
                         }).Single();

            return PartialView(query);
        }
        
        public string serviceComplete(int i)
        {
            ServiceRequest sr = _DbContext.ServiceRequest.Where(x => x.ServiceRequestId == i).FirstOrDefault();
            sr.Status = 1;
            _DbContext.ServiceRequest.Update(sr);
            _DbContext.SaveChanges();
            var ii = _DbContext.FavoriteAndBlocked.Where(x => x.UserId == sr.ServiceProviderId && x.TargetUserId == sr.UserId).FirstOrDefault();
            if(ii== null)
            {
                FavoriteAndBlocked sb = new FavoriteAndBlocked();
                sb.UserId = (int)sr.ServiceProviderId;
                sb.TargetUserId = sr.UserId;
                sb.IsBlocked = false;
                sb.IsFavorite = false;
                _DbContext.FavoriteAndBlocked.Add(sb);
                _DbContext.SaveChanges();
            }
            return "true";
        }

        public IActionResult _calendarPop(int i)
        {
            var query = (from ServiceRequest in _DbContext.ServiceRequest
                         join ServiceRequestAddress in _DbContext.ServiceRequestAddress
                         on ServiceRequest.ServiceRequestId equals ServiceRequestAddress.ServiceRequestId
                         join user in _DbContext.Userr on ServiceRequest.UserId equals user.UserId
                         where ServiceRequest.ServiceRequestId == i
                         select new Popup
                         {
                             ServiceRequestId = ServiceRequest.ServiceRequestId,
                             ServiceId = ServiceRequest.ServiceId,
                             ServiceHours = ServiceRequest.ServiceHours,
                             ServiceStartDate = ServiceRequest.ServiceStartDate,
                             FirstName = user.FirstName,
                             LastName = user.LastName,
                             Comments = ServiceRequest.Comments,
                             AddressLine1 = ServiceRequestAddress.AddressLine1,
                             AddressLine2 = ServiceRequestAddress.AddressLine2,
                             ZipCode = ServiceRequest.ZipCode,
                             SubTotal = ServiceRequest.SubTotal,
                             City = ServiceRequestAddress.City
                         }).Single();

            return PartialView(query);
        }

        public IActionResult eightRating(int i)
        {
            var ty = (int)HttpContext.Session.GetInt32("userid");
            var query = (from User in _DbContext.Userr
                         join Rating in _DbContext.Rating
                         on User.UserId equals Rating.RatingFrom
                         join ServiceRequest in _DbContext.ServiceRequest
                         on Rating.ServiceRequestId equals ServiceRequest.ServiceRequestId
                         where Rating.RatingTo == ty
                         select new Popup
                         {
                             ServiceId = ServiceRequest.ServiceId,
                             FirstName = User.FirstName,
                             LastName = User.LastName,
                             RatingDate = (DateTime)Rating.RatingDate,
                             Ratings = Rating.Ratings,
                             Comments = Rating.Comments
                         }).ToList();
            return View(query);
        }

        public IActionResult _star(int sid)
        {
            Userr u = _DbContext.Userr.Where(x => x.UserId == sid).FirstOrDefault();
            return PartialView(u);
        }

        public string starPopup([FromBody] Rating rate)
        {

            var a = (int)HttpContext.Session.GetInt32("userid");
            Rating r = _DbContext.Rating.Where(x => x.ServiceRequestId == rate.ServiceRequestId).FirstOrDefault();

            if (r != null)
            {
                r.Ratings = rate.Ratings;
                r.Comments = rate.Comments;
                r.Friendly = rate.Friendly;
                r.OnTimeArrival = rate.OnTimeArrival;
                r.QualityOfService = rate.QualityOfService;
                r.RatingDate = DateTime.Now;
                _DbContext.Rating.Update(r);
            }
            else
            {
                rate.RatingFrom = a;
                rate.RatingDate = DateTime.Now;
                _DbContext.Rating.Add(rate);
            }
            _DbContext.SaveChanges();
            return "true";
        }

        public int reschedulePop([FromBody] ServiceRequest book)
        {

            ServiceRequest detail = _DbContext.ServiceRequest.Where(x => x.ServiceRequestId == book.ServiceRequestId).FirstOrDefault();
            int result = DateTime.Compare(DateTime.Now, DateTime.Parse(book.Date));
            if (result == -1)
            {
                detail.ServiceStartDate = DateTime.Parse(book.Date);
                _DbContext.ServiceRequest.Update(detail);
                _DbContext.SaveChanges();
                return 1;
            }
            else if (result == 0)
            {
                return 0;
            }
            else if (result == 1)
            {
                return 0;
            }
            else
            {
                return 0;
            }
        }

        public IActionResult userManagement()
        {
            List<Userr> x = _DbContext.Userr.Where(x => x.UserTypeId != 3).ToList();
            return View(x);
        }

        public IActionResult serviceRequest()
        {

            var query = from ServiceRequest in _DbContext.ServiceRequest
                        join ServiceRequestAddress in _DbContext.ServiceRequestAddress
                        on ServiceRequest.ServiceRequestId equals ServiceRequestAddress.ServiceRequestId
                        join user in _DbContext.Userr
                        on ServiceRequest.UserId equals user.UserId
                        join Rating in _DbContext.Rating
                        on ServiceRequest.ServiceRequestId equals Rating.ServiceRequestId into abc
                        from Rating in abc.DefaultIfEmpty()
                        join spuser in _DbContext.Userr
                        on ServiceRequest.ServiceProviderId equals spuser.UserId into xyz
                        from spuser in xyz.DefaultIfEmpty()
                        select new Popup
                        {
                            ServiceRequestId = ServiceRequest.ServiceRequestId,
                            ServiceId = ServiceRequest.ServiceId,
                            ServiceHours = ServiceRequest.ServiceHours,
                            ServiceStartDate = ServiceRequest.ServiceStartDate,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Comments = ServiceRequest.Comments,
                            AddressLine1 = ServiceRequestAddress.AddressLine1,
                            AddressLine2 = ServiceRequestAddress.AddressLine2,
                            ZipCode = ServiceRequest.ZipCode,
                            SubTotal = ServiceRequest.SubTotal,
                            City = ServiceRequestAddress.City,
                            Ratings = Rating == null ? 0 : Rating.Ratings,
                            Status = ServiceRequest.Status,
                            spFirstName = spuser == null ? "" : spuser.FirstName,
                            spLastName = spuser == null ? "" : spuser.LastName,
                            usertypeid = user.UserTypeId
                        };

            return View(query);
        }

        public IActionResult deactivate(int id)
        {
            Userr u = _DbContext.Userr.Where(x => x.UserId == id).FirstOrDefault();
            u.IsActive = false;
            _DbContext.Userr.Update(u);
            _DbContext.SaveChanges();
            return RedirectToAction("userManagement");
            
        }

        public IActionResult activate(int id)
        {
            Userr u = _DbContext.Userr.Where(x => x.UserId == id).FirstOrDefault();
            u.IsActive = true;
            _DbContext.Userr.Update(u);
            _DbContext.SaveChanges();
            return RedirectToAction("userManagement");

        }

        public IActionResult _editreschedule(int id)
        {
            var query = (from ServiceRequest in _DbContext.ServiceRequest
                         join ServiceRequestAddress in _DbContext.ServiceRequestAddress
                         on ServiceRequest.ServiceRequestId equals ServiceRequestAddress.ServiceRequestId
                         where ServiceRequest.ServiceRequestId == id
                         select new Popup
                         {
                             ServiceRequestId = ServiceRequest.ServiceRequestId,

                             ServiceHours = ServiceRequest.ServiceHours,
                             ServiceStartDate = ServiceRequest.ServiceStartDate,

                             Comments = ServiceRequest.Comments,
                             AddressLine1 = ServiceRequestAddress.AddressLine1,
                             AddressLine2 = ServiceRequestAddress.AddressLine2,
                             ZipCode = ServiceRequest.ZipCode,

                             City = ServiceRequestAddress.City
                         }).Single();
            return PartialView(query);
        }

        public int editresUpdate([FromBody] Popup y)
        {
            ServiceRequest sr = _DbContext.ServiceRequest.Where(x => x.ServiceRequestId == y.ServiceRequestId).FirstOrDefault();
            sr.ServiceStartDate =y.Date;
            sr.Comments = y.Comments;
            sr.ZipCode = y.PostalCode;
            _DbContext.ServiceRequest.Update(sr);
            _DbContext.SaveChanges();

            ServiceRequestAddress srd = _DbContext.ServiceRequestAddress.Where(x => x.ServiceRequestId == y.ServiceRequestId).FirstOrDefault();
            srd.AddressLine1 = y.AddressLine1;
            srd.AddressLine2 = y.AddressLine2;
            srd.City = y.City;
            srd.PostalCode = y.PostalCode;

            _DbContext.ServiceRequestAddress.Update(srd);
            _DbContext.SaveChanges();
            return 1;
        }

        public IActionResult _refundPop(int id)
        {
            ServiceRequest sr = _DbContext.ServiceRequest.Where(x => x.ServiceRequestId == id).FirstOrDefault();
            return PartialView(sr);
        }

        public string refundUpdateChanges([FromBody] ServiceRequest book)
        {
            ServiceRequest sr = _DbContext.ServiceRequest.Where(x => x.ServiceRequestId == book.ServiceRequestId).FirstOrDefault();
            sr.Comments = book.Comments;
            sr.RefundedAmount = book.RefundedAmount;
            _DbContext.ServiceRequest.Update(sr);
            _DbContext.SaveChanges();
            return "true";
        }

        public IActionResult eightSchedule()
        {
            return View();
        }
    }
}
