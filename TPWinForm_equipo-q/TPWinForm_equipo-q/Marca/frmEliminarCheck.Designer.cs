namespace TPWinForm_equipo_q
{
    partial class frmEliminarCheck
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
            this.label1 = new System.Windows.Forms.Label();
            this.BtnEliminarCheckSi = new System.Windows.Forms.Button();
            this.BtnEliminarCheckNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Esta seguro que desea borrar esta marca?";
            // 
            // BtnEliminarCheckSi
            // 
            this.BtnEliminarCheckSi.Location = new System.Drawing.Point(77, 104);
            this.BtnEliminarCheckSi.Name = "BtnEliminarCheckSi";
            this.BtnEliminarCheckSi.Size = new System.Drawing.Size(75, 23);
            this.BtnEliminarCheckSi.TabIndex = 1;
            this.BtnEliminarCheckSi.Text = "Si";
            this.BtnEliminarCheckSi.UseVisualStyleBackColor = true;
            // 
            // BtnEliminarCheckNo
            // 
            this.BtnEliminarCheckNo.Location = new System.Drawing.Point(206, 104);
            this.BtnEliminarCheckNo.Name = "BtnEliminarCheckNo";
            this.BtnEliminarCheckNo.Size = new System.Drawing.Size(75, 23);
            this.BtnEliminarCheckNo.TabIndex = 2;
            this.BtnEliminarCheckNo.Text = "No";
            this.BtnEliminarCheckNo.UseVisualStyleBackColor = true;
            // 
            // FrmEliminarCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 180);
            this.Controls.Add(this.BtnEliminarCheckNo);
            this.Controls.Add(this.BtnEliminarCheckSi);
            this.Controls.Add(this.label1);
            this.Name = "FrmEliminarCheck";
            this.Text = "FrmBorrarCheck";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnEliminarCheckSi;
        private System.Windows.Forms.Button BtnEliminarCheckNo;
    }
}