using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pintacars_Express
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ArrayList Conjunto_Exterior = new ArrayList();
        ArrayList Interior_Capot = new ArrayList();
        ArrayList Interior_Baul = new ArrayList();
        ArrayList Interior_Vehiculo = new ArrayList();
        ArrayList Valores = new ArrayList();
        private void creacion_Dgv_ConjuntoExt()
        {
            DgvConjuntoExt.RowHeadersVisible = false;
            DgvConjuntoExt.ColumnCount = 2;
            DgvConjuntoExt.Columns[0].Name = "CONJUNTO EXTERIOR";
            DgvConjuntoExt.Columns[1].Name = "OBSERVACIONES";
            Conjunto_Exterior.Add("Capot");
            DgvConjuntoExt.Rows.Add(Conjunto_Exterior.ToArray());
        }

        private void creacion_DgvInteriorCapot()
        {
            DgvInteriorCapot.RowHeadersVisible = false;
            DgvInteriorCapot.ColumnCount = 2;
            DgvInteriorCapot.Columns[0].Name = "INTERIOR CAPOT";
            DgvInteriorCapot.Columns[1].Name = "OBSERVACIONES";
            Interior_Capot.Add("Bateria");
            DgvInteriorCapot.Rows.Add(Interior_Capot.ToArray());
        }

        private void creacion_DgvInteriorBaul()
        {
            DgvInteriorBaul.RowHeadersVisible = false;
            DgvInteriorBaul.ColumnCount = 3;
            DgvInteriorBaul.Columns[0].Name = "INTERIOR CAPOT";
            DgvInteriorBaul.Columns[1].Name = "OBSERVACIONES";
            DgvInteriorBaul.Columns[2].Name = "RELACION TRABAJO";
            DgvInteriorBaul.Columns[2].Width = 337;
            Interior_Baul.Add("Gato");
            DgvInteriorBaul.Rows.Add(Interior_Baul.ToArray());
        }

        private void creacion_DgvInteriorVehiculo()
        {
            DgvInteriorVehiculo.RowHeadersVisible = false;
            DgvInteriorVehiculo.ColumnCount = 2;
            DgvInteriorVehiculo.Columns[0].Name = "INTERIOR CAPOT";
            DgvInteriorVehiculo.Columns[1].Name = "OBSERVACIONES";
            Interior_Vehiculo.Add("Tablero");
            DgvInteriorVehiculo.Rows.Add(Interior_Vehiculo.ToArray());
        }

        private void creacion_DgvValores()
        {
            DgvValores.RowHeadersVisible = false;
            DgvValores.ColumnCount = 2;
            DgvValores.Columns[0].Name = "VALORES";
            DgvValores.Columns[1].Name = "ABONOS";
            Valores.Add("TOTAL:");
            Valores.Add("TOTAL:");
            DgvValores.Rows.Add(Valores.ToArray());
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            creacion_Dgv_ConjuntoExt();
            creacion_DgvInteriorCapot();
            creacion_DgvInteriorBaul();
            creacion_DgvInteriorVehiculo();
            creacion_DgvValores();
        }

        private void BtnCotizacion_Inicial_Click(object sender, EventArgs e)
        {
            Form form1 = new Form2();
            form1.Show();
            Hide();
        }
    }
}
