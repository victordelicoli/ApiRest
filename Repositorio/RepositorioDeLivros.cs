using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Repositorio.AcessoDados;

namespace Repositorio
{
    public class RepositorioDeLivros : RepositorioBase
    {
        public void Inserir(Livro livro)
        {
            using (var dt = bd.ExecuteDataTable("insert into livros (Titulo, Autor, Genero, DataLancamento) values (@Titulo, @Autor, @Genero, @DataLancamento)", 600, new Parametro("@Titulo", livro.Titulo), new Parametro("@Autor", livro.Autor), new Parametro("@Genero", livro.Genero),
                new Parametro("@DataLancamento", livro.DataLancamento))) { }
        }
        public void Deletar(int id)
        {
            using (var dt = bd.ExecuteDataTable("delete from livros where id = @id", 600, new Parametro("@id", id))) { }
        }

        public List<Livro> ConsultarTodos()
        {
            var lista = new List<Livro>();
            using (var dt = bd.ExecuteDataTable("select * from livros", 600))
            {
                if(dt.Rows.Count > 0)
                {
                    foreach (DataRow registro in dt.Rows)
                    {
                        lista.Add(Converter(registro));
                    }
                }
            }
            return lista;
        }

        private Livro Converter(DataRow registro)
        {
            return new Livro()
            {
                Autor = ConvertString(registro["Autor"]),
                DataLancamento = ConvertDateTime(registro["DataLancamento"]),
                Genero = ConverterGenero(ConvertInt(registro["Genero"])),
                Id = ConvertInt(registro["Id"]),
                Titulo = ConvertString(registro["Titulo"])
            };
        }

        private Genero ConverterGenero(int id)
        {
            switch (id)
            {
                case 1:
                    return Genero.Biografia;
                case 2:
                    return Genero.Ficção;
                case 3:
                    return Genero.Horror;
                case 4:
                    return Genero.Suspense;
                default:
                    return Genero.Biografia;
            }
        }

        public void LimparTabelaTemporaria()
        {
            throw new NotImplementedException();
        }
    }
}
