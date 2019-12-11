using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFotos.Web.Models
{
    public class Album
    {
        public Album(string titulo, DateTime data, string descricao, string caminho)
        {
            Titulo = titulo;
            Data = data;
            Descricao = descricao;
            Caminho = caminho;
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
        public string Caminho { get; private set; }
    }
}
