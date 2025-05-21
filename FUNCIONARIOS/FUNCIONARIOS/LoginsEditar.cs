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
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
                return;

            // Extrair o CNPJ do item selecionado
            string itemSelecionado = comboBox1.SelectedItem.ToString();
            string[] partes = itemSelecionado.Split(new string[] { " - " }, StringSplitOptions.None);

            if (partes.Length < 3)
            {
                MessageBox.Show("Formato inválido do item selecionado.");
                return;
            }

            string cnpjSelecionado = partes[2];

            string query = "SELECT * FROM cadastro WHERE cnpj_cadastro = @cnpj";

            try
            {
                using (MySqlConnection conexao = DBHelper.ObterConexao())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                    {
                        cmd.Parameters.AddWithValue("@cnpj", cnpjSelecionado);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox1.Text = reader["unidade_cadastro"].ToString();
                                textBox2.Text = reader["municipio_cadastro"].ToString();
                                textBox3.Text = reader["cnpj_cadastro"].ToString();
                                textBox4.Text = reader["sistema_cadastro"].ToString();
                                textBox5.Text = reader["site_cadastro"].ToString();
                                textBox6.Text = reader["login_cadastro"].ToString();
                                textBox7.Text = reader["senha_cadastro"].ToString();
                                textBox8.Text = reader["vencimento_cadastro"].ToString();
                                textBox9.Text = reader["observacao_cadastro"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Dados não encontrados.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
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
        private void LimparCampos()
        {
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
        private void button2_Click(object sender, EventArgs e)
        {
            // Verificar se um item foi selecionado na ComboBox
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma correspondência para editar.");
                return;
            }

            // Extrair o CNPJ da string selecionada na ComboBox
            string itemSelecionado = comboBox1.SelectedItem.ToString();
            string[] partes = itemSelecionado.Split(new string[] { " - " }, StringSplitOptions.None);
            if (partes.Length < 3)
            {
                MessageBox.Show("Item selecionado inválido.");
                return;
            }
            string cnpjOriginal = partes[2]; // Usado para identificar o registro original

            // Obter os novos valores dos TextBox
            string unidade = textBox1.Text.Trim();
            string municipio = textBox2.Text.Trim();
            string cnpj = textBox3.Text.Trim();
            string sistema = textBox4.Text.Trim();
            string site = textBox5.Text.Trim();
            string login = textBox6.Text.Trim();
            string senha = textBox7.Text.Trim();
            string vencimento = textBox8.Text.Trim();
            string observacao = textBox9.Text.Trim();

            // Atualizar no banco de dados
            string query = @"UPDATE cadastro SET 
                        unidade_cadastro = @unidade, 
                        municipio_cadastro = @municipio, 
                        cnpj_cadastro = @cnpj, 
                        sistema_cadastro = @sistema, 
                        site_cadastro = @site, 
                        login_cadastro = @login, 
                        senha_cadastro = @senha, 
                        vencimento_cadastro = @vencimento, 
                        observacao_cadastro = @observacao 
                    WHERE cnpj_cadastro = @cnpjOriginal";

            try
            {
                using (MySqlConnection conexao = DBHelper.ObterConexao())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                    {
                        cmd.Parameters.AddWithValue("@unidade", unidade);
                        cmd.Parameters.AddWithValue("@municipio", municipio);
                        cmd.Parameters.AddWithValue("@cnpj", cnpj);
                        cmd.Parameters.AddWithValue("@sistema", sistema);
                        cmd.Parameters.AddWithValue("@site", site);
                        cmd.Parameters.AddWithValue("@login", login);
                        cmd.Parameters.AddWithValue("@senha", senha);
                        cmd.Parameters.AddWithValue("@vencimento", vencimento);
                        cmd.Parameters.AddWithValue("@observacao", observacao);
                        cmd.Parameters.AddWithValue("@cnpjOriginal", cnpjOriginal);

                        int linhasAfetadas = cmd.ExecuteNonQuery();
                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Dados atualizados com sucesso!");
                            LimparCampos();
                            comboBox1.SelectedIndex = -1;
                            CarregarComboBox(); // Atualizar ComboBox
                        }
                        else
                        {
                            MessageBox.Show("Nenhum registro foi atualizado. Verifique o CNPJ original.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar dados: " + ex.Message);
            }
        }
    }
}
