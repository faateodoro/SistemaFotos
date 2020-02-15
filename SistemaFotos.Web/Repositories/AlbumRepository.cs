using Microsoft.EntityFrameworkCore;
using SistemaFotos.Web.Dados;
using SistemaFotos.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFotos.Web.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly FotosContext _contexto;
        private readonly DbSet<Imagem> _dbSet;

        public AlbumRepository(FotosContext contexto)
        {
            _contexto = contexto;
            _dbSet = _contexto.Set<Imagem>();
        }

        public Imagem GetId(int id) => _dbSet.FirstOrDefault(i => i.Id == id);

    }
}
