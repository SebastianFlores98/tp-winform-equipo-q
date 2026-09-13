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
            this.LabelMain = new System.Windows.Forms.Label();
            this.BtnMainArticulos = new System.Windows.Forms.Button();
            this.BtnMainMarcas = new System.Windows.Forms.Button();
            this.BtnMainCategorias = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelMain
            // 
            this.LabelMain.AutoSize = true;
            this.LabelMain.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMain.Location = new System.Drawing.Point(290, 98);
            this.LabelMain.Name = "LabelMain";
            this.LabelMain.Size = new System.Drawing.Size(206, 26);
            this.LabelMain.TabIndex = 0;
            this.LabelMain.Text = "Gestion de Articulos";
            // 
            // BtnMainArticulos
            // 
            this.BtnMainArticulos.Location = new System.Drawing.Point(354, 202);
            this.BtnMainArticulos.Name = "BtnMainArticulos";
            this.BtnMainArticulos.Size = new System.Drawing.Size(75, 23);
            this.BtnMainArticulos.TabIndex = 1;
            this.BtnMainArticulos.Text = "Articulos";
            this.BtnMainArticulos.UseVisualStyleBackColor = true;
            // 
            // BtnMainMarcas
            // 
            this.BtnMainMarcas.Location = new System.Drawing.Point(354, 247);
            this.BtnMainMarcas.Name = "BtnMainMarcas";
            this.BtnMainMarcas.Size = new System.Drawing.Size(75, 23);
            this.BtnMainMarcas.TabIndex = 2;
            this.BtnMainMarcas.Text = "Marcas";
            this.BtnMainMarcas.UseVisualStyleBackColor = true;
            this.BtnMainMarcas.Click += new System.EventHandler(this.BtnMainMarcas_Click);
            // 
            // BtnMainCategorias
            // 
            this.BtnMainCategorias.Location = new System.Drawing.Point(354, 289);
            this.BtnMainCategorias.Name = "BtnMainCategorias";
            this.BtnMainCategorias.Size = new System.Drawing.Size(75, 23);
            this.BtnMainCategorias.TabIndex = 3;
            this.BtnMainCategorias.Text = "Categorias";
            this.BtnMainCategorias.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnMainCategorias);
            this.Controls.Add(this.BtnMainMarcas);
            this.Controls.Add(this.BtnMainArticulos);
            this.Controls.Add(this.LabelMain);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelMain;
        private System.Windows.Forms.Button BtnMainArticulos;
        private System.Windows.Forms.Button BtnMainMarcas;
        private System.Windows.Forms.Button BtnMainCategorias;
    }
}

