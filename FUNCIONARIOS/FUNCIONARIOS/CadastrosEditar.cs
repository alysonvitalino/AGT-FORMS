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
    public partial class CadastrosEditar : Form
    {
        public CadastrosEditar()
        {
            InitializeComponent();
        }
        private void CadastrosEditar_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            CarregarComboBox();
        }


        private void CarregarComboBox()
        {
            // Carrega os 'cod_entidade' para o comboBox2
            string query = "SELECT DISTINCT cod_entidade FROM unidades ORDER BY cod_entidade ASC";

            try
            {
                using (MySqlConnection conexao = DBHelper.ObterConexao())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            comboBox2.Items.Clear();
                            while (reader.Read())
                            {
                                string item = reader["cod_entidade"].ToString();
                                comboBox2.Items.Add(item);
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                // Limpa os campos se nada estiver selecionado (ex: após uma exclusão)
                LimparCamposUnidade();
                return;
            }

            string codEntidadeSelecionado = comboBox2.SelectedItem.ToString();

            // A query agora faz um JOIN com a tabela municipios para obter o nome do município
            string query = @"
        SELECT 
            u.cep, 
            m.nome AS nome_municipio, 
            u.endereco, 
            u.nome_fantasia, 
            u.cnpj, 
            u.cod_entidade,
            u.id_municipio -- Precisaremos do id_municipio para a atualização
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
                    using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                    {
                        cmd.Parameters.AddWithValue("@codEntidade", codEntidadeSelecionado);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox8.Text = reader["cep"].ToString();
                                textBox9.Text = reader["nome_municipio"].ToString(); // Agora é o nome do município
                                textBox10.Text = reader["endereco"].ToString();
                                textBox11.Text = reader["nome_fantasia"].ToString();
                                textBox12.Text = reader["cnpj"].ToString();
                                textBox13.Text = reader["cod_entidade"].ToString();
                                // Guardar o id_municipio para uso futuro (ex: atualização)
                                // Você pode armazenar em uma variável de classe ou no Tag da ComboBox/Form
                                // Exemplo:
                                this.Tag = reader["id_municipio"].ToString(); // Armazena o id_municipio no Tag do formulário
                            }
                            else
                            {
                                // Caso não encontre dados para o item selecionado (improvável se a ComboBox for bem carregada)
                                LimparCamposUnidade();
                                MessageBox.Show("Dados da unidade não encontrados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados da unidade: " + ex.Message, "Erro de Carregamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma unidade para atualizar.", "Nenhuma Unidade Selecionada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // O valor original do cod_entidade para a cláusula WHERE
            string codEntidadeOriginal = comboBox2.SelectedItem.ToString();

            // Obter o id_municipio a partir do nome do município no textBox9.Text
            // Você precisa de uma consulta separada para isso ou ter o id_municipio armazenado.
            int idMunicipio = ObterIdMunicipioPorNome(textBox9.Text);

            if (idMunicipio == -1) // Se o município não foi encontrado
            {
                MessageBox.Show("O nome do município informado não é válido ou não foi encontrado no banco de dados. Por favor, verifique.", "Erro de Município", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // A query de UPDATE agora usa as colunas corretas da tabela 'unidades'
            // E o id_municipio para a cidade.
            string query = @"
        UPDATE unidades SET 
            cep = @cep, 
            id_municipio = @idMunicipio, 
            endereco = @endereco, 
            nome_fantasia = @nomeFantasia, 
            cnpj = @cnpj, 
            cod_entidade = @codEntidadeNovo 
        WHERE 
            cod_entidade = @codEntidadeOriginal"; // Usamos o cod_entidade original para encontrar o registro

            try
            {
                using (MySqlConnection conexao = DBHelper.ObterConexao())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                    {
                        // Adiciona os parâmetros para a atualização
                        cmd.Parameters.AddWithValue("@cep", textBox8.Text);
                        cmd.Parameters.AddWithValue("@idMunicipio", idMunicipio); // Usamos o ID do município
                        cmd.Parameters.AddWithValue("@endereco", textBox10.Text);
                        cmd.Parameters.AddWithValue("@nomeFantasia", textBox11.Text);
                        cmd.Parameters.AddWithValue("@cnpj", textBox12.Text);
                        cmd.Parameters.AddWithValue("@codEntidadeNovo", textBox13.Text); // O novo valor do cod_entidade, caso tenha sido alterado
                        cmd.Parameters.AddWithValue("@codEntidadeOriginal", codEntidadeOriginal); // O valor original para a cláusula WHERE

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Dados atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            comboBox2.SelectedIndex = -1;
                            LimparCamposUnidade();
                            CarregarComboBox(); // Atualiza o combo para refletir qualquer mudança no cod_entidade
                                                // Se você tiver um CarregarDados() que preenche um DataGridView, chame-o aqui também:
                                                // CarregarDados();
                        }
                        else
                        {
                            MessageBox.Show("Nenhum dado foi atualizado. Verifique se o código da entidade original ainda existe.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Captura exceções específicas do MySQL, como violações de unicidade (ex: CNPJ duplicado)
                if (ex.Number == 1062) // Erro 1062 é geralmente "Duplicate entry for key"
                {
                    MessageBox.Show("Erro: O CNPJ ou Código da Entidade que você tentou inserir já existe. Por favor, verifique os dados.", "Erro de Duplicidade", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Erro ao atualizar os dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro inesperado: {ex.Message}", "Erro Geral", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <param name="nomeMunicipio">O nome do município a ser pesquisado.</param>
        private int ObterIdMunicipioPorNome(string nomeMunicipio)
        {
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
                MessageBox.Show("Erro ao obter ID do município: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return -1; // Retorna -1 se não encontrar ou houver erro
        }
        private void LimparCamposUnidade()
        {
            textBox8.Text = ""; // CEP
            textBox9.Text = ""; // Cidade
            textBox10.Text = ""; // Endereço
            textBox11.Text = ""; // Nome Fantasia
            textBox12.Text = ""; // CNPJ
            textBox13.Text = ""; // Código da Entidade
            this.Tag = null; // Limpa o Tag do formulário
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            Cadastros produto = new Cadastros();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }
    }
}
