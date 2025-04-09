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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AGT_FORMS
{
    public partial class LoginPage : Form
    {
        MySqlConnection conexao;
        public LoginPage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (BoxLogin.Text != "" && BoxSenha.Text != "")
                {
                    string data_source = "datasource=localhost; username=root;password='';database=agt";
                    conexao = new MySqlConnection(data_source);

                    string loginQuery = "SELECT login, senha FROM logins WHERE login = @login AND senha = @senha";

                    MySqlCommand comando = new MySqlCommand(loginQuery, conexao);
                    comando.Parameters.AddWithValue("@login", BoxLogin.Text);
                    comando.Parameters.AddWithValue("@senha", BoxSenha.Text);

                    conexao.Open();

                    MySqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        MessageBox.Show("Login realizado com sucesso!");

                        BoxSenha.Clear();

                        HomePage produto = new HomePage();
                        produto.StartPosition = FormStartPosition.CenterScreen;
                        produto.Show();

                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Dados de login incorretos.");
                    }

                    reader.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, preencha os campos de login e senha.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void BoxLogin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

