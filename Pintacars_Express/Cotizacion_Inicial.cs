using CapaEntidades;
using CapaNegocio;
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
using static Pintacars_Express.FrmInicio_Sesion;

namespace Pintacars_Express
{
    public partial class FrmCotizacion_Inicial : Form
    {
        CN_Clientes oCN_Clientes = new CN_Clientes();
        CN_Cotizacion_Inicial oCN_Cotizacion_Inicial = new CN_Cotizacion_Inicial();
        CN_Inspeccion_Inicial oCN_Inspeccion_Inicial = new CN_Inspeccion_Inicial();
        CN_Tipo_Documento oCN_Tipo_Documento = new CN_Tipo_Documento();
        CN_Validaciones oCN_Validaciones = new CN_Validaciones();


        int numerocotizacioninicial = 0;
        float valortotal = 0;
        string idvendedor = string.Empty;


        static public class CotizacionInicialGlobal //Se crea una variable global
        {
            static public string CotizacionInicial { get; set; } = string.Empty;
        }


        public FrmCotizacion_Inicial()
        {
            InitializeComponent();
        }


        private void FrmCotizacion_Inicial_Load(object sender, EventArgs e)
        {
            creacion_Dgv_Servicios();
            BuscarNumeroCotizacionInicial();
            MostrarTipoDocumento();
            TraerUsuario();
            BtnTerminar_Cotizacion_Inicial.Enabled = false;
        }


        //Botones del menustrip para ir de formulario en formulario en el panel


        private void inicioToolStripMenuItem_Click(object sender, EventArgs e) //Selecciona el formulario del panel principal del proyecto
        {
            Form panel_principal = new FrmPanel_Principal();
            panel_principal.Show();
            Hide();
        }

        private void nuevaOrdendeTrabajoToolStripMenuItem_Click(object sender, EventArgs e) //Selecciona el formulario de la orden de trabajo del proyecto
        {
            Form orden_trabajo = new FrmOrden_Trabajo();
            orden_trabajo.Show();
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


        //Datagridview


        private void creacion_Dgv_Servicios() //Método que agrega columnas al datagridview
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("CANTIDAD");
            dt.Columns.Add("DESCRIPCÍON");
            dt.Columns.Add("Vr. TOTAL");

            DgvServicios.DataSource = dt;

            DgvServicios.RowHeadersVisible = false;
        }


        //Consultar


        private void BuscarNumeroCotizacionInicial() //Método que trae el número de la de la última cotización inicial hecha y le suma 1 para poder realizar la siguiente, y si no encuentra ninguna deja el número 1 por defecto
        {
            if (oCN_Cotizacion_Inicial.BuscarNumeroCotizacionInicial() != " ")
            {
                numerocotizacioninicial = Convert.ToInt32(oCN_Cotizacion_Inicial.BuscarNumeroCotizacionInicial()) + 1;
                LblNumero_Cotizacion_Inicial.Text = "N° " + numerocotizacioninicial.ToString();
            }
            else
                numerocotizacioninicial = 1;
                LblNumero_Cotizacion_Inicial.Text = "N° " + numerocotizacioninicial.ToString();
        }


        private void TraerUsuario() //Método que trae los datos del usuario que en ese momento ingresó al programa
        {
            TxtVendedor.Text = UsuarioGlobal.Usuario.Rows[0][1].ToString();
            idvendedor = UsuarioGlobal.Usuario.Rows[0][0].ToString();
        }


        //private int BuscarCodigoInspeccionInicial()
        //{
        //    int codinspeccioninicial = 0;
        //    if (oCN_Inspeccion_Inicial.BuscarCodigoInspeccionInicial() != " ")
        //    {
        //        codinspeccioninicial = Convert.ToInt32(oCN_Inspeccion_Inicial.BuscarCodigoInspeccionInicial());
        //        return codinspeccioninicial;
        //    }
        //    else
        //        codinspeccioninicial = 1;
        //    return codinspeccioninicial;
        //}


        //Combobox


        private void MostrarTipoDocumento() //Método que muestra en el combobox los tipos de documento que hay en la base de datos
        {
            CboTipo_Documento.DataSource = oCN_Tipo_Documento.MostrarTipoDocumento();
            CboTipo_Documento.DisplayMember = "Nombre";
            CboTipo_Documento.ValueMember = "Cod";
            CboTipo_Documento.SelectedIndex = -1;
        }


        //Limpiar


        private void Limpiar() //Método que limpia las cajas de texto, los combobox y el datagridview
        {
            TxtCliente.Clear();
            TxtDireccion.Clear();
            CboTipo_Documento.SelectedIndex = -1;
            TxtNit.Clear();
            TxtTelefono.Clear();
            TxtCelular.Clear();
            TxtMatricula.Clear();
            TxtCorreo.Clear();
            TxtObservaciones.Clear();
            TxtValor_Total.Clear();
            DataTable dt = (DataTable)DgvServicios.DataSource;
            dt.Clear();
        }


