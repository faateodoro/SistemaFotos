using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
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

        public Imagem(string titulo, string caminho, Galeria galeria) : this(titulo, caminho)
        {
            Galeria = galeria;
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Caminho { get; set; }
        //[Required]
        public Galeria Galeria { get; private set; }
    }
}