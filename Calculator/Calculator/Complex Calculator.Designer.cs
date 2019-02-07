namespace Calculator
{
    partial class Complex_Calculator
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.resultbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.addbutton = new System.Windows.Forms.Button();
            this.subbutton = new System.Windows.Forms.Button();
            this.divbutton = new System.Windows.Forms.Button();
            this.multbutton = new System.Windows.Forms.Button();
            this.equalbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(139, 106);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(410, 118);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(139, 246);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(410, 118);
            this.textBox2.TabIndex = 1;
            // 
            // resultbox
            // 
            this.resultbox.Location = new System.Drawing.Point(139, 472);
            this.resultbox.Multiline = true;
            this.resultbox.Name = "resultbox";
            this.resultbox.Size = new System.Drawing.Size(410, 118);
            this.resultbox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "1st Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "2nd Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 527);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Result";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // addbutton
            // 
            this.addbutton.Location = new System.Drawing.Point(612, 99);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(125, 125);
            this.addbutton.TabIndex = 6;
            this.addbutton.Text = "+";
            this.addbutton.UseVisualStyleBackColor = true;
            this.addbutton.Click += new System.EventHandler(this.addbutton_Click);
            // 
            // subbutton
            // 
            this.subbutton.Location = new System.Drawing.Point(786, 99);
            this.subbutton.Name = "subbutton";
            this.subbutton.Size = new System.Drawing.Size(125, 125);
            this.subbutton.TabIndex = 7;
            this.subbutton.Text = "-";
            this.subbutton.UseVisualStyleBackColor = true;
            // 
            // divbutton
            // 
            this.divbutton.Location = new System.Drawing.Point(612, 239);
            this.divbutton.Name = "divbutton";
            this.divbutton.Size = new System.Drawing.Size(125, 125);
            this.divbutton.TabIndex = 8;
            this.divbutton.Text = "/";
            this.divbutton.UseVisualStyleBackColor = true;
            // 
            // multbutton
            // 
            this.multbutton.Location = new System.Drawing.Point(786, 239);
            this.multbutton.Name = "multbutton";
            this.multbutton.Size = new System.Drawing.Size(125, 125);
            this.multbutton.TabIndex = 9;
            this.multbutton.Text = "*";
            this.multbutton.UseVisualStyleBackColor = true;
            this.multbutton.Click += new System.EventHandler(this.button4_Click);
            // 
            // equalbutton
            // 
            this.equalbutton.Location = new System.Drawing.Point(612, 403);
            this.equalbutton.Name = "equalbutton";
            this.equalbutton.Size = new System.Drawing.Size(279, 125);
            this.equalbutton.TabIndex = 10;
            this.equalbutton.Text = "=";
            this.equalbutton.UseVisualStyleBackColor = true;
            //this.equalbutton.Click += new System.EventHandler(this.equalbutton_Click);
            // 
            // Complex_Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 723);
            this.Controls.Add(this.equalbutton);
            this.Controls.Add(this.multbutton);
            this.Controls.Add(this.divbutton);
            this.Controls.Add(this.subbutton);
            this.Controls.Add(this.addbutton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resultbox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Complex_Calculator";
            this.Text = "Complex_Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox resultbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.Button subbutton;
        private System.Windows.Forms.Button divbutton;
        private System.Windows.Forms.Button multbutton;
        private System.Windows.Forms.Button equalbutton;
    }
}