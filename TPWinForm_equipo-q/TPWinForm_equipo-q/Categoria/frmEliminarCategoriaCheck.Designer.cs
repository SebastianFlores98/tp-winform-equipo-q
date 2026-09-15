namespace TPWinForm_equipo_q.Categoria
{
    partial class frmEliminarCategoriaCheck
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
            this.lblAvisoEliminacion = new System.Windows.Forms.Label();
            this.btnSi = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAvisoEliminacion
            // 
            this.lblAvisoEliminacion.AutoSize = true;
            this.lblAvisoEliminacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvisoEliminacion.Location = new System.Drawing.Point(12, 37);
            this.lblAvisoEliminacion.Name = "lblAvisoEliminacion";
            this.lblAvisoEliminacion.Size = new System.Drawing.Size(302, 16);
            this.lblAvisoEliminacion.TabIndex = 0;
            this.lblAvisoEliminacion.Text = "¿Esta seguro que desea eliminar esta Categoria?";
            // 
            // btnSi
            // 
            this.btnSi.Location = new System.Drawing.Point(55, 101);
            this.btnSi.Name = "btnSi";
            this.btnSi.Size = new System.Drawing.Size(75, 23);
            this.btnSi.TabIndex = 1;
            this.btnSi.Text = "Si";
            this.btnSi.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(190, 101);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmEliminarCategoriaCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 180);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSi);
            this.Controls.Add(this.lblAvisoEliminacion);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(370, 219);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(370, 219);
            this.Name = "frmEliminarCategoriaCheck";
            this.Text = "Atencion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAvisoEliminacion;
        private System.Windows.Forms.Button btnSi;
        private System.Windows.Forms.Button btnCancelar;
    }
}