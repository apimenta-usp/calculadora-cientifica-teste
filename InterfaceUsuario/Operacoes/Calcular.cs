using InterfaceUsuario.Personalizacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfaceUsuario.Operacoes {
    public class Calcular {
        public static void Operacao(string operacao, TextBox txtVisor, double numero1, double numero2) {
            double resultado;
            switch (operacao) {
                case "+":
                    resultado = (numero1 + numero2);
                    txtVisor.Text = Visor.Exibir(resultado);
                    break;
                case "-":
                    resultado = (numero1 - numero2);
                    txtVisor.Text = Visor.Exibir(resultado);
                    break;
                case "*":
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
                    resultado = (numero1 / numero2);
                    txtVisor.Text = Visor.Exibir(resultado);
                    break;
                case "~":
                    Radiciacao(numero1, numero2, txtVisor);
                    break;
                case "^":
                    Potencia(numero1, numero2, txtVisor);
                    break;
            }
        }

        public static double NumeroAleatorio() {
            Random random = new Random();
            int aleatorio = random.Next(1, 1000);
            double numero = aleatorio / 1000.0;
            return numero;
        }

        private static void Radiciacao(double valorRadicando, double valorIndice, TextBox txtVisor) {
            if (valorIndice <= 0) {
                MessageBox.Show("Raiz inexistente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimparCampos(txtVisor);
                return;
            }
            valorIndice = 1 / valorIndice;
            Potencia(valorRadicando, valorIndice, txtVisor);
        }

        private static void Potencia(double valorBase, double valorExpoente, TextBox txtVisor) {
            double resultado = 0.0;
            int valorExpoenteInteiro = (int)Math.Floor(valorExpoente);
            if (valorBase == 0 && valorExpoente < 0) {
                MessageBox.Show("Raiz inexistente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimparCampos(txtVisor);
                return;
            }
            if (valorBase < 0 && valorExpoenteInteiro != valorExpoente) {
                valorBase = Math.Abs(valorBase);
                var valoresFracao = ConverterEmFracao(valorExpoente);
                ulong numeradorFracao = valoresFracao.Item1;
                ulong denominadorFracao = valoresFracao.Item2;

                if (denominadorFracao % 2 == 0) {
                    MessageBox.Show("Raiz inexistente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimparCampos(txtVisor);
                    return;
                }
                if (denominadorFracao % 2 != 0 && numeradorFracao % 2 == 0) {
                    resultado = Math.Pow(valorBase, valorExpoente);
                } else if (denominadorFracao % 2 != 0 && numeradorFracao % 2 != 0) {
                    resultado = Math.Pow(valorBase, valorExpoente) * (-1);
                }
                txtVisor.Text = Visor.Exibir(resultado);
            } else {
                resultado = Math.Pow(valorBase, valorExpoente);
                if (resultado.ToString().Trim().Contains('∞') || resultado.ToString().Trim().ToUpper() == "NAN") {
                    MessageBox.Show("Cálculo não implementado ou \nraiz inexistente!", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimparCampos(txtVisor);
                    return;
                }
                txtVisor.Text = Visor.Exibir(resultado);
            }
            FrmCalculadoraCientifica.PressionouIgual = true;
        }

        private static Tuple<ulong, ulong> ConverterEmFracao(double valorExpoente) {
            valorExpoente = Math.Abs(valorExpoente);
            double superior = 0.0;
            double inferior = 1.0;
            double quociente = superior / inferior;

            while (quociente != valorExpoente) {
                if (quociente < valorExpoente) {
                    superior++;
                } else if (quociente > valorExpoente) {
                    inferior++;
                }
                quociente = superior / inferior;
            }

            ulong numerador = (ulong)Math.Round(superior);
            ulong denominador = (ulong)Math.Round(inferior);

            return new Tuple<ulong, ulong>(numerador, denominador);
        }

        public static void LimparCampos(TextBox txtVisor) {
            txtVisor.Clear();
            FrmCalculadoraCientifica.Numero1 = 0;
            FrmCalculadoraCientifica.Numero2 = 0;
            FrmCalculadoraCientifica.Operacao = string.Empty;
            FrmCalculadoraCientifica.PressionouIgual = false;
            FrmCalculadoraCientifica.PressionouPotenciacao = false;
        }
    }
}
