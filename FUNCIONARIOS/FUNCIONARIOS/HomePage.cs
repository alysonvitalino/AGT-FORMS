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
            nomeUsuario = " " + usuario;
        }
        public HomePage()
        {
            InitializeComponent();
        }

        Image imgAliquota, imgLogins, imgCalculadora, imgCadastros, imgHomePage;
        private void HomePage_Load(object sender, EventArgs e)
        {
            imgAliquota = Properties.Resources.ImagemAliquota;
            imgLogins = Properties.Resources.ImagemLogins;
            imgCalculadora = Properties.Resources.ImagemCalculadora;
            imgCadastros = Properties.Resources.ImagemCadastro;
            imgHomePage = Properties.Resources.HomePageImagem;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {

        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {

        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {

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

        private void button1_MouseEnter_1(object sender, EventArgs e)
        {
            pictureBox1.Image = imgAliquota;
        }

        private void btnLogins_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = imgLogins;
        }

        private void button4_MouseEnter_1(object sender, EventArgs e)
        {
            pictureBox1.Image = imgCadastros;
        }

        private void button3_MouseEnter_1(object sender, EventArgs e)
        {
            pictureBox1.Image = imgCalculadora;
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = imgHomePage;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = imgHomePage;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = imgHomePage;
        }

        private void btnLogins_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = imgHomePage;
        }
    }
}
