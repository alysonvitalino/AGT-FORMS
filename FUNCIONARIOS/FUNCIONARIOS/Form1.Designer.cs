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
            toolStripTextBox1 = new ToolStripTextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            listBox1 = new ListBox();
            label3 = new Label();
            listBox2 = new ListBox();
            dataGridView1 = new DataGridView();
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            calculadoraToolStripMenuItem = new ToolStripMenuItem();
            cadastrosToolStripMenuItem = new ToolStripMenuItem();
            leisEAlíquotasToolStripMenuItem = new ToolStripMenuItem();
            button1 = new Button();
            button2 = new Button();
            button4 = new Button();
            btnLogins = new Button();
            label4 = new Label();
            button6 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Margin = new Padding(1, 0, 1, 0);
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(100, 23);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(131, 135);
            label1.Name = "label1";
            label1.Size = new Size(56, 25);
            label1.TabIndex = 11;
            label1.Text = "Valor:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(131, 163);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(189, 31);
            textBox1.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(131, 197);
            label2.Name = "label2";
            label2.Size = new Size(94, 25);
            label2.TabIndex = 13;
            label2.Text = "Município:";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Items.AddRange(new object[] { "Curitiba", "Pinhais", "Fazenda Rio Grande" });
            listBox1.Location = new Point(131, 225);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(189, 29);
            listBox1.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(131, 257);
            label3.Name = "label3";
            label3.Size = new Size(73, 25);
            label3.TabIndex = 15;
            label3.Text = "Serviço:";
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 25;
            listBox2.Items.AddRange(new object[] { "7.04 Demolição - 5%" });
            listBox2.Location = new Point(131, 285);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(189, 29);
            listBox2.TabIndex = 16;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(23, 381);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(407, 349);
            dataGridView1.TabIndex = 17;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1143, 33);
            menuStrip1.TabIndex = 18;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { calculadoraToolStripMenuItem, cadastrosToolStripMenuItem, leisEAlíquotasToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(73, 29);
            menuToolStripMenuItem.Text = "Menu";
            menuToolStripMenuItem.Click += menuToolStripMenuItem_Click;
            // 
            // calculadoraToolStripMenuItem
            // 
            calculadoraToolStripMenuItem.Name = "calculadoraToolStripMenuItem";
            calculadoraToolStripMenuItem.Size = new Size(237, 34);
            calculadoraToolStripMenuItem.Text = "Calculadora";
            // 
            // cadastrosToolStripMenuItem
            // 
            cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            cadastrosToolStripMenuItem.Size = new Size(237, 34);
            cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // leisEAlíquotasToolStripMenuItem
            // 
            leisEAlíquotasToolStripMenuItem.Name = "leisEAlíquotasToolStripMenuItem";
            leisEAlíquotasToolStripMenuItem.Size = new Size(237, 34);
            leisEAlíquotasToolStripMenuItem.Text = "Leis e Alíquotas";
            // 
            // button1
            // 
            button1.Location = new Point(489, 139);
            button1.Name = "button1";
            button1.Size = new Size(245, 204);
            button1.TabIndex = 19;
            button1.Text = "Alíquotas";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Location = new Point(0, 0);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 25;
            // 
            // button4
            // 
            button4.Location = new Point(489, 381);
            button4.Name = "button4";
            button4.Size = new Size(245, 204);
            button4.TabIndex = 21;
            button4.Text = "Cadastros";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // btnLogins
            // 
            btnLogins.Location = new Point(835, 381);
            btnLogins.Name = "btnLogins";
            btnLogins.Size = new Size(245, 204);
            btnLogins.TabIndex = 22;
            btnLogins.Text = "Login e Senhas";
            btnLogins.UseVisualStyleBackColor = true;
            btnLogins.Click += btnUsuario_Click_1;
            // 
            // label4
            // 
            label4.Location = new Point(48, 77);
            label4.Name = "label4";
            label4.Size = new Size(318, 54);
            label4.TabIndex = 23;
            label4.Text = "Bem Vindo @user";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button6
            // 
            button6.Location = new Point(153, 334);
            button6.Name = "button6";
            button6.Size = new Size(144, 41);
            button6.TabIndex = 24;
            button6.Text = "CALCULAR";
            button6.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(835, 139);
            button3.Name = "button3";
            button3.Size = new Size(245, 204);
            button3.TabIndex = 26;
            button3.Text = "Calculadora";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(button3);
            Controls.Add(button6);
            Controls.Add(label4);
            Controls.Add(btnLogins);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(listBox2);
            Controls.Add(label3);
            Controls.Add(listBox1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AGT";
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
        private ListBox listBox1;
        private Label label3;
        private ListBox listBox2;
        private DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem calculadoraToolStripMenuItem;
        private ToolStripMenuItem cadastrosToolStripMenuItem;
        private ToolStripMenuItem leisEAlíquotasToolStripMenuItem;
        private Button button1;
        private Button button2;
        private Button button4;
        private Button btnLogins;
        private Label label4;
        private Button button6;
        private Button button3;
    }
}
