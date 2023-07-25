using CapaEntidades.Orden_de_Trabajo;
using CapaEntidades;
using CapaNegocio;
using CapaNegocio.Orden_de_Trabajo;
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
using static Pintacars_Express.FrmInicio_Sesion;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.Remoting.Contexts;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;

namespace Pintacars_Express
{
    public partial class FrmOrden_Trabajo : Form
    {
        CN_Partes_Inspeccion oCN_Partes_Inspeccion = new CN_Partes_Inspeccion();
        CN_Tipo_Pago oCN_Tipo_Pago = new CN_Tipo_Pago();
        CN_Marca oCN_Marca = new CN_Marca();
        CN_Vehiculos oCN_Vehiculos = new CN_Vehiculos();
        CN_Orden_Trabajo oCN_Orden_Trabajo = new CN_Orden_Trabajo();
        CN_Orden_Trabajo_Inspeccion oCN_Orden_Trabajo_Inspeccion = new CN_Orden_Trabajo_Inspeccion();
        CN_Cotizacion_Inicial oCN_Cotizacion_Inicial = new CN_Cotizacion_Inicial();
        CN_Pagos oCN_Pagos = new CN_Pagos();
        CN_Clientes oCN_Clientes = new CN_Clientes();
        CN_Validaciones oCN_Validaciones= new CN_Validaciones();


        int numeroordentrabajo = 0;
        string numerocotizacioninicial = 1.ToString();
        string idvendedor = string.Empty;
        float totalpagos = 0;
        string doccliente = string.Empty;


        static public class OrdenTrabajoGlobal //Se crea una variable global
        {
            static public string OrdenTrabajo { get; set; } = string.Empty;
        }


        public FrmOrden_Trabajo()
        {
            InitializeComponent();
        }


        private void FrmOrden_Trabajo_Load(object sender, EventArgs e)
        {
            imagenOriginal = new Bitmap(pictureBox1.Image);
            BuscarNumeroOrdenTrabajo();
            MostrarPartesInspecion_CE();
            MostrarPartesInspecion_IC();
            MostrarPartesInspecion_IB();
            MostrarPartesInspecion_IV();
            MostrarRelacionTrabajo();
            MostrarTipoPago();
            MostrarMarcas();
            TraerUsuario();
            MostrarCliente();
            BtnTerminar.Enabled = false;
            LblCotizacion_Inicial.Text = 1.ToString()/*"N° " + FrmCotizacion_Inicial.CotizacionInicialGlobal.CotizacionInicial*/;
            //CboCotizacion_Inicial.Text = /*FrmCotizacion_Inicial.CotizacionInicialGlobal.CotizacionInicial;*/
            MostrarCotizacionInicial();
            Configurar_datagridviews();
            TomarZoomFactor(pictureBox1);
            Configurar_imagen();
            //creacion_Dgv_ConjuntoExt();
            //creacion_DgvAbonos();
        }


        //Botones del menustrip para ir de formulario en formulario en el panel


        private void inicioToolStripMenuItem_Click(object sender, EventArgs e) //Selecciona el formulario del panel principal del proyecto
        {
            Form panel_principal = new FrmPanel_Principal();
            panel_principal.Show();
            Hide();
        }

        private void nuevaCotizaciónToolStripMenuItem_Click(object sender, EventArgs e) //Selecciona el formulario de la cotización inicial del proyecto
        {
            Form Corizacion_Inicial = new FrmCotizacion_Inicial();
            Corizacion_Inicial.Show();
            Hide();
        }

        private void nuevaCostosGeneralesToolStripMenuItem_Click(object sender, EventArgs e) //Selecciona el formulario de los costos generales del proyecto
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

        private void inicioSesiónToolStripMenuItem_Click(object sender, EventArgs e) //Selecciona el formulario del inicio de sesión del proyecto
        {
            Form inicio_sesion = new FrmInicio_Sesion();
            inicio_sesion.Show();
            Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e) //Cierra el proyecto
        {
            Application.Exit();
        }


        #region Mis métodos


        bool isdrawing = false;
        Graphics g;
        Pen lapiz = new Pen(Color.Red, 15);
        private Image imagenOriginal;
        private Image imagenActual;


        float TomarZoomFactor(PictureBox pictureBox)
        {
            float anchoimagen = pictureBox1.Image.Width;
            float anchopicturebox = pictureBox1.ClientSize.Width;
            float factorzoom = anchopicturebox / anchoimagen;
            return factorzoom;
        }
        

