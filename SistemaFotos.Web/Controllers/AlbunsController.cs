﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaFotos.Web.Dados;
using SistemaFotos.Web.Models;
using SistemaFotos.Web.Repositories;

namespace SistemaFotos.Web.Controllers
{
    public class AlbunsController : Controller
    {
        private FotosContext Contexto;
        private DbSet<Imagem> dbSet;
        private IHostingEnvironment _env;
        private readonly IAlbumRepository _albumRepository;

        public AlbunsController(FotosContext contexto, IHostingEnvironment env,
            IAlbumRepository albumRepository)
        {
            Contexto = contexto;
            dbSet = contexto.Set<Imagem>();
            _env = env;
            _albumRepository = albumRepository;
        }

        public IActionResult Novo()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View(dbSet.ToList());
        }

        [HttpPost]
        public IActionResult SubirImagem(ImagemUpload imagemUpload)
        {
            if (ModelState.IsValid)
            {
                var agora = DateTime.Now;
                string caminho = $"img/uploads/{agora.ToString("yyyyMMddHHmmss") + imagemUpload.Arquivo.FileName}";

                using (var fs = new FileStream(Path.Combine("wwwroot/", caminho), FileMode.Create, FileAccess.Write))
                {
                    imagemUpload.Arquivo.CopyTo(fs);
                }
                Contexto.Imagens.Add(new Imagem(imagemUpload.Titulo, caminho));
                Contexto.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult TodasImagens()
        {
            var imagens = dbSet.ToList();

            return View(imagens);
        }

        [Route ("albuns/exibirdetalhes/{id:int}")]
        public IActionResult ExibirDetalhes(int id)
        {
            var imagem =_albumRepository.GetId(id);
            return View(imagem);
        }
    }
}