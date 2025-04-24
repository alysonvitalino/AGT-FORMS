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
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(BoxLogin.Text) && !string.IsNullOrWhiteSpace(BoxSenha.Text))
                {
                    // Usar DBHelper para obter a conexão
                    using (MySqlConnection conexao = DBHelper.ObterConexao())
                    {
                        string loginQuery = "SELECT login, senha FROM logins WHERE login = @login";

                        MySqlCommand comando = new MySqlCommand(loginQuery, conexao);
                        comando.Parameters.AddWithValue("@login", BoxLogin.Text);

                        MySqlDataReader reader = comando.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            string senhaHash = reader["senha"].ToString();

                            // Verificar se a senha informada corresponde ao hash no banco
                            if (BCrypt.Net.BCrypt.Verify(BoxSenha.Text, senhaHash))
                            {
                                string usuario = BoxLogin.Text;

                                MessageBox.Show($"{usuario}, login realizado com sucesso!");

                                BoxSenha.Clear();

                                // Passar o nome de usuário para a HomePage
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
                            MessageBox.Show("Dados de login incorretos.");
                        }

                        reader.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, preencha os campos de login e senha.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomePage produto = new HomePage();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }
    }
}

