using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRest.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
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