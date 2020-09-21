using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebHelpTicket.Models;

namespace WebHelpTicket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ViewResult TicketForm()
        {
            return View();
        }

        public ViewResult Tables()
        {
            return View();
        }
        public ViewResult Charts()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Password()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
