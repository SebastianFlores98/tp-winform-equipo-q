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
        private List<Dominio.Articulo> listaArticulo; // Los datos que obtengo de la BD los guardo en este atributo privado de la clase frmArticulos

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
            dgvArticulos.Columns["UrlImagen"].Visible = false;
            cargarImagen(listaArticulo[0].UrlImagen);
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
            Dominio.Articulo seleccionado = (Dominio.Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagen);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmABM frmModificarArticulo = new frmABM();
            frmModificarArticulo.ShowDialog();
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
                Cargar(); // ajustá el nombre si tu método de carga de grilla se llama distinto
            }
        }
    }
}
