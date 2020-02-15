using SistemaFotos.Web.Models;

namespace SistemaFotos.Web.Repositories
{
    public interface IAlbumRepository
    {
        Imagem GetId(int id);
    }
}