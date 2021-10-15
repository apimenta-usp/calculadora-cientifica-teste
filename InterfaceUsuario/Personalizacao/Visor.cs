using System;
using System.Globalization;

namespace InterfaceUsuario.Personalizacao {
    public class Visor {
        public static string Exibir(double resultado) {            
            string visor = resultado.ToString(CultureInfo.InvariantCulture);
            if (FrmCalculadoraCientifica.Virgula) {
                visor = visor.Replace('.', ',');
            }
            return visor;
        }

        public static double Capturar(string visor) {
            if (FrmCalculadoraCientifica.Virgula) {
                visor = visor.Replace(',', '.');
            }
            return Convert.ToDouble(visor, CultureInfo.InvariantCulture);            
        }
    }
}
