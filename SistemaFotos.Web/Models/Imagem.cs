using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace SistemaFotos.Web.Models
{
    public class Imagem
    {

        public Imagem()
        {
            
        }

        public Imagem(string titulo, string caminhoImagem)
        {
            Titulo = titulo;
            CaminhoImagem = caminhoImagem;
        }

        public int Id { get; private set; }

        public string Titulo { get; set; }

        public string CaminhoImagem { get; set; }
    }

    public class UploadImagem
    {
        public UploadImagem(string titulo, byte[] dadosImagem)
        {
            Titulo = titulo;
            DadosImagem = dadosImagem;
        }

        public UploadImagem()
        {
        }

        public int Id { get; private set; }

        [FromForm(Name="titulo")]
        public string Titulo { get; set; }

        [FromForm(Name="dadosImagem")]
        public byte[] DadosImagem { get; set; }
    }
}