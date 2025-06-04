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
        private string nomeUsuario;

        public Aliquotas()
        {
            InitializeComponent();
            CarregarDados();
            // As linhas abaixo foram mantidas, mas o ideal é que as colunas do DataGridView
            // sejam configuradas após a atribuição do DataSource para garantir que elas existam.
            // Se as colunas já forem definidas no designer, isso pode ser redundante ou causar erros
            // se o número ou ordem das colunas da consulta mudar.
            dataGridView1.Columns[0].HeaderText = "Município";
            dataGridView1.Columns[1].HeaderText = "Código do Serviço";
            dataGridView1.Columns[2].HeaderText = "Descrição do Serviço";
            dataGridView1.Columns[3].HeaderText = "ISS";
            dataGridView1.Columns[4].HeaderText = "Lei Vigente";
        }

        private void Aliquotas_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
            CarregarComboBox();
        }

        private void CarregarDados()
        {
            // A consulta agora faz um JOIN com a tabela 'municipios' para obter o nome do município
            // em vez do id_municipio da tabela 'aliquotas'.
            string query = @"
                SELECT 
                    m.nome AS municipio, 
                    a.cod_servico, 
                    a.desc_servico, 
                    a.aliquota_iss, 
                    a.lei_vigente 
                FROM 
                    aliquotas a
                INNER JOIN 
                    municipios m ON a.id_municipio = m.id_municipio
                WHERE 
                    a.id_aliquota <> 0";

            try
            {
                using (MySqlConnection conexao = DBHelper.ObterConexao())
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexao))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                        // Reconfigurar os cabeçalhos das colunas após o DataBinding
                        // para garantir que as colunas existam.
                        if (dataGridView1.Columns.Count > 0)
                        {
                            dataGridView1.Columns[0].HeaderText = "Município";
                            dataGridView1.Columns[1].HeaderText = "Código do Serviço";
                            dataGridView1.Columns[2].HeaderText = "Descrição do Serviço";
                            dataGridView1.Columns[3].HeaderText = "ISS";
                            dataGridView1.Columns[4].HeaderText = "Lei Vigente";
                        }
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
            // A consulta para a ComboBox agora busca os nomes distintos diretamente da tabela 'municipios'.
            string query = "SELECT DISTINCT nome FROM municipios ORDER BY nome";

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
                                string item = reader["nome"].ToString();
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
            if (comboBox1.SelectedIndex != -1)
            {
                string selectedMunicipioNome = comboBox1.SelectedItem.ToString();
                CarregarDadosFiltrados(selectedMunicipioNome);
            }
        }

        private void CarregarDadosFiltrados(string municipioNome)
        {
            // A consulta filtrada agora usa o nome do município para fazer a junção
            // e filtrar os dados corretamente.
            string query = @"
                SELECT 
                    m.nome AS municipio, 
                    a.cod_servico, 
                    a.desc_servico, 
                    a.aliquota_iss, 
                    a.lei_vigente 
                FROM 
                    aliquotas a
                INNER JOIN 
                    municipios m ON a.id_municipio = m.id_municipio
                WHERE 
                    m.nome = @municipioNome";

            try
            {
                using (MySqlConnection conexao = DBHelper.ObterConexao())
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexao))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@municipioNome", municipioNome);

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;

                        dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
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
