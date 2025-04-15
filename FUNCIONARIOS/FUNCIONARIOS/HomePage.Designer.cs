namespace AGT_FORMS
{
    partial class HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            toolStripTextBox1 = new ToolStripTextBox();
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            calculadoraToolStripMenuItem = new ToolStripMenuItem();
            cadastrosToolStripMenuItem = new ToolStripMenuItem();
            leisEAlíquotasToolStripMenuItem = new ToolStripMenuItem();
            loginsESenhasToolStripMenuItem = new ToolStripMenuItem();
            button1 = new Button();
            button4 = new Button();
            btnLogins = new Button();
            button3 = new Button();
            label1 = new Label();
            labelUsuario = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(100, 23);
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(18, 87, 123);
            menuStrip1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(4, 1, 0, 1);
            menuStrip1.Size = new Size(1001, 24);
            menuStrip1.TabIndex = 18;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { calculadoraToolStripMenuItem, cadastrosToolStripMenuItem, leisEAlíquotasToolStripMenuItem, loginsESenhasToolStripMenuItem });
            menuToolStripMenuItem.ForeColor = Color.FromArgb(247, 247, 247);
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
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(18, 87, 123);
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.ForeColor = Color.FromArgb(169, 207, 229);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(523, 116);
            button1.Margin = new Padding(1);
            button1.Name = "button1";
            button1.Size = new Size(195, 180);
            button1.TabIndex = 19;
            button1.Text = "Alíquotas";
            button1.TextAlign = ContentAlignment.BottomCenter;
            button1.TextImageRelation = TextImageRelation.ImageAboveText;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.BackColor = Color.FromArgb(18, 87, 123);
            button4.Cursor = Cursors.Hand;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button4.ForeColor = Color.FromArgb(169, 207, 229);
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.Location = new Point(523, 343);
            button4.Margin = new Padding(1);
            button4.Name = "button4";
            button4.Size = new Size(195, 180);
            button4.TabIndex = 21;
            button4.Text = "Cadastros";
            button4.TextAlign = ContentAlignment.BottomCenter;
            button4.TextImageRelation = TextImageRelation.ImageAboveText;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // btnLogins
            // 
            btnLogins.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogins.BackColor = Color.FromArgb(18, 87, 123);
            btnLogins.Cursor = Cursors.Hand;
            btnLogins.FlatStyle = FlatStyle.Flat;
            btnLogins.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLogins.ForeColor = Color.FromArgb(169, 207, 229);
            btnLogins.Image = (Image)resources.GetObject("btnLogins.Image");
            btnLogins.Location = new Point(771, 343);
            btnLogins.Margin = new Padding(1);
            btnLogins.Name = "btnLogins";
            btnLogins.Size = new Size(195, 180);
            btnLogins.TabIndex = 22;
            btnLogins.Text = "Login e Senhas";
            btnLogins.TextAlign = ContentAlignment.BottomCenter;
            btnLogins.TextImageRelation = TextImageRelation.ImageAboveText;
            btnLogins.UseVisualStyleBackColor = false;
            btnLogins.Click += btnUsuario_Click_1;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.BackColor = Color.FromArgb(18, 87, 123);
            button3.Cursor = Cursors.Hand;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button3.ForeColor = Color.FromArgb(169, 207, 229);
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(771, 116);
            button3.Margin = new Padding(1);
            button3.Name = "button3";
            button3.Size = new Size(195, 180);
            button3.TabIndex = 26;
            button3.Text = "Calculadora";
            button3.TextAlign = ContentAlignment.BottomCenter;
            button3.TextImageRelation = TextImageRelation.ImageAboveText;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 148);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(295, 15);
            label1.TabIndex = 27;
            label1.Text = "TEXTO INTRODUTÓRIO E EXPLICATIVO DO PROGRAMA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(308, 320);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 28;
            label2.Text = "label2";
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(169, 207, 229);
            ClientSize = new Size(1001, 588);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(btnLogins);
            Controls.Add(button4);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "HomePage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AGT";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStripTextBox toolStripTextBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem calculadoraToolStripMenuItem;
        private ToolStripMenuItem cadastrosToolStripMenuItem;
        private ToolStripMenuItem leisEAlíquotasToolStripMenuItem;
        private Button button1;
        private Button button4;
        private Button btnLogins;
        private Button button3;
        private ToolStripMenuItem loginsESenhasToolStripMenuItem;
        private Label label1;
        private Label label2;
    }
}
