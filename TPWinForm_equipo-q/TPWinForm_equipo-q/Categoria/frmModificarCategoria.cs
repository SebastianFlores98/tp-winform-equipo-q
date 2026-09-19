using Negocio;
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
    public partial class frmModificarCategoria : Form
    {
        public frmModificarCategoria()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¿Esta seguro que desea modificar la categoria?");
        }

        private void frmModificarCategoria_Load(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            dgvModificarCategoria.DataSource = negocio.listar();
        }
    }
}
