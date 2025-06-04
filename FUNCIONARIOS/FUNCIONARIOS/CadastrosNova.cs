using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AGT_FORMS
{
    public partial class CadastrosNova : Form
    {
        public CadastrosNova()
        {
            InitializeComponent();
        }

        private void CadastrosNova_Load(object sender, EventArgs e)
        {

        }


        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            //Botão para voltar para a tela de cadastros
            Cadastros produto = new Cadastros();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            // Obter o ID do município a partir do nome digitado no textBox6
            // Você precisará garantir que o nome do município inserido exista na tabela 'municipios'.
            string nomeMunicipio = textBox6.Text.Trim();
            int idMunicipio = ObterIdMunicipioPorNome(nomeMunicipio); // Reutilizamos o método criado anteriormente

            if (idMunicipio == -1) // Se o município não foi encontrado
            {
                MessageBox.Show("O nome do município informado não é válido ou não foi encontrado no banco de dados. Por favor, verifique.", "Erro de Município", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Sai do método se o município não for válido
            }

            try
            {
                using (MySqlConnection conexao = DBHelper.ObterConexao())
                {
                    // Query para inserir a nova unidade
                    // As colunas foram ajustadas para corresponder à sua tabela 'unidades'
                    string insertQuery = "INSERT INTO unidades (cod_entidade, cnpj, nome_fantasia, endereco, id_municipio, cep) " +
                                         "VALUES (@codEntidade, @cnpj, @nomeFantasia, @endereco, @idMunicipio, @cep)";

                    using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conexao))
                    {
                        // Adiciona os parâmetros com os valores dos TextBoxes e o id_municipio
                        insertCmd.Parameters.AddWithValue("@codEntidade", textBox2.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@cnpj", textBox3.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@nomeFantasia", textBox4.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@endereco", textBox5.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@idMunicipio", idMunicipio); // Usamos o ID do município
                        insertCmd.Parameters.AddWithValue("@cep", textBox7.Text.Trim());

                        // Executa a query de inserção
                        int linhasAfetadas = insertCmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Unidade cadastrada com sucesso!", "Cadastro Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Limpa os campos após o cadastro bem-sucedido
                            LimparCamposCadastro(); // Novo método para limpar os campos
                                                    // Se você tiver um método para recarregar o DataGridView principal, chame-o aqui
                                                    // Ex: CarregarDados();
                                                    // Se a ComboBox (comboBox1) precisar ser atualizada, chame CarregarComboBox() aqui também
                                                    // Ex: CarregarComboBox();
                        }
                        else
                        {
                            MessageBox.Show("Falha ao cadastrar a unidade. Nenhuma linha foi afetada.", "Erro de Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Captura exceções específicas do MySQL, como violações de unicidade (ex: CNPJ ou cod_entidade duplicado)
                if (ex.Number == 1062) // Erro 1062 é geralmente "Duplicate entry for key"
                {
                    MessageBox.Show("Erro: O CNPJ ou Código da Entidade que você tentou inserir já existe. Por favor, verifique os dados.", "Erro de Duplicidade", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Captura exceções de chave estrangeira, caso o id_municipio seja inválido por algum motivo
                else if (ex.Number == 1452) // Erro 1452 é geralmente "Cannot add or update a child row: a foreign key constraint fails"
                {
                    MessageBox.Show("Erro: O município informado não existe no banco de dados. Por favor, selecione um município válido.", "Erro de Chave Estrangeira", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Erro ao cadastrar a unidade: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro inesperado: {ex.Message}", "Erro Geral", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Reutilizando o método ObterIdMunicipioPorNome, se ele não estiver no mesmo arquivo, você pode copiá-lo
        /// <summary>
        /// Obtém o ID do município a partir do seu nome.
        /// </summary>
        /// <param name="nomeMunicipio">O nome do município a ser pesquisado.</param>
        /// <returns>O id_municipio correspondente, ou -1 se não encontrado.</returns>
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
                // Considere logar este erro em vez de mostrar um MessageBox,
                // pois este método é auxiliar e o erro principal será capturado no buttonCadastrar_Click.
                // MessageBox.Show("Erro ao obter ID do município: " + ex.Message, "Erro Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return -1; // Retorna -1 se não encontrar ou houver erro
        }

        /// <summary>
        /// Limpa os campos de texto do formulário de cadastro de unidade.
        /// </summary>
        private void LimparCamposCadastro()
        {
            textBox2.Clear(); // cod_entidade
            textBox3.Clear(); // cnpj
            textBox4.Clear(); // nome_fantasia
            textBox5.Clear(); // endereco
            textBox6.Clear(); // nome do município (input)
            textBox7.Clear(); // cep
        }


        // As classes e outros métodos (ComboBoxItem, label3_Click, button1_Click) permanecem inalterados
        private class ComboBoxItem
        {
            public string Display { get; set; }
            public string Value { get; set; }

            public ComboBoxItem(string display, string value)
            {
                Display = display;
                Value = value;
            }

            public override string ToString()
            {
                return Display; // o que será mostrado no comboBox
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Este método está vazio, pode ser deixado como está ou removido se não for usado.
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // BOTÃO PARA REQUISITAR OS DADOS DO CNPJ
            string cnpj = textBox3.Text.Trim();

            if (string.IsNullOrEmpty(cnpj))
            {
                MessageBox.Show("Por favor, informe um CNPJ.", "CNPJ Ausente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Assumimos que 'ReceitaFederalService' e 'ConsultarCNPJAsync' estão implementados corretamente.
            // Certifique-se de ter a referência ao namespace onde 'ReceitaFederalService' está definida.
            var service = new ReceitaFederalService();
            var dados = await service.ConsultarCNPJAsync(cnpj);

            if (dados != null)
            {
                textBox4.Text = dados.fantasia ?? "";
                textBox5.Text = $"{dados.logradouro}, {dados.numero} {dados.bairro}".Trim() ?? ""; // Ajuste para melhor formatação
                textBox6.Text = dados.municipio ?? ""; // Recebe o nome do município
                textBox7.Text = dados.cep ?? "";
            }
            else
            {
                MessageBox.Show("Não foi possível consultar o CNPJ. Verifique o número ou tente novamente mais tarde.", "Erro na Consulta de CNPJ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
