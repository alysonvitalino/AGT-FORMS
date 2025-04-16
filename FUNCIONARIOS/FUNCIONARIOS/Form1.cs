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
                // Gerar hash com Bcrypt
                string hash = BCrypt.Net.BCrypt.HashPassword(senha);

                // Mostrar o hash
                MessageBox.Show("Hash gerado:\n\n" + hash, "Senha Hash", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clipboard.SetText(hash);
                textBox2.Text = hash;

                // String de conexão
                string conexaoString = "server=localhost;userid=root;password=;database=agt";

                try
                {
                    using (conexao = new MySqlConnection(conexaoString))
                    {
                        conexao.Open();

                        string query = "INSERT INTO logins (login, senha) VALUES (@login, @senha)";
                        MySqlCommand cmd = new MySqlCommand(query, conexao);

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

                        conexao.Close();
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
    }
}
