using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Prototipo_1___SartorialSys.Clases
{
    internal class Validaciones
    {
        //Método Validar Correo
        public static bool ValidarCorreoElectronico(string correo)
        {
            string patronCorreo = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(correo, patronCorreo);
        }

        //Método Validar Nombres
        public static bool validarNombrApellido(string nombre)
        {
            string patronNA = @"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ]+(?: [a-zA-ZáéíóúÁÉÍÓÚüÜñÑ]+)?$";
            return Regex.IsMatch(nombre, patronNA);
        }

        //Método Validadar Contraseña
        public static bool validarContraseña(string password)
        {
            string patronPass = @"^[a-zA-Z0-9#\$%&_!-]{8,12}$";
            return Regex.IsMatch(password, patronPass);
        }

        internal static bool validarTelefono(string telefono)
        {
            string patronPass = @"^09\d{8}$";
            return Regex.IsMatch(telefono, patronPass);
        }

        internal static bool esValidoCodigoProducto(string text)
        {
            string patronPass = @"^[A-Z]{1,3}\s[A-Z]{1,2}\d{3}$";
            return Regex.IsMatch(text, patronPass);
        }

        internal static bool esValidoDescripcion(string text)
        {
            string patronPass = @"^ [a - zA - ZáéíóúÁÉÍÓÚüÜñÑ\s]{ 0,100}$";
            return Regex.IsMatch(text, patronPass);
        }

        internal static bool esRUCValido(string RUC)
        {
            if (RUC.Length < 13)
            {
                return false;
            }
            if (!esCorrecto(RUC))
            {
                return false;
            }
            return true;
        }

        private static bool esCorrecto(string RUC)
        {
            if (!Regex.IsMatch(RUC, "^(0[0-9]|1[0-9]|2[0-2])[0-69]\\d{7}00[1-9]$"))
            {
                return false;
            }
            if (!esValido(RUC))
            {
                return false;
            }
            return true;
        }

        private static bool esValido(string RUC)
        {
            string verificacion_seis = "32765432";
            string verificacion_nueve = "432765432";
            if (RUC[2] == '6')
            {
                return validar(9, RUC, verificacion_seis);
            }
            else if (RUC[2] == '9')
            {
                return validar(10, RUC, verificacion_nueve);
            }
            else {
                return ValidarCedula.validarCedula(RUC.Substring(0, 10));
            }
            return true;
        }

        private static bool validar(int v, string RUC, string coeficientes)
        {
            int suma_total = 0;
            for (int j = 0; j <= coeficientes.Length; j++)
            {
                int multiplicacion = int.Parse(RUC[j].ToString()) * int.Parse(coeficientes[j].ToString());
                suma_total += multiplicacion;
            }
            int residuo = suma_total % 11;
            return (11 - residuo == RUC[v]);
        }

        internal static bool esCantidadValida(string text)
        {
            return Regex.IsMatch(text, "^\\d{1,4}$");
        }

        internal static bool esCantidadDecimalValida(string text)
        {
            return Regex.IsMatch(text, "^(\\d{1,3}$|(\\d{1,3}\\.\\d{1,2}))$");
        }

        internal static bool estanLlenosLosCampos(string[] datos)
        {
            foreach (string s in datos)
            {
                if (s == "")
                {
                    return false;
                }
            }
        return true;
        }

        internal static bool validarParametros(string[] datos)
        {
            return true;
        }

        internal static bool esValidoElNumeroDeFactura(string text)
        {
            return Regex.IsMatch(text, "^001-001-\\d{9}$");
        }

        internal static bool validarHora(string text)
        {
            return Regex.IsMatch(text, "^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$");
        }
    }
}
