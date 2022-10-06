using System;

namespace Prova.Models
{
    public class Jogo
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Desenvolvedor { get; set; }
        public float Preco { get; set; }
        public int CategoriadeJogoId { get; set; }
        public CategoriadeJogo CategoriadeJogo { get; set; }
    }

}