using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPWinForm_equipo_q.Articulo
{

    public partial class frmABM : Form
    {
        private Dominio.Articulo articulo = null;
        private bool detalle = false;

        public frmABM()
        {
            InitializeComponent();
            Text = "Agregar Articulo";
        }

        public frmABM(Dominio.Articulo aux)
        {
            InitializeComponent();
            articulo = aux;
            Text = "Modificar Articulo";
        }

        public frmABM(Dominio.Articulo aux, bool detalle)
        {
            InitializeComponent();
            articulo = aux;
            Text = "Detalle del Articulo";
            this.detalle = detalle;
        }

        private void frmABM_Load(object sender, EventArgs e)
        {
            if (articulo != null)
            {
                txtId.Text = articulo.Id.ToString();
                txtCodigo.Text = articulo.CodigoArticulo;
                txtNombre.Text = articulo.Nombre;
                txtDescripcion.Text = articulo.Descripcion;
                txtPrecio.Text = articulo.Precio.ToString();

                cbxMarca.Items.Add(articulo.Marca);
                cbxMarca.SelectedIndex = 0;

                cbxCategoria.Items.Add(articulo.Categoria);
                cbxCategoria.SelectedIndex = 0;

                CargarImagen(articulo.UrlImagen);
            }

            activarDesactivarGbx();
        }

        private void activarDesactivarGbx()
        {
            txtId.Enabled = false;
            txtCodigo.Enabled = !detalle;
            txtNombre.Enabled = !detalle;
            txtDescripcion.Enabled = !detalle;
            txtPrecio.Enabled = !detalle;
            cbxMarca.Enabled = !detalle;
            cbxCategoria.Enabled = !detalle;
            btnGrabar.Visible = !detalle;
        }

        private void CargarImagen(string imagen)
        {
            try
            {
                pbxImagenUrl.Load(imagen);
            }
            catch (Exception)
            {
                pbxImagenUrl.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSS5DKzdprfHmIYRpEfNNPVRYPDfh0Bvjjw_Ud_yRIwSw&s=10");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
