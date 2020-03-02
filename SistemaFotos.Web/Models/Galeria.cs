using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFotos.Web.Models
{
    public class Galeria
    {
        public Galeria(string tituloDaGaleria, string descricao, IList<Imagem> arquivo)
        {
            TituloDaGaleria = tituloDaGaleria;
            Data = DateTime.Today;
            Descricao = descricao;
            Arquivo = arquivo;
        }

        public Galeria()
        {
        }

        [Required]
        public int Id { get; private set; }
        [Required]
        public string TituloDaGaleria { get; private set; }
        [Required]
        public DateTime Data { get; private set; }
        [Required]
        public string Descricao { get; private set; }
        [Required]
        public IList<Imagem> Arquivo { get; private set; }
    }
}
