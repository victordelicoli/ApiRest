using Entidades;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos
{
    public class GerenciadorDeLivros
    {
        RepositorioDeLivros repositorioDeLivros;
        public GerenciadorDeLivros()
        {
            repositorioDeLivros = new RepositorioDeLivros();
        }
        public bool Inserir(Livro livro)
        {
            if(ValidarDados(livro))
            {
                repositorioDeLivros.Inserir(livro);
                return true;
            }
            return false;
        }

        public List<Livro> Consultar()
        {
            return repositorioDeLivros.ConsultarTodos();
        }
        public void Deletar(int id)
        {
            if(id > 0) repositorioDeLivros.Deletar(id);
        }

        private bool ValidarDados(Livro livro)
        {
            if (livro == null) return false;
            else if (string.IsNullOrEmpty(livro.Titulo)) return false;
            else if (string.IsNullOrEmpty(livro.Autor)) return false;

            return true;
        }
    }
}