        #endregion


        //Confirmar


        private void BtnConfirmar_Click(object sender, EventArgs e) //Nos recorre el datagridview sumando todos los resultados de la multiplicación de la columna cantidad por la columna Vr. Total y asignando ese resultado a la caja de texto del valor total
        {
            valortotal = 0;
            foreach (DataGridViewRow filas in DgvServicios.Rows)
            {
                if (filas.Cells["CANTIDAD"].Value.ToString() == null ||
                    filas.Cells["DESCRIPCÍON"].Value.ToString() == null ||
                    filas.Cells["Vr. TOTAL"].Value.ToString() == null)
                {
                    break;
                }
                else
                {
                    valortotal += float.Parse(filas.Cells["Vr. TOTAL"].Value.ToString()) * float.Parse(filas.Cells["CANTIDAD"].Value.ToString());
                    DgvServicios.AllowUserToAddRows = false;
                }
            }
            TxtValor_Total.Text = valortotal.ToString();
            BtnTerminar_Cotizacion_Inicial.Enabled = true;
            DgvServicios.AllowUserToAddRows = true;
        }


        //Insertar


        private void BtnTerminar_Cotizacion_Inicial_Click(object sender, EventArgs e) //Nos recorre todas las cajas de texto, combobox, datetimepicker y el datagridview y envia los datos a la base de datos
        {
            try
            {
                CE_Clientes cliente = new CE_Clientes();
                CE_Cotizacion_Inicial cotizacion_inicial = new CE_Cotizacion_Inicial();
                CE_Inspeccion_Inicial inspeccion_inicial = new CE_Inspeccion_Inicial();


                cliente.Nombre = TxtCliente.Text;
                cliente.Direccion = TxtDireccion.Text;
                cliente.Cod_Tipo_Doc = Convert.ToInt32(CboTipo_Documento.SelectedValue);
                cliente.D_I = TxtNit.Text;
                cliente.Telefono = TxtTelefono.Text;
                cliente.Celular = TxtCelular.Text;
                cliente.Correo = TxtCorreo.Text;

                cotizacion_inicial.Fecha_Llegada = DtpFecha_Llegada.Value;
                cotizacion_inicial.Observaciones = TxtObservaciones.Text;
                cotizacion_inicial.Costo_Total = float.Parse(TxtValor_Total.Text);
                cotizacion_inicial.D_I_Usuario = idvendedor;
                cotizacion_inicial.D_I_Cliente = TxtNit.Text;
                cotizacion_inicial.Matricula_Vehiculo = TxtMatricula.Text;

                //inspeccion_inicial.Fecha_Llegada = DtpFecha_Llegada.Value;

                oCN_Clientes.InsertarCliente(cliente);
                oCN_Cotizacion_Inicial.InsertarCotizacionInicial(cotizacion_inicial);

                CotizacionInicialGlobal.CotizacionInicial = numerocotizacioninicial.ToString();

                foreach (DataGridViewRow filas in DgvServicios.Rows)
                {
                    if (filas.Cells["CANTIDAD"].Value.ToString() == null ||
                        filas.Cells["DESCRIPCÍON"].Value.ToString() == null ||
                        filas.Cells["Vr. TOTAL"].Value.ToString() == null)
                    {
                        break;
                    }
                    else
                    {
                        inspeccion_inicial.Cantidad = float.Parse(filas.Cells["CANTIDAD"].Value.ToString());
                        inspeccion_inicial.Descripcion = filas.Cells["DESCRIPCÍON"].Value.ToString();
                        inspeccion_inicial.Costos_Unitarios = float.Parse(filas.Cells["Vr. TOTAL"].Value.ToString());
                        inspeccion_inicial.cod_cotizacion_inicial = numerocotizacioninicial;
                        //cotizacion_inspeccioninicial.cod_inspeccion_inicial = BuscarCodigoInspeccionInicial();
                        oCN_Inspeccion_Inicial.InsertarInspeccionInicial(inspeccion_inicial);
                        DgvServicios.AllowUserToAddRows = false;
                        valortotal += float.Parse(filas.Cells["Vr. TOTAL"].Value.ToString());
                    }
                }
                BuscarNumeroCotizacionInicial();
                Limpiar();
                DgvServicios.AllowUserToAddRows = true;
                BtnTerminar_Cotizacion_Inicial.Enabled = false;
                MessageBox.Show("Cotización Terminada");
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }

        }


        //Validaciones


        private void TxtNit_KeyPress(object sender, KeyPressEventArgs e)
        {
            oCN_Validaciones.SoloNum(e);
        }

        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            oCN_Validaciones.SoloNum(e);
        }

        private void TxtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            oCN_Validaciones.SoloNum(e);
        }
    }
}