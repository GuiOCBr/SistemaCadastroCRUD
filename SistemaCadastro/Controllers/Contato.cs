using Microsoft.AspNetCore.Mvc;

namespace SistemaCadastro.Controllers
{
    public class Contato : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
