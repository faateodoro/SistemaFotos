using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaFotos.Web.Models
{
    public class Imagem
    {
        public Imagem()
        {
        }

        public Imagem(string titulo, string caminho)
        {
            Titulo = titulo;
            Caminho = caminho;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Caminho { get; set; }
    }

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