namespace AGT_FORMS
{
    partial class CadastrosNova
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastrosNova));
            buttonLimpar = new Button();
            buttonCadastrar = new Button();
            buttonVoltar = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            label8 = new Label();
            SuspendLayout();
            // 
            // buttonLimpar
            // 
            buttonLimpar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonLimpar.BackColor = Color.FromArgb(18, 87, 123);
            buttonLimpar.BackgroundImageLayout = ImageLayout.Center;
            buttonLimpar.Cursor = Cursors.Hand;
            buttonLimpar.FlatStyle = FlatStyle.Flat;
            buttonLimpar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonLimpar.ForeColor = Color.FromArgb(169, 207, 229);
            buttonLimpar.Image = (Image)resources.GetObject("buttonLimpar.Image");
            buttonLimpar.Location = new Point(1011, 467);
            buttonLimpar.Margin = new Padding(2, 3, 2, 3);
            buttonLimpar.Name = "buttonLimpar";
            buttonLimpar.RightToLeft = RightToLeft.Yes;
            buttonLimpar.Size = new Size(113, 118);
            buttonLimpar.TabIndex = 0;
            buttonLimpar.Text = "Limpar";
            buttonLimpar.TextAlign = ContentAlignment.BottomCenter;
            buttonLimpar.TextImageRelation = TextImageRelation.ImageAboveText;
            buttonLimpar.UseVisualStyleBackColor = false;
            buttonLimpar.Click += buttonLimpar_Click;
            // 
            // buttonCadastrar
            // 
            buttonCadastrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonCadastrar.BackColor = Color.FromArgb(18, 87, 123);
            buttonCadastrar.Cursor = Cursors.Hand;
            buttonCadastrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonCadastrar.ForeColor = Color.FromArgb(169, 207, 229);
            buttonCadastrar.Location = new Point(653, 467);
            buttonCadastrar.Margin = new Padding(2, 3, 2, 3);
            buttonCadastrar.Name = "buttonCadastrar";
            buttonCadastrar.Size = new Size(120, 57);
            buttonCadastrar.TabIndex = 1;
            buttonCadastrar.Text = "Cadastrar";
            buttonCadastrar.UseVisualStyleBackColor = false;
            buttonCadastrar.Click += buttonCadastrar_Click;
            // 
            // buttonVoltar
            // 
            buttonVoltar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonVoltar.BackColor = Color.FromArgb(18, 87, 123);
            buttonVoltar.Cursor = Cursors.Hand;
            buttonVoltar.FlatStyle = FlatStyle.Flat;
            buttonVoltar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonVoltar.ForeColor = Color.FromArgb(169, 207, 229);
            buttonVoltar.Image = (Image)resources.GetObject("buttonVoltar.Image");
            buttonVoltar.Location = new Point(1011, 607);
            buttonVoltar.Margin = new Padding(2, 3, 2, 3);
            buttonVoltar.Name = "buttonVoltar";
            buttonVoltar.Size = new Size(113, 118);
            buttonVoltar.TabIndex = 2;
            buttonVoltar.Text = "Voltar";
            buttonVoltar.TextAlign = ContentAlignment.BottomCenter;
            buttonVoltar.TextImageRelation = TextImageRelation.ImageAboveText;
            buttonVoltar.UseVisualStyleBackColor = false;
            buttonVoltar.Click += buttonVoltar_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox1.Location = new Point(297, 400);
            textBox1.Margin = new Padding(2, 3, 2, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(220, 27);
            textBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Navy;
            label1.Location = new Point(297, 377);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(99, 23);
            label1.TabIndex = 4;
            label1.Text = "Código ERP";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.ForeColor = Color.Navy;
            label2.Location = new Point(297, 283);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(137, 23);
            label2.TabIndex = 5;
            label2.Text = "Código Entidade";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F);
            label3.ForeColor = Color.Navy;
            label3.Location = new Point(297, 195);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(49, 23);
            label3.TabIndex = 6;
            label3.Text = "CNPJ";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F);
            label4.ForeColor = Color.Navy;
            label4.Location = new Point(297, 467);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(123, 23);
            label4.TabIndex = 7;
            label4.Text = "Nome Fantasia";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F);
            label5.ForeColor = Color.Navy;
            label5.Location = new Point(654, 195);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(81, 23);
            label5.TabIndex = 8;
            label5.Text = "Endereço";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F);
            label6.ForeColor = Color.Navy;
            label6.Location = new Point(653, 283);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(63, 23);
            label6.TabIndex = 9;
            label6.Text = "Cidade";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F);
            label7.ForeColor = Color.Navy;
            label7.Location = new Point(654, 377);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(40, 23);
            label7.TabIndex = 10;
            label7.Text = "CEP";
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox2.Location = new Point(297, 309);
            textBox2.Margin = new Padding(2, 3, 2, 3);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(220, 27);
            textBox2.TabIndex = 11;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox3.Location = new Point(297, 218);
            textBox3.Margin = new Padding(2, 3, 2, 3);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(220, 27);
            textBox3.TabIndex = 12;
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox4.Location = new Point(297, 493);
            textBox4.Margin = new Padding(2, 3, 2, 3);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(220, 27);
            textBox4.TabIndex = 13;
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox5.Location = new Point(653, 218);
            textBox5.Margin = new Padding(2, 3, 2, 3);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(220, 27);
            textBox5.TabIndex = 14;
            // 
            // textBox6
            // 
            textBox6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox6.Location = new Point(654, 309);
            textBox6.Margin = new Padding(2, 3, 2, 3);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(220, 27);
            textBox6.TabIndex = 15;
            // 
            // textBox7
            // 
            textBox7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox7.Location = new Point(654, 400);
            textBox7.Margin = new Padding(2, 3, 2, 3);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(220, 27);
            textBox7.TabIndex = 16;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.ForeColor = Color.Navy;
            label8.Location = new Point(526, 81);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(179, 28);
            label8.TabIndex = 17;
            label8.Text = "Adicionar Unidade:";
            // 
            // CadastrosNova
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(169, 207, 229);
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1239, 748);
            Controls.Add(label8);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(buttonVoltar);
            Controls.Add(buttonCadastrar);
            Controls.Add(buttonLimpar);
            Margin = new Padding(2, 3, 2, 3);
            Name = "CadastrosNova";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Adicionar Unidade";
            Load += CadastrosNova_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonLimpar;
        private Button buttonCadastrar;
        private Button buttonVoltar;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private Label label8;
    }
}