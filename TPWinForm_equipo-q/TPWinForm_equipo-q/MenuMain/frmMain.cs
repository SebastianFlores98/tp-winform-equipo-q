using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPWinForm_equipo_q.Categoria;

namespace TPWinForm_equipo_q
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void BtnMainMarcas_Click(object sender, EventArgs e)
        {
            frmMarcas frmMarcasMenu = new frmMarcas();
            frmMarcasMenu.ShowDialog();
        }

        private void BtnMainCategorias_Click(object sender, EventArgs e)
        {
            frmCategorias frmCategoriaMenu = new frmCategorias();
            frmCategoriaMenu.ShowDialog();
        }
    }
}
