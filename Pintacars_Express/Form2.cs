using System;
using System.Collections;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        ArrayList Servicios = new ArrayList();


        private void creacion_Dgv_Servicios()
        {
            DgvServicios.RowHeadersVisible = false;
            DgvServicios.ColumnCount = 3;
            DgvServicios.Columns[0].Name = "CANTIDAD";
            DgvServicios.Columns[1].Name = "DESCRIPCÍON";
            DgvServicios.Columns[2].Name = "Vr. TOTAL";
            Servicios.Add("1");
            Servicios.Add("Arreglo de guardabarros");
            Servicios.Add(30000);
            DgvServicios.Rows.Add(Servicios.ToArray());
        }



        private void Form2_Load(object sender, EventArgs e)
        {
            creacion_Dgv_Servicios();
        }

        private void BtnCotizacion_Click(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            form1.Show();
            Hide();
        }
    }
}
