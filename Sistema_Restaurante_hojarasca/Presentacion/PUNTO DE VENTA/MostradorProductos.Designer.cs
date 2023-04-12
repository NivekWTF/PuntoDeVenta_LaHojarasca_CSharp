
namespace Sistema_Restaurante_hojarasca.Presentacion.PUNTO_DE_VENTA
{
    partial class MostradorProductos
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelProductos = new System.Windows.Forms.FlowLayoutPanel();
            this.UI_GradientPanel3 = new UIDC.UI_GradientPanel();
            this.btnDelante = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.UI_GradientPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelProductos
            // 
            this.PanelProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelProductos.Location = new System.Drawing.Point(0, 50);
            this.PanelProductos.Name = "PanelProductos";
            this.PanelProductos.Size = new System.Drawing.Size(651, 361);
            this.PanelProductos.TabIndex = 5;
            // 
            // UI_GradientPanel3
            // 
            this.UI_GradientPanel3.BackColor = System.Drawing.Color.White;
            this.UI_GradientPanel3.Controls.Add(this.btnDelante);
            this.UI_GradientPanel3.Controls.Add(this.btnAtras);
            this.UI_GradientPanel3.Controls.Add(this.label19);
            this.UI_GradientPanel3.Controls.Add(this.panel1);
            this.UI_GradientPanel3.Controls.Add(this.panel2);
            this.UI_GradientPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.UI_GradientPanel3.Location = new System.Drawing.Point(0, 0);
            this.UI_GradientPanel3.Name = "UI_GradientPanel3";
            this.UI_GradientPanel3.Size = new System.Drawing.Size(651, 50);
            this.UI_GradientPanel3.TabIndex = 4;
            this.UI_GradientPanel3.UIBackColor = System.Drawing.Color.Navy;
            this.UI_GradientPanel3.UIBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.UI_GradientPanel3.UIBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UI_GradientPanel3.UIForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.UI_GradientPanel3.UIPrimerColor = System.Drawing.Color.MidnightBlue;
            this.UI_GradientPanel3.UIStyle = UIDC.UI_GradientPanel.GradientStyle.Corners;
            this.UI_GradientPanel3.UITopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.UI_GradientPanel3.UITopRight = System.Drawing.Color.Black;
            // 
            // btnDelante
            // 
            this.btnDelante.BackColor = System.Drawing.Color.Transparent;
            this.btnDelante.BackgroundImage = global::Sistema_Restaurante_hojarasca.Properties.Resources.angle_right;
            this.btnDelante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelante.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelante.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelante.FlatAppearance.BorderSize = 0;
            this.btnDelante.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDelante.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDelante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelante.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnDelante.ForeColor = System.Drawing.Color.White;
            this.btnDelante.Location = new System.Drawing.Point(577, 10);
            this.btnDelante.Name = "btnDelante";
            this.btnDelante.Size = new System.Drawing.Size(74, 30);
            this.btnDelante.TabIndex = 627;
            this.btnDelante.UseVisualStyleBackColor = false;
            this.btnDelante.Click += new System.EventHandler(this.btnDelante_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.Transparent;
            this.btnAtras.BackgroundImage = global::Sistema_Restaurante_hojarasca.Properties.Resources.angle_left;
            this.btnAtras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAtras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtras.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAtras.FlatAppearance.BorderSize = 0;
            this.btnAtras.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAtras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtras.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnAtras.ForeColor = System.Drawing.Color.White;
            this.btnAtras.Location = new System.Drawing.Point(0, 10);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(74, 30);
            this.btnAtras.TabIndex = 626;
            this.btnAtras.UseVisualStyleBackColor = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.Font = new System.Drawing.Font("Montserrat Black", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(0, 10);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(651, 30);
            this.label19.TabIndex = 5;
            this.label19.Text = "PRODUCTOS";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(651, 10);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(651, 10);
            this.panel2.TabIndex = 1;
            // 
            // MostradorProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelProductos);
            this.Controls.Add(this.UI_GradientPanel3);
            this.Name = "MostradorProductos";
            this.Size = new System.Drawing.Size(651, 411);
            this.Load += new System.EventHandler(this.MostradorProductos_Load);
            this.UI_GradientPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel PanelProductos;
        internal UIDC.UI_GradientPanel UI_GradientPanel3;
        internal System.Windows.Forms.Button btnDelante;
        internal System.Windows.Forms.Button btnAtras;
        internal System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
