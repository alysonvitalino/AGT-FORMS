using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;

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
                        string loginQuery = "SELECT login, senha, nivelAcesso FROM logins WHERE login = @login";

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
                                Sessao.Usuario = BoxLogin.Text;
                                Sessao.NivelAcesso = reader["nivelAcesso"].ToString();

                                MessageBox.Show($"{Sessao.Usuario}, login realizado com sucesso!");
                                BoxSenha.Clear();

                                HomePage produto = new HomePage();
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

        public void EnviarEmail(string destinatario, string assunto, string corpo)
        {
            try
            {
                MailMessage mensagem = new MailMessage();
                mensagem.From = new MailAddress("aplicativogestaotributaria@gmail.com"); // seu e-mail
                mensagem.To.Add(destinatario);
                mensagem.Subject = assunto;
                mensagem.Body = corpo;
                mensagem.IsBodyHtml = false; // true se quiser enviar como HTML

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("aplicativogestaotributaria@gmail.com", "yhhw zcqh iuyz llsv");
                smtp.EnableSsl = true;

                smtp.Send(mensagem);

                MessageBox.Show("E-mail enviado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao enviar e-mail: " + ex.Message);
            }
        }

        public static string GerarSenhaTemporaria(int tamanho = 10)
        {
            const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%&*";
            StringBuilder senha = new StringBuilder();
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] bytesAleatorios = new byte[1];

                while (senha.Length < tamanho)
                {
                    rng.GetBytes(bytesAleatorios);
                    char caractere = (char)bytesAleatorios[0];
                    if (caracteresPermitidos.Contains(caractere))
                    {
                        senha.Append(caractere);
                    }
                }
            }

            return senha.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(BoxLogin.Text))
                    {
                        using (MySqlConnection conexao = DBHelper.ObterConexao())
                        {
                            string query = "SELECT email FROM logins WHERE login = @login";
                            MySqlCommand comando = new MySqlCommand(query, conexao);
                            comando.Parameters.AddWithValue("@login", BoxLogin.Text);
                            MySqlDataReader reader = comando.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                string email = reader["email"].ToString();
                                reader.Close();

                                // Gerar senha temporária e atualizar no banco
                                string senhaTemp = GerarSenhaTemporaria();
                                string hash = BCrypt.Net.BCrypt.HashPassword(senhaTemp);

                                string update = "UPDATE logins SET senha = @senha WHERE login = @login";
                                MySqlCommand updateCmd = new MySqlCommand(update, conexao);
                                updateCmd.Parameters.AddWithValue("@senha", hash);
                                updateCmd.Parameters.AddWithValue("@login", BoxLogin.Text);
                                updateCmd.ExecuteNonQuery();

                                // Enviar por email
                                EnviarEmail(email, "Recuperação de Senha",
                                    $"Sua nova senha temporária é: {senhaTemp}.");

                                MessageBox.Show($"A nova senha foi enviada para o e-mail: {email}");
                            }
                            else
                            {
                                MessageBox.Show("Login não encontrado.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Informe o login para recuperação.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }

        }
    }

