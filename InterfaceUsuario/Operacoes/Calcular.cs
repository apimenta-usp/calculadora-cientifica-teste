using InterfaceUsuario.Personalizacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfaceUsuario.Operacoes {
    public class Calcular {
        public static void OperacaoBasica(string operacao, TextBox txtVisor, double numero1, double numero2) {
            double resultado;
            switch (operacao) {
                case "+":
                    //txtVisor.Text = (numero1 + numero2).ToString(CultureInfo.InvariantCulture);
                    resultado = (numero1 + numero2);
                    txtVisor.Text = Visor.Exibir(resultado);
                    break;
                case "-":
                    //txtVisor.Text = (numero1 - numero2).ToString(CultureInfo.InvariantCulture);
                    resultado = (numero1 - numero2);
                    txtVisor.Text = Visor.Exibir(resultado);
                    break;
                case "*":
                    //txtVisor.Text = (numero1 * numero2).ToString(CultureInfo.InvariantCulture);
                    resultado = (numero1 * numero2);
                    txtVisor.Text = Visor.Exibir(resultado);
                    break;
                case "/":
                    if (numero2 == 0) {
                        MessageBox.Show("Divisão por zero!", "Erro!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtVisor.Clear();
                        break;
                    }
                    //txtVisor.Text = (numero1 / numero2).ToString(CultureInfo.InvariantCulture);
                    resultado = (numero1 / numero2);
                    txtVisor.Text = Visor.Exibir(resultado);
                    break;
            }
        }

        public static double NumeroAleatorio() {
            Random random = new Random();
            int aleatorio = random.Next(1, 1000);
            double numero = aleatorio / 1000.0;
            return numero;
        }
    }
}
