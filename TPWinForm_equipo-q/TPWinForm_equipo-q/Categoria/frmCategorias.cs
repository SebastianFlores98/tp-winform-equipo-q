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
            seleccionada = (Dominio.Categoria)dgvCategoria.CurrentRow.DataBoundItem;

            frmAgregarCategoria modificarCategoria = new frmAgregarCategoria(seleccionada);
            modificarCategoria.ShowDialog();
            Cargar();
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
                dgvCategoria.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvCategoria_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategoria.SelectedRows.Count > 0)
            {
                Dominio.Categoria seleccionado = (Dominio.Categoria)dgvCategoria.CurrentRow.DataBoundItem;
            }
        }

        private void textBoxBuscador_TextChanged(object sender, EventArgs e)
        {

        }
    }    
}
