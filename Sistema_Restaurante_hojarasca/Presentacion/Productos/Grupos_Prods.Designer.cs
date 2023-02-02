
namespace Sistema_Restaurante_hojarasca.MODULOS.Productos
{
    partial class Grupos_Prods
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Grupos_Prods));
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblAgregarIcono = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dlg = new System.Windows.Forms.OpenFileDialog();
            this.pcbAgregarIcono = new System.Windows.Forms.PictureBox();
            this.ImagenGrupo = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbAgregarIcono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenGrupo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCerrar.Location = new System.Drawing.Point(426, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(58, 49);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.ImagenGrupo);
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.btnVolver);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.txtGrupo);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(-15, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 528);
            this.panel1.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pcbAgregarIcono);
            this.panel3.Controls.Add(this.lblAgregarIcono);
            this.panel3.Location = new System.Drawing.Point(259, 99);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(178, 160);
            this.panel3.TabIndex = 6;
            // 
            // lblAgregarIcono
            // 
            this.lblAgregarIcono.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAgregarIcono.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAgregarIcono.Font = new System.Drawing.Font("Montserrat SemiBold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgregarIcono.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblAgregarIcono.Location = new System.Drawing.Point(0, 0);
            this.lblAgregarIcono.Name = "lblAgregarIcono";
            this.lblAgregarIcono.Size = new System.Drawing.Size(178, 83);
            this.lblAgregarIcono.TabIndex = 3;
            this.lblAgregarIcono.Text = "Agregar ícono\r\n(Opcional)";
            this.lblAgregarIcono.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAgregarIcono.Click += new System.EventHandler(this.lblAgregarIcono_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Montserrat Medium", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEliminar.Location = new System.Drawing.Point(97, 355);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(304, 57);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnVolver.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Montserrat Medium", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnVolver.Location = new System.Drawing.Point(97, 434);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(304, 57);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(198)))), ((int)(((byte)(91)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Montserrat ExtraBold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardar.Location = new System.Drawing.Point(97, 279);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(304, 57);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtGrupo
            // 
            this.txtGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.txtGrupo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Bold);
            this.txtGrupo.ForeColor = System.Drawing.SystemColors.Window;
            this.txtGrupo.Location = new System.Drawing.Point(63, 41);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(375, 35);
            this.txtGrupo.TabIndex = 1;
            this.txtGrupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(63, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(375, 1);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat Black", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(180, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 44);
            this.label1.TabIndex = 5;
            this.label1.Text = "Grupo";
            // 
            // dlg
            // 
            this.dlg.FileName = "dlg";
            // 
            // pcbAgregarIcono
            // 
            this.pcbAgregarIcono.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pcbAgregarIcono.BackgroundImage")));
            this.pcbAgregarIcono.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pcbAgregarIcono.Dock = System.Windows.Forms.DockStyle.Top;
            this.pcbAgregarIcono.Location = new System.Drawing.Point(0, 83);
            this.pcbAgregarIcono.Name = "pcbAgregarIcono";
            this.pcbAgregarIcono.Size = new System.Drawing.Size(178, 25);
            this.pcbAgregarIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbAgregarIcono.TabIndex = 2;
            this.pcbAgregarIcono.TabStop = false;
            this.pcbAgregarIcono.Click += new System.EventHandler(this.pcbAgregarIcono_Click);
            // 
            // ImagenGrupo
            // 
            this.ImagenGrupo.Image = global::Sistema_Restaurante_hojarasca.Properties.Resources.warning;
            this.ImagenGrupo.Location = new System.Drawing.Point(62, 99);
            this.ImagenGrupo.Name = "ImagenGrupo";
            this.ImagenGrupo.Size = new System.Drawing.Size(375, 160);
            this.ImagenGrupo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImagenGrupo.TabIndex = 5;
            this.ImagenGrupo.TabStop = false;
            // 
            // Grupos_Prods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(487, 657);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "Grupos_Prods";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grupos_Prods";
            this.Load += new System.EventHandler(this.Grupos_Prods_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbAgregarIcono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenGrupo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pcbAgregarIcono;
        private System.Windows.Forms.Label lblAgregarIcono;
        private System.Windows.Forms.PictureBox ImagenGrupo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog dlg;
    }
}