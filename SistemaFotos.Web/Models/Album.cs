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
        public Album(string tituloDoAlbum, string descricao, IList<Imagem> arquivo)
        {
            TituloDoAlbum = tituloDoAlbum;
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
        public string TituloDoAlbum { get; private set; }
        [Required]
        public DateTime Data { get; private set; }
        [Required]
        public string Descricao { get; private set; }
        [Required]
        public IList<Imagem> Arquivo { get; private set; }
    }
}
