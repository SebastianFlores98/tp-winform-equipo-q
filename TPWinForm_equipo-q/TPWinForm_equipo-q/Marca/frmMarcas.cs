using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPWinForm_equipo_q.Marca;

namespace TPWinForm_equipo_q
{
    public partial class frmMarcas : Form
    {
        public frmMarcas()
        {
            InitializeComponent();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            frmEliminarCheck frmEliminarVentana = new frmEliminarCheck();
            frmEliminarVentana.ShowDialog();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregar frmAgregarVentana = new frmAgregar();
            frmAgregarVentana.ShowDialog();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            frmModificar frmModificarVentana = new frmModificar();
            frmModificarVentana.ShowDialog();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            frmDetalle frmDetalleVentana = new frmDetalle();
            frmDetalleVentana.ShowDialog();
        }
    }
}
