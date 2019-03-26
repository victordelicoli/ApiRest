using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class AcessoDados
    {
        public class Parametro
        {
            public string Nome { get; set; }
            public object Valor { get; set; }

            public Parametro(string nome, object valor)
            {
                this.Nome = nome;
                this.Valor = valor;
            }
        }
        public class Acesso
        {
            private string _stringDeConexao;


            public Acesso()
            {
                this._stringDeConexao = GetStringDeConexao();
            }

            private string GetStringDeConexao()
            {
                string usuario = "sa";
                string senha = "SenhaPadrao";
                string servidor = @".\SQLEXPRESS";
                string banco = "BaseLivros";
                string strConexao = "";
                strConexao = string.Format("Server={0};Database={1};User ID={2};Password={3};", servidor, banco, usuario, senha);
                return strConexao;
            }

            public DataTable ExecuteDataTable(string strSQL, int commandTimeout, params Parametro[] parametros)
            {
                var dt = new DataTable();
                using (var conexao = new SqlConnection(_stringDeConexao))
                {
                    conexao.Open();
                    using (var cmd = conexao.CreateCommand())
                    {
                        cmd.CommandText = strSQL;
                        cmd.CommandTimeout = commandTimeout;

                        foreach (var parametro in parametros)
                        {
                            var param = cmd.Parameters.AddWithValue(parametro.Nome, parametro.Valor);
                            param.IsNullable = true;

                            if (parametro.Valor == null)
                            {
                                param.Value = DBNull.Value;
                            }

                            if (parametro.Valor is DateTime)
                            {
                                if ((DateTime)parametro.Valor < new DateTime(1900, 1, 1))
                                {
                                    param.Value = DBNull.Value;
                                }
                            }
                        }

                        using (var dr = cmd.ExecuteReader())
                        {
                            dt.Load(dr);
                            dr.Close();
                        }
                    }
                    conexao.Close();
                }
                return dt;
            }
        }
    }
}
