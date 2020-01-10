using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public HomeController(FotosContext contexto)
        {
            Contexto = contexto;
            dbSet = contexto.Set<Imagem>();
        }
        public IActionResult Index()
        {
            // IList<Imagem> imagens = new List<Imagem>();
            // var i1 = new Imagem("Orientação a Objetos", "img/oo-csharp.png");
            // var i2 = new Imagem("Bootstrap 4", "img/bootstrap4.png");
            // var i3 = new Imagem("Xamarin", "img/xamarin.png");

            // Contexto.Imagens.Add(i1);
            // Contexto.Imagens.Add(i2);
            // Contexto.Imagens.Add(i3);
            // Contexto.SaveChanges();

            return View(dbSet.ToList());
        }

        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubirImagem([FromForm]UploadImagem uploadImagem)
        {
            if(ModelState.IsValid)
            {
                var imagem = new Imagem();

                imagem.Titulo = uploadImagem.Titulo;

                var hoje = DateTime.Today;
                string caminho = "wwwroot/img/" + hoje.ToString("yyyymmdd") + ".png";

                using (MemoryStream ms = new MemoryStream())
                using (var arquivo = new FileStream(caminho, FileMode.Create))
                {
                    byte[] bytes = ms.ToArray();

                    arquivo.Write(bytes, 0, bytes.Length);
                }
            }
            // if (imagem != null)
            // {
            //     Contexto.Imagens.Add(imagem);
            //     Contexto.SaveChanges();
            // }
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
