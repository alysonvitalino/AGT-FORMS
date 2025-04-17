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

        private string nomeUsuario;
        public LoginPage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BoxLogin.Text != "" && BoxSenha.Text != "")
            {
                string data_source = "server=localhost;userid=root;password=;database=agt";
                conexao = new MySqlConnection(data_source);

                try
                {
                    conexao.Open();

                    // Busca apenas o hash da senha pelo login
                    string loginQuery = "SELECT senha FROM logins WHERE login = @login";
                    MySqlCommand comando = new MySqlCommand(loginQuery, conexao);
                    comando.Parameters.AddWithValue("@login", BoxLogin.Text);

                    MySqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        string hashArmazenado = reader.GetString("senha");
                        string senhaDigitada = BoxSenha.Text;

                        // Verifica se a senha digitada bate com o hash
                        bool senhaValida = BCrypt.Net.BCrypt.Verify(senhaDigitada, hashArmazenado);

                        if (senhaValida)
                        {
                            string usuario = BoxLogin.Text;
                            MessageBox.Show($"{usuario}, login realizado com sucesso!");

                            BoxSenha.Clear();

                            HomePage produto = new HomePage(usuario);
                            produto.StartPosition = FormStartPosition.CenterScreen;
                            produto.Show();

                            Hide();
                        }
                        else
                        {
                            MessageBox.Show("Senha incorreta.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuário não encontrado.");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
                finally
                {
                    if (conexao.State == ConnectionState.Open)
                        conexao.Close();
                }
            }
            else
            {
                MessageBox.Show("Por favor, preencha os campos de login e senha.");
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

