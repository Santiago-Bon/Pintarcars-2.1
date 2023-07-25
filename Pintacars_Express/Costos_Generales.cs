using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Pintacars_Express.FrmInicio_Sesion;

namespace Pintacars_Express
{
    public partial class FrmCostos_Generales : Form
    {
        CN_Materiales oCN_Materiales = new CN_Materiales();
        CN_Tipo_Trabajador oCN_Tipo_Trabajador = new CN_Tipo_Trabajador();
        //CN_Marca oCN_Marca = new CN_Marca();   
        CN_Costos_Generales oCN_Costos_Generales = new CN_Costos_Generales();
        CN_Costos_Generales_Materiales oCN_Costos_Generales_Materiales = new CN_Costos_Generales_Materiales();
        CN_Costos_Generales_Trabajadores oCN_Costos_Generales_Trabajadores = new CN_Costos_Generales_Trabajadores();
        CN_Orden_Trabajo oCN_Orden_Trabajo = new CN_Orden_Trabajo();
        CN_Vehiculos oCN_Vehiculos = new CN_Vehiculos();


        int numerocostosgenerales = 0;
        string numeroordentrabajo = /*FrmOrden_Trabajo.OrdenTrabajoGlobal.OrdenTrabajo;*/5.ToString();
        float valortotalmateriales = 0;
        float valortotaltrabajadores = 0;
        string idvendedor = string.Empty;
        public static bool error = false;


        public FrmCostos_Generales()
        {
            InitializeComponent();
        }


        private void Orden_Servicio_Load(object sender, EventArgs e)
        {
            BuscarNumeroCostosGenerales();
            MostrarMateriales();
            MostrarTipoTrabajador();
            //MostrarMarcas();
            TraerUsuario();
            MostrarVehiculo();
            BtnTerminar.Enabled = false;
            LblNumero_Orden_Trabajo.Text = "N° " + numeroordentrabajo;
            Cbo_Orden_Trabajo.Text = numeroordentrabajo;
            MostrarOrdenTrabajo();
            Configurar_datagridviews();
            //creacion_Dgv_Costo_Materiales();
            //creacion_Dgv_Costo_Mano_de_Obra();
        }


        //Botones del menustrip para ir de formulario en formulario en el panel


        private void inicioToolStripMenuItem_Click(object sender, EventArgs e) //Selecciona el formulario del panel principal del proyecto
        {
            Form panel_principal = new FrmPanel_Principal();
            panel_principal.Show();
            Hide();
        }

        private void iniciarSesiónToolStripMenuItem_Click(object sender, EventArgs e) //Selecciona el formulario del inicio de sesión del proyecto
        {
            Form inicio_sesion = new FrmInicio_Sesion();
            inicio_sesion.Show();
            Hide();
        }

        private void nuevaCotizaciónInicialToolStripMenuItem_Click(object sender, EventArgs e) //Selecciona el formulario de la cotización inicial del proyecto
        {
            Form Corizacion_Inicial = new FrmCotizacion_Inicial();
            Corizacion_Inicial.Show();
            Hide();
        }

        private void nuevaOrdendeTrabajoToolStripMenuItem_Click(object sender, EventArgs e) //Selecciona el formulario de la orden de trabajo del proyecto
        {
            Form OFrm_Orden_trabajo = new FrmOrden_Trabajo();
            OFrm_Orden_trabajo.Show();
            Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e) //Cierra el proyecto
        {
            Application.Exit();
        }


        #region Mis Métodos


