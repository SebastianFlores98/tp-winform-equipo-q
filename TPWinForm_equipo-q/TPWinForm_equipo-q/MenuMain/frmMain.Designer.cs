namespace TPWinForm_equipo_q
{
    partial class frmMain
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
            this.lblGestionArticulos = new System.Windows.Forms.Label();
            this.BtnMainArticulos = new System.Windows.Forms.Button();
            this.BtnMainMarcas = new System.Windows.Forms.Button();
            this.BtnMainCategorias = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGestionArticulos
            // 
            this.lblGestionArticulos.AutoSize = true;
            this.lblGestionArticulos.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGestionArticulos.Location = new System.Drawing.Point(387, 121);
            this.lblGestionArticulos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGestionArticulos.Name = "lblGestionArticulos";
            this.lblGestionArticulos.Size = new System.Drawing.Size(259, 31);
            this.lblGestionArticulos.TabIndex = 0;
            this.lblGestionArticulos.Text = "Gestión de Artículos";
            // 
            // BtnMainArticulos
            // 
            this.BtnMainArticulos.Location = new System.Drawing.Point(472, 249);
            this.BtnMainArticulos.Margin = new System.Windows.Forms.Padding(4);
            this.BtnMainArticulos.Name = "BtnMainArticulos";
            this.BtnMainArticulos.Size = new System.Drawing.Size(100, 28);
            this.BtnMainArticulos.TabIndex = 1;
            this.BtnMainArticulos.Text = "Artículos";
            this.BtnMainArticulos.UseVisualStyleBackColor = true;
            this.BtnMainArticulos.Click += new System.EventHandler(this.BtnMainArticulos_Click);
            // 
            // BtnMainMarcas
            // 
            this.BtnMainMarcas.Location = new System.Drawing.Point(472, 304);
            this.BtnMainMarcas.Margin = new System.Windows.Forms.Padding(4);
            this.BtnMainMarcas.Name = "BtnMainMarcas";
            this.BtnMainMarcas.Size = new System.Drawing.Size(100, 28);
            this.BtnMainMarcas.TabIndex = 2;
            this.BtnMainMarcas.Text = "Marcas";
            this.BtnMainMarcas.UseVisualStyleBackColor = true;
            this.BtnMainMarcas.Click += new System.EventHandler(this.BtnMainMarcas_Click);
            // 
            // BtnMainCategorias
            // 
            this.BtnMainCategorias.Location = new System.Drawing.Point(472, 356);
            this.BtnMainCategorias.Margin = new System.Windows.Forms.Padding(4);
            this.BtnMainCategorias.Name = "BtnMainCategorias";
            this.BtnMainCategorias.Size = new System.Drawing.Size(100, 28);
            this.BtnMainCategorias.TabIndex = 3;
            this.BtnMainCategorias.Text = "Categorías";
            this.BtnMainCategorias.UseVisualStyleBackColor = true;
            this.BtnMainCategorias.Click += new System.EventHandler(this.BtnMainCategorias_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.BtnMainCategorias);
            this.Controls.Add(this.BtnMainMarcas);
            this.Controls.Add(this.BtnMainArticulos);
            this.Controls.Add(this.lblGestionArticulos);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de artículos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGestionArticulos;
        private System.Windows.Forms.Button BtnMainArticulos;
        private System.Windows.Forms.Button BtnMainMarcas;
        private System.Windows.Forms.Button BtnMainCategorias;
    }
}

