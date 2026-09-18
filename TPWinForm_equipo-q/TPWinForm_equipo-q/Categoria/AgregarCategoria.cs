using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace TPWinForm_equipo_q.Categoria
{
    public partial class frmAgregarCategoria : Form
    {
        public frmAgregarCategoria()
        {
            InitializeComponent();
        }

        private void btnCancelarCategoria_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AgregarCategoria_Load(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            dgvCategoria.DataSource = negocio.listar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Dominio.Categoria nueva = new Dominio.Categoria();
            CategoriaNegocio negocio = new CategoriaNegocio();

            try
            {
                nueva.Descripcion = txtAgregarCategoria.Text;

                negocio.agregar(nueva);
                MessageBox.Show("Se agrego correctamente");
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
