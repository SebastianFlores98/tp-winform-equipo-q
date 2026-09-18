using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace TPWinForm_equipo_q.Articulo
{

    public partial class frmABM : Form
    {
        private Dominio.Articulo articulo = null;
        private bool detalle = false;

        public frmABM()
        {
            InitializeComponent();
            Text = "Agregar Artículo";
        }

        public frmABM(Dominio.Articulo aux)
        {
            InitializeComponent();
            articulo = aux;
            Text = "Modificar Artículo";
        }

        public frmABM(Dominio.Articulo aux, bool detalle)
        {
            InitializeComponent();
            articulo = aux;
            Text = "Detalle del Artículo";
            this.detalle = detalle;
        }

        private void frmABM_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                cboMarca.DataSource = marcaNegocio.Listar(); 
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";

                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (articulo != null)
            {
                txtId.Text = articulo.Id.ToString();
                txtCodigo.Text = articulo.CodigoArticulo;
                txtNombre.Text = articulo.Nombre;
                txtDescripcion.Text = articulo.Descripcion;
                txtPrecio.Text = articulo.Precio.ToString();

                cboMarca.SelectedValue = articulo.Marca.Id;
                cboCategoria.SelectedValue = articulo.Categoria.Id;

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
            cboMarca.Enabled = !detalle;
            cboCategoria.Enabled = !detalle;
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

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (articulo == null)
                {
                    articulo = new Dominio.Articulo();
                }

                articulo.CodigoArticulo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Marca = (Dominio.Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Dominio.Categoria)cboCategoria.SelectedItem;
                articulo.Precio = decimal.Parse(txtPrecio.Text);

                if(articulo.Id != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Modificado exitosamente");

                } else
                {
                    negocio.agregar(articulo);
                    MessageBox.Show("Agregado exitosamente");
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
