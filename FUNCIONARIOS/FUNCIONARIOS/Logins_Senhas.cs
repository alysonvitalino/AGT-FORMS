using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGT_FORMS
{
    public partial class Logins_Senhas : Form
    {
        private bool colunasCriadas = false; // Variável de controle para as colunas

        private string nomeUsuario; // Certifique-se que 'nomeUsuario' é preenchido em algum lugar, se necessário.

        public Logins_Senhas()
        {
            InitializeComponent();
            CarregarDados();
            // Os cabeçalhos das colunas são definidos após o carregamento dos dados
            // para garantir que as colunas existam e que a ordem esteja correta.
            // As definições de HeaderText e ReadOnly estão agora no método CarregarDados().
        }

        private void CarregarDadosFiltrados(int idUnidade, int idMunicipio, string cnpj)
        {
            // A consulta agora faz JOINs com 'unidades' e 'municipios' para obter os nomes
            // em vez de usar campos 'unidade_cadastro', 'municipio_cadastro' diretamente na tabela 'cadastro'.
            // O filtro será feito pelos IDs e CNPJ, que são mais precisos.
            string query = @"
            SELECT 
                u.cod_entidade AS Codigo_da_Unidade,
                m.nome AS Municipio,
                u.cnpj AS CNPJ,
                c.sistema AS Sistema,
                c.login_sistema AS Login,
                c.senha_sistema AS Senha,
                c.dia_vencimento AS Dia_Do_Vencimento,
                c.observacao AS Observacao,
                c.site AS Site
            FROM 
                cadastro c
            INNER JOIN 
                unidades u ON c.id_unidade = u.id_unidade
            INNER JOIN 
                municipios m ON c.id_municipio = m.id_municipio
            WHERE 
                u.id_unidade = @idUnidade 
                AND m.id_municipio = @idMunicipio 
                AND u.cnpj = @cnpjCadastro"; // Usamos u.cnpj pois é a coluna de CNPJ na tabela 'unidades'

            try
            {
                using (MySqlConnection conexao = DBHelper.ObterConexao())
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexao))
                    {
                        // Adiciona os parâmetros para evitar SQL Injection
                        adapter.SelectCommand.Parameters.AddWithValue("@idUnidade", idUnidade);
                        adapter.SelectCommand.Parameters.AddWithValue("@idMunicipio", idMunicipio);
                        adapter.SelectCommand.Parameters.AddWithValue("@cnpjCadastro", cnpj); // O CNPJ é da tabela unidades

                        using (DataTable dt = new DataTable())
                        {
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                            ConfigurarColunasDataGridView(); // Reconfigura as colunas após o filtro
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados filtrados: " + ex.Message, "Erro de Filtro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica se há um item selecionado e se é um ComboBoxItem (nosso tipo personalizado)
            if (comboBox1.SelectedItem is ComboBoxItemWithIds selectedItemData)
            {
                // Os valores já estão pré-parseados no objeto ComboBoxItemWithIds
                int idUnidadeSelecionada = selectedItemData.IdUnidade;
                int idMunicipioSelecionado = selectedItemData.IdMunicipio;
                string cnpjSelecionado = selectedItemData.Cnpj;

                // Filtra os dados com base na seleção
                CarregarDadosFiltrados(idUnidadeSelecionada, idMunicipioSelecionado, cnpjSelecionado);
            }
            else
            {
                // Caso algo inesperado ocorra ou nenhum item seja selecionado
                CarregarDados(); // Recarrega todos os dados
            }
        }

        private void CarregarComboBox()
        {
            string query = @"
        SELECT 
            c.id_cadastro, -- Adicione esta linha para pegar o ID do cadastro
            u.cod_entidade AS UnidadeNome, 
            m.nome AS MunicipioNome, 
            u.cnpj AS CnpjUnidade,
            u.id_unidade AS IdUnidade,
            m.id_municipio AS IdMunicipio
        FROM 
            cadastro c
        INNER JOIN 
            unidades u ON c.id_unidade = u.id_unidade
        INNER JOIN 
            municipios m ON c.id_municipio = m.id_municipio
        ORDER BY 
            u.cod_entidade ASC";

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
                                ComboBoxItemWithIds item = new ComboBoxItemWithIds(
                                    reader["UnidadeNome"].ToString(),
                                    reader["MunicipioNome"].ToString(),
                                    reader["CnpjUnidade"].ToString(),
                                    Convert.ToInt32(reader["IdUnidade"]),
                                    Convert.ToInt32(reader["IdMunicipio"]),
                                    Convert.ToInt32(reader["id_cadastro"]) // Passa o ID do cadastro
                                );
                                comboBox1.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar ComboBox: " + ex.Message, "Erro de Carregamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarDados()
        {
            // Consulta principal para carregar todos os dados no DataGridView.
            // Faz JOINs com 'unidades' e 'municipios' para obter os nomes.
            string query = @"
            SELECT 
                u.cod_entidade AS Codigo_da_Unidade,
                m.nome AS Municipio,
                u.cnpj AS CNPJ,
                c.sistema AS Sistema,
                c.login_sistema AS Login,
                c.senha_sistema AS Senha,
                c.dia_vencimento AS Dia_Do_Vencimento,
                c.observacao AS Observacao,
                c.site AS Site -- Campo 'site' diretamente da tabela 'cadastro'
            FROM 
                cadastro c
            INNER JOIN 
                unidades u ON c.id_unidade = u.id_unidade
            INNER JOIN 
                municipios m ON c.id_municipio = m.id_municipio
            ORDER BY 
                u.cod_entidade, m.nome, u.cnpj";

            try
            {
                using (MySqlConnection conexao = DBHelper.ObterConexao())
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexao))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;

                            // Configura as colunas uma única vez após o primeiro carregamento
                            if (!colunasCriadas)
                            {
                                ConfigurarColunasDataGridView();
                                colunasCriadas = true;
                            }
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message, "Erro de Carregamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Novo método para configurar as colunas do DataGridView de forma centralizada
        private void ConfigurarColunasDataGridView()
        {
            // Limpa as colunas existentes antes de adicionar novas, se já houver
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns.Clear();
            }

            // Adiciona e configura as colunas manualmente para garantir a ordem e o tipo
            // Se você já as definiu no designer, pode comentar/remover essas linhas e ajustar os HeaderText
            // apenas se o DataPropertyName for diferente.
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Codigo_da_Unidade", HeaderText = "Código da Unidade", DataPropertyName = "Codigo_da_Unidade", ReadOnly = true });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Municipio", HeaderText = "Município", DataPropertyName = "Municipio", ReadOnly = true });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "CNPJ", HeaderText = "CNPJ", DataPropertyName = "CNPJ", ReadOnly = true });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Sistema", HeaderText = "Sistema", DataPropertyName = "Sistema", ReadOnly = true });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Login", HeaderText = "Login", DataPropertyName = "Login", ReadOnly = true });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Senha", HeaderText = "Senha", DataPropertyName = "Senha", ReadOnly = true });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Dia_Do_Vencimento", HeaderText = "Dia do Vencimento", DataPropertyName = "Dia_Do_Vencimento", ReadOnly = true });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Observacao", HeaderText = "Observação", DataPropertyName = "Observacao", ReadOnly = true });

            // Adiciona a coluna de link para o site
            DataGridViewLinkColumn linkColumn = new DataGridViewLinkColumn();
            linkColumn.Name = "Site_Link"; // Nome da coluna para o DataGridView
            linkColumn.HeaderText = "Site"; // Título visível
            linkColumn.DataPropertyName = "Site"; // Vincula aos dados da coluna 'Site' da sua query
            linkColumn.ReadOnly = true;
            dataGridView1.Columns.Add(linkColumn);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar se clicou na coluna 'Site_Link' (o nome que definimos no DataGridView)
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Site_Link") // Usa o nome da coluna que definimos
                {
                    object cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (cellValue != null && cellValue != DBNull.Value)
                    {
                        string url = cellValue.ToString();

                        // Adiciona http:// ou https:// se o URL não começar com um deles
                        if (!url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                            !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                        {
                            url = "http://" + url; // Assume http se não especificado
                        }

                        try
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = url,
                                UseShellExecute = true
                            });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erro ao tentar abrir o site: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nenhum site disponível para este registro.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        // --- Nova classe para itens do ComboBox ---
        // Esta classe personalizada permite armazenar múltiplos valores
        // (nome, CNPJ, e os IDs) em um único item da ComboBox,
        // enquanto exibe uma string formatada.
        private class ComboBoxItemWithIds
        {
            public string DisplayText { get; set; }
            public int IdCadastro { get; set; } // Adiciona o ID do cadastro
            public int IdUnidade { get; set; }
            public int IdMunicipio { get; set; }
            public string Cnpj { get; set; }

            // Construtor atualizado
            public ComboBoxItemWithIds(string unidadeNome, string municipioNome, string cnpj, int idUnidade, int idMunicipio, int idCadastro)
            {
                DisplayText = $"{unidadeNome} - {municipioNome} - {cnpj}";
                IdUnidade = idUnidade;
                IdMunicipio = idMunicipio;
                Cnpj = cnpj;
                IdCadastro = idCadastro; // Atribui o ID do cadastro
            }

            public override string ToString()
            {
                return DisplayText;
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

        private void button6_Click(object sender, EventArgs e)
        {
            //incluir
            if (Sessao.NivelAcesso == "Admin" || Sessao.NivelAcesso == null)
            {
                LoginsAdicionar produto = new LoginsAdicionar();
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
            //editar
            if (Sessao.NivelAcesso == "Admin" || Sessao.NivelAcesso == null)
            {
                LoginsEditar produto = new LoginsEditar();
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
            if (Sessao.NivelAcesso == "Admin" || Sessao.NivelAcesso == null)
            {
                if (comboBox1.SelectedIndex != -1 && comboBox1.SelectedItem is ComboBoxItemWithIds selectedCadastro)
                {
                    // Agora pegamos o ID do cadastro diretamente
                    int idCadastroParaExcluir = selectedCadastro.IdCadastro;

                    var confirmResult = MessageBox.Show(
                        $"Deseja realmente excluir o cadastro para a unidade '{selectedCadastro.DisplayText}'?",
                        "Confirmação de Exclusão",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirmResult == DialogResult.Yes)
                    {
                        try
                        {
                            // Query DELETE agora usa apenas o ID do cadastro (chave primária)
                            string query = "DELETE FROM cadastro WHERE id_cadastro = @idCadastro";

                            using (MySqlConnection conexao = DBHelper.ObterConexao())
                            {
                                using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                                {
                                    cmd.Parameters.AddWithValue("@idCadastro", idCadastroParaExcluir); // Usa o ID do cadastro

                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Cadastro excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        comboBox1.SelectedIndex = -1;
                                        CarregarComboBox();
                                        CarregarDados();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Nenhum registro foi encontrado para exclusão com o ID fornecido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show($"Erro de banco de dados ao excluir o cadastro: {ex.Message} (Código: {ex.Number})", "Erro de Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ocorreu um erro inesperado ao excluir o cadastro: {ex.Message}", "Erro Geral", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecione um cadastro na lista para excluir.", "Nenhuma Seleção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Você não tem permissão para realizar esta operação.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Logins_Senhas_Load_1(object sender, EventArgs e)
        {
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
            CarregarComboBox();
        }
    }
}
