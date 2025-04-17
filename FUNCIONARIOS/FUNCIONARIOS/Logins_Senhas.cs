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
    public partial class Logins_Senhas : Form
    {
        private bool colunasCriadas = false; // Variável de controle para as colunas

        private string nomeUsuario;
        public Logins_Senhas()
        {
            InitializeComponent();
            CarregarDados();
            dataGridView1.Columns[0].HeaderText = "Código_da_Unidade";
            dataGridView1.Columns[1].HeaderText = "Municipio";
            dataGridView1.Columns[2].HeaderText = "CNPJ";
            dataGridView1.Columns[3].HeaderText = "Sistema";
            dataGridView1.Columns[4].HeaderText = "Login";
            dataGridView1.Columns[5].HeaderText = "Senha";
            dataGridView1.Columns[6].HeaderText = "Dia_Do_Vencimento";
            dataGridView1.Columns[7].HeaderText = "Observação";
            dataGridView1.Columns[8].HeaderText = "Site";
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;
            dataGridView1.Columns[6].ReadOnly = true;
            dataGridView1.Columns[7].ReadOnly = true;
            dataGridView1.Columns[8].ReadOnly = true;

        }
        private void cadastros_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
            CarregarComboBox();
        }
        
        private void CarregarDadosFiltrados(string unidade, string municipio, string cnpj)
        {
            string query = "SELECT unidade_cadastro, municipio_cadastro, cnpj_cadastro, sistema_cadastro, site_cadastro, " +
                           "login_cadastro, senha_cadastro, vencimento_cadastro, observacao_cadastro " +
                           "FROM cadastro WHERE unidade_cadastro = @unidade AND municipio_cadastro = @municipio AND cnpj_cadastro = @cnpj";

            try
            {
                using (MySqlConnection conexao =DBHelper.ObterConexao())
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexao))
                    {
                        // Adiciona os parâmetros para evitar SQL Injection
                        adapter.SelectCommand.Parameters.AddWithValue("@unidade", unidade);
                        adapter.SelectCommand.Parameters.AddWithValue("@municipio", municipio);
                        adapter.SelectCommand.Parameters.AddWithValue("@cnpj", cnpj);

                        using (DataTable dt = new DataTable())
                        {
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados filtrados: " + ex.Message);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica se há um item selecionado
            if (comboBox1.SelectedIndex != -1)
            {
                string selectedItem = comboBox1.SelectedItem.ToString();

                // Quebra a string selecionada para pegar os valores individuais de Unidade, Municipio e CNPJ
                string[] partes = selectedItem.Split(new string[] { " - " }, StringSplitOptions.None);
                string unidadeSelecionada = partes[0];
                string municipioSelecionado = partes[1];
                string cnpjSelecionado = partes[2];

                // Filtra os dados com base na seleção
                CarregarDadosFiltrados(unidadeSelecionada, municipioSelecionado, cnpjSelecionado);
            }
        }
        private void CarregarComboBox()
        {
            string query = "SELECT unidade_cadastro, municipio_cadastro, cnpj_cadastro FROM cadastro";

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
        private void CarregarDados()
        {
            string query = "SELECT unidade_cadastro, municipio_cadastro, cnpj_cadastro, sistema_cadastro, site_cadastro, " +
                           "login_cadastro, senha_cadastro, vencimento_cadastro, observacao_cadastro FROM cadastro";

            try
            {
                using (MySqlConnection conexao =DBHelper.ObterConexao())
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexao))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;

                            if (!colunasCriadas)
                            {
                                // Remover a coluna 'site_cadastro' original se existir
                                if (dataGridView1.Columns.Contains("site_cadastro"))
                                {
                                    dataGridView1.Columns.Remove("site_cadastro");
                                }

                                DataGridViewLinkColumn linkColumn = new DataGridViewLinkColumn();
                                linkColumn.Name = "site_cadastro";  // Nome da coluna de link
                                linkColumn.HeaderText = "Site";     // Título da coluna
                                linkColumn.DataPropertyName = "site_cadastro";  // Dados da célula
                                dataGridView1.Columns.Add(linkColumn);

                                colunasCriadas = true;
                            }
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar se clicou na coluna 'site_cadastro' (a coluna de links)
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "site_cadastro")
                {
                    string url = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    // Verifica se o URL é válido (começa com http:// ou https://)
                    if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
                    {
                        try
                        {
                            // Usar Process.Start para abrir o link no navegador padrão
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = url,
                                UseShellExecute = true // Garante que o navegador padrão seja utilizado
                            });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao tentar abrir o site: " + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("URL inválido: " + url);
                    }
                }
            }
        }   
        private void button1_Click(object sender, EventArgs e)
        {
            HomePage produto = new HomePage();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            calculadora produto = new calculadora();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Aliquotas produto = new Aliquotas();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Cadastros produto = new Cadastros();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }
        private void páginaInicialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomePage produto = new HomePage();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }
        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calculadora produto = new calculadora();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }
        private void cadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastros produto = new Cadastros();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }
        private void leisEAlíquotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Aliquotas produto = new Aliquotas();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }
        private void loginsESenhasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logins_Senhas produto = new Logins_Senhas();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1; 
            CarregarDados();  
        }
    }
}
