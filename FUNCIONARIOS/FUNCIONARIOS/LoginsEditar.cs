using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGT_FORMS
{
    public partial class LoginsEditar : Form
    {
        public LoginsEditar()
        {
            InitializeComponent();
        }
        private void CarregarComboBox()
        {
            string query = "SELECT unidade_cadastro, municipio_cadastro, cnpj_cadastro FROM cadastro ORDER BY unidade_cadastro ASC";

            try
            {
                using (MySqlConnection conexao = DBHelper.ObterConexao())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            comboBox1.Items.Clear();
                            while (reader.Read())
                            {
                                string item = reader["unidade_cadastro"].ToString() + " - " + reader["municipio_cadastro"].ToString() + " - " + reader["cnpj_cadastro"].ToString();
                                comboBox1.Items.Add(item);
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
        private void button1_Click(object sender, EventArgs e)
        {
            Logins_Senhas produto = new Logins_Senhas();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void LoginsEditar_Load(object sender, EventArgs e)
        {
            CarregarComboBox();
        }
    }
}
