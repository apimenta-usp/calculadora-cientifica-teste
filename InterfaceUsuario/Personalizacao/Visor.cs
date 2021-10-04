using System.Globalization;

namespace InterfaceUsuario.Personalizacao {
    public class Visor {
        public static string MostrarNoVisor(double resultado) {
            bool virgula = true;
            string visor = resultado.ToString(CultureInfo.InvariantCulture);
            /* Obs.: Este método vai substituir (replace) 
               o ponto por vírgula, caso o separador decimal 
               "vírgula" esteja ativado. 
               Ou seja, o booleano Virgula for true. */
            if (virgula) {
                visor.Replace('.', ',');
            }
            return visor;
        }
    }
}
