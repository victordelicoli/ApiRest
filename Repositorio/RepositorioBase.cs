using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class RepositorioBase
    {
        internal AcessoDados.Acesso bd;
        public RepositorioBase()
        {
            bd = new AcessoDados.Acesso();
        }
        public int ConvertInt(object coluna)
        {
            if (!DBNull.Value.Equals(coluna))
                return Convert.ToInt32(coluna);

            return 0;
        }
        public string ConvertString(object coluna)
        {
            if (!DBNull.Value.Equals(coluna))
                return Convert.ToString(coluna);

            return "";
        }
        public DateTime ConvertDateTime(object coluna)
        {
            if (!DBNull.Value.Equals(coluna))
                return Convert.ToDateTime(coluna);

            return new DateTime(1900,1,1);
        }
    }
}
