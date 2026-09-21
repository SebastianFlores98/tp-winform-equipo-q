using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace TPWinForm_equipo_q.Articulo
{

    public partial class frmABM : Form
    {
        private Dominio.Articulo articulo = null;
        private bool detalle = false;

        private List<string> listaImagenes = new List<string>();
        private int imagenActual = 0;

        // Muestra las imagenes 
        private void mostrarImagenActual()
        {
            // Si no hay imágenes en la lista deshabilita los botones y carga una imagen por defecto.
            if (listaImagenes == null || listaImagenes.Count == 0)
            {
                pbxCarrusel.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSS5DKzdprfHmIYRpEfNNPVRYPDfh0Bvjjw_Ud_yRIwSw&s=10");
                txtUrlImagen.Text = "Sin Imagen";
                btnAnterior.Enabled = false;
                btnSiguiente.Enabled = false;
                return;
            }

            try
            {
                txtUrlImagen.Text = listaImagenes[imagenActual];
                pbxCarrusel.Load(listaImagenes[imagenActual]);
            }
            catch (Exception)
            {
                pbxCarrusel.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSS5DKzdprfHmIYRpEfNNPVRYPDfh0Bvjjw_Ud_yRIwSw&s=10");
            }

            // Habilita o deshabilita las flechas para ver las imágenes
            btnAnterior.Enabled = (imagenActual > 0);
            btnSiguiente.Enabled = (imagenActual < listaImagenes.Count - 1);
        }

        public frmABM()
        {
            InitializeComponent();
            Text = "Agregar Artículo";
        }

        public frmABM(Dominio.Articulo aux)
        {
            InitializeComponent();
            articulo = aux;
            Text = "Modificar Artículo";
        }

        public frmABM(Dominio.Articulo aux, bool detalle)
        {
            InitializeComponent();
            articulo = aux;
            Text = "Detalle del Artículo";
            this.detalle = detalle;
        }

        private void frmABM_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                cboMarca.DataSource = marcaNegocio.Listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";

                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";

                cboMarca.SelectedIndex = -1;
                cboCategoria.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (articulo != null)
            {
                txtId.Text = articulo.Id.ToString();
                txtCodigo.Text = articulo.CodigoArticulo;
                txtNombre.Text = articulo.Nombre;
                txtDescripcion.Text = articulo.Descripcion;
                txtPrecio.Text = articulo.Precio.ToString();

                cboMarca.SelectedValue = articulo.Marca.Id;
                cboCategoria.SelectedValue = articulo.Categoria.Id;

                ImagenNegocio imagenNegocio = new ImagenNegocio();
                listaImagenes = imagenNegocio.ListarImagenes(articulo.Id);

                mostrarImagenActual();
            }
            else
            {
                btnAnterior.Enabled = false;
                btnSiguiente.Enabled = false;
            }

            activarDesactivarGbx();
        }

        private void activarDesactivarGbx()
        {
            txtId.Enabled = false;
            txtCodigo.Enabled = !detalle;
            txtNombre.Enabled = !detalle;
            txtDescripcion.Enabled = !detalle;
            txtPrecio.Enabled = !detalle;
            cboMarca.Enabled = !detalle;
            cboCategoria.Enabled = !detalle;
            txtUrlImagen.Enabled = !detalle;
            btnGrabar.Visible = !detalle;
            btnAgregarImagen.Visible = !detalle;
        }

        private bool cargarImagen(string imagen)
        {
            // Consulto si el campo de imagen está vacío
            if (string.IsNullOrEmpty(imagen) || imagen == "Sin Imagen")
            {
                pbxCarrusel.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSS5DKzdprfHmIYRpEfNNPVRYPDfh0Bvjjw_Ud_yRIwSw&s=10");
                return false;
            }

            try
            {
                pbxCarrusel.Load(imagen);
                return true;
            }
            catch (Exception)
            {
                pbxCarrusel.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSS5DKzdprfHmIYRpEfNNPVRYPDfh0Bvjjw_Ud_yRIwSw&s=10");
                return false;
            }
        }

        private bool ValidarCboMarca()
        {
            if (cboMarca.SelectedIndex < 0)
            {
                MessageBox.Show("Debe ingresar una marca");
                return true;
            }
            return false;
        }

        private bool ValidarCboCategoria()
        {
            if (cboCategoria.SelectedIndex < 0)
            {
                MessageBox.Show("Debe ingresar una categoria");
                return true;
            }
            return false;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (ValidarCboMarca())
                {
                    return;
                }

                if (ValidarCboCategoria())
                {
                    return;
                }

                if (articulo == null)
                {
                    articulo = new Dominio.Articulo();
                }

                articulo.CodigoArticulo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Marca = (Dominio.Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Dominio.Categoria)cboCategoria.SelectedItem;
                
                if(string.IsNullOrWhiteSpace(txtPrecio.Text))
                {
                    MessageBox.Show("Ingresar Precio");
                    return;
                }
                if(!Validaciones.SoloNumeros(txtPrecio.Text))
                {
                    MessageBox.Show("Ingresar solo Números", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                articulo.Precio = decimal.Parse(txtPrecio.Text);

                articulo.Imagenes = listaImagenes;

                if (articulo.Id != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Modificado exitosamente");

                }
                else
                {
                    negocio.agregar(articulo);
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

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (imagenActual > 0)
            {
                imagenActual--;
                mostrarImagenActual();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (imagenActual < listaImagenes.Count - 1)
            {
                imagenActual++;
                mostrarImagenActual();
            }
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            string urlIngresada = txtUrlImagen.Text.Trim();

            if (!cargarImagen(urlIngresada))
            {
                MessageBox.Show("No se puede agregar.", "Enlace Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifico si ya fue agregada antes
            if (listaImagenes.Contains(urlIngresada))
            {
                MessageBox.Show("Esta imagen ya se encuentra añadida en este artículo.", "Imagen Duplicada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            listaImagenes.Add(urlIngresada);

            imagenActual = listaImagenes.Count - 1;
            mostrarImagenActual();

            txtUrlImagen.Clear();
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)//probando validar que solo se ingresen numeros
        {
        }
    }
}
