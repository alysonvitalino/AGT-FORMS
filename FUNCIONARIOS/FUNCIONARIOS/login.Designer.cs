namespace FUNCIONARIOS
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            BoxLogin = new TextBox();
            BoxSenha = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(464, 332);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
            button1.TabIndex = 0;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9F);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(464, 192);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 2;
            label1.Text = "Login";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9F);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(464, 251);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 3;
            label2.Text = "Senha";
            // 
            // BoxLogin
            // 
            BoxLogin.BackColor = SystemColors.HotTrack;
            BoxLogin.Location = new Point(464, 216);
            BoxLogin.Margin = new Padding(3, 4, 3, 4);
            BoxLogin.Name = "BoxLogin";
            BoxLogin.Size = new Size(212, 27);
            BoxLogin.TabIndex = 4;
            BoxLogin.TextChanged += BoxLogin_TextChanged;
            // 
            // BoxSenha
            // 
            BoxSenha.BackColor = SystemColors.HotTrack;
            BoxSenha.Location = new Point(464, 275);
            BoxSenha.Margin = new Padding(3, 4, 3, 4);
            BoxSenha.Name = "BoxSenha";
            BoxSenha.Size = new Size(212, 27);
            BoxSenha.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.LOGIN_E_SENHAS__4_;
            pictureBox1.Location = new Point(617, 425);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(170, 107);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(914, 600);
            Controls.Add(pictureBox1);
            Controls.Add(BoxSenha);
            Controls.Add(BoxLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "login";
            StartPosition = FormStartPosition.CenterScreen;
            Load += login_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private TextBox BoxLogin;
        private TextBox BoxSenha;
        private PictureBox pictureBox1;
    }
}