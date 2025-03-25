namespace FUNCIONARIOS
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolStripTextBox1 = new ToolStripTextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            calculadoraToolStripMenuItem = new ToolStripMenuItem();
            cadastrosToolStripMenuItem = new ToolStripMenuItem();
            leisEAlíquotasToolStripMenuItem = new ToolStripMenuItem();
            loginsESenhasToolStripMenuItem = new ToolStripMenuItem();
            button1 = new Button();
            button4 = new Button();
            btnLogins = new Button();
            label4 = new Label();
            button6 = new Button();
            button3 = new Button();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(100, 23);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(92, 69);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 11;
            label1.Text = "Valor:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(92, 86);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(134, 23);
            textBox1.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(92, 111);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 13;
            label2.Text = "Município:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(92, 155);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 15;
            label3.Text = "Serviço:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(16, 229);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(285, 209);
            dataGridView1.TabIndex = 17;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(4, 1, 0, 1);
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 18;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { calculadoraToolStripMenuItem, cadastrosToolStripMenuItem, leisEAlíquotasToolStripMenuItem, loginsESenhasToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(50, 22);
            menuToolStripMenuItem.Text = "Menu";
            menuToolStripMenuItem.Click += menuToolStripMenuItem_Click;
            // 
            // calculadoraToolStripMenuItem
            // 
            calculadoraToolStripMenuItem.Name = "calculadoraToolStripMenuItem";
            calculadoraToolStripMenuItem.Size = new Size(158, 22);
            calculadoraToolStripMenuItem.Text = "Calculadora";
            calculadoraToolStripMenuItem.Click += calculadoraToolStripMenuItem_Click;
            // 
            // cadastrosToolStripMenuItem
            // 
            cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            cadastrosToolStripMenuItem.Size = new Size(158, 22);
            cadastrosToolStripMenuItem.Text = "Cadastros";
            cadastrosToolStripMenuItem.Click += cadastrosToolStripMenuItem_Click;
            // 
            // leisEAlíquotasToolStripMenuItem
            // 
            leisEAlíquotasToolStripMenuItem.Name = "leisEAlíquotasToolStripMenuItem";
            leisEAlíquotasToolStripMenuItem.Size = new Size(158, 22);
            leisEAlíquotasToolStripMenuItem.Text = "Leis e Alíquotas";
            leisEAlíquotasToolStripMenuItem.Click += leisEAlíquotasToolStripMenuItem_Click;
            // 
            // loginsESenhasToolStripMenuItem
            // 
            loginsESenhasToolStripMenuItem.Name = "loginsESenhasToolStripMenuItem";
            loginsESenhasToolStripMenuItem.Size = new Size(158, 22);
            loginsESenhasToolStripMenuItem.Text = "Logins e Senhas";
            loginsESenhasToolStripMenuItem.Click += loginsESenhasToolStripMenuItem_Click;
            // 
            // button1
            // 
            button1.Location = new Point(342, 83);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(172, 122);
            button1.TabIndex = 19;
            button1.Text = "Alíquotas";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button4
            // 
            button4.Location = new Point(342, 229);
            button4.Margin = new Padding(2);
            button4.Name = "button4";
            button4.Size = new Size(172, 122);
            button4.TabIndex = 21;
            button4.Text = "Cadastros";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // btnLogins
            // 
            btnLogins.Location = new Point(584, 229);
            btnLogins.Margin = new Padding(2);
            btnLogins.Name = "btnLogins";
            btnLogins.Size = new Size(172, 122);
            btnLogins.TabIndex = 22;
            btnLogins.Text = "Login e Senhas";
            btnLogins.UseVisualStyleBackColor = true;
            btnLogins.Click += btnUsuario_Click_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(92, 37);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(135, 21);
            label4.TabIndex = 23;
            label4.Text = "Bem Vindo @user";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // button6
            // 
            button6.Location = new Point(107, 200);
            button6.Margin = new Padding(2);
            button6.Name = "button6";
            button6.Size = new Size(101, 25);
            button6.TabIndex = 24;
            button6.Text = "CALCULAR";
            button6.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(584, 83);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(172, 122);
            button3.TabIndex = 26;
            button3.Text = "Calculadora";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(92, 129);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 27;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(92, 172);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 28;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(button3);
            Controls.Add(button6);
            Controls.Add(label4);
            Controls.Add(btnLogins);
            Controls.Add(button4);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AGT";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStripTextBox toolStripTextBox1;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem calculadoraToolStripMenuItem;
        private ToolStripMenuItem cadastrosToolStripMenuItem;
        private ToolStripMenuItem leisEAlíquotasToolStripMenuItem;
        private Button button1;
        private Button button4;
        private Button btnLogins;
        private Label label4;
        private Button button6;
        private Button button3;
        private ToolStripMenuItem loginsESenhasToolStripMenuItem;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
    }
}
