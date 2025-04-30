using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AGT_FORMS
{
    public partial class CadastrosNova : Form
    {
        public CadastrosNova()
        {
            InitializeComponent();
        }

        private void CarregarComboBox()
        {
            string query = "SELECT cod_erp FROM unidades";

            try
            {
                using (MySqlConnection conexao = DBHelper.ObterConexao())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            comboBox2.Items.Clear();
                            while (reader.Read())
                            {
                                string item = reader["cod_erp"].ToString();
                                comboBox2.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar ComboBox: " + ex.Message);
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
