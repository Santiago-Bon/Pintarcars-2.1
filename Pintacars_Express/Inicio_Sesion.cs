using CapaEntidades;
using CapaNegocio;
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
    public partial class FrmInicio_Sesion : Form
    {
        CN_Usuarios oCN_Usuarios = new CN_Usuarios();
        CN_Validaciones validaciones = new CN_Validaciones();

        public FrmInicio_Sesion()
        {
            InitializeComponent();
        }

        static public class UsuarioGlobal //Se crea una variable global
        {
            static public DataTable Usuario { get; set; }
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            CE_Usuarios usuario = new CE_Usuarios();

            usuario.Correo = TxtCorreo.Text.Trim();
            UsuarioGlobal.Usuario = oCN_Usuarios.TraerUsuario(usuario);
            usuario.Contraseña = validaciones.Encriptacion(TxtContrasena.Text.Trim());

            if (oCN_Usuarios.BuscarUsuario(usuario) == true)
            {
                Form panel_principal = new FrmPanel_Principal();
                panel_principal.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Datos Incorrectos");
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmInicio_Sesion_Load(object sender, EventArgs e)
        {
            BtnMostrar.BackgroundImage = imageList1.Images[1];
        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            if (TxtContrasena.PasswordChar == '*')
            {
                TxtContrasena.PasswordChar = '\0';
                BtnMostrar.BackgroundImage = imageList1.Images[0];
            }
            else if (TxtContrasena.PasswordChar == '\0')
            {
                TxtContrasena.PasswordChar = '*';
                BtnIngresar.ImageIndex = 1;
                BtnMostrar.BackgroundImage = imageList1.Images[1];
            }
        }
    }
}
