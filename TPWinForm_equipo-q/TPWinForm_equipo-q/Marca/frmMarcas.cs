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

    }
}
