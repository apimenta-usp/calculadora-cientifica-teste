using InterfaceUsuario.Personalizacao;
using System.Windows.Forms;

namespace InterfaceUsuario.Operacoes {
    public class AdicionarCaracter {
        public static void Numerico(string caracter, TextBox txtVisor) {
            byte tamanho;
            if (txtVisor.Text.Trim().Contains(",") || txtVisor.Text.Trim().Contains("."))
                tamanho = 11;
            else
                tamanho = 10;
            if (FrmCalculadoraCientifica.PressionouIgual || FrmCalculadoraCientifica.PressionouMemoria 
                || !(double.TryParse(txtVisor.Text.Trim(), out double numero))) {
                txtVisor.Clear();
                FrmCalculadoraCientifica.PressionouIgual = false;
                FrmCalculadoraCientifica.PressionouMemoria = false;
            }
            if (txtVisor.Text.Trim().Equals("0") || txtVisor.Text.Trim().Equals("-0"))
                txtVisor.Text = caracter;
            else if (txtVisor.Text.Trim().Length < tamanho)
                txtVisor.Text += caracter;
        }

        public static void Operacao(string caracter, TextBox txtVisor) {
            if (!double.TryParse(txtVisor.Text.Trim(), out double numero)) {
                txtVisor.Clear();
            }
            if (!txtVisor.Text.Trim().Equals(string.Empty)) {
                FrmCalculadoraCientifica.Numero1 = Visor.Capturar(txtVisor.Text.Trim());
                FrmCalculadoraCientifica.Operacao = caracter;
                txtVisor.Clear();
            }
        }
    }
}
