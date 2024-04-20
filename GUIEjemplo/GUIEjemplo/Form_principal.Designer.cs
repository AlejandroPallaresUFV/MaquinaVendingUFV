namespace GUIEjemplo
{
    partial class Form_Calculadora
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_Operador1 = new System.Windows.Forms.TextBox();
            this.textBox_Operador2 = new System.Windows.Forms.TextBox();
            this.button_Suma = new System.Windows.Forms.Button();
            this.button_Multiplicar = new System.Windows.Forms.Button();
            this.button_Resta = new System.Windows.Forms.Button();
            this.button_Dividir = new System.Windows.Forms.Button();
            this.label_Resultado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_sec = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Operador1
            // 
            this.textBox_Operador1.BackColor = System.Drawing.Color.White;
            this.textBox_Operador1.Location = new System.Drawing.Point(59, 86);
            this.textBox_Operador1.Name = "textBox_Operador1";
            this.textBox_Operador1.Size = new System.Drawing.Size(184, 31);
            this.textBox_Operador1.TabIndex = 0;
            this.textBox_Operador1.Text = "\r\n";
            this.textBox_Operador1.TextChanged += new System.EventHandler(this.textBox_Operador1_TextChanged);
            // 
            // textBox_Operador2
            // 
            this.textBox_Operador2.BackColor = System.Drawing.Color.White;
            this.textBox_Operador2.Location = new System.Drawing.Point(59, 161);
            this.textBox_Operador2.Name = "textBox_Operador2";
            this.textBox_Operador2.Size = new System.Drawing.Size(184, 31);
            this.textBox_Operador2.TabIndex = 1;
            // 
            // button_Suma
            // 
            this.button_Suma.BackColor = System.Drawing.Color.Gray;
            this.button_Suma.Location = new System.Drawing.Point(286, 68);
            this.button_Suma.Name = "button_Suma";
            this.button_Suma.Size = new System.Drawing.Size(74, 66);
            this.button_Suma.TabIndex = 2;
            this.button_Suma.Text = "+";
            this.button_Suma.UseVisualStyleBackColor = false;
            this.button_Suma.Click += new System.EventHandler(this.button_Suma_Click);
            // 
            // button_Multiplicar
            // 
            this.button_Multiplicar.BackColor = System.Drawing.Color.Gray;
            this.button_Multiplicar.Location = new System.Drawing.Point(286, 152);
            this.button_Multiplicar.Name = "button_Multiplicar";
            this.button_Multiplicar.Size = new System.Drawing.Size(74, 66);
            this.button_Multiplicar.TabIndex = 3;
            this.button_Multiplicar.Text = "x";
            this.button_Multiplicar.UseVisualStyleBackColor = false;
            this.button_Multiplicar.Click += new System.EventHandler(this.button_Multiplicar_Click);
            this.button_Multiplicar.MouseEnter += new System.EventHandler(this.button_Multiplicar_MouseEnter);
            // 
            // button_Resta
            // 
            this.button_Resta.BackColor = System.Drawing.Color.Gray;
            this.button_Resta.Location = new System.Drawing.Point(383, 68);
            this.button_Resta.Name = "button_Resta";
            this.button_Resta.Size = new System.Drawing.Size(74, 66);
            this.button_Resta.TabIndex = 4;
            this.button_Resta.Text = "-";
            this.button_Resta.UseVisualStyleBackColor = false;
            this.button_Resta.Click += new System.EventHandler(this.button_Resta_Click);
            // 
            // button_Dividir
            // 
            this.button_Dividir.BackColor = System.Drawing.Color.Gray;
            this.button_Dividir.Location = new System.Drawing.Point(383, 152);
            this.button_Dividir.Name = "button_Dividir";
            this.button_Dividir.Size = new System.Drawing.Size(74, 66);
            this.button_Dividir.TabIndex = 5;
            this.button_Dividir.Text = "/";
            this.button_Dividir.UseVisualStyleBackColor = false;
            this.button_Dividir.Click += new System.EventHandler(this.button_Dividir_Click);
            // 
            // label_Resultado
            // 
            this.label_Resultado.AutoSize = true;
            this.label_Resultado.Location = new System.Drawing.Point(550, 129);
            this.label_Resultado.Name = "label_Resultado";
            this.label_Resultado.Size = new System.Drawing.Size(109, 25);
            this.label_Resultado.TabIndex = 6;
            this.label_Resultado.Text = "Resultado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(496, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "=";
            // 
            // button_sec
            // 
            this.button_sec.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_sec.Location = new System.Drawing.Point(501, 240);
            this.button_sec.Name = "button_sec";
            this.button_sec.Size = new System.Drawing.Size(170, 43);
            this.button_sec.TabIndex = 8;
            this.button_sec.Text = "Clikas o que?";
            this.button_sec.UseVisualStyleBackColor = false;
            this.button_sec.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_Calculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(721, 314);
            this.Controls.Add(this.button_sec);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_Resultado);
            this.Controls.Add(this.button_Dividir);
            this.Controls.Add(this.button_Resta);
            this.Controls.Add(this.button_Multiplicar);
            this.Controls.Add(this.button_Suma);
            this.Controls.Add(this.textBox_Operador2);
            this.Controls.Add(this.textBox_Operador1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_Calculadora";
            this.Text = "Calculeitoh";
            this.Load += new System.EventHandler(this.Form_principal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Operador1;
        private System.Windows.Forms.TextBox textBox_Operador2;
        private System.Windows.Forms.Button button_Suma;
        private System.Windows.Forms.Button button_Multiplicar;
        private System.Windows.Forms.Button button_Resta;
        private System.Windows.Forms.Button button_Dividir;
        private System.Windows.Forms.Label label_Resultado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_sec;
    }
}

