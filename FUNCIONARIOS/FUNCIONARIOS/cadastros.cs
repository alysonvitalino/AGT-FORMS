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
            // Os cabeçalhos das colunas são definidos após o carregamento dos dados para garantir que as colunas existam.
            // Veja o método CarregarDados para as configurações.
        }

        private void Cadastros_Load(object sender, EventArgs e) // Alterado de logins_Load para Cadastros_Load
        {
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
            CarregarComboBox();
        }

        private void CarregarDados()
        {
            // A consulta agora faz um JOIN com a tabela 'municipios' para obter o nome do município
            // e ajusta os nomes das colunas de acordo com a sua estrutura.
            string query = @"
                SELECT 
                    u.cod_entidade, 
                    u.cnpj, 
                    u.nome_fantasia, 
                    u.endereco, 
                    m.nome AS cidade_unidade, 
                    u.cep 
                FROM 
                    unidades u
                INNER JOIN 
                    municipios m ON u.id_municipio = m.id_municipio";

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
                        // para garantir que as colunas existam e reflitam os novos nomes da consulta.
                        if (dataGridView1.Columns.Count >= 6) // Verifica o número mínimo de colunas esperadas
                        {
                            dataGridView1.Columns[0].HeaderText = "Código da Entidade"; // Corresponde a 'u.cod_entidade'
                            dataGridView1.Columns[1].HeaderText = "CNPJ da Entidade";    // Corresponde a 'u.cnpj'
                            dataGridView1.Columns[2].HeaderText = "Nome Fantasia";       // Corresponde a 'u.nome_fantasia'
                            dataGridView1.Columns[3].HeaderText = "Endereço da Unidade"; // Corresponde a 'u.endereco'
                            dataGridView1.Columns[4].HeaderText = "Cidade da Unidade";   // Corresponde a 'm.nome'
                            dataGridView1.Columns[5].HeaderText = "CEP da Unidade";      // Corresponde a 'u.cep'
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
            // A ComboBox agora vai carregar os códigos das entidades (cod_entidade) da tabela unidades.
            // Se você quiser filtrar por município, a lógica seria similar à do exemplo anterior.
            string query = "SELECT DISTINCT cod_entidade FROM unidades ORDER BY cod_entidade ASC";

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
                                string item = reader["cod_entidade"].ToString();
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
                string selectedCodEntidade = comboBox1.SelectedItem.ToString();
                CarregarDadosFiltrados(selectedCodEntidade);
            }
        }

        private void CarregarDadosFiltrados(string codEntidade)
        {
            // A consulta filtrada agora usa o 'cod_entidade' para filtrar as unidades.
            // O JOIN com 'municipios' é mantido para exibir o nome da cidade.
            string query = @"
                SELECT 
                    u.cod_entidade, 
                    u.cnpj, 
                    u.nome_fantasia, 
                    u.endereco, 
                    m.nome AS cidade_unidade, 
                    u.cep 
                FROM 
                    unidades u
                INNER JOIN 
                    municipios m ON u.id_municipio = m.id_municipio
                WHERE 
                    u.cod_entidade = @codEntidade";

            try
            {
                using (MySqlConnection conexao = DBHelper.ObterConexao())
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexao))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@codEntidade", codEntidade);
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
            if (Sessao.NivelAcesso == "Admin" || Sessao.NivelAcesso == null)
            {
                CadastrosEditar produto = new CadastrosEditar();
                produto.StartPosition = FormStartPosition.CenterScreen;
                produto.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Acesso Negado.");
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Sessao.NivelAcesso == "Admin" || Sessao.NivelAcesso == null)
            {
                CadastrosNova produto = new CadastrosNova();
                produto.StartPosition = FormStartPosition.CenterScreen;
                produto.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Acesso Negado.");
            }

        }
        private void button8_Click(object sender, EventArgs e)
        {
            // Apenas usuários 'Admin' ou com 'Sessao.NivelAcesso' nulo (o que pode ser um fallback para admin se nulo significa sem restrição)
            if (Sessao.NivelAcesso == "Admin" || Sessao.NivelAcesso == null)
            {
                // Verifica se um item foi selecionado no comboBox1
                if (comboBox1.SelectedItem != null)
                {
                    // Pega o 'cod_entidade' da unidade selecionada no ComboBox
                    string codEntidadeParaExcluir = comboBox1.SelectedItem.ToString();

                    // Mensagem de confirmação para o usuário
                    var confirmResult = MessageBox.Show(
                        $"Tem certeza que deseja excluir a unidade com Código da Entidade: {codEntidadeParaExcluir}?",
                        "Confirmação de Exclusão",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirmResult == DialogResult.Yes)
                    {
                        // Query para excluir a unidade baseada no 'cod_entidade'
                        string query = "DELETE FROM unidades WHERE cod_entidade = @codEntidade";

                        try
                        {
                            using (MySqlConnection conexao = DBHelper.ObterConexao())
                            {
                                using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                                {
                                    // Adiciona o parâmetro para evitar SQL Injection
                                    cmd.Parameters.AddWithValue("@codEntidade", codEntidadeParaExcluir);

                                    // Executa a query de exclusão
                                    int linhasAfetadas = cmd.ExecuteNonQuery();

                                    if (linhasAfetadas > 0)
                                    {
                                        MessageBox.Show("Unidade excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        CarregarComboBox(); // Atualiza a ComboBox para remover o item excluído
                                        CarregarDados();    // Atualiza o DataGridView para refletir a mudança
                                    }
                                    else
                                    {
                                        MessageBox.Show("Nenhuma unidade foi encontrada ou excluída com o código fornecido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                        }
                        catch (MySqlException ex)
                        {
                            // Captura exceções específicas do MySQL, como violações de chave estrangeira
                            if (ex.Number == 1451) // Erro 1451 é geralmente "Cannot delete or update a parent row: a foreign key constraint fails"
                            {
                                MessageBox.Show("Não foi possível excluir a unidade porque existem cadastros associados a ela. Por favor, exclua os cadastros relacionados primeiro ou configure a exclusão em cascata no banco de dados.", "Erro de Chave Estrangeira", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show($"Erro ao excluir a unidade: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ocorreu um erro inesperado: {ex.Message}", "Erro Geral", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selecione uma unidade na lista para excluir.", "Nenhuma Unidade Selecionada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Você não tem permissão para realizar esta operação.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
