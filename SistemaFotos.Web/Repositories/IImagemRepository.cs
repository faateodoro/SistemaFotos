using SistemaFotos.Web.Models;
using System.Threading.Tasks;

namespace SistemaFotos.Web.Repositories
{
    public interface IImagemRepository
    {
        Task<Imagem> GetIdAsync(int id);
        Task AlterarImagemAsync(Imagem imagem);
        Task DeletarImagemAsync(int id);
        Task SalvarImagemAsync(ImagemUpload imagemUpload);
    }
}