        private void Configurar_datagridviews()
        {
            //DgvCosto_Materiales.Columns["Cantidad"].DefaultCellStyle.ForeColor = DgvCosto_Materiales.DefaultCellStyle.BackColor;
            //DgvCosto_Materiales.Columns["Cantidad"].DefaultCellStyle.SelectionForeColor = DgvCosto_Materiales.DefaultCellStyle.SelectionBackColor;
            //DgvCosto_Materiales.Columns["COSTO"].DefaultCellStyle.ForeColor = DgvCosto_Materiales.DefaultCellStyle.BackColor;
            //DgvCosto_Materiales.Columns["COSTO"].DefaultCellStyle.SelectionForeColor = DgvCosto_Materiales.DefaultCellStyle.SelectionBackColor;
            //DgvCosto_Materiales.Columns["FECHA_COMPRA"].DefaultCellStyle.ForeColor = DgvCosto_Materiales.DefaultCellStyle.BackColor;
            //DgvCosto_Materiales.Columns["FECHA_COMPRA"].DefaultCellStyle.SelectionForeColor = DgvCosto_Materiales.DefaultCellStyle.SelectionBackColor;
            //DgvCosto_Mano_Obra.Columns["RESPONSABLES"].DefaultCellStyle.ForeColor = DgvCosto_Materiales.DefaultCellStyle.BackColor;
            //DgvCosto_Mano_Obra.Columns["RESPONSABLES"].DefaultCellStyle.SelectionForeColor = DgvCosto_Materiales.DefaultCellStyle.SelectionBackColor;
            //DgvCosto_Mano_Obra.Columns["COSTOPHORA"].DefaultCellStyle.ForeColor = DgvCosto_Materiales.DefaultCellStyle.BackColor;
            //DgvCosto_Mano_Obra.Columns["COSTOPHORA"].DefaultCellStyle.SelectionForeColor = DgvCosto_Materiales.DefaultCellStyle.SelectionBackColor;
        }


        //Consultar


        private void BuscarNumeroCostosGenerales() //Método que trae el número de la del último costos generales hecho y le suma 1 para poder realizar el siguiente, y si no encuentra ninguno deja el número 1 por defecto
        {
            if (oCN_Costos_Generales.BuscarNumeroCostosGenerales() != " ")
            {
                numerocostosgenerales = Convert.ToInt32(oCN_Costos_Generales.BuscarNumeroCostosGenerales()) + 1;
                LblNumero_Costos_Generales.Text = "N° " + numerocostosgenerales.ToString();
            }
            else
            {
                numerocostosgenerales = 1;
                LblNumero_Costos_Generales.Text = "N° " + numerocostosgenerales.ToString();
            }
        }
        

        private void TraerUsuario() //Método que trae los datos del usuario que en ese momento ingresó al programa
        {
            TxtRecibe.Text = UsuarioGlobal.Usuario.Rows[0][1].ToString();
            idvendedor = UsuarioGlobal.Usuario.Rows[0][0].ToString();
        }


        //Datagridview


        private void MostrarMateriales() //Método que agrega columnas y trae en una consulta datos de la base de datos al datagridview, y agrega un valor por defecto a la columnas agregadas
        {
            int conteo = 0;
            DgvCosto_Materiales.Columns.Add("CANTIDAD", "CANTIDAD");
            DgvCosto_Materiales.DataSource = oCN_Materiales.MostrarMateriales();
            DgvCosto_Materiales.Columns.Add("COSTO", "COSTO");
            DgvCosto_Materiales.Columns.Add("FECHA_COMPRA", "FECHA DE COMPRA");
            DgvCosto_Materiales.Columns["Cod"].Visible = false;
            DgvCosto_Materiales.AllowUserToAddRows = false;
            //DgvCosto_Materiales.Columns["DESCRIPCIÓN"].ReadOnly = true;

            foreach (DataGridViewRow filas in DgvCosto_Materiales.Rows)
            {
                DgvCosto_Materiales.Rows[conteo].Cells[0].Value = 0;
                DgvCosto_Materiales.Rows[conteo].Cells[3].Value = 0;
                DgvCosto_Materiales.Rows[conteo].Cells[4].Value = DateTime.Now;
                conteo++;
            }
            DgvCosto_Materiales.AllowUserToAddRows = true;
        }


        private void MostrarTipoTrabajador() //Método que agrega columnas y trae en una consulta datos de la base de datos al datagridview, y agrega un valor por defecto a la columnas agregadas
        {
            int conteo = 0;
            DgvCosto_Mano_Obra.DataSource = oCN_Tipo_Trabajador.MostrarTipoTrabajador();
            DgvCosto_Mano_Obra.Columns.Add("RESPONSABLES", "RESPONSABLES");
            DgvCosto_Mano_Obra.Columns.Add("COSTOPHORA", "COSTO P/ HORA");
            DgvCosto_Mano_Obra.Columns["Cod"].Visible = false;
            DgvCosto_Mano_Obra.AllowUserToAddRows = false;
            //DgvCosto_Mano_Obra.Columns["POSICIONES"].ReadOnly = true;

            //foreach (DataGridViewRow filas in DgvCosto_Mano_Obra.Rows)
            //{
            //    DgvCosto_Mano_Obra.Rows[conteo].Cells[2].Value = "null";
            //    //DgvCosto_Mano_Obra.Rows[conteo].Cells[3].Value = 0;
            //    //DgvCosto_Mano_Obra.Rows[conteo].Cells[4].Value = DateTime.Now;
            //    conteo++;
            //}
            //DgvCosto_Mano_Obra.AllowUserToAddRows = true;
        }


