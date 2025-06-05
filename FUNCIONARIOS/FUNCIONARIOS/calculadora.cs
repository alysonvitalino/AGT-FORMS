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
using OfficeOpenXml;
using System.IO;

namespace AGT_FORMS
{
   
public partial class calculadora : Form
    {
        MySqlConnection conexao;

        private string nomeUsuario;
        public calculadora()
        {
            InitializeComponent();
            PreencherComboBox();

            comboBox1.SelectedIndex = 12;

            dataGridView1.ColumnCount = 15;


            dataGridView1.Columns[1].Name = "";
            dataGridView1.Columns[0].Name = "ValorBase";
            dataGridView1.Columns[2].Name = "CSRF";
            dataGridView1.Columns[3].Name = "ISS";
            dataGridView1.Columns[4].Name = "INSS";
            dataGridView1.Columns[5].Name = "IR";
            dataGridView1.Columns[6].Name = "IR+CSRF";
            dataGridView1.Columns[7].Name = "IR+CSRF+ INSS";
            dataGridView1.Columns[8].Name = "IR+CSRF+ INSS+ISS";
            dataGridView1.Columns[9].Name = "IR+CSRF+ISS";
            dataGridView1.Columns[10].Name = "CSRF+ISS";
            dataGridView1.Columns[11].Name = "INSS+ISS";
            dataGridView1.Columns[12].Name = "IR+ISS";
            dataGridView1.Columns[13].Name = "CSRF+ISS";
            dataGridView1.Columns[14].Name = "DataHora";

            // Ajusta o tamanho automático das colunas
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void paginaInicialToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            HomePage produto = new HomePage();
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
            Cadastros produto = new Cadastros();
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

        private bool corAlternada = false;

        int idCalculo = 0;

        private void button5_Click(object sender, EventArgs e)
        {
            idCalculo = idCalculo + 1;
            try
            {
                // Verifica se um valor foi inserido na TextBox1
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

                // Verifica se há uma alíquota selecionada na ComboBox2
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

                // Obtém a alíquota de ISS a partir da seleção da ComboBox2
                if (!double.TryParse(rowSelecionada["aliquota_iss"].ToString(), out double aliquotaIss))
                {
                    MessageBox.Show("Erro ao converter a alíquota de ISS.");
                    return;
                }

                aliquotaIss = aliquotaIss / 100;

                // Pega o valor das deduções (TextBox2). Se estiver vazio, define como 0
                double deducoes = 0;
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    if (!double.TryParse(textBox2.Text, out deducoes))
                    {
                        MessageBox.Show("Digite um valor válido para as deduções.");
                        return;
                    }
                }

                // Obtém a alíquota de IR a partir da ComboBox3
                double aliquotaIr = 0;
                if (comboBox3.SelectedItem != null)
                {
                    if (comboBox3.SelectedItem.ToString() == "ND")
                        aliquotaIr = 0;
                    else if (comboBox3.SelectedItem.ToString() == "1%")
                        aliquotaIr = 0.01;
                    else if (comboBox3.SelectedItem.ToString() == "1.5%")
                        aliquotaIr = 0.015;
                }

                // Calculando os diferentes valores
                double liqCsr = valorBase * 0.0465; // 4.65%
                double liqIss = valorBase * aliquotaIss; // Alíquota de ISS dinâmica
                double liqInss = (valorBase - deducoes) * 0.11; // 11% após deduções
                double liqIr = valorBase * aliquotaIr;
                double liqIrCsr = liqIr + liqCsr;
                double liqIrCsrInss = liqIrCsr + liqInss;
                double liqIrCsrInssIss = liqIrCsrInss + liqIss;
                double liqIrCsrIss = liqIrCsr + liqIss;
                double liqIrIss = liqIr + liqIss;
                double liqCsrIss = liqCsr + liqIss;
                double liqInssIss = liqInss + liqIss;

                // Calculando o valor restante após as deduções para cada coluna
                double liqCsrRestante = valorBase - liqCsr;
                double liqIssRestante = valorBase - liqIss;
                double liqInssRestante = valorBase - liqInss;
                double liqIrRestante = valorBase - liqIr;
                double liqIrCsrRestante = valorBase - liqIrCsr;
                double liqIrCsrInssRestante = valorBase - liqIrCsrInss;
                double liqIrCsrInssIssRestante = valorBase - liqIrCsrInssIss;
                double liqIrIssRestante = valorBase - liqIrIss;
                double liqCsrIssRestante = valorBase - liqCsrIss;
                double liqInssIssRestante = valorBase - liqInssIss;
                double liqIrCsrIssRestante = valorBase - liqIrCsrIss;

                // Primeira linha de "Valor do Imposto" e "Valor Líquido"
                int rowIndex1 = dataGridView1.Rows.Add(
                    valorBase.ToString("C2"),
                    "Valor do Imposto",
                    liqCsr.ToString("C2"),
                    liqIss.ToString("C2"),
                    liqInss.ToString("C2"),
                    liqIr.ToString("C2"),
                    liqIrCsr.ToString("C2"),
                    liqIrCsrInss.ToString("C2"),
                    liqIrCsrInssIss.ToString("C2"),
                    liqIrCsrIss.ToString("C2"),
                    liqCsrIss.ToString("C2"),
                    liqInssIss.ToString("C2"),
                    liqIrIss.ToString("C2"),
                    liqCsrIss.ToString("C2"), 
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                );

                // Segunda linha de "Valor Líquido"
                int rowIndex2 = dataGridView1.Rows.Add(
                    valorBase.ToString("C2"),
                    "Valor Líquido",
                    liqCsrRestante.ToString("C2"),
                    liqIssRestante.ToString("C2"),
                    liqInssRestante.ToString("C2"),
                    liqIrRestante.ToString("C2"),
                    liqIrCsrRestante.ToString("C2"),
                    liqIrCsrInssRestante.ToString("C2"),
                    liqIrCsrInssIssRestante.ToString("C2"),
                    liqIrCsrIssRestante.ToString("C2"),
                    liqCsrIssRestante.ToString("C2"),
                    liqInssIssRestante.ToString("C2"),
                    liqIrIssRestante.ToString("C2"),
                    liqCsrIssRestante.ToString("C2"),
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                );

                dataGridView1.Columns["DataHora"].ValueType = typeof(DateTime);
                dataGridView1.Sort(dataGridView1.Columns["DataHora"], ListSortDirection.Descending);
                dataGridView1.Sort(dataGridView1.Columns[14], ListSortDirection.Descending);

                // Alternando as cores das linhas
                if (corAlternada)
                {
                    // Define a cor de fundo das linhas para verde claro
                    dataGridView1.Rows[rowIndex1].DefaultCellStyle.BackColor = Color.LightBlue;
                    dataGridView1.Rows[rowIndex2].DefaultCellStyle.BackColor = Color.LightBlue;
                }
                else
                {
                    // Define a cor de fundo das linhas para azul claro
                    dataGridView1.Rows[rowIndex1].DefaultCellStyle.BackColor = Color.Azure;
                    dataGridView1.Rows[rowIndex2].DefaultCellStyle.BackColor = Color.Azure;
                }

                corAlternada = !corAlternada;

                // Ajustando o tamanho das colunas de acordo com o conteúdo
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao calcular o valor: " + ex.Message);
            }
        }

