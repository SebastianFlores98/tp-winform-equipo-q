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

namespace TPWinForm_equipo_q.Articulo
{
    public partial class frmArticulos : Form
    {
        private List<Dominio.Articulo> listaArticulo;

        public frmArticulos()
        {
            InitializeComponent();
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
            Cargar();         
        }

        private void Cargar()
        {
            ArticuloNegocio listado = new ArticuloNegocio();
            listaArticulo = listado.Listar();
            dgvArticulos.DataSource = listaArticulo;
            ocultarColumnas();
            cargarImagen(listaArticulo[0].UrlImagen);
        }

        private void ocultarColumnas()
        {
            dgvArticulos.Columns["UrlImagen"].Visible = false;
            dgvArticulos.Columns["Id"].Visible = false;
        }

        private void cargarImagen(string imagen)
        {
            try
            {
               pbxArticulo.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxArticulo.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSS5DKzdprfHmIYRpEfNNPVRYPDfh0Bvjjw_Ud_yRIwSw&s=10");
            }
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Dominio.Articulo seleccionado = (Dominio.Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.UrlImagen);
            }
            
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Dominio.Articulo seleccionado = (Dominio.Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            DialogResult respuesta = MessageBox.Show(
                "¿Seguro que querés eliminar este artículo?",
                "Eliminar Artículo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.Eliminar(seleccionado.Id);
                MessageBox.Show("Artículo eliminado con éxito.");
                Cargar(); 
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Dominio.Articulo seleccionado = (Dominio.Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmABM frmDetalleArticulo = new frmABM(seleccionado, true);
            frmDetalleArticulo.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Dominio.Articulo seleccionado = (Dominio.Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmABM frmModificarArticulo = new frmABM(seleccionado);
            frmModificarArticulo.ShowDialog();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmABM frmModificarArticulo = new frmABM();
            frmModificarArticulo.ShowDialog();
        }

       

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {

            List<Dominio.Articulo> listaFiltrada;
            string filtro = txtFiltro.Text;
            if (filtro.Length >= 3)
            {
                listaFiltrada = listaArticulo.FindAll(x => x.Nombre.ToLower().Contains(filtro.ToLower())
                || x.Categoria.Descripcion.ToLower().Contains(filtro.ToLower())
                || x.Marca.Descripcion.ToLower().Contains(filtro.ToLower())
                || x.CodigoArticulo.ToLower().Contains(filtro.ToLower())
                );

            }
            else
            {
                listaFiltrada = listaArticulo;
            }

            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = listaFiltrada;
            ocultarColumnas();
        }
    }
}
