using CapaEntidades;
using CapaNegocio;
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
    public partial class Cotizacion : Form
    {
        CN_Partes_Inspeccion oCN_Partes_Inspeccion = new CN_Partes_Inspeccion();
        CN_Tipo_Pago oCN_Tipo_Pago = new CN_Tipo_Pago();
        CN_Marca oCN_Marca = new CN_Marca();
        CN_Vehiculos oCN_Vehiculos = new CN_Vehiculos();
        CN_Cotizacion oCN_Cotizacion = new CN_Cotizacion();
        CN_Cotizacion_Inspeccion oCN_Cotizacion_Inspeccion = new CN_Cotizacion_Inspeccion();
        CN_Pagos oCN_Pagos = new CN_Pagos();
        int numerocotizacion = 0;


        public Cotizacion()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            BuscarNumeroCotizacionInicial();
            MostrarPartesInspecion_CE();
            MostrarPartesInspecion_IC();
            MostrarPartesInspecion_IB();
            MostrarPartesInspecion_IV();
            MostrarTipoPago();
            MostrarMarcas();

            //creacion_Dgv_ConjuntoExt();

            //creacion_DgvAbonos();
        }


        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form panel_principal = new Panel_Principal();
            panel_principal.Show();
            Hide();
        }

        private void nuevaCotizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Corizacion_Inicial = new Cotizacion_Inicial();
            Corizacion_Inicial.Show();
            Hide();
        }

        private void nuevaOrdenDeServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form orden_servicio = new Orden_Servicio();
            orden_servicio.Show();
            Hide();
        }

        private void inicioSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form inicio_sesion = new Inicio_Sesion();
            inicio_sesion.Show();
            Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        #region Mis métodos

        //ArrayList Interior_Capot = new ArrayList();
        //ArrayList Interior_Baul = new ArrayList();
        //ArrayList Interior_Vehiculo = new ArrayList();
        //ArrayList Valores = new ArrayList();
        //private void creacion_Dgv_ConjuntoExt()
        //{
        //    DataTable dt = new DataTable();
        //    DataRow fila = dt.NewRow();

        //    dt.Columns.Add("CONJUNTO EXTERIOR");
        //    dt.Columns.Add("OBSERVACIONES");


        //    fila["CONJUNTO EXTERIOR"] = "hola";
        //    dt.Rows.Add(fila);          

        //    DgvConjuntoExt.RowHeadersVisible = false;

        //    DgvConjuntoExt.DataSource = dt;
        //}


        //private void creacion_DgvAbonos()
        //{
        //    DgvAbonos.RowHeadersVisible = false;
        //    DgvAbonos.ColumnCount = 1;
        //    //DgvValores.Columns[0].Name = "VALORES";
        //    //DgvValores.Columns[1].Name = "ABONOS";
        //    //Valores.Add("TOTAL:");
        //    //Valores.Add("TOTAL:");
        //    //DgvAbonos.Rows.Add(Valores.ToArray());
        //}


        //Consultar


        private void BuscarNumeroCotizacionInicial()
        {
            if (oCN_Cotizacion.BuscarNumeroCotizacion() != " ")
            {
                numerocotizacion = Convert.ToInt32(oCN_Cotizacion.BuscarNumeroCotizacion()) + 1;
                LblNumero_Cotizacion.Text = "N° " + numerocotizacion.ToString();
            }
            else
                numerocotizacion = 1;
            LblNumero_Cotizacion.Text = "N° " + numerocotizacion.ToString();
        }


        private void MostrarPartesInspecion_CE()
        {
            DgvConjuntoExt.DataSource = oCN_Partes_Inspeccion.MostrarPartesInspecion_CE();
            DgvConjuntoExt.Columns.Add("OBSERVACIONES", "OBSERVACIONES");
            DgvConjuntoExt.Columns["cod"].Visible = false;
            //DgvConjuntoExt.Columns["CONJUNTO EXTERIOR"].ReadOnly = true;
        }


        private void MostrarPartesInspecion_IC()
        {
            DgvInteriorCapot.DataSource = oCN_Partes_Inspeccion.MostrarPartesInspecion_IC();
            DgvInteriorCapot.Columns.Add("OBSERVACIONES", "OBSERVACIONES");
            DgvInteriorCapot.Columns["cod"].Visible = false;
            //DgvInteriorCapot.Columns["INTERIOR CAPOT"].ReadOnly = true;
        }


        private void MostrarPartesInspecion_IB()
        {
            DgvInteriorBaul.DataSource = oCN_Partes_Inspeccion.MostrarPartesInspecion_IB();
            DgvInteriorBaul.Columns.Add("OBSERVACIONES", "OBSERVACIONES");
            DgvInteriorBaul.Columns["cod"].Visible = false;
            //DgvInteriorBaul.Columns["INTERIOR BAUL"].ReadOnly = true;
        }


        private void MostrarPartesInspecion_IV()
        {
            DgvInteriorVehiculo.DataSource = oCN_Partes_Inspeccion.MostrarPartesInspecion_IV();
            DgvInteriorVehiculo.Columns.Add("ESTADO", "ESTADO");
            DgvInteriorVehiculo.Columns["cod"].Visible = false;
            //DgvInteriorVehiculo.Columns["INTERIOR DEL VEHICULO"].ReadOnly = true;
        }


        private void MostrarTipoPago()
        {
            DataGridViewComboBoxColumn columna = new DataGridViewComboBoxColumn();

            DgvAbonos.Columns.Add("ABONO", "ABONO");

            columna.HeaderText = "TIPO DE PAGO";
            columna.Name = "TIPO_PAGO";
            columna.DataSource = oCN_Tipo_Pago.MostrarTipoPago();
            columna.DisplayMember = "Nombre";
            columna.ValueMember = "Cod";
            DgvAbonos.Columns.Add(columna);
        }


        private void MostrarMarcas()
        {
            CboMarca.DataSource = oCN_Marca.MostrarMarcas();
            CboMarca.DisplayMember = "Nombre";
            CboMarca.ValueMember = "Cod";
            CboMarca.SelectedIndex = -1;
        }
        #endregion

        private void BtnTerminar_Click(object sender, EventArgs e)
        {
            CE_Vehiculos vehiculo = new CE_Vehiculos();
            CE_Cotizacion cotizacion = new CE_Cotizacion();
            CE_Cotizacion_Inspeccion cotizacion_inspeccion = new CE_Cotizacion_Inspeccion();
            CE_Pagos pago = new CE_Pagos();

            vehiculo.Matricula = TxtPlaca.Text;
            vehiculo.Modelo = TxtModelo.Text;
            vehiculo.Color = TxtColor.Text;
            vehiculo.Año = TxtAño.Text;
            vehiculo.Clave = TxtClave.Text;
            vehiculo.Cod_Marca = Convert.ToInt32(CboMarca.SelectedValue);
            oCN_Vehiculos.InsertarVehiculo(vehiculo);

            cotizacion.Kilometraje = TxtKilometraje.Text;
            cotizacion.Fecha_Llegada = DtpFecha_Recibido.Value;
            cotizacion.Fecha_Entrega = DtpFecha_Entrega.Value;
            foreach (DataGridViewRow filas in DgvRelacionTrabajo.Rows)
            {
                cotizacion.Descripcion = filas.Cells["RELACION_TRABAJO"].Value.ToString();
                DgvRelacionTrabajo.AllowUserToAddRows = false;
            }
            cotizacion.entrega = TxtEntrega.Text;
            cotizacion.recibe = TxtRecibe.Text;
            cotizacion.mano_obra = float.Parse(TxtMano_Obra.Text);
            cotizacion.repuestos = float.Parse(TxtRepuestos.Text);
            cotizacion.otros = float.Parse(TxtOtros.Text);
            cotizacion.Precio = float.Parse(TxtTotal.Text);
            cotizacion.saldo = float.Parse(TxtSaldo.Text);
            cotizacion.D_I_Cliente = "333";
            cotizacion.Matricula_Vehiculo = TxtPlaca.Text;
            cotizacion.Cod_Cotizacion_Inicial = 1;
            DgvRelacionTrabajo.AllowUserToAddRows = true;
            oCN_Cotizacion.InsertarCotizacion(cotizacion);

            foreach (DataGridViewRow filas in DgvConjuntoExt.Rows)
            {
                cotizacion_inspeccion.cod_partes_inspeccion = Convert.ToInt32(filas.Cells["cod"].Value.ToString());
                cotizacion_inspeccion.observaciones = filas.Cells["OBSERVACIONES"].Value.ToString();
                cotizacion_inspeccion.cod_cotizacion = numerocotizacion;
                DgvConjuntoExt.AllowUserToAddRows = false;
                MessageBox.Show(cotizacion_inspeccion.ToString());
                oCN_Cotizacion_Inspeccion.InsertarCotizacionInspeccion(cotizacion_inspeccion);
            }
            //foreach (DataGridViewRow filas in DgvInteriorCapot.Rows)
            //{
            //    cotizacion_inspeccion.cod_partes_inspeccion = Convert.ToInt32(filas.Cells["Cod"].Value.ToString());
            //    cotizacion_inspeccion.observaciones = filas.Cells["OBSERVACIONES"].Value.ToString();
            //    cotizacion_inspeccion.cod_cotizacion = numerocotizacion;
            //    DgvInteriorCapot.AllowUserToAddRows = false;
            //    oCN_Cotizacion_Inspeccion.InsertarCotizacionInspeccion(cotizacion_inspeccion);
            //}
            //foreach (DataGridViewRow filas in DgvInteriorVehiculo.Rows)
            //{
            //    cotizacion_inspeccion.cod_partes_inspeccion = Convert.ToInt32(filas.Cells["Cod"].Value.ToString());
            //    cotizacion_inspeccion.observaciones = filas.Cells["ESTADO"].Value.ToString();
            //    cotizacion_inspeccion.cod_cotizacion = numerocotizacion;
            //    DgvInteriorVehiculo.AllowUserToAddRows = false;
            //    oCN_Cotizacion_Inspeccion.InsertarCotizacionInspeccion(cotizacion_inspeccion);
            //}
            //foreach (DataGridViewRow filas in DgvInteriorBaul.Rows)
            //{
            //    cotizacion_inspeccion.cod_partes_inspeccion = Convert.ToInt32(filas.Cells["Cod"].Value.ToString());
            //    cotizacion_inspeccion.observaciones = filas.Cells["OBSERVACIONES"].Value.ToString();
            //    cotizacion_inspeccion.cod_cotizacion = numerocotizacion;
            //    DgvInteriorBaul.AllowUserToAddRows = false;
            //    oCN_Cotizacion_Inspeccion.InsertarCotizacionInspeccion(cotizacion_inspeccion);
            //}
            foreach (DataGridViewRow filas in DgvAbonos.Rows)
            {
                pago.Fecha = DateTime.Now;
                //pago.cod_cotizacion = Convert.ToInt32(filas.Cells["ABONO"].Value.ToString());
                pago.cod_cotizacion = numerocotizacion;
                DgvAbonos.AllowUserToAddRows = false;
                //oCN_Pagos.InsertarPago(pago);
            }
            DgvConjuntoExt.AllowUserToAddRows = true;
            DgvInteriorCapot.AllowUserToAddRows = false;
            DgvInteriorVehiculo.AllowUserToAddRows = false;
            DgvInteriorBaul.AllowUserToAddRows = false;
            DgvAbonos.AllowUserToAddRows = false;

            BuscarNumeroCotizacionInicial();
            MessageBox.Show("Cotización Terminada");
        }
    }
}