        private void PreencherComboBox()
        {
            try
            {
                using (MySqlConnection conexao = DBHelper.ObterConexao())
                {
                    // Preencher ComboBox1 com os nomes distintos dos municípios da tabela 'municipios'
                    string sql = "SELECT DISTINCT nome, id_municipio FROM municipios ORDER BY nome;"; // DISTINCT evita duplicatas
                    using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                    {
                        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(comando))
                        {
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);

                            comboBox1.DataSource = dataTable;
                            comboBox1.DisplayMember = "nome";       // Exibe o nome do município
                            comboBox1.ValueMember = "id_municipio"; // O valor interno será o id_municipio

                            // Remover o evento antes de adicionar para evitar múltiplas assinaturas
                            comboBox1.SelectedIndexChanged -= ComboBox1_SelectedIndexChanged;
                            // Evento para atualizar ComboBox2 quando um município for selecionado
                            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

                            // Carregar a ComboBox2 com base no primeiro município da lista
                            if (comboBox1.Items.Count > 0)
                            {
                                // Garantir que um item esteja selecionado para que SelectedValue não seja null
                                comboBox1.SelectedIndex = 0;
                                AtualizarComboBox2(Convert.ToInt32(comboBox1.SelectedValue));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os municípios: " + ex.Message, "Erro de Carregamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                // Passa o id_municipio (inteiro) para o método de atualização
                AtualizarComboBox2(Convert.ToInt32(comboBox1.SelectedValue));
            }
            else
            {
                // Opcional: Limpar comboBox2 se nada estiver selecionado
                comboBox2.DataSource = null;
                comboBox2.Items.Clear();
            }
        }

        private void AtualizarComboBox2(int idMunicipio) // Recebe o id_municipio como int
        {
            try
            {
                using (MySqlConnection conexaoTemp = DBHelper.ObterConexao())
                {
                    // A consulta agora filtra por id_municipio na tabela 'aliquotas'
                    string sql2 = "SELECT cod_servico, desc_servico, aliquota_iss FROM aliquotas WHERE id_municipio = @idMunicipio;";
                    using (MySqlCommand comando2 = new MySqlCommand(sql2, conexaoTemp))
                    {
                        comando2.Parameters.AddWithValue("@idMunicipio", idMunicipio); // Adiciona o id_municipio como parâmetro
                        using (MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(comando2))
                        {
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

                            // Preenche a comboBox2 com os dados
                            comboBox2.DataSource = dataTable2;
                            comboBox2.DisplayMember = "DescricaoCompleta"; // Exibe a concatenação
                            comboBox2.ValueMember = "cod_servico";         // Define o valor interno como o código do serviço
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os serviços para o município: " + ex.Message, "Erro de Carregamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }
        
        public static void IncrementarContadorExcel()
        {
            using (MySqlConnection conexao = DBHelper.ObterConexao())
            {
                string sql = "UPDATE contador_relatorios SET quantidade = quantidade + 1 WHERE id = 1";
                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                cmd.ExecuteNonQuery();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelPackage.License.SetNonCommercialPersonal("<Your Name>");
                //or..
                ExcelPackage.License.SetNonCommercialOrganization("<Your Noncommercial Organization>");

                using (var package = new ExcelPackage(new FileInfo("MyWorkbook.xlsx")))
                {

                }

                string caminhoArquivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "resultados_calculos.xlsx");

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Resultados");

                    for (int col = 0; col < dataGridView1.ColumnCount; col++)
                        worksheet.Cells[1, col + 1].Value = dataGridView1.Columns[col].HeaderText;

                    for (int row = 0; row < dataGridView1.Rows.Count; row++)
                    {
                        for (int col = 0; col < dataGridView1.Columns.Count; col++)
                        {
                            if (dataGridView1.Rows[row].Cells[col].Value != null)
                                worksheet.Cells[row + 2, col + 1].Value = dataGridView1.Rows[row].Cells[col].Value.ToString();
                        }
                    }

                    FileInfo fi = new FileInfo(caminhoArquivo);
                    package.SaveAs(fi);

                    // Incrementa o contador no banco
                    IncrementarContadorExcel();

                    MessageBox.Show("Arquivo Excel gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar o Excel: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
