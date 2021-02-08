
namespace Proyecto1
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
            this.analizar = new System.Windows.Forms.Button();
            this.txtEntrada = new System.Windows.Forms.RichTextBox();
            this.txtSalida = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // analizar
            // 
            this.analizar.Location = new System.Drawing.Point(314, 323);
            this.analizar.Name = "analizar";
            this.analizar.Size = new System.Drawing.Size(94, 29);
            this.analizar.TabIndex = 0;
            this.analizar.Text = "Go!";
            this.analizar.UseVisualStyleBackColor = true;
            this.analizar.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtEntrada
            // 
            this.txtEntrada.Location = new System.Drawing.Point(70, 51);
            this.txtEntrada.Name = "txtEntrada";
            this.txtEntrada.Size = new System.Drawing.Size(249, 226);
            this.txtEntrada.TabIndex = 1;
            this.txtEntrada.Text = "";
            // 
            // txtSalida
            // 
            this.txtSalida.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtSalida.ForeColor = System.Drawing.SystemColors.Window;
            this.txtSalida.Location = new System.Drawing.Point(438, 51);
            this.txtSalida.Name = "txtSalida";
            this.txtSalida.Size = new System.Drawing.Size(266, 232);
            this.txtSalida.TabIndex = 2;
            this.txtSalida.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Entrada";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(438, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Salida";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSalida);
            this.Controls.Add(this.txtEntrada);
            this.Controls.Add(this.analizar);
            this.Name = "Form1";
            this.Text = "Proyecto1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button analizar;
        private System.Windows.Forms.RichTextBox txtEntrada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtSalida;
    }
}

