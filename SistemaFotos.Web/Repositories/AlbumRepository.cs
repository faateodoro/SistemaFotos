using Microsoft.EntityFrameworkCore;
using SistemaFotos.Web.Dados;
using SistemaFotos.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SistemaFotos.Web.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private FotosContext _contexto;
        private DbSet<Imagem> _dbSet;

        public AlbumRepository(FotosContext contexto)
        {
            _contexto = contexto;
            _dbSet = _contexto.Set<Imagem>();
        }

        public async Task Alterar(Imagem imagem)
        {
            var imagemDB = _dbSet.Where(i => i.Id == imagem.Id).SingleOrDefault();
            imagemDB.Titulo = imagem.Titulo;
            _contexto.Update(imagemDB);
            await _contexto.SaveChangesAsync();
        }

        public async Task Deletar(Imagem imagem)
        {
            _contexto.Remove(imagem);
            await _contexto.SaveChangesAsync();
        }

        public async Task<Imagem> GetIdAsync(int id) => await _dbSet.FirstOrDefaultAsync(i => i.Id == id);

    }
}
