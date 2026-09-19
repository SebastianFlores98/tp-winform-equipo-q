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

namespace TPWinForm_equipo_q.Marca
{
    public partial class frmMarcas : Form
    {

        private List<Dominio.Marca> listadoMarca;
        public frmMarcas()
        {
            InitializeComponent();
        }

        private void Cargar()
        {
            MarcaNegocio listado = new MarcaNegocio();
            listadoMarca = listado.Listar();
            dgvMarcas.DataSource = listadoMarca;
            ocultarColumnas();
         
        }

        private void ocultarColumnas()
        {
            dgvMarcas.Columns["Id"].Visible = false;
        }
        private void frmMarcas_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btnEliminarMarca_Click(object sender, EventArgs e)
        {
            Dominio.Marca seleccionado = (Dominio.Marca)dgvMarcas.CurrentRow.DataBoundItem;

            DialogResult respuesta = MessageBox.Show(
                "¿Seguro que querés eliminar esta marca?",
                "Eliminar Marca",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                MarcaNegocio negocio = new MarcaNegocio();
                // 1. Ponemos el bloque "try" para intentar ejecutar el código
                try
                {
                    negocio.Eliminar(seleccionado.Id);
                    MessageBox.Show("Marca eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cargar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
