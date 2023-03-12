using System;
using System.IO;
using System.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using BidOneProjectV1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace BidOneProjectV1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       
        public IActionResult Index()
        {
            return View("ProcessForm");
        }

        [HttpPost]
        public IActionResult ProcessForm(IFormCollection form)
        {
            
            var firstName = form["firstName"][0];
            var lastName = form["lastName"][0];

            _logger.LogInformation("Log message in the ProcessForm() method");

            var jsonObject = new { FirstName = firstName, LastName = lastName };
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject);
  
            //string filePath = Path.Combine(HttpRuntime.AppDomainAppPath, "submittedData.json");
            System.IO.File.WriteAllText(@".\path.json", jsonString);
            return View("ProcessForm");

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