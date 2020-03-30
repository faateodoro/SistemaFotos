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
using FileIO = System.IO.File;

namespace SistemaFotos.Web.Controllers
{
    public class AlbunsController : Controller
    {
        private FotosContext Contexto;
        private DbSet<Imagem> dbSet;
        private IImagemRepository _imagemRepository;

        public AlbunsController(FotosContext contexto,
            IImagemRepository imagemRepository)
        {
            Contexto = contexto;
            dbSet = contexto.Set<Imagem>();
            _imagemRepository = imagemRepository;
        }

        public IActionResult Novo()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            return View(await dbSet.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> SubirImagem(ImagemUpload imagemUpload)
        {
            if (ModelState.IsValid)
            {
                await _imagemRepository.SalvarImagemAsync(imagemUpload);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> TodasImagens()
        {
            var imagens = await dbSet.ToListAsync();
            return View(imagens);
        }

        [Route("albuns/detalhes/{id:int}")]
        public async Task<IActionResult> DetalhesImagem(int id)
        {
            var imagem = await _imagemRepository.GetIdAsync(id);
            return View(imagem);
        }

        
        [Route("albuns/alterar/{id:int}")]
        public async Task<IActionResult> AlterarDetalhesImagem(int id)
        {
            var imagem = await _imagemRepository.GetIdAsync(id);
            return View(imagem);
        }

        [HttpPost]
        public async Task<IActionResult> AlterarDetalhes(Imagem imagem)
        {
            await _imagemRepository.AlterarImagemAsync(imagem);
            return RedirectToAction("TodasImagens");
        }

        public async Task<IActionResult> DeletarImagem(int id)
        {
            if (ModelState.IsValid)
            {
                await _imagemRepository.DeletarImagemAsync(id);
            }
            return RedirectToAction("TodasImagens");
        }

        public IActionResult MinhasGalerias()
        {
            return View();
        }
    }
}