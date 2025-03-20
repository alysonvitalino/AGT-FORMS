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
    public partial class calculadora : Form
    {
        MySqlConnection conexao;
        public calculadora()
        {
            InitializeComponent();
            PreencherComboBox();
            dataGridView1.ColumnCount = 5; // Define o número de colunas

            // Define os cabeçalhos das colunas
            dataGridView1.Columns[0].Name = "Código";
            dataGridView1.Columns[1].Name = "Serviço";
            dataGridView1.Columns[2].Name = "Alíquota";
            dataGridView1.Columns[3].Name = "Valor Base";
            dataGridView1.Columns[4].Name = "Valor Final";

            // Ajusta o tamanho automático das colunas
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void SeuFormulario_Load(object sender, EventArgs e)
        {
            
        }



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void paginaInicialToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 produto = new Form1();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Aliquotas produto = new Aliquotas();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cadastros produto = new cadastros();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            logins produto = new logins();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se um valor foi inserido na TextBox
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Por favor, insira um valor antes de calcular.");
                    return;
                }

                // Converte o valor da TextBox para double
                if (!double.TryParse(textBox1.Text, out double valorBase))
                {
                    MessageBox.Show("Digite um valor numérico válido.");
                    return;
                }

                // Verifica se há uma alíquota selecionada
                if (comboBox2.SelectedItem == null)
                {
                    MessageBox.Show("Selecione uma alíquota na ComboBox.");
                    return;
                }

                // Obtém o DataRowView da seleção atual da ComboBox2
                DataRowView rowSelecionada = comboBox2.SelectedItem as DataRowView;
                if (rowSelecionada == null)
                {
                    MessageBox.Show("Erro ao obter os dados da alíquota.");
                    return;
                }

                // Obtém a alíquota e converte para double
                if (!double.TryParse(rowSelecionada["aliquota_iss"].ToString(), out double aliquotaIss))
                {
                    MessageBox.Show("Erro ao converter a alíquota.");
                    return;
                }

                // Converte a alíquota de percentual para decimal (ex: 5% -> 0.05)
                double aliquotaDecimal = aliquotaIss / 100;

                // Calcula o valor final
                double valorFinal = valorBase + (valorBase * aliquotaDecimal);

                // Adiciona os valores no DataGridView1
                dataGridView1.Rows.Add(
                    rowSelecionada["cod_servico"].ToString(),
                    rowSelecionada["desc_servico"].ToString(),
                    aliquotaIss.ToString("0.00") + "%",  // Exibe a alíquota com o símbolo "%"
                    valorBase.ToString("C2"),  // Formata o valor base como moeda
                    valorFinal.ToString("C2")  // Formata o valor final como moeda
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao calcular o valor: " + ex.Message);
            }
        }


        private void PreencherComboBox()
        {
            string data_source = "server=localhost; userid=root; password=''; database=agt";
            conexao = new MySqlConnection(data_source);

            try
            {
                conexao.Open();

                // Preencher ComboBox1 com a coluna "municipio"
                string sql = "SELECT DISTINCT municipio FROM aliquotas;"; // DISTINCT evita duplicatas
                MySqlCommand comando = new MySqlCommand(sql, conexao);
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(comando);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                comboBox1.DataSource = dataTable;
                comboBox1.DisplayMember = "municipio";
                comboBox1.ValueMember = "municipio";

                // Evento para atualizar ComboBox2 quando um município for selecionado
                comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

                // Carregar a ComboBox2 com base no primeiro município da lista
                if (comboBox1.Items.Count > 0)
                {
                    AtualizarComboBox2(comboBox1.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os municípios: " + ex.Message);
            }
            finally
            {
                conexao.Close(); // Fecha a conexão ao final do método
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                AtualizarComboBox2(comboBox1.SelectedValue.ToString());
            }
        }

        private void AtualizarComboBox2(string municipio)
        {
            try
            {
                // Abrimos e fechamos a conexão apenas dentro deste método
                using (MySqlConnection conexaoTemp = new MySqlConnection("server=localhost; userid=root; password=''; database=agt"))
                {
                    conexaoTemp.Open();

                    string sql2 = "SELECT cod_servico, desc_servico, aliquota_iss FROM aliquotas WHERE municipio = @municipio;";
                    MySqlCommand comando2 = new MySqlCommand(sql2, conexaoTemp);
                    comando2.Parameters.AddWithValue("@municipio", municipio);
                    MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(comando2);
                    DataTable dataTable2 = new DataTable();
                    dataAdapter2.Fill(dataTable2);

                    // Criar uma nova coluna para armazenar a concatenação
                    dataTable2.Columns.Add("DescricaoCompleta", typeof(string));

                    foreach (DataRow row in dataTable2.Rows)
                    {
                        row["DescricaoCompleta"] = row["cod_servico"].ToString() + " - "
                                                  + row["desc_servico"].ToString() + " - "
                                                  + row["aliquota_iss"].ToString() + "%";
                    }

                    comboBox2.DataSource = dataTable2;
                    comboBox2.DisplayMember = "DescricaoCompleta"; // Exibe a concatenação
                    comboBox2.ValueMember = "cod_servico"; // Define o valor interno como o código do serviço
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }
        }



    }
}
