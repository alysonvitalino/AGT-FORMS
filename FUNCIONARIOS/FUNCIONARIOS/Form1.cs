using MySql.Data.MySqlClient;
using System.Data;

namespace FUNCIONARIOS
{
    public partial class Form1 : Form
    {
        MySqlConnection conexao;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string data_source = "datasource=localhost; username=root;password='';database=funcionarios";
                conexao = new MySqlConnection(data_source);
                string sql = "INSERT INTO funcionario(nome,email) values('" + textBox1.Text + "','" + textBox2.Text + "')";
                MySqlCommand comando = new MySqlCommand(sql, conexao);
                conexao.Open();
                comando.ExecuteReader();
                MessageBox.Show("Cadastro realizado com sucesso!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string data_source = "datasource=localhost; username=root;password='';database=funcionarios";
                conexao = new MySqlConnection(data_source);
                string sql = "DELETE FROM funcionario WHERE id_funcionario=" + Convert.ToInt32(textBox3.Text) + ";";
                //MessageBox.Show(sql);
                MySqlCommand comando = new MySqlCommand(sql, conexao);
                conexao.Open();
                comando.ExecuteReader();
                MessageBox.Show("Cadastro deletado com sucesso!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            //select * from funcionario;
            string data_source = "datasource=localhost; username=root;password='';database=funcionarios";
            conexao = new MySqlConnection(data_source);
            string sql = "SELECT * FROM funcionario;";
            //MessageBox.Show(sql);
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            conexao.Open();

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(comando);
            DataTable dataTable = new DataTable();

            // Preenche o DataTable com os dados
            dataAdapter.Fill(dataTable);

            // Define o DataSource do DataGridView para o DataTable
            dataGridView1.DataSource = dataTable;

            MessageBox.Show("Dados carregados com sucesso!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 produto = new Form2();
            produto.StartPosition = FormStartPosition.CenterScreen; // Ajusta a posição da janela
            produto.Show();
            Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        
    }
}
