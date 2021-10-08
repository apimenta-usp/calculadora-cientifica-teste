using System;
using System.Globalization;

namespace InterfaceUsuario.Personalizacao {
    public class Visor {
        public static string MostrarNoVisor(double resultado, bool virgula) {            
            string visor = resultado.ToString(CultureInfo.InvariantCulture);
            if (virgula) {
                visor = visor.Replace('.', ',');
            }
            return visor;
        }

        public static double CapturarVisor(string visor, bool virgula) {
            if (virgula) {
                visor = visor.Replace(',', '.');
            }
            double numero = Convert.ToDouble(visor, CultureInfo.InvariantCulture);
            return numero;
        }
    }
}
