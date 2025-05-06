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
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            CarregarComboBox();
            CarregarComboBox1();
        }

        private void CarregarComboBox()
        {
            string query = "SELECT cod_erp FROM unidades";

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
                                string item = reader["cod_erp"].ToString();
                                comboBox2.Items.Add(item);
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codErpSelecionado = comboBox2.SelectedItem.ToString();

            string query = "SELECT id_unidade, cep_unidade, cidade_unidade, endereco_unidade, nome_fantasia, cnpj_unidade, cod_entidade, cod_erp " +
                           "FROM unidades WHERE cod_erp = @cod_erp";

            try
            {
                using (MySqlConnection conexao = DBHelper.ObterConexao())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                    {
                        cmd.Parameters.AddWithValue("@cod_erp", codErpSelecionado);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox8.Text = reader["cep_unidade"].ToString();
                                textBox9.Text = reader["cidade_unidade"].ToString();
                                textBox10.Text = reader["endereco_unidade"].ToString();
                                textBox11.Text = reader["nome_fantasia"].ToString();
                                textBox12.Text = reader["cnpj_unidade"].ToString();
                                textBox13.Text = reader["cod_entidade"].ToString();
                                textBox14.Text = reader["cod_erp"].ToString(); // opcional, já está no combo
                                textBox15.Text = reader["id_unidade"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados da unidade: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string query = "UPDATE unidades SET cod_erp = @codErp, cep_unidade = @cep, cidade_unidade = @cidade, endereco_unidade = @endereco, " +
                  "nome_fantasia = @nomeFantasia, cnpj_unidade = @cnpj, cod_entidade = @codEntidade " +
                  "WHERE id_unidade = @idUnidade";


            try
            {
                using (MySqlConnection conexao = DBHelper.ObterConexao())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                    {
                        cmd.Parameters.AddWithValue("@cep", textBox8.Text);
                        cmd.Parameters.AddWithValue("@cidade", textBox9.Text);
                        cmd.Parameters.AddWithValue("@endereco", textBox10.Text);
                        cmd.Parameters.AddWithValue("@nomeFantasia", textBox11.Text);
                        cmd.Parameters.AddWithValue("@cnpj", textBox12.Text);
                        cmd.Parameters.AddWithValue("@codEntidade", textBox13.Text);
                        cmd.Parameters.AddWithValue("@codErp", Convert.ToInt64(textBox14.Text)); // ou comboBox2.SelectedItem.ToString()
                        cmd.Parameters.AddWithValue("@idUnidade", Convert.ToInt64(textBox15.Text));

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Dados atualizados com sucesso!");
                            CarregarComboBox();
                            comboBox2.SelectedItem = textBox14.Text;

                        }
                        else
                        {
                            MessageBox.Show("Nenhum dado foi atualizado.");
                        }
                            
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar os dados: " + ex.Message);
            }
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            //Botão para limpar todos os textBox
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
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
            string codErp = textBox1.Text;

            if (string.IsNullOrWhiteSpace(codErp))
            {
                MessageBox.Show("O campo 'cod_erp' é obrigatório.");
                return;
            }

            try
            {
                using (MySqlConnection conexao = DBHelper.ObterConexao())
                {
                    // Verificar se já existe uma unidade com o mesmo cod_erp
                    string checkQuery = "SELECT COUNT(*) FROM unidades WHERE cod_erp = @codErp";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conexao))
                    {
                        checkCmd.Parameters.AddWithValue("@codErp", codErp);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Já existe uma unidade com este código ERP.");
                            return;
                        }
                    }

                    // Inserir a nova unidade
                    string insertQuery = "INSERT INTO unidades (cod_erp, cod_entidade, cnpj_unidade, nome_fantasia, endereco_unidade, cidade_unidade, cep_unidade) " +
                                         "VALUES (@codErp, @codEntidade, @cnpj, @nomeFantasia, @endereco, @cidade, @cep)";

                    using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conexao))
                    {
                        insertCmd.Parameters.AddWithValue("@codErp", codErp);
                        insertCmd.Parameters.AddWithValue("@codEntidade", textBox2.Text);
                        insertCmd.Parameters.AddWithValue("@cnpj", textBox3.Text);
                        insertCmd.Parameters.AddWithValue("@nomeFantasia", textBox4.Text);
                        insertCmd.Parameters.AddWithValue("@endereco", textBox5.Text);
                        insertCmd.Parameters.AddWithValue("@cidade", textBox6.Text);
                        insertCmd.Parameters.AddWithValue("@cep", textBox7.Text);

                        int linhasAfetadas = insertCmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Unidade cadastrada com sucesso!");
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();
                            textBox5.Clear();
                            textBox6.Clear();
                            textBox7.Clear();
                            CarregarComboBox();
                        }
                        else
                        {
                            MessageBox.Show("Falha ao cadastrar a unidade.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar a unidade: " + ex.Message);
            }
        }
        private void CarregarComboBox1()
        {
            string query = "SELECT cod_erp, nome_fantasia, cnpj_unidade FROM unidades";

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
                                string codErp = reader["cod_erp"].ToString();
                                string nomeFantasia = reader["nome_fantasia"].ToString();
                                string cnpj = reader["cnpj_unidade"].ToString();

                                // Exibe as informações formatadas, mas armazena o codErp
                                string displayText = $"{codErp} - {nomeFantasia} - {cnpj}";
                                comboBox1.Items.Add(new ComboBoxItem(displayText, codErp));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar ComboBox1: " + ex.Message);
            }
        }
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is ComboBoxItem selectedItem)
            {
                string codErp = selectedItem.Value;

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
                                    CarregarComboBox1(); // atualiza lista
                                    CarregarComboBox();
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

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
