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

            try
            {
                using (MySqlConnection conexao = DBHelper.ObterConexao())
                {
                    

                    // Inserir a nova unidade
                    string insertQuery = "INSERT INTO unidades (cod_entidade, cnpj_unidade, nome_fantasia, endereco_unidade, cidade_unidade, cep_unidade) " +
                                         "VALUES (@codEntidade, @cnpj, @nomeFantasia, @endereco, @cidade, @cep)";

                    using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conexao))
                    {
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
            //BOTÃO PARA REQUISITAR OS DADOS DO CNPJ
            //https://www.gov.br/conecta/catalogo/apis/consulta-cnpj/swagger.json/swagger_view#tag/cnpj/paths/~1api-cnpj-qsa~1v2~1qsa~1{CNPJqsa}/get
            string cnpj = textBox3.Text.Trim();

            if (string.IsNullOrEmpty(cnpj))
            {
                MessageBox.Show("Por favor, informe um CNPJ.");
                return;
            }

            var service = new ReceitaFederalService();
            var dados = await service.ConsultarCNPJAsync(cnpj);

            if (dados != null)
            {
                textBox4.Text = dados.fantasia ?? ""; 
                textBox5.Text = $"{dados.logradouro}, {dados.numero} {dados.bairro}" ?? "";
                textBox6.Text = dados.municipio ?? ""; 
                textBox7.Text = dados.cep ?? ""; 
            }
        }
    }
}
