using Microsoft.AspNetCore.Http;

namespace SistemaFotos.Web.Models
{
    public class ImagemUpload
    {

        public ImagemUpload()
        {
        }

        public ImagemUpload(string titulo, IFormFile arquivo)
        {
            Titulo = titulo;
            Arquivo = arquivo;
        }

        public string Titulo { get; set; }

        public IFormFile Arquivo { get; set; }
    }
}