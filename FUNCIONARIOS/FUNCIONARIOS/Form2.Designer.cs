namespace FUNCIONARIOS
{
    partial class Aliquotas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            comboBox1 = new ComboBox();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            button1 = new Button();
            button3 = new Button();
            button4 = new Button();
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            paginaInicialToolStripMenuItem = new ToolStripMenuItem();
            calculadoraToolStripMenuItem = new ToolStripMenuItem();
            cadastrosToolStripMenuItem = new ToolStripMenuItem();
            leisEAlíquotasToolStripMenuItem = new ToolStripMenuItem();
            loginsESenhasToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 34);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(127, 15);
            label1.TabIndex = 0;
            label1.Text = "Selecione o município:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(19, 62);
            comboBox1.Margin = new Padding(2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(129, 23);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(19, 102);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(639, 333);
            dataGridView1.TabIndex = 2;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Location = new Point(676, 102);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(104, 58);
            button2.TabIndex = 21;
            button2.Text = "Página Inicial";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(676, 286);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(104, 58);
            button1.TabIndex = 22;
            button1.Text = "Cadastros";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.Location = new Point(676, 376);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(104, 58);
            button3.TabIndex = 23;
            button3.Text = "Calculadora";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.Location = new Point(676, 191);
            button4.Margin = new Padding(2);
            button4.Name = "button4";
            button4.Size = new Size(104, 58);
            button4.TabIndex = 24;
            button4.Text = "Logins e Senhas";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 25;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { paginaInicialToolStripMenuItem, calculadoraToolStripMenuItem, cadastrosToolStripMenuItem, leisEAlíquotasToolStripMenuItem, loginsESenhasToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(50, 20);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // paginaInicialToolStripMenuItem
            // 
            paginaInicialToolStripMenuItem.Name = "paginaInicialToolStripMenuItem";
            paginaInicialToolStripMenuItem.Size = new Size(158, 22);
            paginaInicialToolStripMenuItem.Text = "Pagina Inicial";
            paginaInicialToolStripMenuItem.Click += paginaInicialToolStripMenuItem_Click;
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
            // Aliquotas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Aliquotas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AGT - Aliquotas";
            WindowState = FormWindowState.Maximized;
            Load += Aliquotas_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button1;
        private Button button3;
        private Button button4;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem calculadoraToolStripMenuItem;
        private ToolStripMenuItem cadastrosToolStripMenuItem;
        private ToolStripMenuItem leisEAlíquotasToolStripMenuItem;
        private ToolStripMenuItem loginsESenhasToolStripMenuItem;
        private ToolStripMenuItem paginaInicialToolStripMenuItem;
    }
}