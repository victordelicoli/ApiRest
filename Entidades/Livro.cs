using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Livro
    {

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public DateTime DataLancamento { get; set; }
        public Genero Genero { get; set; }
    }
    public enum Genero
    {
        Biografia,
        Horror,
        Ficção,
        Suspense
    }
}
