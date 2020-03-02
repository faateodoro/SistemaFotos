using SistemaFotos.Web.Models;
using System.Threading.Tasks;

namespace SistemaFotos.Web.Repositories
{
    public interface IImagemRepository
    {
        Task<Imagem> GetIdAsync(int id);
        Task Alterar(Imagem imagem);
        Task Deletar(Imagem imagem);
    }
}