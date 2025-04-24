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
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(580, 415);
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
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9F);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(580, 240);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(56, 25);
            label1.TabIndex = 2;
            label1.Text = "Login";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9F);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(580, 313);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(60, 25);
            label2.TabIndex = 3;
            label2.Text = "Senha";
            // 
            // BoxLogin
            // 
            BoxLogin.BackColor = SystemColors.HotTrack;
            BoxLogin.Location = new Point(580, 270);
            BoxLogin.Margin = new Padding(4, 5, 4, 5);
            BoxLogin.Name = "BoxLogin";
            BoxLogin.Size = new Size(264, 31);
            BoxLogin.TabIndex = 4;
            // 
            // BoxSenha
            // 
            BoxSenha.BackColor = SystemColors.HotTrack;
            BoxSenha.Location = new Point(580, 343);
            BoxSenha.Margin = new Padding(4, 5, 4, 5);
            BoxSenha.Name = "BoxSenha";
            BoxSenha.Size = new Size(264, 31);
            BoxSenha.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(580, 503);
            button2.Name = "button2";
            button2.Size = new Size(212, 132);
            button2.TabIndex = 6;
            button2.Text = "POUPA TEMPO";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // LoginPage
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1141, 750);
            Controls.Add(button2);
            Controls.Add(BoxSenha);
            Controls.Add(BoxLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "LoginPage";
            StartPosition = FormStartPosition.CenterScreen;
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
    }
}