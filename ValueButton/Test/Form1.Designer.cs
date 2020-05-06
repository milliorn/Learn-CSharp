namespace Test
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
            this.valueButton1 = new ValueButtonLib.ValueButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // valueButton1
            // 
            this.valueButton1.ButtonValue = 5;
            this.valueButton1.Location = new System.Drawing.Point(-3, 3);
            this.valueButton1.Name = "valueButton1";
            this.valueButton1.Size = new System.Drawing.Size(800, 450);
            this.valueButton1.TabIndex = 0;
            this.valueButton1.Text = "valueButton1";
            this.valueButton1.UseVisualStyleBackColor = true;
            this.valueButton1.Click += new System.EventHandler(this.valueButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(323, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.valueButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ValueButtonLib.ValueButton valueButton1;
        private System.Windows.Forms.Label label1;
    }
}