        //private void MostrarMarcas()
        //{
        //    CboMarca.DataSource = oCN_Marca.MostrarMarcas();
        //    CboMarca.DisplayMember = "Nombre";
        //    CboMarca.ValueMember = "Cod";
        //    CboMarca.SelectedIndex = -1;
        //}


        private void MostrarOrdenTrabajo() //Método que muestra en el combobox las órdenes de trabajo que hay en la base de datos
        {
            Cbo_Orden_Trabajo.DataSource = oCN_Orden_Trabajo.MostrarOrdenTrabajo();
            Cbo_Orden_Trabajo.DisplayMember = "Cod";
            Cbo_Orden_Trabajo.ValueMember = "Cod";
            Cbo_Orden_Trabajo.SelectedIndex = -1;
        }


        private void MostrarVehiculo() //Método que muestralos datos del vehículo en las cajas de texto dependiendo de la orden de trabajo seleccionada
        {
            try
            {
                error = true;
                DataTable tablavehiculo = new DataTable();
                CE_Orden_Trabajo orden_trabajo = new CE_Orden_Trabajo();

                orden_trabajo.Cod = numeroordentrabajo;

                tablavehiculo = oCN_Vehiculos.MostrarVehiculo(orden_trabajo);

                TxtMatricula.Text = tablavehiculo.Rows[0][0].ToString();
                Txt_Marca.Text = tablavehiculo.Rows[0][1].ToString();
            }
            catch
            {
                error = false;
                DialogResult opcion;
                opcion = MessageBox.Show("Por favor, ingrese al menos una orden de trabajo para poder crear un documento de costos generales\n¿Desea dirigirse al módulo de orden de trabajo?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (opcion == DialogResult.Yes)
                {                
                    FrmOrden_Trabajo oFrmOrden_Trabajo = new FrmOrden_Trabajo();
                    oFrmOrden_Trabajo.Show();
                    this.Hide();
                }
                else if (opcion == DialogResult.No)
                {
                    //FrmOrden_Trabajo oFrmOrden_Trabajo = new FrmOrden_Trabajo();
                    //oFrmOrden_Trabajo.Show();
                    //this.Hide();
                }
            }
        }


        //Limpiar


        private void Limpiar() //Método que limpia las cajas de texto, los combobox, los datetimepickers y el datagridview, vuelve a llamar a los métodos del datagridview
        {
            TxtMatricula.Clear();
            Txt_Marca.Clear();
            TxtProyecto.Clear();
            TxtCosto_Total_Materiales.Clear();
            TxtCosto_Total_Mano_Obra.Clear();
            TxtCosto_Total.Clear();
            DtpFecha_Entrega.Text = DateTime.Now.ToString();
            DgvCosto_Materiales.Columns.Clear();
            DgvCosto_Mano_Obra.Columns.Clear();
            MostrarMateriales();
            MostrarTipoTrabajador();
            //DataTable dt = (DataTable)DgvRelacionTrabajo.DataSource;
            //dt.Clear();
        }


        #endregion


        //Confirmar


        private void BtnConfirmar_Click(object sender, EventArgs e) //Método que recorre los datagridviews, en el primero multiplica la columna costo por la columna cantidad y suma el resultado de cada fila, en el segundo suma cada fila de la columna costophora, se le asignas los resultados a las cajas de texto y ambos se suman para dar el total
        {
            valortotalmateriales = 0;
            valortotaltrabajadores = 0;

            foreach (DataGridViewRow filas in DgvCosto_Materiales.Rows)
            {
                if (filas.Cells["CANTIDAD"].Value.ToString() == null ||
                    filas.Cells["COSTO"].Value.ToString() == null ||
                    filas.Cells["FECHA_COMPRA"].Value.ToString() == null ||
                    filas.Cells["Cod"].Value.ToString() == null ||
                    filas.Cells["DESCRIPCIÓN"].Value.ToString() == null)
                {
                    break;
                }
                else
                {
                    valortotalmateriales += float.Parse(filas.Cells["COSTO"].Value.ToString()) * float.Parse(filas.Cells["CANTIDAD"].Value.ToString());
                    DgvCosto_Materiales.AllowUserToAddRows = false;
                }
            }

            foreach (DataGridViewRow filas in DgvCosto_Mano_Obra.Rows)
            {
                if (filas.Cells["POSICIONES"].Value.ToString() == null ||
                    filas.Cells["RESPONSABLES"].Value.ToString() == null ||
                    filas.Cells["COSTOPHORA"].Value.ToString() == null ||
                    filas.Cells["Cod"].Value.ToString() == null)
                {
                    break;
                }
                else
                {
                    //DgvCosto_Mano_Obra.AllowUserToAddRows = false;
                    valortotaltrabajadores += float.Parse(filas.Cells["COSTOPHORA"].Value.ToString());
                }
            }
            TxtCosto_Total_Materiales.Text = valortotalmateriales.ToString();
            TxtCosto_Total_Mano_Obra.Text = valortotaltrabajadores.ToString();
            TxtCosto_Total.Text = (valortotalmateriales + valortotaltrabajadores).ToString();
            BtnTerminar.Enabled = true;
            DgvCosto_Materiales.AllowUserToAddRows = true;
            //DgvCosto_Mano_Obra.AllowUserToAddRows = true;
        }


        //Insertar


        private void BtnTerminar_Click(object sender, EventArgs e) //Recorre todas las cajas de texto, datetimepickers y datagridviews y envia los datos a la base de datos
        {
            try
            {
                CE_Costos_Generales costos_generales = new CE_Costos_Generales();
                CE_Costos_Generales_Materiales costos_generales_materiales = new CE_Costos_Generales_Materiales();
                CE_Costos_Generales_Trabajadores costos_generales_trabajadores = new CE_Costos_Generales_Trabajadores();

                costos_generales.Fecha_Inicio = DtpFecha_Inicio.Value;
                costos_generales.Fecha_Entrega_Final = DtpFecha_Entrega.Value;
                costos_generales.Proceso = TxtProyecto.Text;
                costos_generales.Costo_Total_Materiales = float.Parse(TxtCosto_Total_Materiales.Text);
                costos_generales.Costo_Total_Mano_Obra = float.Parse(TxtCosto_Total_Mano_Obra.Text);
                costos_generales.Costo_Total = float.Parse(TxtCosto_Total.Text);
                costos_generales.D_I_Usuario = idvendedor;
                costos_generales.Matricula_Vehiculo = TxtMatricula.Text;
                costos_generales.Cod_Orden_Trabajo = Convert.ToInt32(numeroordentrabajo);
                oCN_Costos_Generales.InsertarCostosGenerales(costos_generales);

                foreach (DataGridViewRow filas in DgvCosto_Materiales.Rows)
                {
                    if (filas.Cells["CANTIDAD"].Value.ToString() == null ||
                        filas.Cells["COSTO"].Value.ToString() == null ||
                        filas.Cells["FECHA_COMPRA"].Value.ToString() == null ||
                        filas.Cells["Cod"].Value.ToString() == null ||
                        filas.Cells["DESCRIPCIÓN"].Value.ToString() == null)
                    {
                        break;
                    }
                    else
                    {
                        costos_generales_materiales.Cantidad = float.Parse(filas.Cells["CANTIDAD"].Value.ToString());
                        costos_generales_materiales.Costos_Unitarios = float.Parse(filas.Cells["COSTO"].Value.ToString());
                        costos_generales_materiales.Fecha_Compra = Convert.ToDateTime(filas.Cells["FECHA_COMPRA"].Value.ToString());
                        costos_generales_materiales.Cod_Materiales = Convert.ToInt32(filas.Cells["Cod"].Value.ToString());
                        costos_generales_materiales.Cod_Costos_Generales = numerocostosgenerales;

                        oCN_Costos_Generales_Materiales.InsertarCostosGeneralesMateriales(costos_generales_materiales);
                        DgvCosto_Materiales.AllowUserToAddRows = false;
                    }
                }
                foreach (DataGridViewRow filas in DgvCosto_Mano_Obra.Rows)
                {
                    if (filas.Cells["POSICIONES"].Value.ToString() == null ||
                        filas.Cells["RESPONSABLES"].Value.ToString() == null ||
                        filas.Cells["COSTOPHORA"].Value.ToString() == null ||
                        filas.Cells["Cod"].Value.ToString() == null)
                    {
                        break;
                    }
                    else
                    {
                        costos_generales_trabajadores.responsable = filas.Cells["RESPONSABLES"].Value.ToString();
                        costos_generales_trabajadores.costo_hora = float.Parse(filas.Cells["COSTOPHORA"].Value.ToString());
                        costos_generales_trabajadores.cod_tipo_trabajador = Convert.ToInt32(filas.Cells["Cod"].Value.ToString());
                        costos_generales_trabajadores.Cod_Costos_Generales = numerocostosgenerales;

                        oCN_Costos_Generales_Trabajadores.InsertarCostosGeneralesTrabajadores(costos_generales_trabajadores);
                        DgvCosto_Mano_Obra.AllowUserToAddRows = false;
                    }
                }
                //Limpiar();
                DgvCosto_Materiales.AllowUserToAddRows = true;
                DgvCosto_Mano_Obra.AllowUserToAddRows = true;
                BtnTerminar.Enabled = false;
                BuscarNumeroCostosGenerales();
                MostrarOrdenTrabajo();
                LblNumero_Orden_Trabajo.Text = "N° ";
                MessageBox.Show("Costos Generales Terminada");
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }


        //Cambiar


        private void BtnCambiar_Click(object sender, EventArgs e) //Habilita el combobox de las órdenes de trabajo para poder cambiarla con sus datos por número de orden
        {
            Cbo_Orden_Trabajo.Enabled = true;
        }

        private void Cbo_Orden_Trabajo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbo_Orden_Trabajo.Text != numeroordentrabajo & Cbo_Orden_Trabajo.SelectedIndex > 0)
            {
                LblNumero_Orden_Trabajo.Text = "N° " + Cbo_Orden_Trabajo.Text;
                numeroordentrabajo = Cbo_Orden_Trabajo.Text;
                MostrarVehiculo();
            }
        }


