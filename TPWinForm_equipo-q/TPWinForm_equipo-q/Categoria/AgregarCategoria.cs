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

namespace TPWinForm_equipo_q.Categoria
{
    public partial class frmAgregarCategoria : Form
    {
        private Dominio.Categoria categoria = null;
        public frmAgregarCategoria()
        {
            InitializeComponent();
        }

        public frmAgregarCategoria(Dominio.Categoria categoria)
        {
            InitializeComponent();
            this.categoria = categoria;
            Text = "Modificar Categoria";
        }

        private void btnCancelarCategoria_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AgregarCategoria_Load(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            dgvCategoria.DataSource = negocio.listar();

            if (categoria != null)
            {
                txtAgregarCategoria.Text = categoria.Descripcion.ToString();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            {
               CategoriaNegocio negocio = new CategoriaNegocio();

                try
                {
                    if (categoria == null)
                        categoria = new Dominio.Categoria();

                    categoria.Descripcion = txtAgregarCategoria.Text;

                    if(categoria.Id != 0)
                    {
                        negocio.modificar(categoria);
                        MessageBox.Show("Modificado exitosamente");
                    }
                    else
                    {
                        negocio.agregar(categoria);
                        MessageBox.Show("Se agrego correctamente");
                    }
                    
                    Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
