
namespace Sistema_Restaurante_hojarasca.CONEXION
{
    partial class CONEXION_MANUAL
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
            this.lblTexto = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCnString = new System.Windows.Forms.TextBox();
            this.btnGenerarCadena = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTexto
            // 
            this.lblTexto.AutoSize = true;
            this.lblTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTexto.Location = new System.Drawing.Point(33, 37);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(372, 24);
            this.lblTexto.TabIndex = 0;
            this.lblTexto.Text = "Ingrese la cadena de conexión LOCAL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(34, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(592, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Se creará un Archivo que contendrá tu conexión Encryptada. Ahora tu conexión es m" +
    "ás SEGURA ante posibles HACKERS.";
            // 
            // txtCnString
            // 
            this.txtCnString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCnString.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCnString.Location = new System.Drawing.Point(37, 123);
            this.txtCnString.Multiline = true;
            this.txtCnString.Name = "txtCnString";
            this.txtCnString.Size = new System.Drawing.Size(662, 57);
            this.txtCnString.TabIndex = 2;
            // 
            // btnGenerarCadena
            // 
            this.btnGenerarCadena.BackColor = System.Drawing.Color.Green;
            this.btnGenerarCadena.FlatAppearance.BorderSize = 0;
            this.btnGenerarCadena.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarCadena.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarCadena.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGenerarCadena.Location = new System.Drawing.Point(37, 202);
            this.btnGenerarCadena.Name = "btnGenerarCadena";
            this.btnGenerarCadena.Size = new System.Drawing.Size(479, 45);
            this.btnGenerarCadena.TabIndex = 3;
            this.btnGenerarCadena.Text = "Generar cadena de conexión";
            this.btnGenerarCadena.UseVisualStyleBackColor = false;
            this.btnGenerarCadena.Click += new System.EventHandler(this.btnGenerarCadena_Click);
            // 
            // CONEXION_MANUAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 287);
            this.Controls.Add(this.btnGenerarCadena);
            this.Controls.Add(this.txtCnString);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTexto);
            this.Name = "CONEXION_MANUAL";
            this.Text = "Conexión Manual";
            this.Load += new System.EventHandler(this.CONEXION_MANUAL_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCnString;
        private System.Windows.Forms.Button btnGenerarCadena;
    }
}