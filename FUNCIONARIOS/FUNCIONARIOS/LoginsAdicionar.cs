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
    public partial class LoginsAdicionar : Form
    {
        public LoginsAdicionar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logins_Senhas produto = new Logins_Senhas();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 1. Obter o id_unidade a partir do cod_entidade (textBox1)
            //    Assumindo que textBox1.Text contém o cod_entidade da unidade
            string codEntidadeParaUnidade = textBox1.Text.Trim();
            int idUnidade = ObterIdUnidadePorCodEntidade(codEntidadeParaUnidade);

            if (idUnidade == -1)
            {
                MessageBox.Show("O Código da Entidade (Unidade) informado não é válido ou não foi encontrado.", "Erro de Unidade", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Obter o id_municipio a partir do nome do município (textBox2)
            //    Reutilizamos o método ObterIdMunicipioPorNome, que deve estar disponível no seu formulário
            string nomeMunicipioParaCadastro = textBox2.Text.Trim();
            int idMunicipio = ObterIdMunicipioPorNome(nomeMunicipioParaCadastro);

            if (idMunicipio == -1)
            {
                MessageBox.Show("O nome do município informado não é válido ou não foi encontrado no banco de dados. Por favor, verifique.", "Erro de Município", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validação básica do dia de vencimento
            if (!int.TryParse(textBox8.Text.Trim(), out int diaVencimento) || diaVencimento < 1 || diaVencimento > 31)
            {
                MessageBox.Show("O Dia do Vencimento deve ser um número entre 1 e 31.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conexao = DBHelper.ObterConexao())
                {
                    // Inserir o novo cadastro na tabela 'cadastro'
                    // As colunas foram ajustadas para corresponder à sua tabela 'cadastro'
                    string insertQuery = @"
                INSERT INTO cadastro 
                    (id_unidade, id_municipio, sistema, site, login_sistema, senha_sistema, dia_vencimento, observacao) 
                VALUES 
                    (@idUnidade, @idMunicipio, @sistema, @site, @loginSistema, @senhaSistema, @diaVencimento, @observacao)";

                    using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conexao))
                    {
                        // Adiciona os parâmetros com os valores dos TextBoxes e os IDs obtidos
                        insertCmd.Parameters.AddWithValue("@idUnidade", idUnidade);
                        insertCmd.Parameters.AddWithValue("@idMunicipio", idMunicipio);
                        insertCmd.Parameters.AddWithValue("@sistema", textBox4.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@site", textBox5.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@loginSistema", textBox6.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@senhaSistema", textBox7.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@diaVencimento", diaVencimento); // Usamos o int validado
                        insertCmd.Parameters.AddWithValue("@observacao", textBox9.Text.Trim());

                        int linhasAfetadas = insertCmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparCamposCadastroNovaEntrada(); // Novo método para limpar os campos
                                                               // Se você tiver um método para recarregar o DataGridView principal, chame-o aqui
                                                               // Ex: CarregarDados();
                                                               // Se a ComboBox (comboBox1) precisar ser atualizada, chame CarregarComboBox() aqui também
                                                               // Ex: CarregarComboBox();
                        }
                        else
                        {
                            MessageBox.Show("Falha ao realizar o cadastro. Nenhuma linha foi afetada.", "Erro de Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Captura exceções específicas do MySQL
                if (ex.Number == 1062) // Erro 1062: Duplicate entry for key (se tiver alguma PK/UNIQUE aqui)
                {
                    MessageBox.Show("Erro: Um cadastro com essas informações (CNPJ da Unidade, Sistema) já existe. Por favor, verifique os dados.", "Erro de Duplicidade", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Number == 1452) // Erro 1452: Cannot add or update a child row: a foreign key constraint fails
                {
                    MessageBox.Show("Erro de chave estrangeira: A unidade ou município associado não existe no banco de dados. Verifique os IDs.", "Erro de Integridade", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Erro ao realizar o cadastro: {ex.Message} (Código: {ex.Number})", "Erro de Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro inesperado: {ex.Message}", "Erro Geral", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Métodos Auxiliares Necessários ---

        /// <summary>
        /// Obtém o ID da unidade a partir do seu código de entidade (cod_entidade).
        /// </summary>
        /// <param name="codEntidade">O código de entidade da unidade a ser pesquisada.</param>
        /// <returns>O id_unidade correspondente, ou -1 se não encontrado.</returns>
        private int ObterIdUnidadePorCodEntidade(string codEntidade)
        {
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
                // Considere logar este erro em vez de mostrar um MessageBox,
                // pois este método é auxiliar e o erro principal será capturado no button2_Click.
                // MessageBox.Show("Erro ao obter ID da unidade: " + ex.Message, "Erro Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return -1; // Retorna -1 se não encontrar ou houver erro
        }

        /// <summary>
        /// Obtém o ID do município a partir do seu nome.
        /// Este método já foi criado e utilizado anteriormente.
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
                // Considere logar este erro em vez de mostrar um MessageBox.
            }
            return -1; // Retorna -1 se não encontrar ou houver erro
        }

        /// <summary>
        /// Limpa os campos de texto do formulário após um cadastro bem-sucedido.
        /// </summary>
        private void LimparCamposCadastroNovaEntrada()
        {
            textBox1.Clear(); // cod_entidade
            textBox2.Clear(); // nome do município
            textBox4.Clear(); // sistema
            textBox5.Clear(); // site
            textBox6.Clear(); // login_sistema
            textBox7.Clear(); // senha_sistema
            textBox8.Clear(); // dia_vencimento
            textBox9.Clear(); // observacao
        }
    }
}
