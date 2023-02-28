using Microsoft.AspNetCore.Mvc;
using SistemaCadastro.Models;
using System.Diagnostics;

namespace SistemaCadastro.Controllers
{
    public class HomeController : Controller
    {
       // private readonly ILogger<HomeController> _logger;

       // public HomeController(ILogger<HomeController> logger)
        //{
           // _logger = logger;
      //  }

        public IActionResult Index()
        {
            HomeModel home = new HomeModel();
            home.Nome = "Guilherme Oliveira";
            home.Email = "guilherme@gmail.com";

            return View(home);
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