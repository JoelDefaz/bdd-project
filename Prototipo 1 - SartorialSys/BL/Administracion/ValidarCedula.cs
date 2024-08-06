using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Prototipo_1___SartorialSys.Clases
{
    internal class ValidarCedula
    {
        internal static bool estanLosCamposLlenos(string[] datos)
        {
            for(int i = 0; i < datos.Length; i++)
            {
                if(datos[i] == "")
                {
                    return false;
                }
            }
            return true;
        }

        internal static bool validarCedula(string cedula)
        {
            string verificacion = "212121212";
            int suma_total = 0;
                if(cedula.Length != 10)
                {
                    return false;
                }
                if (!esCorreectoElNumeroVerificador(cedula))
                {
                    return false;
                }
                return true;
        }

        private static bool esCorreectoElNumeroVerificador(string cedula)
        {
            string coeficientes = "212121212";
            int suma_total = 0;
            for(int j=0; j < cedula.Length-1; j++)
            {
                int multiplicacion = int.Parse(cedula[j].ToString()) * int.Parse(coeficientes[j].ToString());
                if (multiplicacion >= 10)
                {
                    multiplicacion = multiplicacion - 9;
                }
                suma_total = suma_total + multiplicacion;
            }
            int decenaSuperior = ((suma_total / 10) + 1) * 10;
            int verificar = decenaSuperior - suma_total;
            if (!((verificar == 10 && cedula[9] == '0') || (verificar == int.Parse(cedula[9].ToString()))))
            {
                return false;
            }
            return true;
        }
    }
}
