using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Logging;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Crypto.Generators;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AGT_FORMS
{
    public partial class Form1 : Form
    {
        MySqlConnection conexao;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string senha = textBox3.Text;
            string usuario = textBox1.Text;

            if (!string.IsNullOrWhiteSpace(senha) && !string.IsNullOrWhiteSpace(usuario))
            {
<<<<<<< HEAD
                int workfactor = 16;

                string salt = BCrypt.Net.BCrypt.GenerateSalt(workfactor);

                string hash = BCrypt.Net.BCrypt.HashPassword(senha, salt);
=======
>>>>>>> 808c5cf4c0306b0865b4fc22cf7a07ffe1db86ba

                int workfactor = 16;

                string salt = BCrypt.Net.BCrypt.GenerateSalt(workfactor);

                string hash = BCrypt.Net.BCrypt.HashPassword(senha, salt);

                Clipboard.SetText(hash);
                textBox2.Text = hash;

<<<<<<< HEAD
=======
                string conexaoString = "server=localhost;userid=root;password=;database=agt";

>>>>>>> 808c5cf4c0306b0865b4fc22cf7a07ffe1db86ba
                try
                {
                    using (MySqlConnection conexao = DBHelper.ObterConexao()) // Usando DBHelper para a conexão
                    {
                        string query = "INSERT INTO logins (login, senha) VALUES (@login, @senha)";
                        using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                        {
                            cmd.Parameters.AddWithValue("@login", usuario);
                            cmd.Parameters.AddWithValue("@senha", hash);

                            int resultado = cmd.ExecuteNonQuery();

                            if (resultado > 0)
                            {
                                MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Falha ao cadastrar usuário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, "Erro ao inserir no banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Preencha o login e a senha.", "Campos obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            LoginPage produto = new LoginPage();
=======
            HomePage produto = new HomePage();
>>>>>>> 808c5cf4c0306b0865b4fc22cf7a07ffe1db86ba
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }
    }
}
