using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using com_02web.Models;
using Microsoft.AspNetCore.Http;

namespace com_02web.Controllers
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
      return View();
    }

    [HttpPost]
    public string Index([FromForm] FormulaireViewModel formulaire)
    {
      return $"Bien reçu la photo {formulaire.Titre} et le fichier {formulaire.Photo.Name} de {formulaire.Photo.Length} octets";
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