        //Eventos


        private void DgvCosto_Materiales_CellBeginEdit_1(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                //DgvCosto_Materiales.Rows[e.RowIndex].Cells[0].Value = "";
                //DgvCosto_Materiales.Rows[e.RowIndex].Cells[0].Style.ForeColor = Color.Black;
                //DgvCosto_Materiales.Rows[e.RowIndex].Cells[3].Value = "";
                //DgvCosto_Materiales.Rows[e.RowIndex].Cells[3].Style.ForeColor = Color.Black;
                //DgvCosto_Materiales.Rows[e.RowIndex].Cells[4].Value = "";
                //DgvCosto_Materiales.Rows[e.RowIndex].Cells[4].Style.ForeColor = Color.Black;
            }
        }


        private void DgvCosto_Materiales_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            //if (Convert.ToString(DgvCosto_Materiales.Rows[e.RowIndex].Cells[2].Value) == "")
            //{
            //    DgvCosto_Materiales.Rows[e.RowIndex].Cells[0].Value = 0;
            //    DgvCosto_Materiales.Rows[e.RowIndex].Cells[0].Style.ForeColor = DgvCosto_Materiales.DefaultCellStyle.BackColor;
            //    DgvCosto_Materiales.Rows[e.RowIndex].Cells[0].Style.SelectionForeColor = DgvCosto_Materiales.DefaultCellStyle.SelectionBackColor;
            //}
            //else if (Convert.ToString(DgvCosto_Materiales.Rows[e.RowIndex].Cells[0].Value) != "")
            //{
            //    DgvCosto_Materiales.Rows[e.RowIndex].Cells[0].Style.SelectionForeColor = Color.White;
            //}
        }
    }
}