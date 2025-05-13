namespace AGT_FORMS
{
    partial class Form1
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
            textBox1 = new TextBox();
            button1 = new Button();
            textBox3 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            button2 = new Button();
            label4 = new Label();
            textBox2 = new TextBox();
            label5 = new Label();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(328, 89);
            label1.Name = "label1";
            label1.Size = new Size(136, 25);
            label1.TabIndex = 0;
            label1.Text = "Crie um usuário";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(212, 176);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(341, 395);
            button1.Name = "button1";
            button1.Size = new Size(111, 33);
            button1.TabIndex = 2;
            button1.Text = "GERAR";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(433, 176);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(150, 31);
            textBox3.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(212, 148);
            label2.Name = "label2";
            label2.Size = new Size(56, 25);
            label2.TabIndex = 5;
            label2.Text = "Login";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(438, 148);
            label3.Name = "label3";
            label3.Size = new Size(60, 25);
            label3.TabIndex = 6;
            label3.Text = "Senha";
            // 
            // button2
            // 
            button2.Location = new Point(589, 12);
            button2.Name = "button2";
            button2.Size = new Size(199, 118);
            button2.TabIndex = 7;
            button2.Text = "PÁGINA INICIAL";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(369, 214);
            label4.Name = "label4";
            label4.Size = new Size(54, 25);
            label4.TabIndex = 9;
            label4.Text = "Email";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(212, 242);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(371, 31);
            textBox2.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(333, 287);
            label5.Name = "label5";
            label5.Size = new Size(137, 25);
            label5.TabIndex = 10;
            label5.Text = "Nível de Acesso";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Admin", "Usuário" });
            comboBox1.Location = new Point(310, 315);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.TabIndex = 11;
            // 
            // Form1
            // 
            AcceptButton = button2;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox3);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private TextBox textBox3;
        private Label label2;
        private Label label3;
        private Button button2;
        private Label label4;
        private TextBox textBox2;
        private Label label5;
        private ComboBox comboBox1;
    }
}