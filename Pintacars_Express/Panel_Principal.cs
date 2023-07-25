using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pintacars_Express
{
    public partial class FrmPanel_Principal : Form
    {
        public FrmPanel_Principal()
        {
            InitializeComponent();
        }
        
        
        private void nuevaCotizaciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form Corizacion_Inicial = new FrmCotizacion_Inicial();
            Corizacion_Inicial.Show();
            Hide();
        }
        private void nuevaOrdendeTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form orden_trabajo = new FrmOrden_Trabajo();
            orden_trabajo.Show();
            Hide();
        }

        private void nuevaCostosGeneralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form costos_generales = new FrmCostos_Generales();
            costos_generales.Show();
            bool error = FrmCostos_Generales.error;
            if (error == true)
            {
                costos_generales.Show();
                Hide();
            }           
            else if (error == false)
            {
                costos_generales.Hide();
            }
        }

        private void inicioSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form inicio_sesion = new FrmInicio_Sesion();
            inicio_sesion.Show();
            Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
