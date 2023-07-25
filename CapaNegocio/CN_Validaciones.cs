using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class CN_Validaciones
    {
        //Encriptación


        public string Encriptacion(string contrasena)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertimos la contraseña en bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contrasena));

                // Convertimos los bytes en una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }


        //Solo Números


        public void SoloNum(KeyPressEventArgs P)
        {
            if (Char.IsDigit(P.KeyChar)) // Busca si el Char del evento es un numero.
            {
                P.Handled = false; // Si es un numero, permite la digitacion.
            }
            else if (Char.IsControl(P.KeyChar)) // Busca si el char es un control.
            {
                P.Handled = false; // Si es un control, permite la digitacion.
            }
            else
            {
                P.Handled = true; // Si el Char es una letra, no permite la digitacion.
                MessageBox.Show("Error, solo numeros");
            }
        }


        //Solo Letras


        public void SoloLetras(KeyPressEventArgs P)
        {
            if (Char.IsLetter(P.KeyChar)) // Busca si el Char del evento es una letra
            {
                P.Handled = false; // Si es una letra, permite la digitacion.
            }
            else if (Char.IsControl(P.KeyChar)) // Busca si el char es un control.
            {
                P.Handled = false; // Si es un control, permite la digitacion.
            }
            else
            {
                P.Handled = true; // Si el Char es un numero, no permite la digitacion.
                MessageBox.Show("Error, solo letras");
            }
        }


        //Correo


        public bool correo(string correo)
        {
            bool esvalido = Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            if (!esvalido)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        //public bool email(string comprobarEmail)
        //{
        //    string formato;
        //    formato = "\\W+([-+.']\\W +)*@\\W+([-.]\\W +)*\\.\\W+([-.]\\W+)*";
        //    if (Regex.IsMatch(comprobarEmail, formato))
        //    {
        //        if (Regex.Replace(comprobarEmail, formato, string.Empty).Length == 0)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }         
        //}
    }
}
