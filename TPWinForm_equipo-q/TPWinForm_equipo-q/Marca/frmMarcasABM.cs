using Dominio;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TPWinForm_equipo_q.Marca
{
    public partial class frmMarcasABM : Form
    {
        private Dominio.Marca Marca = null;
        public frmMarcasABM()
        {
            InitializeComponent();
            Text = "Agregar Marca";
        }

        public frmMarcasABM(Dominio.Marca aux)
        {
            InitializeComponent();
            Marca = aux;
            Text = "Modificar Marca";
        }
     

        private void frmMarcasABM_Load(object sender, EventArgs e)
        {

            if (Marca != null)
            {
                txtId.Text = Marca.Id.ToString();
                txtDescripcion.Text = Marca.Descripcion;
                txtId.Enabled = false;
            }
            else
            {
                Marca = new Dominio.Marca();
                txtId.Enabled = false;
            }
 
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            try
            {           

                Marca.Descripcion = txtDescripcion.Text;

                if (Marca.Id != 0)
                {
                    negocio.modificar(Marca);
                    MessageBox.Show("Modificado exitosamente");

                }
                else
                {
                    negocio.agregar(Marca);

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
