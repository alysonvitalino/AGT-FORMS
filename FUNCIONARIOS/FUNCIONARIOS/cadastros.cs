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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AGT_FORMS
{
    public partial class Cadastros : Form
    {
        public Cadastros()
        {
            InitializeComponent();
            CarregarDados();
            //(id_unidade, cod_erp, cod_entidade, cnpj_unidade, nome_fantasia, endereco_unidade, cidade_unidade, cep_unidade)
            dataGridView1.Columns[0].HeaderText = "Código ERP";
            dataGridView1.Columns[1].HeaderText = "Código da Entidade";
            dataGridView1.Columns[2].HeaderText = "CNPJ da Entidade";
            dataGridView1.Columns[3].HeaderText = "Nome Fantasia";
            dataGridView1.Columns[4].HeaderText = "Endereço da Unidade";
            dataGridView1.Columns[5].HeaderText = "Cidade da Unidade";
            dataGridView1.Columns[6].HeaderText = "CEP da Unidade";

        }

        private void logins_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
            CarregarComboBox();
        }
        private void CarregarDados()
        {
            string query = "SELECT cod_erp, cod_entidade, cnpj_unidade, nome_fantasia, endereco_unidade, cidade_unidade, cep_unidade FROM unidades";

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
            string query = "SELECT cod_erp FROM unidades ORDER BY cod_erp ASC";

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
                                string item = reader["cod_erp"].ToString();
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
                string selectedItem = comboBox1.SelectedItem.ToString();
                CarregarDadosFiltrados(selectedItem);
            }
        }
        private void CarregarDadosFiltrados(string cod_erp)
        {
            string query = "SELECT cod_erp, cod_entidade, cnpj_unidade, nome_fantasia, endereco_unidade, cidade_unidade, cep_unidade FROM unidades WHERE cod_erp = @cod_erp";

            try
            {
                using (MySqlConnection conexao = DBHelper.ObterConexao())
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexao))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@cod_erp", cod_erp);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados filtrados: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Logins_Senhas produto = new Logins_Senhas();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Aliquotas produto = new Aliquotas();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomePage produto = new HomePage();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            calculadora produto = new calculadora();
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
        private void cadastrosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Cadastros produto = new Cadastros();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void leisEAlíquotasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Aliquotas produto = new Aliquotas();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void loginsESenhasToolStripMenuItem_Click_1(object sender, EventArgs e)
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
        private void button5_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            CarregarDados();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CadastrosEditar produto = new CadastrosEditar();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CadastrosNova produto = new CadastrosNova();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string codErp = comboBox1.SelectedItem.ToString();

                var confirmResult = MessageBox.Show("Tem certeza que deseja excluir esta unidade?",
                                                     "Confirmação", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    string query = "DELETE FROM unidades WHERE cod_erp = @codErp";

                    try
                    {
                        using (MySqlConnection conexao = DBHelper.ObterConexao())
                        {
                            using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                            {
                                cmd.Parameters.AddWithValue("@codErp", codErp);
                                int linhasAfetadas = cmd.ExecuteNonQuery();

                                if (linhasAfetadas > 0)
                                {
                                    MessageBox.Show("Unidade excluída com sucesso!");
                                    CarregarComboBox(); // Atualiza o combo
                                    CarregarDados();    // Atualiza o DataGrid
                                }
                                else
                                {
                                    MessageBox.Show("Nenhuma unidade foi excluída.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir a unidade: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma unidade para excluir.");
            }
        }

    }
}
