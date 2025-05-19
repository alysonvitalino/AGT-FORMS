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
    public partial class LoginsAdicionar : Form
    {
        public LoginsAdicionar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logins_Senhas produto = new Logins_Senhas();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conexao = DBHelper.ObterConexao())
                {
                    // Inserir o novo cadastro
                    string insertQuery = "INSERT INTO cadastro (unidade_cadastro, municipio_cadastro, cnpj_cadastro, sistema_cadastro, site_cadastro, login_cadastro, senha_cadastro, vencimento_cadastro, observacao_cadastro) " +
                                         "VALUES (@unidade, @municipio, @cnpj, @sistema, @site, @login, @senha, @vencimento, @observacao)";

                    using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conexao))
                    {
                        insertCmd.Parameters.AddWithValue("@unidade", Convert.ToInt32(textBox1.Text));
                        insertCmd.Parameters.AddWithValue("@municipio", textBox2.Text);
                        insertCmd.Parameters.AddWithValue("@cnpj", textBox3.Text);
                        insertCmd.Parameters.AddWithValue("@sistema", textBox4.Text);
                        insertCmd.Parameters.AddWithValue("@site", textBox5.Text);
                        insertCmd.Parameters.AddWithValue("@login", textBox6.Text);
                        insertCmd.Parameters.AddWithValue("@senha", textBox7.Text);
                        insertCmd.Parameters.AddWithValue("@vencimento", Convert.ToInt32(textBox8.Text)); // vencimento
                        insertCmd.Parameters.AddWithValue("@observacao", textBox9.Text); // observação

                        int linhasAfetadas = insertCmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Cadastro realizado com sucesso!");
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();
                            textBox5.Clear();
                            textBox6.Clear();
                            textBox7.Clear();
                            textBox8.Clear();
                            textBox9.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Falha ao realizar o cadastro.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao realizar o cadastro: " + ex.Message);
            }
        }
    }
}
