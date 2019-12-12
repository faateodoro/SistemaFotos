using Microsoft.AspNetCore.Mvc;
using SistemaFotos.Web.Models;

namespace SistemaFotos.Web.Controllers
{
    public class GaleriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Novo(Album album)
        {
            if(album.Equals(null))
            {
            }
            return View();
        }
    }
}