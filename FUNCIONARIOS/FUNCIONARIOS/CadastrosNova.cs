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

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string cnpj = textBox3.Text;
            string token = "SEU_TOKEN_AQUI"; // Substitua pelo seu token
            string plugin = "RF";

            try
            {
                var dados = await ConsultaCNPJ.Program.ConsultarCNPJAsync(token, cnpj, plugin);

                if (dados.code == "0")
                {
                    textBox4.Text = dados.fantasia;
                    textBox5.Text = $"{dados.logradouro}, {dados.numero}";
                    textBox6.Text = dados.municipio;
                    textBox7.Text = dados.cep;
                }
                else
                {
                    MessageBox.Show("Erro ao consultar CNPJ: " + dados.message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar com a API: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
