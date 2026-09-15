using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPWinForm_equipo_q.Categoria
{
    public partial class frmEliminarCategoria : Form
    {
        public frmEliminarCategoria()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmEliminarCategoriaCheck eliminarCheck = new frmEliminarCategoriaCheck();
            eliminarCheck.ShowDialog();
        }
    }
}
