using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFotos.Web.Models
{
    public class Album
    {
        public Album(string titulo, string descricao, IFormFile arquivo)
        {
            Titulo = titulo;
            Data = DateTime.Today;
            Descricao = descricao;
            Arquivo = arquivo;
        }

        public Album()
        {
        }

        [Required]
        public int Id { get; private set; }
        [Required]
        public string Titulo { get; private set; }
        [Required]
        public DateTime Data { get; private set; }
        [Required]
        public string Descricao { get; private set; }
        [Required]
        public IFormFile Arquivo { get; private set; }
    }
}
