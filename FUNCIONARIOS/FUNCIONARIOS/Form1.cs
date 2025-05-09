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
            string email = textBox2.Text;

            if (!string.IsNullOrWhiteSpace(senha) && !string.IsNullOrWhiteSpace(usuario))
            {
                int workfactor = 16;

                string salt = BCrypt.Net.BCrypt.GenerateSalt(workfactor);

                string hash = BCrypt.Net.BCrypt.HashPassword(senha, salt);

                Clipboard.SetText(hash);
                try
                {
                    using (MySqlConnection conexao = DBHelper.ObterConexao()) // Usando DBHelper para a conexão
                    {
                        string query = "INSERT INTO logins (login, senha, email) VALUES (@login, @senha, @email)";
                        using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                        {
                            cmd.Parameters.AddWithValue("@login", usuario);
                            cmd.Parameters.AddWithValue("@senha", hash);
                            cmd.Parameters.AddWithValue("@email", email);

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
                MessageBox.Show("Preencha o login, senha e email.", "Campos obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginPage produto = new LoginPage();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
        }
    }
}
