using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Encryption.Models;
using Zoeller;
using Microsoft.AspNetCore.Authorization;

namespace Encryption.Controllers
{
    //[Authorize(Roles = "Developers")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public string Encrypt(string phrase)
        {
            string returnValue = null;
            try
            {
                returnValue = Encryptor.Encrypt(phrase);
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }

            return returnValue;
        }

        [HttpGet]
        public string decrypt(string phrase)
        {
            string returnValue = null;
            try
            {
                returnValue = Encryptor.Decrypt(phrase);
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }

            return returnValue;
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
