using SistemaFotos.Web.Models;
using System.Threading.Tasks;

namespace SistemaFotos.Web.Repositories
{
    public interface IAlbumRepository
    {
        Task<Imagem> GetIdAsync(int id);
        Task Alterar(Imagem imagem);
    }
}