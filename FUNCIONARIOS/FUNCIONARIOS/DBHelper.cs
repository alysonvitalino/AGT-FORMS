using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AGT_FORMS
{
    public static class DBHelper
    {
        private static readonly string conexaoString = "server=localhost;userid=root;password=;database=agt";

        public static MySqlConnection ObterConexao()
        {
            MySqlConnection conexao = new MySqlConnection(conexaoString);
            conexao.Open();
            return conexao;
        }
    }
}
