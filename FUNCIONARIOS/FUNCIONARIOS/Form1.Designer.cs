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
            button3 = new Button();
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
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(914, 28);
            menuStrip1.TabIndex = 18;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { calculadoraToolStripMenuItem, cadastrosToolStripMenuItem, leisEAlíquotasToolStripMenuItem, loginsESenhasToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(60, 24);
            menuToolStripMenuItem.Text = "Menu";
            menuToolStripMenuItem.Click += menuToolStripMenuItem_Click;
            // 
            // calculadoraToolStripMenuItem
            // 
            calculadoraToolStripMenuItem.Name = "calculadoraToolStripMenuItem";
            calculadoraToolStripMenuItem.Size = new Size(197, 26);
            calculadoraToolStripMenuItem.Text = "Calculadora";
            calculadoraToolStripMenuItem.Click += calculadoraToolStripMenuItem_Click;
            // 
            // cadastrosToolStripMenuItem
            // 
            cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            cadastrosToolStripMenuItem.Size = new Size(197, 26);
            cadastrosToolStripMenuItem.Text = "Cadastros";
            cadastrosToolStripMenuItem.Click += cadastrosToolStripMenuItem_Click;
            // 
            // leisEAlíquotasToolStripMenuItem
            // 
            leisEAlíquotasToolStripMenuItem.Name = "leisEAlíquotasToolStripMenuItem";
            leisEAlíquotasToolStripMenuItem.Size = new Size(197, 26);
            leisEAlíquotasToolStripMenuItem.Text = "Leis e Alíquotas";
            leisEAlíquotasToolStripMenuItem.Click += leisEAlíquotasToolStripMenuItem_Click;
            // 
            // loginsESenhasToolStripMenuItem
            // 
            loginsESenhasToolStripMenuItem.Name = "loginsESenhasToolStripMenuItem";
            loginsESenhasToolStripMenuItem.Size = new Size(197, 26);
            loginsESenhasToolStripMenuItem.Text = "Logins e Senhas";
            loginsESenhasToolStripMenuItem.Click += loginsESenhasToolStripMenuItem_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(453, 155);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(180, 156);
            button1.TabIndex = 19;
            button1.Text = "Alíquotas";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.Location = new Point(453, 374);
            button4.Margin = new Padding(2);
            button4.Name = "button4";
            button4.Size = new Size(180, 156);
            button4.TabIndex = 21;
            button4.Text = "Cadastros";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // btnLogins
            // 
            btnLogins.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogins.Location = new Point(684, 374);
            btnLogins.Margin = new Padding(2);
            btnLogins.Name = "btnLogins";
            btnLogins.Size = new Size(180, 156);
            btnLogins.TabIndex = 22;
            btnLogins.Text = "Login e Senhas";
            btnLogins.UseVisualStyleBackColor = true;
            btnLogins.Click += btnUsuario_Click_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(105, 50);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(167, 28);
            label4.TabIndex = 23;
            label4.Text = "Bem Vindo @user";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.Location = new Point(684, 155);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(180, 156);
            button3.TabIndex = 26;
            button3.Text = "Calculadora";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(914, 600);
            Controls.Add(button3);
            Controls.Add(label4);
            Controls.Add(btnLogins);
            Controls.Add(button4);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
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
        private Label label4;
        private Button button3;
        private ToolStripMenuItem loginsESenhasToolStripMenuItem;
    }
}