        private void Configurar_imagen()
        {
            pictureBox1.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    isdrawing = true;
                    g = Graphics.FromImage(pictureBox1.Image);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                }
            };
            pictureBox1.MouseUp += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {

                    isdrawing = false;
                    g.Dispose();
                }
            };
            pictureBox1.MouseMove += (sender, e) =>
            {
                if (isdrawing)
                {
                    int x = (int)(e.X / TomarZoomFactor(pictureBox1));
                    int y = (int)(e.Y / TomarZoomFactor(pictureBox1) - 90);
                    g.DrawLine(lapiz, x, y, x + 10, y + 10);
                    
                    pictureBox1.Refresh();
                }
            };
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            BorrarImagen();
        }

        private void BorrarImagen()
        {
            // Restaurar la imagen actual con la copia independiente de la imagen original
            imagenActual = (Image)imagenOriginal.Clone();

            // Establecer la imagen actual en el PictureBox
            pictureBox1.Image = imagenActual;

            // Refrescar el PictureBox para mostrar la imagen original sin las líneas dibujadas
            pictureBox1.Refresh();
        }


        private void Configurar_datagridviews()
        {
            DgvConjuntoExt.Columns["Observaciones"].DefaultCellStyle.ForeColor = DgvConjuntoExt.DefaultCellStyle.BackColor;
            DgvConjuntoExt.Columns["Observaciones"].DefaultCellStyle.SelectionForeColor = DgvConjuntoExt.DefaultCellStyle.SelectionBackColor;
            DgvInteriorCapot.Columns["Observaciones"].DefaultCellStyle.ForeColor = DgvInteriorCapot.DefaultCellStyle.BackColor;
            DgvInteriorCapot.Columns["Observaciones"].DefaultCellStyle.SelectionForeColor = DgvInteriorCapot.DefaultCellStyle.SelectionBackColor;
            DgvInteriorVehiculo.Columns["Estado"].DefaultCellStyle.ForeColor = DgvInteriorVehiculo.DefaultCellStyle.BackColor;
            DgvInteriorVehiculo.Columns["Estado"].DefaultCellStyle.SelectionForeColor = DgvInteriorVehiculo.DefaultCellStyle.SelectionBackColor;
            DgvInteriorBaul.Columns["Observaciones"].DefaultCellStyle.ForeColor = DgvInteriorBaul.DefaultCellStyle.BackColor;
            DgvInteriorBaul.Columns["Observaciones"].DefaultCellStyle.SelectionForeColor = DgvInteriorBaul.DefaultCellStyle.SelectionBackColor;
            DgvRelacionTrabajo.Columns["Relacion_Trabajo"].DefaultCellStyle.ForeColor = DgvRelacionTrabajo.DefaultCellStyle.BackColor;
            DgvRelacionTrabajo.Columns["Relacion_Trabajo"].DefaultCellStyle.SelectionForeColor = DgvRelacionTrabajo.DefaultCellStyle.SelectionBackColor;
        }


        //Consultar


        private void BuscarNumeroOrdenTrabajo() //Método que trae el número de la de la última orden de trabajo hecha y le suma 1 para poder realizar la siguiente, y si no encuentra ninguna deja el número 1 por defecto
        {
            if (oCN_Orden_Trabajo.BuscarNumeroOrdenTrabajo() != " ")
            {
                numeroordentrabajo = Convert.ToInt32(oCN_Orden_Trabajo.BuscarNumeroOrdenTrabajo()) + 1;
                LblNumero_Orden_Trabajo.Text = "N° " + numeroordentrabajo.ToString();
            }
            else
                numeroordentrabajo = 1;
            LblNumero_Orden_Trabajo.Text = "N° " + numeroordentrabajo.ToString();
        }


        private void TraerUsuario() //Método que trae los datos del usuario que en ese momento ingresó al programa
        {
            TxtRecibe.Text = UsuarioGlobal.Usuario.Rows[0][1].ToString();
            idvendedor = UsuarioGlobal.Usuario.Rows[0][0].ToString();
        }


        //Datagridview


        private void MostrarPartesInspecion_CE() //Método que agrega columnas y trae en una consulta datos de la base de datos al datagridview, y agrega un valor por defecto a la columnas agregadas
        {
            int conteo = 0;
            DgvConjuntoExt.DataSource = oCN_Partes_Inspeccion.MostrarPartesInspecion_CE();
            DgvConjuntoExt.Columns.Add("OBSERVACIONES", "OBSERVACIONES");
            DgvConjuntoExt.Columns["cod"].Visible = false;
            //DgvConjuntoExt.Columns["CONJUNTO EXTERIOR"].ReadOnly = true;
            DgvConjuntoExt.AllowUserToAddRows = false;
            foreach (DataGridViewRow filas in DgvConjuntoExt.Rows)
            {
                DgvConjuntoExt.Rows[conteo].Cells[2].Value = "null";
                conteo++;
            }
            DgvConjuntoExt.AllowUserToAddRows = true;
        }


        private void MostrarPartesInspecion_IC() //Método que agrega columnas y trae en una consulta datos de la base de datos al datagridview, y agrega un valor por defecto a la columnas agregadas
        {
            int conteo = 0;
            DgvInteriorCapot.DataSource = oCN_Partes_Inspeccion.MostrarPartesInspecion_IC();
            DgvInteriorCapot.Columns.Add("OBSERVACIONES", "OBSERVACIONES");
            DgvInteriorCapot.Columns["cod"].Visible = false;
            //DgvInteriorCapot.Columns["INTERIOR CAPOT"].ReadOnly = true;
            DgvInteriorCapot.AllowUserToAddRows = false;
            foreach (DataGridViewRow filas in DgvInteriorCapot.Rows)
            {
                DgvInteriorCapot.Rows[conteo].Cells[2].Value = "null";
                conteo++;
            }
            DgvInteriorCapot.AllowUserToAddRows = true;
        }


        private void MostrarPartesInspecion_IB() //Método que agrega columnas y trae en una consulta datos de la base de datos al datagridview, y agrega un valor por defecto a la columnas agregadas
        {
            int conteo = 0;
            DgvInteriorBaul.DataSource = oCN_Partes_Inspeccion.MostrarPartesInspecion_IB();
            DgvInteriorBaul.Columns.Add("OBSERVACIONES", "OBSERVACIONES");
            DgvInteriorBaul.Columns["cod"].Visible = false;
            //DgvInteriorBaul.Columns["INTERIOR BAUL"].ReadOnly = true;
            DgvInteriorBaul.AllowUserToAddRows = false;
            foreach (DataGridViewRow filas in DgvInteriorBaul.Rows)
            {
                DgvInteriorBaul.Rows[conteo].Cells[2].Value = "null";
                conteo++;
            }
            DgvInteriorBaul.AllowUserToAddRows = true;
        }


        private void MostrarPartesInspecion_IV() //Método que agrega columnas y trae en una consulta datos de la base de datos al datagridview, y agrega un valor por defecto a la columnas agregadas
        {
            int conteo = 0;
            DgvInteriorVehiculo.DataSource = oCN_Partes_Inspeccion.MostrarPartesInspecion_IV();
            DgvInteriorVehiculo.Columns.Add("ESTADO", "ESTADO");
            DgvInteriorVehiculo.Columns["cod"].Visible = false;
            //DgvInteriorVehiculo.Columns["INTERIOR DEL VEHICULO"].ReadOnly = true;
            DgvInteriorVehiculo.AllowUserToAddRows = false;
            foreach (DataGridViewRow filas in DgvInteriorVehiculo.Rows)
            {
                DgvInteriorVehiculo.Rows[conteo].Cells[2].Value = "null";
                conteo++;
            }
            DgvInteriorVehiculo.AllowUserToAddRows = true;
        }


        private void MostrarRelacionTrabajo() //Método que agrega columnas al datagridview, y agrega un valor por defecto a la columnas agregadas
        {
            int conteo = 0;
            //DgvRelacionTrabajo.DataSource = oCN_Partes_Inspeccion.MostrarPartesInspecion_IV();
            DgvRelacionTrabajo.Columns.Add("RELACION_TRABAJO", "RELACION TRABAJO");
            DgvRelacionTrabajo.AllowUserToAddRows = false;
            foreach (DataGridViewRow filas in DgvRelacionTrabajo.Rows)
            {
                DgvRelacionTrabajo.Rows[conteo].Cells["RELACION_TRABAJO"].Value = "null";
                conteo++;
            }
            DgvRelacionTrabajo.AllowUserToAddRows = true;
        }


        private void MostrarTipoPago() //Método que agrega columnas y trae en una consulta datos de la base de datos a la colulumna del combobox del datagridview, y agrega un valor por defecto a la columnas agregadas
        {
            DataGridViewComboBoxColumn columna = new DataGridViewComboBoxColumn();

            DgvAbonos.Columns.Add("ABONO","ABONO");

            columna.HeaderText = "TIPO DE PAGO";
            columna.Name = "TIPO_PAGO";
            columna.DataSource = oCN_Tipo_Pago.MostrarTipoPago();
            columna.DisplayMember= "Nombre";
            columna.ValueMember = "Cod";
            DgvAbonos.Columns.Add(columna);
            DgvAbonos.AllowUserToAddRows = true;
        }


        //Combobox


        private void MostrarMarcas() //Método que muestra en el combobox las marcas que hay en la base de datos
        {
            CboMarca.DataSource = oCN_Marca.MostrarMarcas();
            CboMarca.DisplayMember = "Nombre";
            CboMarca.ValueMember = "Cod";
            CboMarca.SelectedIndex = -1;
        }


        private void MostrarCotizacionInicial() //Método que muestra en el combobox las cotizaciones iniciales que hay en la base de datos
        {
            CboCotizacion_Inicial.DataSource = oCN_Cotizacion_Inicial.MostrarCotizacionInicial();
            CboCotizacion_Inicial.DisplayMember = "Cod";
            CboCotizacion_Inicial.ValueMember = "Cod";
            CboCotizacion_Inicial.SelectedIndex = -1;
        }


        //Cajas de texto


        private void MostrarCliente() //Método que muestralos datos del cliente en las cajas de texto dependiendo de la cotización inicial seleccionada
        {
            DataTable tablacliente = new DataTable();
            CE_Cotizacion_Inicial cotizacion_inicial = new CE_Cotizacion_Inicial();

            cotizacion_inicial.Cod = Convert.ToInt32(numerocotizacioninicial);

            tablacliente = oCN_Clientes.MostrarCliente(cotizacion_inicial);

            doccliente = tablacliente.Rows[0][0].ToString(); 
            TxtSeñores.Text = tablacliente.Rows[0][1].ToString();
            TxtDireccion.Text = tablacliente.Rows[0][2].ToString();
            TxtCel_Tel.Text = tablacliente.Rows[0][3].ToString();
            TxtPlaca.Text = tablacliente.Rows[0][4].ToString();
        }


        //Carpeta - Imagen


        private void CrearCarpetaImagen()
        {
            string palabra = numeroordentrabajo + " " + DateTime.Now.ToString("yyyy-MMMM-dd");
            MessageBox.Show(palabra);
            string carpeta = /*@"C:\Users\carlo\OneDrive\Documentos\Pintacars\Programa\Imágenes\"+palabra+""*/
                @"C:\Users\Aprendiz.BUCDFPCSEFSD025\Documents\Proyecto PintarCars\Imagenes\" + palabra + "";

            string nombreArchivo = "Imagen.png";
            string rutaCompleta = Path.Combine(carpeta, nombreArchivo);

            //string carpeta = Application.StartupPath + @"\Carpetica";

            try
            {
                if (Directory.Exists(carpeta))
                {
                    MessageBox.Show("La carpeta ya existe");
                }
                else
                {
                    MessageBox.Show("Creando");
                    Directory.CreateDirectory(carpeta);

                    pictureBox1.Image.Save(rutaCompleta, ImageFormat.Png);
                }
            }
            catch (Exception error)
            {

                MessageBox.Show(error.ToString());
            }

            //string RutaCarpeta = @"C:\Users\Sena CSET\Downloads\imagenes prueba de pintacars";
            //string nombreArchivo = "Prueba1.png";
            //string rutaCompleta = Path.Combine(RutaCarpeta, nombreArchivo);
            //pictureBox1.Image.Save(rutaCompleta, ImageFormat.Png);
        }


        //Limpiar


        private void Limpiar() //Método que limpia las cajas de texto, los combobox, los datetimepickers y el datagridview, vuelve a llamar a los métodos del datagridview
        {
            TxtPlaca.Clear();
            TxtSeñores.Clear();
            TxtDireccion.Clear();
            TxtCel_Tel.Clear();
            CboMarca.SelectedIndex = -1;
            TxtModelo.Clear();
            TxtColor.Clear();
            TxtAño.Clear();
            TxtKilometraje.Clear();
            TxtClave.Clear();
            TxtEntrega.Clear();
            TxtRecibe.Clear();
            TxtMano_Obra.Clear();
            TxtRepuestos.Clear();
            TxtOtros.Clear();
            TxtTotal.Clear();
            TxtSaldo.Clear();
            DtpFecha_Entrega.Text = DateTime.Now.ToString();
            DgvConjuntoExt.Columns.Clear();
            DgvInteriorCapot.Columns.Clear();
            DgvInteriorBaul.Columns.Clear();
            DgvInteriorVehiculo.Columns.Clear();
            DgvRelacionTrabajo.Columns.Clear();
            DgvAbonos.Columns.Clear();
            MostrarPartesInspecion_CE();
            MostrarPartesInspecion_IC();
            MostrarPartesInspecion_IB();
            MostrarPartesInspecion_IV();
            MostrarRelacionTrabajo();
            MostrarTipoPago();
            Configurar_datagridviews();
            BorrarImagen();
            //DataTable dt = (DataTable)DgvRelacionTrabajo.DataSource;
            //dt.Clear();
        }


        #endregion


        //Confirmar


        private void BtnConfirmar_Click(object sender, EventArgs e) //Suma el valor del total de la mano de obra, el valor del total de los repuestos y el valor del total de los otros y el resultado lo asigna a la caja de texto del total, y habilita el botón de terminar
        {
            try
            {
                TxtTotal.Text = (float.Parse(TxtMano_Obra.Text) + float.Parse(TxtRepuestos.Text) + float.Parse(TxtOtros.Text)).ToString();
                BtnTerminar.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }


        private void BtnConfirmar_Pago_Click(object sender, EventArgs e) //Recorre el datagridview en la columna de abonos y suma cada fila, y el total lo resta con el valor de la caja de texto del total, el valor final lo asigna a la caja de texto del saldo
        {
            totalpagos = 0;
            foreach (DataGridViewRow filas in DgvAbonos.Rows)
            {
                totalpagos += float.Parse(filas.Cells["ABONO"].Value.ToString());
                DgvAbonos.AllowUserToAddRows = false;
            }
            DgvAbonos.AllowUserToAddRows = true;
            TxtSaldo.Text = (float.Parse(TxtTotal.Text) - totalpagos).ToString();
        }


        //Insertar


        private void BtnTerminar_Click_1(object sender, EventArgs e) //Recorre todas las cajas de texto, combobox, datetimepickers y datagridviews y envia los datos a la base de datos
        {
            try
            {
                CE_Vehiculos vehiculo = new CE_Vehiculos();
                CE_Orden_Trabajo orden_trabajo = new CE_Orden_Trabajo();
                CE_Orden_Trabajo_Inspeccion orden_trabajo_inspeccion = new CE_Orden_Trabajo_Inspeccion();
                CE_Pagos pago = new CE_Pagos();

                int conteo = 0;

                vehiculo.Matricula = TxtPlaca.Text;
                vehiculo.Modelo = TxtModelo.Text;
                vehiculo.Color = TxtColor.Text;
                vehiculo.Año = TxtAño.Text;
                vehiculo.Cod_Marca = Convert.ToInt32(CboMarca.SelectedValue);
                oCN_Vehiculos.InsertarVehiculo(vehiculo);

                orden_trabajo.Clave = TxtClave.Text;
                orden_trabajo.Kilometraje = TxtKilometraje.Text;
                orden_trabajo.Fecha_Llegada = DtpFecha_Recibido.Value;
                orden_trabajo.Fecha_Entrega = DtpFecha_Entrega.Value;
                foreach (DataGridViewRow filas in DgvRelacionTrabajo.Rows)
                {
                    orden_trabajo.Descripcion = filas.Cells["RELACION_TRABAJO"].Value.ToString();
                    DgvRelacionTrabajo.AllowUserToAddRows = false;
                }
                orden_trabajo.entrega = TxtEntrega.Text;
                orden_trabajo.D_I_Usuario = idvendedor.ToString();
                orden_trabajo.mano_obra = float.Parse(TxtMano_Obra.Text);
                orden_trabajo.repuestos = float.Parse(TxtRepuestos.Text);
                orden_trabajo.otros = float.Parse(TxtOtros.Text);
                orden_trabajo.Precio = float.Parse(TxtTotal.Text);
                orden_trabajo.saldo = float.Parse(TxtSaldo.Text);
                orden_trabajo.D_I_Cliente = doccliente;
                orden_trabajo.Matricula_Vehiculo = TxtPlaca.Text;
                orden_trabajo.Cod_Cotizacion_Inicial = Convert.ToInt32(numerocotizacioninicial);
                DgvRelacionTrabajo.AllowUserToAddRows = true;
                oCN_Orden_Trabajo.InsertarOrdenTrabajo(orden_trabajo);

                OrdenTrabajoGlobal.OrdenTrabajo = numeroordentrabajo.ToString();

                foreach (DataGridViewRow filas in DgvConjuntoExt.Rows)
                {
                    orden_trabajo_inspeccion.observaciones = filas.Cells["OBSERVACIONES"].Value.ToString();
                    orden_trabajo_inspeccion.cod_partes_inspeccion = Convert.ToInt32(filas.Cells["cod"].Value.ToString());
                    orden_trabajo_inspeccion.cod_Orden_Trabajo = numeroordentrabajo;
                    oCN_Orden_Trabajo_Inspeccion.InsertarOrdenTrabajoInspeccion(orden_trabajo_inspeccion);
                    DgvConjuntoExt.AllowUserToAddRows = false;
                }

                foreach (DataGridViewRow filas in DgvInteriorCapot.Rows)
                {
                    orden_trabajo_inspeccion.observaciones = filas.Cells["OBSERVACIONES"].Value.ToString();
                    orden_trabajo_inspeccion.cod_partes_inspeccion = Convert.ToInt32(filas.Cells["Cod"].Value.ToString());
                    orden_trabajo_inspeccion.cod_Orden_Trabajo = numeroordentrabajo;
                    oCN_Orden_Trabajo_Inspeccion.InsertarOrdenTrabajoInspeccion(orden_trabajo_inspeccion);
                    DgvInteriorCapot.AllowUserToAddRows = false;
                }

                foreach (DataGridViewRow filas in DgvInteriorVehiculo.Rows)
                {
                    orden_trabajo_inspeccion.cod_partes_inspeccion = Convert.ToInt32(filas.Cells["Cod"].Value.ToString());
                    orden_trabajo_inspeccion.observaciones = filas.Cells["ESTADO"].Value.ToString();
                    orden_trabajo_inspeccion.cod_Orden_Trabajo = numeroordentrabajo;
                    oCN_Orden_Trabajo_Inspeccion.InsertarOrdenTrabajoInspeccion(orden_trabajo_inspeccion);
                    DgvInteriorVehiculo.AllowUserToAddRows = false;
                }

                foreach (DataGridViewRow filas in DgvInteriorBaul.Rows)
                {
                    orden_trabajo_inspeccion.cod_partes_inspeccion = Convert.ToInt32(filas.Cells["Cod"].Value.ToString());
                    orden_trabajo_inspeccion.observaciones = filas.Cells["OBSERVACIONES"].Value.ToString();
                    orden_trabajo_inspeccion.cod_Orden_Trabajo = numeroordentrabajo;
                    oCN_Orden_Trabajo_Inspeccion.InsertarOrdenTrabajoInspeccion(orden_trabajo_inspeccion);
                    DgvInteriorBaul.AllowUserToAddRows = false;
                }

                foreach (DataGridViewRow filas in DgvAbonos.Rows)
                {
                    pago.Monto = float.Parse(filas.Cells["ABONO"].Value.ToString());
                    pago.Fecha = DateTime.Now;
                    pago.Cod_Tipo_Pago = Convert.ToInt32(filas.Cells["TIPO_PAGO"].Value.ToString());
                    pago.Cod_Orden_Trabajo = numeroordentrabajo;
                    oCN_Pagos.InsertarPago(pago);
                    DgvAbonos.AllowUserToAddRows = false;
                }

                DgvConjuntoExt.AllowUserToAddRows = true;
                DgvInteriorCapot.AllowUserToAddRows = false;
                DgvInteriorVehiculo.AllowUserToAddRows = false;
                DgvInteriorBaul.AllowUserToAddRows = false;
                DgvAbonos.AllowUserToAddRows = false;

                CrearCarpetaImagen();
                BuscarNumeroOrdenTrabajo();
                BtnTerminar.Enabled = false;
                numerocotizacioninicial = string.Empty;
                LblCotizacion_Inicial.Text = "N° ";
                MostrarCotizacionInicial();
                Limpiar();
                MessageBox.Show("Orden de Trabajo Terminada");
            }
            catch (Exception)
            {

                MessageBox.Show("Error");
            }
        }


        //Cambiar


        private void BtnCambiar_Click(object sender, EventArgs e) //Habilita el combobox de las cotizaciones iniciales para poder cambiarla con sus datos por número de cotización
        {
            CboCotizacion_Inicial.Enabled = true;
        }


        //Eventos


        private void CboCotizacion_Inicial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboCotizacion_Inicial.Text != numerocotizacioninicial & CboCotizacion_Inicial.SelectedIndex >0)
            {
                LblCotizacion_Inicial.Text = "N° " + CboCotizacion_Inicial.Text;
                numerocotizacioninicial = CboCotizacion_Inicial.Text;
                MostrarCliente(); 
            }
            //else
            //{
            //    CboCotizacion_Inicial.Text = FrmCotizacion_Inicial.CotizacionInicialGlobal.CotizacionInicial;
            //}
        }


        private void DgvConjuntoExt_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                DgvConjuntoExt.Rows[e.RowIndex].Cells[2].Value = "";
                DgvConjuntoExt.Rows[e.RowIndex].Cells[2].Style.ForeColor = Color.Black;
            }
        }


        private void DgvConjuntoExt_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToString(DgvConjuntoExt.Rows[e.RowIndex].Cells[2].Value) == "")
            {
                DgvConjuntoExt.Rows[e.RowIndex].Cells[2].Value = "null";
                DgvConjuntoExt.Rows[e.RowIndex].Cells[2].Style.ForeColor = DgvConjuntoExt.DefaultCellStyle.BackColor;
                DgvConjuntoExt.Rows[e.RowIndex].Cells[2].Style.SelectionForeColor = DgvConjuntoExt.DefaultCellStyle.SelectionBackColor;
            }
            else if (Convert.ToString(DgvConjuntoExt.Rows[e.RowIndex].Cells[2].Value) != "")
            {
                DgvConjuntoExt.Rows[e.RowIndex].Cells[2].Style.SelectionForeColor = Color.White;
            }
        }


        private void DgvInteriorCapot_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                DgvInteriorCapot.Rows[e.RowIndex].Cells[2].Value = "";
                DgvInteriorCapot.Rows[e.RowIndex].Cells[2].Style.ForeColor = Color.Black;
            }
        }


        private void DgvInteriorCapot_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToString(DgvInteriorCapot.Rows[e.RowIndex].Cells[2].Value) == "")
            {
                DgvInteriorCapot.Rows[e.RowIndex].Cells[2].Value = "null";
                DgvInteriorCapot.Rows[e.RowIndex].Cells[2].Style.ForeColor = DgvInteriorCapot.DefaultCellStyle.BackColor;
                DgvInteriorCapot.Rows[e.RowIndex].Cells[2].Style.SelectionForeColor = DgvInteriorCapot.DefaultCellStyle.SelectionBackColor;
            }
            else if (Convert.ToString(DgvInteriorCapot.Rows[e.RowIndex].Cells[2].Value) != "")
            {
                DgvInteriorCapot.Rows[e.RowIndex].Cells[2].Style.SelectionForeColor = Color.White;
            }
        }


        private void DgvInteriorVehiculo_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                DgvInteriorVehiculo.Rows[e.RowIndex].Cells[2].Value = "";
                DgvInteriorVehiculo.Rows[e.RowIndex].Cells[2].Style.ForeColor = Color.Black;
            }
        }


        private void DgvInteriorVehiculo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToString(DgvInteriorVehiculo.Rows[e.RowIndex].Cells[2].Value) == "")
            {
                DgvInteriorVehiculo.Rows[e.RowIndex].Cells[2].Value = "null";
                DgvInteriorVehiculo.Rows[e.RowIndex].Cells[2].Style.ForeColor = DgvInteriorVehiculo.DefaultCellStyle.BackColor;
                DgvInteriorVehiculo.Rows[e.RowIndex].Cells[2].Style.SelectionForeColor = DgvInteriorVehiculo.DefaultCellStyle.SelectionBackColor;
            }
            else if (Convert.ToString(DgvInteriorVehiculo.Rows[e.RowIndex].Cells[2].Value) != "")
            {
                DgvInteriorVehiculo.Rows[e.RowIndex].Cells[2].Style.SelectionForeColor = Color.White;
            }
        }


        private void DgvInteriorBaul_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                DgvInteriorBaul.Rows[e.RowIndex].Cells[2].Value = "";
                DgvInteriorBaul.Rows[e.RowIndex].Cells[2].Style.ForeColor = Color.Black;
            }
        }


        private void DgvInteriorBaul_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToString(DgvInteriorBaul.Rows[e.RowIndex].Cells[2].Value) == "")
            {
                DgvInteriorBaul.Rows[e.RowIndex].Cells[2].Value = "null";
                DgvInteriorBaul.Rows[e.RowIndex].Cells[2].Style.ForeColor = DgvInteriorBaul.DefaultCellStyle.BackColor;
                DgvInteriorBaul.Rows[e.RowIndex].Cells[2].Style.SelectionForeColor = DgvInteriorBaul.DefaultCellStyle.SelectionBackColor;
            }
            else if (Convert.ToString(DgvInteriorBaul.Rows[e.RowIndex].Cells[2].Value) != "")
            {
                DgvInteriorBaul.Rows[e.RowIndex].Cells[2].Style.SelectionForeColor = Color.White;
            }
        }


        private void DgvRelacionTrabajo_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //DgvRelacionTrabajo.Rows[e.RowIndex].Cells["RELACION_TRABAJO"].Value = "";
            //DgvRelacionTrabajo.Columns["RELACION_TRABAJO"].DefaultCellStyle.NullValue = "";
            //DgvRelacionTrabajo.Columns["RELACION_TRABAJO"].DefaultCellStyle.ForeColor = Color.Black;
        }


        private void DgvRelacionTrabajo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (Convert.ToString(DgvRelacionTrabajo.Rows[e.RowIndex].Cells[0].Value) == "")
            //{
            //    DgvRelacionTrabajo.Rows[e.RowIndex].Cells["RELACION_TRABAJO"].Value = "null";
            //    DgvRelacionTrabajo.Rows[e.RowIndex].Cells["RELACION_TRABAJO"].Style.ForeColor = DgvRelacionTrabajo.DefaultCellStyle.BackColor;
            //    DgvRelacionTrabajo.Rows[e.RowIndex].Cells["RELACION_TRABAJO"].Style.SelectionForeColor = DgvRelacionTrabajo.DefaultCellStyle.SelectionBackColor;

            //}
            //else if (Convert.ToString(DgvRelacionTrabajo.Rows[e.RowIndex].Cells[0].Value) != "")
            //{
            //    DgvRelacionTrabajo.Rows[e.RowIndex].Cells["RELACION_TRABAJO"].Style.SelectionForeColor = Color.White;
            //    MessageBox.Show("olap");
            //}
        }


        //Validaciones


        private void TxtAño_KeyPress(object sender, KeyPressEventArgs e)
        {
            oCN_Validaciones.SoloNum(e);
        }

        private void TxtModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            oCN_Validaciones.SoloNum(e);
        }

        private void TxtMano_Obra_KeyPress(object sender, KeyPressEventArgs e)
        {
            oCN_Validaciones.SoloNum(e);
        }

        private void TxtRepuestos_KeyPress(object sender, KeyPressEventArgs e)
        {
            oCN_Validaciones.SoloNum(e);
        }

        private void TxtOtros_KeyPress(object sender, KeyPressEventArgs e)
        {
            oCN_Validaciones.SoloNum(e);
        }









        //private bool ValidNumber(string value)
        //{
        //    //Obtenemos la longitud de la celda
        //    int len = value.Length;
        //    for (int i = 0; i != len; ++i)
        //    {
        //        //Detectamos si la celda tiene únicamente números
        //        if (!(value[i] >= '0' && value[i] <= '9'))
        //            return true;
        //    }
        //    return false;
        //}



        private void DgvAbonos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //if (e.ColumnIndex == 1)
            //{
            //    if (e.ColumnIndex == 1)
            //    {
            //        e.Cancel = true;
            //        DgvAbonos.Rows[e.RowIndex].ErrorText = "Solo se puede ingresar números.";
            //    }
            //}


            //bool isdouble = double.TryParse(e.FormattedValue.ToString(), out double resultadonumerico);
            //if (isdouble)
            //{
            //    if(resultadonumerico<16 || resultadonumerico > 65)
            //    {
            //        DgvAbonos.CancelEdit();
            //        e.Cancel = true;
            //        MessageBox.Show("binen");
            //    }
            //    MessageBox.Show("binen");
            //}
            //else
            //{
            //    e.Cancel = false;
            //    MessageBox.Show("Solo números");
            //}

        }

        private void DgvAbonos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //string cNombreCelda = DgvAbonos.Columns(e.ColumnIndex).Name;
            //if(cNombreCelda == "Abonos")
            //{

            //    e.Control.KeyPress += new EventHandler(CheckKey);

            //}

        }







        //private void CheckKey(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar)
        //       && !char.IsDigit(e.KeyChar)
        //       && e.KeyChar != '.')
        //    {
        //        e.Handled = true;
        //    }
        //}
    }
}
