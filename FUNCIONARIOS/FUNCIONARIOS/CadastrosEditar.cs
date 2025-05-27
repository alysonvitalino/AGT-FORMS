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

            string query = "SELECT cep_unidade, cidade_unidade, endereco_unidade, nome_fantasia, cnpj_unidade, cod_entidade, cod_erp " +
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
                  "WHERE cod_erp = @codErp";


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
                        cmd.Parameters.AddWithValue("@codErp", comboBox2.SelectedItem?.ToString());

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Dados atualizados com sucesso!");
                            CarregarComboBox();

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

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            Cadastros produto = new Cadastros();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }
    }
}
