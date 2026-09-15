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
    public partial class frmCategorias : Form
    {
        public frmCategorias()
        {
            InitializeComponent();
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            frmCategoriaAgregar agregarCategoria = new frmCategoriaAgregar();
            agregarCategoria.ShowDialog();
        }

        private void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            frmModificarCategoria modificarCategoria = new frmModificarCategoria();
            modificarCategoria.ShowDialog();
        }

        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            frmEliminarCategoria eliminarCategoria = new frmEliminarCategoria();
            eliminarCategoria.ShowDialog();
        }
    }
}
