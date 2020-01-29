using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaFotos.Web.Dados;
using SistemaFotos.Web.Models;

namespace SistemaFotos.Web.Controllers
{
    public class HomeController : Controller
    {
        private FotosContext Contexto;
        private DbSet<Imagem> dbSet;
        private IHostingEnvironment _env;

        public HomeController(FotosContext contexto, IHostingEnvironment env)
        {
            Contexto = contexto;
            dbSet = contexto.Set<Imagem>();
            _env = env;
        }
        public IActionResult Index()
        {
            //IList<Imagem> imagens = new List<Imagem>();
            //var i1 = new Imagem("Orientação a Objetos", "img/oo-csharp.png");
            //var i2 = new Imagem("Bootstrap 4", "img/bootstrap4.png");
            //var i3 = new Imagem("Xamarin", "img/xamarin.png");

            //Contexto.Imagens.Add(i1);
            //Contexto.Imagens.Add(i2);
            //Contexto.Imagens.Add(i3);
            //Contexto.SaveChanges();

            return View(dbSet.ToList());
            //return View();
        }

        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubirImagem(ImagemUpload imagemUpload)
        {
            if (ModelState.IsValid)
            {
                var agora = DateTime.Now;
                string caminho = $"img/uploads/{agora.ToString("yyyyMMddHHmmss")}.png";

                using(var fs = new FileStream(Path.Combine("wwwroot/",caminho), FileMode.Create, FileAccess.Write))
                {
                    imagemUpload.Arquivo.CopyTo(fs);
                }
                Contexto.Imagens.Add(new Imagem(imagemUpload.Titulo, caminho));
                Contexto.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
