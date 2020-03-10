using Microsoft.EntityFrameworkCore;
using SistemaFotos.Web.Dados;
using SistemaFotos.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SistemaFotos.Web.Repositories
{
    public class ImagemRepository : IImagemRepository
    {
        private FotosContext _contexto;
        private DbSet<Imagem> _dbSet;

        public ImagemRepository(FotosContext contexto)
        {
            _contexto = contexto;
            _dbSet = _contexto.Set<Imagem>();
        }

        public async Task SalvarImagemAsync(ImagemUpload imagemUpload)
        {
            var agora = DateTime.Now;
            string caminho = $"img/uploads/{agora.ToString("yyyyMMddHHmmss") + imagemUpload.Arquivo.FileName}";

            using (var fs = new FileStream(Path.Combine("wwwroot/", caminho), FileMode.Create, FileAccess.Write))
            {
                imagemUpload.Arquivo.CopyTo(fs);
            }
            _contexto.Imagens.Add(new Imagem(imagemUpload.Titulo, caminho));
            await _contexto.SaveChangesAsync();
        }

        public async Task AlterarImagemAsync(Imagem imagem)
        {
            var imagemDB = _dbSet.Where(i => i.Id == imagem.Id).SingleOrDefault();
            imagemDB.Titulo = imagem.Titulo;
            _contexto.Update(imagemDB);
            await _contexto.SaveChangesAsync();
        }

        public async Task DeletarImagemAsync(Imagem imagem)
        {
            _contexto.Remove(imagem);
            await _contexto.SaveChangesAsync();
        }

        public async Task<Imagem> GetIdAsync(int id) => await _dbSet.FirstOrDefaultAsync(i => i.Id == id);

    }
}
