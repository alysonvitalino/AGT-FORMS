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
        // Variável para armazenar o ID do cadastro selecionado para edição
        private int idCadastroSelecionado = -1;

        public LoginsEditar()
        {
            InitializeComponent();
            // O evento SelectedIndexChanged é atribuído no Designer ou no Load,
            // mas para garantir que está aqui:
            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged; // Remove para evitar duplicação se já estiver no designer
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        // Classe interna para os itens da ComboBox
        private class ComboBoxItemEditar
        {
            public string DisplayText { get; set; }
            public int IdCadastro { get; set; }

            public ComboBoxItemEditar(string displayText, int idCadastro)
            {
                DisplayText = displayText;
                IdCadastro = idCadastro;
            }

            public override string ToString()
            {
                return DisplayText;
            }
        }

        private void CarregarComboBox()
        {
            // Query para carregar a ComboBox com informações relevantes
            // u.cod_entidade é usado para identificar a unidade, m.nome para o município
            // e c.sistema pode ajudar a diferenciar registros para a mesma unidade/CNPJ
            string query = @"
                SELECT
                    c.id_cadastro,
                    u.cod_entidade,
                    m.nome AS nome_municipio,
                    COALESCE(c.cnpj_cadastro, u.cnpj) AS cnpj_visualizacao, /* Prioriza cnpj_cadastro se existir, senão u.cnpj */
                    c.sistema
                FROM
                    cadastro c
                INNER JOIN
                    unidades u ON c.id_unidade = u.id_unidade
                INNER JOIN
                    municipios m ON c.id_municipio = m.id_municipio
                ORDER BY
                    u.cod_entidade ASC, m.nome ASC, c.sistema ASC";

            try
            {
                using (MySqlConnection conexao = DBHelper.ObterConexao())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            comboBox1.Items.Clear();
                            comboBox1.DisplayMember = "DisplayText"; // Importante para a classe ComboBoxItemEditar
                            comboBox1.ValueMember = "IdCadastro";   // Importante para a classe ComboBoxItemEditar

                            while (reader.Read())
                            {
                                string displayText = $"{reader["cod_entidade"]} - {reader["nome_municipio"]} - CNPJ: {reader["cnpj_visualizacao"]} - Sis: {reader["sistema"]}";
                                int idCadastro = Convert.ToInt32(reader["id_cadastro"]);
                                comboBox1.Items.Add(new ComboBoxItemEditar(displayText, idCadastro));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar ComboBox: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is ComboBoxItemEditar selectedItem)
            {
                idCadastroSelecionado = selectedItem.IdCadastro; // Armazena o ID do cadastro
                CarregarDadosParaEdicao(idCadastroSelecionado);
            }
            else
            {
                LimparCampos();
                idCadastroSelecionado = -1;
            }
        }

        private void CarregarDadosParaEdicao(int idCadastro)
        {
            string query = @"
                SELECT
                    u.cod_entidade,
                    m.nome AS nome_municipio,
                    c.cnpj_cadastro,
                    c.sistema,
                    c.site,
                    c.login_sistema,
                    c.senha_sistema,
                    c.dia_vencimento,
                    c.observacao
                FROM
                    cadastro c
                INNER JOIN
                    unidades u ON c.id_unidade = u.id_unidade
                INNER JOIN
                    municipios m ON c.id_municipio = m.id_municipio
                WHERE
                    c.id_cadastro = @idCadastro";

            try
            {
                using (MySqlConnection conexao = DBHelper.ObterConexao())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                    {
                        cmd.Parameters.AddWithValue("@idCadastro", idCadastro);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox1.Text = reader["cod_entidade"].ToString();
                                textBox2.Text = reader["nome_municipio"].ToString();
                                textBox3.Text = reader["cnpj_cadastro"].ToString(); // CNPJ específico do cadastro
                                textBox4.Text = reader["sistema"].ToString();
                                textBox5.Text = reader["site"].ToString();
                                textBox6.Text = reader["login_sistema"].ToString();
                                textBox7.Text = reader["senha_sistema"].ToString();
                                textBox8.Text = reader["dia_vencimento"].ToString();
                                textBox9.Text = reader["observacao"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Dados não encontrados para o ID de cadastro fornecido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                LimparCampos();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados para edição: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimparCampos();
            }
        }


        private void button1_Click(object sender, EventArgs e) // Botão Voltar/Cancelar
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
            textBox1.Clear(); // cod_entidade
            textBox2.Clear(); // nome_municipio
            textBox3.Clear(); // cnpj_cadastro
            textBox4.Clear(); // sistema
            textBox5.Clear(); // site
            textBox6.Clear(); // login_sistema
            textBox7.Clear(); // senha_sistema
            textBox8.Clear(); // dia_vencimento
            textBox9.Clear(); // observacao
            idCadastroSelecionado = -1;
            // comboBox1.SelectedIndex = -1; // Descomente se quiser limpar a seleção da combo também
        }

        private void button2_Click(object sender, EventArgs e) // Botão Salvar
        {
            if (idCadastroSelecionado == -1)
            {
                MessageBox.Show("Por favor, selecione um item na lista para editar.", "Seleção Necessária", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Obter IDs de unidade e município com base nos TextBoxes
            string codEntidadeParaUnidade = textBox1.Text.Trim();
            int idUnidade = ObterIdUnidadePorCodEntidade(codEntidadeParaUnidade);

            if (idUnidade == -1)
            {
                MessageBox.Show("O Código da Entidade (Unidade) informado não é válido ou não foi encontrado.", "Erro de Unidade", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nomeMunicipioParaCadastro = textBox2.Text.Trim();
            int idMunicipio = ObterIdMunicipioPorNome(nomeMunicipioParaCadastro);

            if (idMunicipio == -1)
            {
                MessageBox.Show("O nome do município informado não é válido ou não foi encontrado. Verifique.", "Erro de Município", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validação do dia de vencimento
            if (!int.TryParse(textBox8.Text.Trim(), out int diaVencimento) || diaVencimento < 1 || diaVencimento > 31)
            {
                MessageBox.Show("O Dia do Vencimento deve ser um número entre 1 e 31.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obter os demais valores dos TextBox
            string cnpjCadastro = textBox3.Text.Trim(); // CNPJ específico do cadastro
            string sistema = textBox4.Text.Trim();
            string site = textBox5.Text.Trim();
            string loginSistema = textBox6.Text.Trim();
            string senhaSistema = textBox7.Text.Trim();
            string observacao = textBox9.Text.Trim();


            string query = @"UPDATE cadastro SET
                                id_unidade = @idUnidade,
                                id_municipio = @idMunicipio,
                                cnpj_cadastro = @cnpjCadastro,
                                sistema = @sistema,
                                site = @site,
                                login_sistema = @loginSistema,
                                senha_sistema = @senhaSistema,
                                dia_vencimento = @diaVencimento,
                                observacao = @observacao
                            WHERE id_cadastro = @idCadastroAtual";

            try
            {
                using (MySqlConnection conexao = DBHelper.ObterConexao())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                    {
                        cmd.Parameters.AddWithValue("@idUnidade", idUnidade);
                        cmd.Parameters.AddWithValue("@idMunicipio", idMunicipio);
                        cmd.Parameters.AddWithValue("@cnpjCadastro", string.IsNullOrEmpty(cnpjCadastro) ? (object)DBNull.Value : cnpjCadastro); // Permite nulo
                        cmd.Parameters.AddWithValue("@sistema", sistema);
                        cmd.Parameters.AddWithValue("@site", site);
                        cmd.Parameters.AddWithValue("@loginSistema", loginSistema);
                        cmd.Parameters.AddWithValue("@senhaSistema", senhaSistema);
                        cmd.Parameters.AddWithValue("@diaVencimento", diaVencimento);
                        cmd.Parameters.AddWithValue("@observacao", observacao);
                        cmd.Parameters.AddWithValue("@idCadastroAtual", idCadastroSelecionado);

                        int linhasAfetadas = cmd.ExecuteNonQuery();
                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Dados atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparCampos();
                            comboBox1.SelectedIndex = -1; // Limpa seleção
                            CarregarComboBox(); // Atualizar ComboBox com os novos dados, se necessário
                        }
                        else
                        {
                            MessageBox.Show("Nenhum registro foi atualizado. Verifique os dados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Tratar exceções específicas do MySQL, como duplicidade se houver chaves únicas afetadas pela edição
                if (ex.Number == 1062) // Duplicate entry
                {
                    MessageBox.Show("Erro: A alteração resultaria em um registro duplicado (ex: CNPJ, ou outra chave única). Por favor, verifique os dados.", "Erro de Duplicidade", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Number == 1452) // Foreign key constraint fails
                {
                    MessageBox.Show("Erro de chave estrangeira: A unidade ou município associado não existe. Verifique os códigos/nomes.", "Erro de Integridade", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Erro de banco de dados ao atualizar: {ex.Message} (Código: {ex.Number})", "Erro de Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar dados: " + ex.Message, "Erro Geral", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Métodos Auxiliares para obter IDs ---
        // Estes métodos devem ser idealmente parte da sua classe DBHelper ou uma classe de serviço de dados.
        // Se já os tem no LoginsAdicionar, pode reutilizá-los ou movê-los para um local comum.

        private int ObterIdUnidadePorCodEntidade(string codEntidade)
        {
            if (string.IsNullOrWhiteSpace(codEntidade)) return -1;
            string query = "SELECT id_unidade FROM unidades WHERE cod_entidade = @codEntidade";
            try
            {
                using (MySqlConnection conexao = DBHelper.ObterConexao())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                    {
                        cmd.Parameters.AddWithValue("@codEntidade", codEntidade);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Logar este erro em vez de mostrar um MessageBox diretamente aqui
                Console.WriteLine($"Erro ao obter ID da unidade por cod_entidade ({codEntidade}): {ex.Message}");
            }
            return -1;
        }

        private int ObterIdMunicipioPorNome(string nomeMunicipio)
        {
            if (string.IsNullOrWhiteSpace(nomeMunicipio)) return -1;
            string query = "SELECT id_municipio FROM municipios WHERE nome = @nomeMunicipio";
            try
            {
                using (MySqlConnection conexao = DBHelper.ObterConexao())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                    {
                        cmd.Parameters.AddWithValue("@nomeMunicipio", nomeMunicipio);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Logar este erro
                Console.WriteLine($"Erro ao obter ID do município por nome ({nomeMunicipio}): {ex.Message}");
            }
            return -1;
        }
    }
}