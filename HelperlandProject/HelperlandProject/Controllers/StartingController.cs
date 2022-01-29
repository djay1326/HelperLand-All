using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelperlandProject.Models;
using HelperlandProject.Data;
using Microsoft.EntityFrameworkCore;

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
    }
}
