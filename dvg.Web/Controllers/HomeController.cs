using dvg.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Serilog;

namespace dvg.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly Serilog.ILogger _logger;

        public HomeController(Serilog.ILogger logger)
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