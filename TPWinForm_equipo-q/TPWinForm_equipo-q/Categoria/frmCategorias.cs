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
    public partial class frmCategorias : Form
    {
        private List<Dominio.Categoria> listaCategoria;

        public frmCategorias()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarCategoria agregarCategoria = new frmAgregarCategoria();
            agregarCategoria.ShowDialog();
            Cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Dominio.Categoria seleccionada;
            if (dgvCategoria.CurrentRow != null)
            {
                seleccionada = (Dominio.Categoria)dgvCategoria.CurrentRow.DataBoundItem;
                frmAgregarCategoria modificarCategoria = new frmAgregarCategoria(seleccionada);
                modificarCategoria.ShowDialog();
                Cargar();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una categoria");
            }
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            CategoriaNegocio listado = new CategoriaNegocio();
            try
            {
                listaCategoria = listado.listar();
                dgvCategoria.DataSource = listaCategoria;
                ocultarColumnas();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void ocultarColumnas()
        {
            dgvCategoria.Columns["Id"].Visible = false;
        }

        private void dgvCategoria_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategoria.SelectedRows.Count != 0)
            {
                Dominio.Categoria seleccionado = (Dominio.Categoria)dgvCategoria.CurrentRow.DataBoundItem;
            }
        }

        private void textBoxBuscadorFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Dominio.Categoria> listaFiltrada;
            string filtro = textBoxBuscadorFiltro.Text;

            if (filtro.Length >= 2)
            {
                listaFiltrada = listaCategoria.FindAll(x => x.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaCategoria;
            }

            dgvCategoria.DataSource = null;
            dgvCategoria.DataSource = listaFiltrada;
            ocultarColumnas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            Dominio.Categoria seleccionada;
            try
            {
                if(dgvCategoria.CurrentRow == null)
                {
                    MessageBox.Show("Debes seleccionar una Categoria");
                    return;
                }
                seleccionada = (Dominio.Categoria)dgvCategoria.CurrentRow.DataBoundItem;

                //validamos que la categoria no este siendo usada por un articulo
                if(Negocio.Validaciones.CategoriaEnUso(seleccionada.Id))
                {
                    MessageBox.Show("Categoria en uso por uno o más articulos, no puede ser eliminada");
                    return;
                }

                DialogResult respuesta = MessageBox.Show("¿Seguro que querés eliminar esta Categoria?", "Eliminar Categoria", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {

                    negocio.eliminar(seleccionada.Id);
                    Cargar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void textBoxBuscadorFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
