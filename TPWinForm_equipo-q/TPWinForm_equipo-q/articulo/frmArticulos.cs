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
            cboCampo.Items.Add("Precio");
            cboCampo.Items.Add("Marca");
            cboCampo.Items.Add("Categoria");
        }

        private void Cargar()
        {
            ArticuloNegocio listado = new ArticuloNegocio();

            try
            {
                listaArticulo = listado.Listar();
                dgvArticulos.DataSource = listaArticulo;
                ocultarColumnas();
                cargarImagen(listaArticulo[0].UrlImagen);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
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
            catch (Exception)
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmABM frmAgregarArticulo = new frmABM();
            frmAgregarArticulo.ShowDialog();
            Cargar();
        }

        // Valida que haya un Id seleccionado en la grilla
        private bool validarIdSeleccionado()
        {
            if (dgvArticulos.CurrentRow == null || dgvArticulos.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Por favor, seleccione un artículo de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; 
            }
            return true; 
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!validarIdSeleccionado())
            {
                return;
            }

            Dominio.Articulo seleccionado = (Dominio.Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmABM frmModificarArticulo = new frmABM(seleccionado);
            frmModificarArticulo.ShowDialog();
            Cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!validarIdSeleccionado())
            {
                return;
            }

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
            if (!validarIdSeleccionado())
            {
                return;
            }

            Dominio.Articulo seleccionado = (Dominio.Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmABM frmDetalleArticulo = new frmABM(seleccionado, true);
            frmDetalleArticulo.ShowDialog();
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

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            if (opcion == "Precio")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
        }

        private void btnFiltroAvanzado_Click(object sender, EventArgs e)
        {

            ArticuloNegocio negocioFiltro = new ArticuloNegocio();
            try
            {
                string campo = null;
                if (cboCampo.SelectedItem != null) campo = cboCampo.SelectedItem.ToString();

                string criterio = null;
                if (cboCriterio.SelectedItem != null) criterio = cboCriterio.SelectedItem.ToString();

                string filtro = txtFiltroAvanzado.Text;

                if (Validaciones.FiltroVacio(campo, criterio, filtro))
                {
                    MessageBox.Show("Completá campo, criterio y filtro antes de buscar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (campo == "Precio" && Validaciones.FiltroPrecioInvalido(filtro))
                {
                    MessageBox.Show("El filtro de Precio solo admite números.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dgvArticulos.DataSource = negocioFiltro.filtrar(campo, criterio, filtro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
