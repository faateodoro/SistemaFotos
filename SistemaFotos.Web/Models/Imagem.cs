using System.IO;

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

        public string Titulo { get; private set; }

        public string CaminhoImagem { get; private set; }
    }
}