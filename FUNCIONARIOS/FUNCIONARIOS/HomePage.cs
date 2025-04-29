using MySql.Data.MySqlClient;
using System.Data;

namespace AGT_FORMS
{
    public partial class HomePage : Form
    {
        private string nomeUsuario;
        public HomePage(string usuario)
        {
            InitializeComponent();
            nomeUsuario = usuario;
        }
        public HomePage()
        {
            InitializeComponent();
        }
        public static int ObterContadorExcel()
        {
            using (MySqlConnection conexao = DBHelper.ObterConexao())
            {
                string sql = "SELECT quantidade FROM contador_relatorios WHERE id = 1";
                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                object resultado = cmd.ExecuteScalar();
                return resultado != null ? Convert.ToInt32(resultado) : 0;
            }
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            label3.Text = $"Olá, {nomeUsuario}! Acesse as funcionalidades no menu ao lado";
            int totalCliques = ObterContadorExcel();
            labelContador1.Text = $"Total de exportações em Excel: {totalCliques}";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LoginPage produto = new LoginPage();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }
        private void btnUsuario_Click_1(object sender, EventArgs e)
        {
            Logins_Senhas produto = new Logins_Senhas();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Aliquotas produto = new Aliquotas();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Cadastros produto = new Cadastros();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            calculadora produto = new calculadora();
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
    }
}
