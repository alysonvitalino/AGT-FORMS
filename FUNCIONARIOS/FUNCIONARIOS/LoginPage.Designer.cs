namespace AGT_FORMS
{
    partial class LoginPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginPage));
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            BoxLogin = new TextBox();
            BoxSenha = new TextBox();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(830, 407);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(109, 38);
            button1.TabIndex = 0;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(18, 87, 123);
            label1.Font = new Font("Segoe UI", 9F);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(753, 201);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(56, 25);
            label1.TabIndex = 2;
            label1.Text = "Login";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(18, 87, 123);
            label2.Font = new Font("Segoe UI", 9F);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(753, 298);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(60, 25);
            label2.TabIndex = 3;
            label2.Text = "Senha";
            // 
            // BoxLogin
            // 
            BoxLogin.Anchor = AnchorStyles.Top;
            BoxLogin.BackColor = Color.FromArgb(169, 207, 229);
            BoxLogin.Location = new Point(753, 231);
            BoxLogin.Margin = new Padding(4, 5, 4, 5);
            BoxLogin.Name = "BoxLogin";
            BoxLogin.Size = new Size(264, 31);
            BoxLogin.TabIndex = 4;
            // 
            // BoxSenha
            // 
            BoxSenha.Anchor = AnchorStyles.Top;
            BoxSenha.BackColor = Color.FromArgb(169, 207, 229);
            BoxSenha.Location = new Point(753, 328);
            BoxSenha.Margin = new Padding(4, 5, 4, 5);
            BoxSenha.Name = "BoxSenha";
            BoxSenha.Size = new Size(264, 31);
            BoxSenha.TabIndex = 5;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top;
            button2.Location = new Point(917, 606);
            button2.Name = "button2";
            button2.Size = new Size(212, 132);
            button2.TabIndex = 6;
            button2.Text = "POUPA TEMPO";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-34, -20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1219, 799);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // LoginPage
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1141, 750);
            Controls.Add(button2);
            Controls.Add(BoxSenha);
            Controls.Add(BoxLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "LoginPage";
            StartPosition = FormStartPosition.CenterScreen;
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
        private Button button2;
        private PictureBox pictureBox1;
    }
}