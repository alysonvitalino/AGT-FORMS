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

namespace FUNCIONARIOS
{
    public partial class cadastros : Form
    {
        public cadastros()
        {
            InitializeComponent();
            CarregarDados();

        }
        private void cadastros_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
            CarregarComboBox();
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
        private void CarregarDadosFiltrados(string unidade, string municipio, string cnpj)
        {
            string conexaoString = "server=localhost; userid=root; password=''; database=agt";
            string query = "SELECT unidade_cadastro, municipio_cadastro, cnpj_cadastro, sistema_cadastro, site_cadastro, " +
                           "login_cadastro, senha_cadastro, vencimento_cadastro, obervacao_cadastro " +
                           "FROM cadastro WHERE unidade_cadastro = @unidade AND municipio_cadastro = @municipio AND cnpj_cadastro = @cnpj";

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(conexaoString))
                {
                    conexao.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexao))
                    {
                        // Adiciona os parâmetros para evitar SQL Injection
                        adapter.SelectCommand.Parameters.AddWithValue("@unidade", unidade);
                        adapter.SelectCommand.Parameters.AddWithValue("@municipio", municipio);
                        adapter.SelectCommand.Parameters.AddWithValue("@cnpj", cnpj);

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados filtrados: " + ex.Message);
            }
        }
        private void CarregarComboBox()
        {
            string conexaoString = "server=localhost; userid=root; password=''; database=agt";
            string query = "SELECT unidade_cadastro, municipio_cadastro, cnpj_cadastro FROM cadastro";

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(conexaoString))
                {
                    conexao.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();

                        // Limpa a comboBox antes de adicionar os novos itens
                        comboBox1.Items.Clear();

                        while (reader.Read())
                        {
                            // Concatenando os valores de "Unidade", "Municipio" e "CNPJ"
                            string item = reader["unidade_cadastro"].ToString() + " - " + reader["municipio_cadastro"].ToString() + " - " + reader["cnpj_cadastro"].ToString();
                            comboBox1.Items.Add(item);
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
            string conexaoString = "server=localhost; userid=root; password=''; database=agt";
            string query = "SELECT unidade_cadastro, municipio_cadastro, cnpj_cadastro, sistema_cadastro, site_cadastro, " +
                           "login_cadastro, senha_cadastro, vencimento_cadastro, obervacao_cadastro FROM cadastro";

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(conexaoString))
                {
                    conexao.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexao))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }

                dataGridView1.Columns[0].Name = "Unidade";
                dataGridView1.Columns[1].Name = "Municipio";
                dataGridView1.Columns[2].Name = "CNPJ";
                dataGridView1.Columns[3].Name = "Sistema";
                dataGridView1.Columns[4].Name = "Site";
                dataGridView1.Columns[5].Name = "Login";
                dataGridView1.Columns[6].Name = "Senha";
                dataGridView1.Columns[7].Name = "Vencimento";
                dataGridView1.Columns[8].Name = "Observação";

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 produto = new Form1();
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
            logins produto = new logins();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void páginaInicialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 produto = new Form1();
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
            cadastros produto = new cadastros();
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
            logins produto = new logins();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1; //LIMPA A SELEÇÃO DO COMBOBOX1
            CarregarDados();
        }
    }
}
