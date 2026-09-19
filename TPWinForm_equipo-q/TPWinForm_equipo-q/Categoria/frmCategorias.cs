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
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmModificarCategoria modificarCategoria = new frmModificarCategoria();
            modificarCategoria.ShowDialog();
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            CategoriaNegocio listado = new CategoriaNegocio();
            listaCategoria = listado.listar();
            dgvCategoria.DataSource = listaCategoria;
        }

        private void dgvCategoria_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategoria.SelectedRows.Count > 0)
            {
                Dominio.Categoria seleccionado = (Dominio.Categoria)dgvCategoria.CurrentRow.DataBoundItem;
            }
        }
    }    
}
