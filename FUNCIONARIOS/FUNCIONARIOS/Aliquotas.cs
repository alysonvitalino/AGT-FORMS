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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace AGT_FORMS
{
    public partial class Aliquotas : Form
    {
        public Aliquotas()
        {
            InitializeComponent();
            CarregarDados();
          //  CarregarComboBox();
            dataGridView1.Columns[0].HeaderText = "Munícipio";
            dataGridView1.Columns[1].HeaderText = "Código do Serviço";
            dataGridView1.Columns[2].HeaderText = "Descrição do Serviço";
            dataGridView1.Columns[3].HeaderText = "ISS";
        }

        private void Aliquotas_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
            CarregarComboBox();
        }
        private void CarregarDados()
        {
            string conexaoString = "server=localhost; userid=root; password=''; database=agt";
            string query = "SELECT municipio, cod_servico, desc_servico, aliquota_iss FROM aliquotas";

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
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
        }
        private void CarregarComboBox()
        {
            string conexaoString = "server=localhost; userid=root; password=''; database=agt";
            string query = "SELECT DISTINCT (municipio) FROM aliquotas";

           // MessageBox.Show(query);
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
                            string item = reader["municipio"].ToString();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                string selectedItem = comboBox1.SelectedItem.ToString();
                CarregarDadosFiltrados(selectedItem);
            }
        }
        private void CarregarDadosFiltrados(string municipio)
        {
            string conexaoString = "server=localhost; userid=root; password=''; database=agt";
            string query = "SELECT municipio, cod_servico, desc_servico, aliquota_iss FROM aliquotas WHERE municipio = @municipio";

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(conexaoString))
                {
                    conexao.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexao))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@municipio", municipio);

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

        private void button2_Click(object sender, EventArgs e)
        {
            HomePage produto = new HomePage();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cadastros produto = new Cadastros();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            calculadora produto = new calculadora();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Logins_Senhas produto = new Logins_Senhas();
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

        private void paginaInicialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomePage produto = new HomePage();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }
    }
}
