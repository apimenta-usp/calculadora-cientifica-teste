using InterfaceUsuario.Personalizacao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using static InterfaceUsuario.Properties.Resources;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;
using System.Globalization;
using InterfaceUsuario.Operacoes;

namespace InterfaceUsuario {
    public partial class FrmCalculadoraCientifica : Form {
        public static bool Virgula { get; private set; }
        public bool Claro { get; private set; }
        public static double Numero1 { get; set; }
        public static double Numero2 { get; set; }
        public static double Memoria { get; set; }
        public static string Operacao { get; set; }
        public static bool PressionouIgual { get; set; }
        public static bool PressionouPotenciacao { get; set; }
        public static bool PressionouExponencial { get; set; }
        public static bool PressionouMemoria { get; set; }
        public const double Pi = 3.14159265359;
        globalKeyboardHook gkh = new globalKeyboardHook();

        public FrmCalculadoraCientifica() {
            InitializeComponent();
        }

        //private void LimparCampos() {
        //    txtVisor.Clear();
        //    Numero1 = 0;
        //    Numero2 = 0;
        //    Operacao = string.Empty;
        //    PressionouIgual = false;
        //    PressionouPotenciacao = false;
        //}

        private void FrmCalculadoraCientifica_Load(object sender, EventArgs e) {
            Claro = true;
            Virgula = false;
            mnsFixar2Funcao.Checked = false;
            mnsClaro.Checked = true;
            mnsPonto.Checked = true;
            chk2Funcao.Checked = false;
            Calcular.LimparCampos(txtVisor);
            Memoria = 0;
            PressionouMemoria = false;            
            //TemaClaro();
            TemaPrincipal(Claro, Virgula);
            gkh.HookedKeys.Add(Keys.Enter);
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
        }

        void gkh_KeyDown(object sender, KeyEventArgs e) {
            e.Handled = true;
        }

        //private void AdicionarCaracterNumerico(string caracter) {
        //    sbyte tamanho;
        //    if (txtVisor.Text.Trim().Contains(",") || txtVisor.Text.Trim().Contains("."))
        //        tamanho = 11;
        //    else
        //        tamanho = 10;
        //    if (PressionouIgual || PressionouMemoria) {
        //        txtVisor.Clear();
        //        PressionouIgual = false;
        //        PressionouMemoria = false;
        //    }
        //    if (txtVisor.Text.Trim().Equals("0") || txtVisor.Text.Trim().Equals("-0"))
        //        txtVisor.Text = caracter;
        //    else if (txtVisor.Text.Trim().Length < tamanho)
        //        txtVisor.Text += caracter;
        //}

        //private void AdicionarCaracterOperacao(string caracter) {
        //    if (!txtVisor.Text.Trim().Equals(string.Empty)) {
        //        Numero1 = Convert.ToDouble(txtVisor.Text.Trim(), CultureInfo.InvariantCulture);
        //        Operacao = caracter;
        //        txtVisor.Clear();
        //    }
        //}

        #region Eventos Click
        private void mnsCopiarVisor_Click(object sender, EventArgs e) {
            if (txtVisor.Text.Trim().Equals(string.Empty)) {
                return;
            }
            Clipboard.SetText(txtVisor.Text.Trim());
        }

        private void mnsSair_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void mnsPonto_Click(object sender, EventArgs e) {
            Virgula = false;
            txtVisor.Text = txtVisor.Text.Trim().Replace(',', '.');
            if (Claro) ControleDeImagens.UmaImagem(btnSeparadorDecimal, PontoTemaClaroNormal);
            else ControleDeImagens.UmaImagem(btnSeparadorDecimal, PontoTemaEscuroNormal);
            mnsPonto.Checked = !Virgula;
            mnsVirgula.Checked = Virgula;
        }

        private void mnsVirgula_Click(object sender, EventArgs e) {
            Virgula = true;
            txtVisor.Text = txtVisor.Text.Trim().Replace('.', ',');
            if (Claro) ControleDeImagens.UmaImagem(btnSeparadorDecimal, VirgulaTemaClaroNormal);
            else ControleDeImagens.UmaImagem(btnSeparadorDecimal, VirgulaTemaEscuroNormal);
            mnsPonto.Checked = !Virgula;
            mnsVirgula.Checked = Virgula;
        }

        private void mnsClaro_Click(object sender, EventArgs e) {
            Claro = true;
            //TemaClaro();
            TemaPrincipal(Claro, Virgula);
        }

        private void mnsEscuro_Click(object sender, EventArgs e) {
            Claro = false;
            //TemaEscuro();
            TemaPrincipal(Claro, Virgula);
        }

        private void btn0_Click(object sender, EventArgs e) {
            sbyte tamanho;
            if (txtVisor.Text.Trim().Contains(",") || txtVisor.Text.Trim().Contains("."))
                tamanho = 11;
            else
                tamanho = 10;
            if (PressionouIgual || PressionouMemoria) {
                txtVisor.Clear();
                PressionouIgual = false;
                PressionouMemoria = false;
            }
            if (txtVisor.Text.Trim().Equals("0") || txtVisor.Text.Trim().Equals("-0"))
                txtVisor.Text = "0";
            else if (txtVisor.Text.Trim().Length < tamanho)
                txtVisor.Text += "0";
        }

        private void btn1_Click(object sender, EventArgs e) {
            AdicionarCaracter.Numerico("1", txtVisor);
        }

        private void btn2_Click(object sender, EventArgs e) {
            AdicionarCaracter.Numerico("2", txtVisor);
        }

        private void btn3_Click(object sender, EventArgs e) {
            AdicionarCaracter.Numerico("3", txtVisor);
        }

        private void btn4_Click(object sender, EventArgs e) {
            AdicionarCaracter.Numerico("4", txtVisor);
        }

        private void btn5_Click(object sender, EventArgs e) {
            AdicionarCaracter.Numerico("5", txtVisor);
        }

        private void btn6_Click(object sender, EventArgs e) {
            AdicionarCaracter.Numerico("6", txtVisor);
        }

        private void btn7_Click(object sender, EventArgs e) {
            AdicionarCaracter.Numerico("7", txtVisor);
        }

        private void btn8_Click(object sender, EventArgs e) {
            AdicionarCaracter.Numerico("8", txtVisor);
        }

        private void btn9_Click(object sender, EventArgs e) {
            AdicionarCaracter.Numerico("9", txtVisor);
        }

        private void btnSeparadorDecimal_Click(object sender, EventArgs e) {
            if (PressionouIgual || PressionouMemoria) {
                txtVisor.Clear();
                PressionouIgual = false;
                PressionouMemoria = false;
            }
            if (txtVisor.Text.Trim().Equals(string.Empty) || txtVisor.Text.Trim() == "-") {
                if (!Virgula) txtVisor.Text = "0.";
                else txtVisor.Text = "0,";
                return;
            }
            if (txtVisor.Text.Contains(".") || txtVisor.Text.Contains(",")) return;
            if (txtVisor.Text.Trim().Length > 9) return;
            if (!Virgula)
                txtVisor.Text += ".";
            else
                txtVisor.Text += ",";
        }

        private void btnOposicao_Click(object sender, EventArgs e) {
            if (!txtVisor.Text.Trim().Equals(string.Empty)) {
                double visor = (Visor.Capturar(txtVisor.Text.Trim())) * (-1);
                txtVisor.Text = Visor.Exibir(visor);
            }
        }

        private void btnSoma_Click(object sender, EventArgs e) {
            AdicionarCaracter.Operacao("+", txtVisor);
        }

        private void btnSubtracao_Click(object sender, EventArgs e) {
            AdicionarCaracter.Operacao("-", txtVisor);
        }

        private void btnMultiplicacao_Click(object sender, EventArgs e) {
            AdicionarCaracter.Operacao("*", txtVisor);
        }

        private void btnDivisao_Click(object sender, EventArgs e) {
            AdicionarCaracter.Operacao("/", txtVisor);
        }

        private void btnIgual_Click(object sender, EventArgs e) {
            if (!txtVisor.Text.Trim().Equals(string.Empty) 
                && double.TryParse(txtVisor.Text.Trim(), out double numero)) {
                Numero2 = Visor.Capturar(txtVisor.Text.Trim());
                Calcular.Operacao(Operacao, txtVisor, Numero1, Numero2);
                PressionouIgual = true;
            }
        }

        private void btnMemoriaAdicionar_Click(object sender, EventArgs e) {
            if (!double.TryParse(txtVisor.Text.Trim(), out double numero)) {
                txtVisor.Clear();
            }
            if (!txtVisor.Text.Trim().Equals(string.Empty)) {
                if (!chk2Funcao.Checked) {
                    Memoria += Visor.Capturar(txtVisor.Text.Trim());
                } else {
                    Memoria -= Visor.Capturar(txtVisor.Text.Trim());
                    if (!mnsFixar2Funcao.Checked) chk2Funcao.Checked = false;
                }
                PressionouMemoria = true;
            }
        }

        private void btnMemoriaRecuperar_Click(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                txtVisor.Text = Visor.Exibir(Memoria);
                PressionouMemoria = true;
            } else {
                Memoria = 0;
                if (!mnsFixar2Funcao.Checked) chk2Funcao.Checked = false;
            }
        }

        private void btnMemoriaSubstituir_Click(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (!double.TryParse(txtVisor.Text.Trim(), out double numero)) {
                    txtVisor.Clear();
                }
                if (!txtVisor.Text.Trim().Equals(string.Empty)) {
                    Memoria = Visor.Capturar(txtVisor.Text.Trim());
                    PressionouMemoria = true;
                }
            } else {
                string valorAleatorio = Calcular.NumeroAleatorio().ToString("F3", CultureInfo.InvariantCulture);
                if (Virgula) {
                    valorAleatorio = valorAleatorio.Replace('.', ',');
                }
                txtVisor.Text = valorAleatorio;
                if (!mnsFixar2Funcao.Checked) chk2Funcao.Checked = false;
            }
        }

        private void btnInserirDados_Click(object sender, EventArgs e) {

        }

        private void btnDesvioAmostral_Click(object sender, EventArgs e) {

        }

        private void btnMediaAritmetica_Click(object sender, EventArgs e) {

        }

        private void btnNumeroDados_Click(object sender, EventArgs e) {

        }

        private void btnLogaritmoNeperiano_Click(object sender, EventArgs e) {
            if (!double.TryParse(txtVisor.Text.Trim(), out double numero)) {
                txtVisor.Clear();
            }
            if (!txtVisor.Text.Trim().Equals(string.Empty)) {
                double resultado = Visor.Capturar(txtVisor.Text.Trim());
                string visor;
                if (!chk2Funcao.Checked) {
                    visor = Math.Log(resultado).ToString();
                    if (resultado <= 0 || visor.Contains('∞') || visor.ToUpper() == "NAN") {
                        MessageBox.Show("Logaritmo inexistente!", "Erro!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtVisor.Clear();
                    } else
                        txtVisor.Text = Visor.Exibir(Math.Log(resultado));
                } else {
                    visor = Math.Exp(resultado).ToString();
                    if (visor.Contains('∞') || visor.ToUpper() == "NAN") {
                        MessageBox.Show("Número muito grande!", "Aviso!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtVisor.Clear();
                    } else
                        txtVisor.Text = Visor.Exibir(Math.Exp(resultado));
                    if (!mnsFixar2Funcao.Checked) chk2Funcao.Checked = false;
                }
                PressionouIgual = true;
            }
        }

        private void btnLogaritmoDecimal_Click(object sender, EventArgs e) {
            if (!double.TryParse(txtVisor.Text.Trim(), out double numero)) {
                txtVisor.Clear();
            }
            if (!txtVisor.Text.Trim().Equals(string.Empty)) {
                double resultado = Visor.Capturar(txtVisor.Text.Trim());
                string visor;
                if (!chk2Funcao.Checked) {
                    visor = Math.Log10(resultado).ToString();
                    if (resultado <= 0 || visor.Contains('∞') || visor.ToUpper() == "NAN") {
                        MessageBox.Show("Logaritmo inexistente!", "Erro!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtVisor.Clear();
                    } else
                        txtVisor.Text = Visor.Exibir(Math.Log10(resultado));
                } else {
                    visor = Math.Pow(10, resultado).ToString();
                    if (visor.Contains('∞') || visor.ToUpper() == "NAN") {
                        MessageBox.Show("Número muito grande!", "Aviso!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtVisor.Clear();
                    } else
                        txtVisor.Text = Visor.Exibir(Math.Pow(10, resultado));
                    if (!mnsFixar2Funcao.Checked) chk2Funcao.Checked = false;
                }
                PressionouIgual = true;
            }
        }

        private void btnInversao_Click(object sender, EventArgs e) {
            if (!double.TryParse(txtVisor.Text.Trim(), out double numero)) {
                txtVisor.Clear();
            }
            if (!txtVisor.Text.Trim().Equals(string.Empty)) {
                numero = Visor.Capturar(txtVisor.Text.Trim());
                if (!chk2Funcao.Checked) {
                    if (numero == 0) {
                        MessageBox.Show("Divisão por zero!", "Erro!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtVisor.Clear();
                    } else {
                        txtVisor.Text = Visor.Exibir(1 / numero);
                    }
                } else {
                    double radicando = 1.0 / 3.0;
                    txtVisor.Text = Visor.Exibir(Math.Pow(numero, radicando));
                    if (!mnsFixar2Funcao.Checked) chk2Funcao.Checked = false;
                }
                PressionouIgual = true;
            }
        }

        private void btnRaizQuadrada_Click(object sender, EventArgs e) {
            if (!double.TryParse(txtVisor.Text.Trim(), out double numero)) {
                txtVisor.Clear();
            }
            if (!txtVisor.Text.Trim().Equals(string.Empty)) {
                numero = Visor.Capturar(txtVisor.Text.Trim());
                if (!chk2Funcao.Checked) {
                    if (numero < 0) {
                        MessageBox.Show("Raiz quadrada de número negativo!", "Erro!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtVisor.Clear();
                    } else {
                        txtVisor.Text = Visor.Exibir(Math.Sqrt(numero));
                    }
                } else {
                    txtVisor.Text = Visor.Exibir(Math.Pow(numero, 2));
                    if (!mnsFixar2Funcao.Checked) chk2Funcao.Checked = false;
                }
                PressionouIgual = true;
            }
        }

        private void btnPotenciacao_Click(object sender, EventArgs e) {
            if (!double.TryParse(txtVisor.Text.Trim(), out double numero)) {
                txtVisor.Clear();
            }
            if (!txtVisor.Text.Trim().Equals(string.Empty)) {
                if (!chk2Funcao.Checked) {
                    AdicionarCaracter.Operacao("^", txtVisor);
                } else {
                    AdicionarCaracter.Operacao("~", txtVisor);
                    if (!mnsFixar2Funcao.Checked) chk2Funcao.Checked = false;
                }
                PressionouPotenciacao = true;
            }
        }

        private void btnExponencial_Click(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (!double.TryParse(txtVisor.Text.Trim(), out double numero)) {
                    txtVisor.Clear();
                }
                if (!txtVisor.Text.Trim().Equals(string.Empty)) {
                    AdicionarCaracter.Operacao("&", txtVisor);
                    PressionouExponencial = true;
                }
            } else {
                txtVisor.Text = Visor.Exibir(Pi);
                PressionouIgual = true;
                if (!mnsFixar2Funcao.Checked) chk2Funcao.Checked = false;
            }
        }

        private void btnDecimalCientifico_Click(object sender, EventArgs e) {
            if (!double.TryParse(txtVisor.Text.Trim(), out double numero)) {
                txtVisor.Clear();
            }
            if (!txtVisor.Text.Trim().Equals(string.Empty)) {
                if (!chk2Funcao.Checked) {
                    txtVisor.Text = Calcular.DecimalCientifico(txtVisor.Text.Trim());
                } else {
                    txtVisor.Text = Calcular.Fatorial(txtVisor.Text.Trim());
                    if (!mnsFixar2Funcao.Checked) chk2Funcao.Checked = false;
                }
                PressionouIgual = true;
            }
        }

        private void btnSeno_Click(object sender, EventArgs e) {
            if (!double.TryParse(txtVisor.Text.Trim(), out double numero)) {
                txtVisor.Clear();
            }
            if (!txtVisor.Text.Trim().Equals(string.Empty)) {
                if (!chk2Funcao.Checked) {
                    txtVisor.Text = Calcular.AnguloDireto("seno", txtVisor.Text.Trim(), optGrau, optGrado);
                }
                PressionouIgual = true;
            }
        }

        private void btnCosseno_Click(object sender, EventArgs e) {
            if (!double.TryParse(txtVisor.Text.Trim(), out double numero)) {
                txtVisor.Clear();
            }
            if (!txtVisor.Text.Trim().Equals(string.Empty)) {
                if (!chk2Funcao.Checked) {
                    txtVisor.Text = Calcular.AnguloDireto("cosseno", txtVisor.Text.Trim(), optGrau, optGrado);
                }
                PressionouIgual = true;
            }
        }

        private void btnTangente_Click(object sender, EventArgs e) {
            if (!double.TryParse(txtVisor.Text.Trim(), out double numero)) {
                txtVisor.Clear();
            }
            if (!txtVisor.Text.Trim().Equals(string.Empty)) {
                if (!chk2Funcao.Checked) {
                    txtVisor.Text = Calcular.AnguloDireto("tangente", txtVisor.Text.Trim(), optGrau, optGrado);
                }
            }
            PressionouIgual = true;
        }

        private void btnRemover_Click(object sender, EventArgs e) {
            if (!double.TryParse(txtVisor.Text.Trim(), out double numero)) {
                txtVisor.Clear();
            }
            if (!txtVisor.Text.Trim().Equals(string.Empty)) {
                if (!chk2Funcao.Checked) {
                    if (PressionouIgual) {
                        Calcular.LimparCampos(txtVisor);
                        return;
                    }
                    if ((txtVisor.Text.Trim().Length == 2 && txtVisor.Text.Trim().Contains("-")) ||
                        (txtVisor.Text.Trim() == "-0." || txtVisor.Text.Trim() == "-0,")) {
                        txtVisor.Clear();
                        return;
                    }
                    sbyte tamanho = (sbyte)txtVisor.Text.Trim().Length;
                    txtVisor.Text = txtVisor.Text.Trim().Remove((tamanho - 1));
                } else {
                    if (PressionouIgual || PressionouPotenciacao) {
                        Calcular.LimparCampos(txtVisor);
                        return;
                    }
                    if (!txtVisor.Text.Trim().Equals(string.Empty)) {
                        double porcentagem = Visor.Capturar(txtVisor.Text.Trim());
                        porcentagem = porcentagem / 100;
                        txtVisor.Text = Visor.Exibir(Numero1 * porcentagem);
                    }
                    if (!mnsFixar2Funcao.Checked) chk2Funcao.Checked = false;
                }
            }
        }

        private void btnApagarVisor_Click(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Operacao.Equals(string.Empty) || PressionouIgual) Calcular.LimparCampos(txtVisor);
                else txtVisor.Clear();
            } else {
                Calcular.LimparCampos(txtVisor);
                if (!mnsFixar2Funcao.Checked) chk2Funcao.Checked = false;
            }
        }
        #endregion

        #region Evento CheckedChanged
        private void chk2Funcao_CheckedChanged(object sender, EventArgs e) {
            bool assinalado = chk2Funcao.Checked;
            TemaBotoesMemoria(Claro, assinalado);
            TemaBotoesEstatistica(Claro, assinalado);
            TemaBotoesFuncoes(Claro, assinalado);
            TemaBotaoLimpeza(Claro, assinalado);
            if (!assinalado) mnsFixar2Funcao.Checked = false;
        }

        private void mnsFixar2Funcao_CheckedChanged(object sender, EventArgs e) {
            chk2Funcao.Checked = mnsFixar2Funcao.Checked;
        }
        #endregion

        #region Eventos MouseEnter
        private void btn0_MouseEnter(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btn0, ZeroTemaClaroRealce);
            else ControleDeImagens.UmaImagem(btn0, ZeroTemaEscuroRealce);
        }

        private void btn1_MouseEnter(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btn1, UmTemaClaroRealce);
            else ControleDeImagens.UmaImagem(btn1, UmTemaEscuroRealce);
        }

        private void btn2_MouseEnter(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btn2, DoisTemaClaroRealce);
            else ControleDeImagens.UmaImagem(btn2, DoisTemaEscuroRealce);
        }

        private void btn3_MouseEnter(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btn3, TresTemaClaroRealce);
            else ControleDeImagens.UmaImagem(btn3, TresTemaEscuroRealce);
        }

        private void btn4_MouseEnter(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btn4, QuatroTemaClaroRealce);
            else ControleDeImagens.UmaImagem(btn4, QuatroTemaEscuroRealce);
        }

        private void btn5_MouseEnter(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btn5, CincoTemaClaroRealce);
            else ControleDeImagens.UmaImagem(btn5, CincoTemaEscuroRealce);
        }

        private void btn6_MouseEnter(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btn6, SeisTemaClaroRealce);
            else ControleDeImagens.UmaImagem(btn6, SeisTemaEscuroRealce);
        }

        private void btn7_MouseEnter(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btn7, SeteTemaClaroRealce);
            else ControleDeImagens.UmaImagem(btn7, SeteTemaEscuroRealce);
        }

        private void btn8_MouseEnter(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btn8, OitoTemaClaroRealce);
            else ControleDeImagens.UmaImagem(btn8, OitoTemaEscuroRealce);
        }

        private void btn9_MouseEnter(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btn9, NoveTemaClaroRealce);
            else ControleDeImagens.UmaImagem(btn9, NoveTemaEscuroRealce);
        }

        private void btnSeparadorDecimal_MouseEnter(object sender, EventArgs e) {
            if (!Virgula) {
                if (Claro) ControleDeImagens.UmaImagem(btnSeparadorDecimal, PontoTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnSeparadorDecimal, PontoTemaEscuroRealce);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnSeparadorDecimal, VirgulaTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnSeparadorDecimal, VirgulaTemaEscuroRealce);
            }
        }

        private void btnOposicao_MouseEnter(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btnOposicao, OposicaoTemaClaroRealce);
            else ControleDeImagens.UmaImagem(btnOposicao, OposicaoTemaEscuroRealce);
        }

        private void btnSoma_MouseEnter(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btnSoma, MaisTemaClaroRealce);
            else ControleDeImagens.UmaImagem(btnSoma, MaisTemaEscuroRealce);
        }

        private void btnSubtracao_MouseEnter(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btnSubtracao, MenosTemaClaroRealce);
            else ControleDeImagens.UmaImagem(btnSubtracao, MenosTemaEscuroRealce);
        }

        private void btnMultiplicacao_MouseEnter(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btnMultiplicacao, VezesTemaClaroRealce);
            else ControleDeImagens.UmaImagem(btnMultiplicacao, VezesTemaEscuroRealce);
        }

        private void btnDivisao_MouseEnter(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btnDivisao, DividirTemaClaroRealce);
            else ControleDeImagens.UmaImagem(btnDivisao, DividirTemaEscuroRealce);
        }

        private void btnIgual_MouseEnter(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btnIgual, IgualTemaClaroRealce);
            else ControleDeImagens.UmaImagem(btnIgual, IgualTemaEscuroRealce);
        }

        private void btnMemoriaAdicionar_MouseEnter(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnMemoriaAdicionar, MemoriaMaisTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnMemoriaAdicionar, MemoriaMaisTemaEscuroRealce);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnMemoriaAdicionar, MemoriaMenosTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnMemoriaAdicionar, MemoriaMenosTemaEscuroRealce);
            }
        }

        private void btnMemoriaRecuperar_MouseEnter(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnMemoriaRecuperar, MemoriaRecuperarTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnMemoriaRecuperar, MemoriaRecuperarTemaEscuroRealce);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnMemoriaRecuperar, MemoriaLimparTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnMemoriaRecuperar, MemoriaLimparTemaEscuroRealce);
            }
        }

        private void btnMemoriaSubstituir_MouseEnter(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnMemoriaSubstituir, MemoriaSubstituirTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnMemoriaSubstituir, MemoriaSubstituirTemaEscuroRealce);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnMemoriaSubstituir, RandomTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnMemoriaSubstituir, RandomTemaEscuroRealce);
            }
        }

        private void btnInserirDados_MouseEnter(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnInserirDados, InserirDadosTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnInserirDados, InserirDadosTemaEscuroRealce);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnInserirDados, LimparDadosTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnInserirDados, LimparDadosTemaEscuroRealce);
            }
        }

        private void btnDesvioAmostral_MouseEnter(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnDesvioAmostral, DesvioAmostralTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnDesvioAmostral, DesvioAmostralTemaEscuroRealce);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnDesvioAmostral, DesvioPopulacionalTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnDesvioAmostral, DesvioPopulacionalTemaEscuroRealce);
            }
        }

        private void btnMediaAritmetica_MouseEnter(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnMediaAritmetica, MediaAritmeticaTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnMediaAritmetica, MediaAritmeticaTemaEscuroRealce);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnMediaAritmetica, SomatoriaXQuadradoTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnMediaAritmetica, SomatoriaXQuadradoTemaEscuroRealce);
            }
        }

        private void btnNumeroDados_MouseEnter(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnNumeroDados, NumeroDadosTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnNumeroDados, NumeroDadosTemaEscuroRealce);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnNumeroDados, SomatoriaXTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnNumeroDados, SomatoriaXTemaEscuroRealce);
            }
        }

        private void btnLogaritmoNeperiano_MouseEnter(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnLogaritmoNeperiano, LogaritmoNeperianoTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnLogaritmoNeperiano, LogaritmoNeperianoTemaEscuroRealce);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnLogaritmoNeperiano, PotenciaNeperianaTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnLogaritmoNeperiano, PotenciaNeperianaTemaEscuroRealce);
            }
        }

        private void btnLogaritmoDecimal_MouseEnter(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnLogaritmoDecimal, LogaritmoDecimalTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnLogaritmoDecimal, LogaritmoDecimalTemaEscuroRealce);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnLogaritmoDecimal, PotenciaDecimalTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnLogaritmoDecimal, PotenciaDecimalTemaEscuroRealce);
            }
        }

        private void btnInversao_MouseEnter(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnInversao, InversaoTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnInversao, InversaoTemaEscuroRealce);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnInversao, RaizCubicaTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnInversao, RaizCubicaTemaEscuroRealce);
            }
        }

        private void btnRaizQuadrada_MouseEnter(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnRaizQuadrada, RaizQuadradaTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnRaizQuadrada, RaizQuadradaTemaEscuroRealce);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnRaizQuadrada, XQuadradoTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnRaizQuadrada, XQuadradoTemaEscuroRealce);
            }
        }

        private void btnPotenciacao_MouseEnter(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnPotenciacao, PotenciacaoTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnPotenciacao, PotenciacaoTemaEscuroRealce);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnPotenciacao, RadiciacaoTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnPotenciacao, RadiciacaoTemaEscuroRealce);
            }
        }

        private void btnExponencial_MouseEnter(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnExponencial, ExponencialTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnExponencial, ExponencialTemaEscuroRealce);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnExponencial, PiTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnExponencial, PiTemaEscuroRealce);
            }
        }

        private void btnDecimalCientifico_MouseEnter(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnDecimalCientifico, DecimalCientificoTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnDecimalCientifico, DecimalCientificoTemaEscuroRealce);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnDecimalCientifico, FatorialTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnDecimalCientifico, FatorialTemaEscuroRealce);
            }
        }

        private void btnSeno_MouseEnter(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnSeno, SenoTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnSeno, SenoTemaEscuroRealce);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnSeno, SenoInversoTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnSeno, SenoInversoTemaEscuroRealce);
            }
        }

        private void btnCosseno_MouseEnter(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnCosseno, CossenoTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnCosseno, CossenoTemaEscuroRealce);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnCosseno, CossenoInversoTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnCosseno, CossenoInversoTemaEscuroRealce);
            }
        }

        private void btnTangente_MouseEnter(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnTangente, TangenteTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnTangente, TangenteTemaEscuroRealce);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnTangente, TangenteInversaTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnTangente, TangenteInversaTemaEscuroRealce);
            }
        }

        private void btnRemover_MouseEnter(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnRemover, RemoverTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnRemover, RemoverTemaEscuroRealce);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnRemover, PorcentagemTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnRemover, PorcentagemTemaEscuroRealce);
            }
        }

        private void btnApagarVisor_MouseEnter(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnApagarVisor, ApagarVisorTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnApagarVisor, ApagarVisorTemaEscuroRealce);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnApagarVisor, LimparTudoTemaClaroRealce);
                else ControleDeImagens.UmaImagem(btnApagarVisor, LimparTudoTemaEscuroRealce);
            }
        }
        #endregion

        #region Eventos MouseLeave
        private void btn0_MouseLeave(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btn0, ZeroTemaClaroNormal);
            else ControleDeImagens.UmaImagem(btn0, ZeroTemaEscuroNormal);
        }

        private void btn1_MouseLeave(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btn1, UmTemaClaroNormal);
            else ControleDeImagens.UmaImagem(btn1, UmTemaEscuroNormal);
        }

        private void btn2_MouseLeave(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btn2, DoisTemaClaroNormal);
            else ControleDeImagens.UmaImagem(btn2, DoisTemaEscuroNormal);
        }

        private void btn3_MouseLeave(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btn3, TresTemaClaroNormal);
            else ControleDeImagens.UmaImagem(btn3, TresTemaEscuroNormal);
        }

        private void btn4_MouseLeave(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btn4, QuatroTemaClaroNormal);
            else ControleDeImagens.UmaImagem(btn4, QuatroTemaEscuroNormal);
        }

        private void btn5_MouseLeave(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btn5, CincoTemaClaroNormal);
            else ControleDeImagens.UmaImagem(btn5, CincoTemaEscuroNormal);
        }

        private void btn6_MouseLeave(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btn6, SeisTemaClaroNormal);
            else ControleDeImagens.UmaImagem(btn6, SeisTemaEscuroNormal);
        }

        private void btn7_MouseLeave(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btn7, SeteTemaClaroNormal);
            else ControleDeImagens.UmaImagem(btn7, SeteTemaEscuroNormal);
        }

        private void btn8_MouseLeave(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btn8, OitoTemaClaroNormal);
            else ControleDeImagens.UmaImagem(btn8, OitoTemaEscuroNormal);
        }

        private void btn9_MouseLeave(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btn9, NoveTemaClaroNormal);
            else ControleDeImagens.UmaImagem(btn9, NoveTemaEscuroNormal);
        }

        private void btnSeparadorDecimal_MouseLeave(object sender, EventArgs e) {
            if (!Virgula) {
                if (Claro) ControleDeImagens.UmaImagem(btnSeparadorDecimal, PontoTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnSeparadorDecimal, PontoTemaEscuroNormal);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnSeparadorDecimal, VirgulaTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnSeparadorDecimal, VirgulaTemaEscuroNormal);
            }
        }

        private void btnOposicao_MouseLeave(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btnOposicao, OposicaoTemaClaroNormal);
            else ControleDeImagens.UmaImagem(btnOposicao, OposicaoTemaEscuroNormal);
        }

        private void btnSoma_MouseLeave(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btnSoma, MaisTemaClaroNormal);
            else ControleDeImagens.UmaImagem(btnSoma, MaisTemaEscuroNormal);
        }

        private void btnSubtracao_MouseLeave(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btnSubtracao, MenosTemaClaroNormal);
            else ControleDeImagens.UmaImagem(btnSubtracao, MenosTemaEscuroNormal);
        }

        private void btnMultiplicacao_MouseLeave(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btnMultiplicacao, VezesTemaClaroNormal);
            else ControleDeImagens.UmaImagem(btnMultiplicacao, VezesTemaEscuroNormal);
        }

        private void btnDivisao_MouseLeave(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btnDivisao, DividirTemaClaroNormal);
            else ControleDeImagens.UmaImagem(btnDivisao, DividirTemaEscuroNormal);
        }

        private void btnIgual_MouseLeave(object sender, EventArgs e) {
            if (Claro) ControleDeImagens.UmaImagem(btnIgual, IgualTemaClaroNormal);
            else ControleDeImagens.UmaImagem(btnIgual, IgualTemaEscuroNormal);
        }

        private void btnMemoriaAdicionar_MouseLeave(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnMemoriaAdicionar, MemoriaMaisTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnMemoriaAdicionar, MemoriaMaisTemaEscuroNormal);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnMemoriaAdicionar, MemoriaMenosTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnMemoriaAdicionar, MemoriaMenosTemaEscuroNormal);
            }
        }

        private void btnMemoriaRecuperar_MouseLeave(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnMemoriaRecuperar, MemoriaRecuperarTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnMemoriaRecuperar, MemoriaRecuperarTemaEscuroNormal);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnMemoriaRecuperar, MemoriaLimparTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnMemoriaRecuperar, MemoriaLimparTemaEscuroNormal);
            }
        }

        private void btnMemoriaSubstituir_MouseLeave(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnMemoriaSubstituir, MemoriaSubstituirTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnMemoriaSubstituir, MemoriaSubstituirTemaEscuroNormal);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnMemoriaSubstituir, RandomTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnMemoriaSubstituir, RandomTemaEscuroNormal);
            }
        }

        private void btnInserirDados_MouseLeave(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnInserirDados, InserirDadosTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnInserirDados, InserirDadosTemaEscuroNormal);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnInserirDados, LimparDadosTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnInserirDados, LimparDadosTemaEscuroNormal);
            }
        }

        private void btnDesvioAmostral_MouseLeave(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnDesvioAmostral, DesvioAmostralTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnDesvioAmostral, DesvioAmostralTemaEscuroNormal);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnDesvioAmostral, DesvioPopulacionalTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnDesvioAmostral, DesvioPopulacionalTemaEscuroNormal);
            }
        }

        private void btnMediaAritmetica_MouseLeave(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnMediaAritmetica, MediaAritmeticaTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnMediaAritmetica, MediaAritmeticaTemaEscuroNormal);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnMediaAritmetica, SomatoriaXQuadradoTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnMediaAritmetica, SomatoriaXQuadradoTemaEscuroNormal);
            }
        }

        private void btnNumeroDados_MouseLeave(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnNumeroDados, NumeroDadosTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnNumeroDados, NumeroDadosTemaEscuroNormal);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnNumeroDados, SomatoriaXTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnNumeroDados, SomatoriaXTemaEscuroNormal);
            }
        }

        private void btnLogaritmoNeperiano_MouseLeave(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnLogaritmoNeperiano, LogaritmoNeperianoTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnLogaritmoNeperiano, LogaritmoNeperianoTemaEscuroNormal);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnLogaritmoNeperiano, PotenciaNeperianaTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnLogaritmoNeperiano, PotenciaNeperianaTemaEscuroNormal);
            }
        }

        private void btnLogaritmoDecimal_MouseLeave(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnLogaritmoDecimal, LogaritmoDecimalTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnLogaritmoDecimal, LogaritmoDecimalTemaEscuroNormal);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnLogaritmoDecimal, PotenciaDecimalTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnLogaritmoDecimal, PotenciaDecimalTemaEscuroNormal);
            }
        }

        private void btnInversao_MouseLeave(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnInversao, InversaoTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnInversao, InversaoTemaEscuroNormal);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnInversao, RaizCubicaTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnInversao, RaizCubicaTemaEscuroNormal);
            }
        }

        private void btnRaizQuadrada_MouseLeave(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnRaizQuadrada, RaizQuadradaTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnRaizQuadrada, RaizQuadradaTemaEscuroNormal);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnRaizQuadrada, XQuadradoTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnRaizQuadrada, XQuadradoTemaEscuroNormal);
            }
        }

        private void btnPotenciacao_MouseLeave(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnPotenciacao, PotenciacaoTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnPotenciacao, PotenciacaoTemaEscuroNormal);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnPotenciacao, RadiciacaoTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnPotenciacao, RadiciacaoTemaEscuroNormal);
            }
        }

        private void btnExponencial_MouseLeave(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnExponencial, ExponencialTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnExponencial, ExponencialTemaEscuroNormal);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnExponencial, PiTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnExponencial, PiTemaEscuroNormal);
            }
        }

        private void btnDecimalCientifico_MouseLeave(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnDecimalCientifico, DecimalCientificoTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnDecimalCientifico, DecimalCientificoTemaEscuroNormal);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnDecimalCientifico, FatorialTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnDecimalCientifico, FatorialTemaEscuroNormal);
            }
        }

        private void btnSeno_MouseLeave(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnSeno, SenoTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnSeno, SenoTemaEscuroNormal);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnSeno, SenoInversoTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnSeno, SenoInversoTemaEscuroNormal);
            }
        }

        private void btnCosseno_MouseLeave(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnCosseno, CossenoTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnCosseno, CossenoTemaEscuroNormal);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnCosseno, CossenoInversoTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnCosseno, CossenoInversoTemaEscuroNormal);
            }
        }

        private void btnTangente_MouseLeave(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnTangente, TangenteTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnTangente, TangenteTemaEscuroNormal);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnTangente, TangenteInversaTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnTangente, TangenteInversaTemaEscuroNormal);
            }
        }

        private void btnRemover_MouseLeave(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro) ControleDeImagens.UmaImagem(btnRemover, RemoverTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnRemover, RemoverTemaEscuroNormal);
            } else {
                if (Claro) ControleDeImagens.UmaImagem(btnRemover, PorcentagemTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnRemover, PorcentagemTemaEscuroNormal);
            }
        }

        private void btnApagarVisor_MouseLeave(object sender, EventArgs e) {
            if (!chk2Funcao.Checked) {
                if (Claro)
                    ControleDeImagens.UmaImagem(btnApagarVisor, ApagarVisorTemaClaroNormal);
                else
                    ControleDeImagens.UmaImagem(btnApagarVisor, ApagarVisorTemaEscuroNormal);
            } else {
                if (Claro)
                    ControleDeImagens.UmaImagem(btnApagarVisor, LimparTudoTemaClaroNormal);
                else
                    ControleDeImagens.UmaImagem(btnApagarVisor, LimparTudoTemaEscuroNormal);
            }
        }
        #endregion

        #region Outros Métodos
        private void TemaPrincipal(bool claro, bool virgula) {
            // Formulário
            if (claro) BackColor = Color.Moccasin;
            else BackColor = Color.FromArgb(24, 23, 23);
            // Menu Principal
            TemaMenu(claro);
            // Demais componentes
            TemaComponentesNoButton(claro);
            // Botões
            TemaBotoes(claro, virgula, chk2Funcao.Checked);
        }

        //private void TemaClaro() {
        //    // Tema
        //    Claro = true;
        //    // Formulário
        //    BackColor = Color.Moccasin;
        //    // Menu Principal
        //    TemaMenu(Claro);
        //    // Demais componentes
        //    TemaComponentesNoButton(Claro);
        //    // Botões
        //    TemaBotoes(Claro, Virgula, chk2Funcao.Checked);
        //}

        //private void TemaEscuro() {
        //    // Tema
        //    Claro = false;
        //    // Formulário
        //    BackColor = Color.FromArgb(24, 23, 23);
        //    // Menu Principal
        //    TemaMenu(Claro);
        //    // Demais componentes
        //    TemaComponentesNoButton(Claro);
        //    // Botões
        //    TemaBotoes(Claro, Virgula, chk2Funcao.Checked);
        //}

        private void TemaMenu(bool claro) {
            if (claro) {
                // BackColor
                mnsMenuPrincipal.BackColor = Color.White;
                mnsArquivo.BackColor = Color.White;
                mnsCopiarVisor.BackColor = Color.White;
                mnsSair.BackColor = Color.White;
                mnsPersonalizar.BackColor = Color.White;
                mnsFixar2Funcao.BackColor = Color.White;
                mnsSeparadorDecimal.BackColor = Color.White;
                mnsPonto.BackColor = Color.White;
                mnsVirgula.BackColor = Color.White;
                mnsTema.BackColor = Color.White;
                mnsClaro.BackColor = Color.White;
                mnsEscuro.BackColor = Color.White;
                mnsAjuda.BackColor = Color.White;
                mnsManual.BackColor = Color.White;
                mnsSobre.BackColor = Color.White;
                // ForeColor
                mnsMenuPrincipal.ForeColor = Color.Black;
                mnsArquivo.ForeColor = Color.Black;
                mnsCopiarVisor.ForeColor = Color.Black;
                mnsSair.ForeColor = Color.Black;
                mnsPersonalizar.ForeColor = Color.Black;
                mnsFixar2Funcao.ForeColor = Color.Black;
                mnsSeparadorDecimal.ForeColor = Color.Black;
                mnsPonto.ForeColor = Color.Black;
                mnsVirgula.ForeColor = Color.Black;
                mnsTema.ForeColor = Color.Black;
                mnsClaro.ForeColor = Color.Black;
                mnsEscuro.ForeColor = Color.Black;
                mnsAjuda.ForeColor = Color.Black;
                mnsManual.ForeColor = Color.Black;
                mnsSobre.ForeColor = Color.Black;
            } else {
                // BackColor
                mnsMenuPrincipal.BackColor = Color.Black;
                mnsArquivo.BackColor = Color.Black;
                mnsCopiarVisor.BackColor = Color.Black;
                mnsSair.BackColor = Color.Black;
                mnsPersonalizar.BackColor = Color.Black;
                mnsFixar2Funcao.BackColor = Color.Black;
                mnsSeparadorDecimal.BackColor = Color.Black;
                mnsPonto.BackColor = Color.Black;
                mnsVirgula.BackColor = Color.Black;
                mnsTema.BackColor = Color.Black;
                mnsClaro.BackColor = Color.Black;
                mnsEscuro.BackColor = Color.Black;
                mnsAjuda.BackColor = Color.Black;
                mnsManual.BackColor = Color.Black;
                mnsSobre.BackColor = Color.Black;
                // ForeColor
                mnsMenuPrincipal.ForeColor = Color.White;
                mnsArquivo.ForeColor = Color.White;
                mnsCopiarVisor.ForeColor = Color.White;
                mnsSair.ForeColor = Color.White;
                mnsPersonalizar.ForeColor = Color.White;
                mnsFixar2Funcao.ForeColor = Color.White;
                mnsSeparadorDecimal.ForeColor = Color.White;
                mnsPonto.ForeColor = Color.White;
                mnsVirgula.ForeColor = Color.White;
                mnsTema.ForeColor = Color.White;
                mnsClaro.ForeColor = Color.White;
                mnsEscuro.ForeColor = Color.White;
                mnsAjuda.ForeColor = Color.White;
                mnsManual.ForeColor = Color.White;
                mnsSobre.ForeColor = Color.White;
            }
            mnsClaro.Checked = claro;
            mnsEscuro.Checked = !claro;
        }

        private void TemaComponentesNoButton(bool claro) {
            if (claro) {
                // Visor
                txtVisor.BackColor = Color.White;
                txtVisor.ForeColor = Color.Black;
                // 2ª Função
                chk2Funcao.BackColor = Color.Transparent;
                chk2Funcao.ForeColor = Color.Black;
                // Ângulos
                lblAngulo.BackColor = Color.Transparent;
                lblAngulo.ForeColor = Color.Black;
                optGrau.BackColor = Color.Transparent;
                optGrau.ForeColor = Color.Black;
                optRadiano.BackColor = Color.Transparent;
                optRadiano.ForeColor = Color.Black;
                optGrado.BackColor = Color.Transparent;
                optGrado.ForeColor = Color.Black;
                // Estatística
                lblEstatistica.BackColor = Color.Transparent;
                lblEstatistica.ForeColor = Color.Black;
            } else {
                // Visor
                txtVisor.BackColor = Color.Black;
                txtVisor.ForeColor = Color.White;
                // 2ª Função
                chk2Funcao.BackColor = Color.Transparent;
                chk2Funcao.ForeColor = Color.White;
                // Ângulos
                lblAngulo.BackColor = Color.Transparent;
                lblAngulo.ForeColor = Color.White;
                optGrau.BackColor = Color.Transparent;
                optGrau.ForeColor = Color.White;
                optRadiano.BackColor = Color.Transparent;
                optRadiano.ForeColor = Color.White;
                optGrado.BackColor = Color.Transparent;
                optGrado.ForeColor = Color.White;
                // Estatística
                lblEstatistica.BackColor = Color.Transparent;
                lblEstatistica.ForeColor = Color.White;
            }
        }

        private void TemaBotoes(bool claro, bool virgula, bool funcao2) {
            TemaBotoesPrincipais(claro, virgula);
            TemaBotoesMemoria(claro, funcao2);
            TemaBotoesEstatistica(claro, funcao2);
            TemaBotoesFuncoes(claro, funcao2);
            TemaBotaoLimpeza(claro, funcao2);
        }

        private void TemaBotoesPrincipais(bool claro, bool virgula) {
            if (claro) {
                if (virgula) ControleDeImagens.UmaImagem(btnSeparadorDecimal, VirgulaTemaClaroNormal);
                else ControleDeImagens.UmaImagem(btnSeparadorDecimal, PontoTemaClaroNormal);
                ControleDeImagens.UmaImagem(btn0, ZeroTemaClaroNormal);
                ControleDeImagens.UmaImagem(btn1, UmTemaClaroNormal);
                ControleDeImagens.UmaImagem(btn2, DoisTemaClaroNormal);
                ControleDeImagens.UmaImagem(btn3, TresTemaClaroNormal);
                ControleDeImagens.UmaImagem(btn4, QuatroTemaClaroNormal);
                ControleDeImagens.UmaImagem(btn5, CincoTemaClaroNormal);
                ControleDeImagens.UmaImagem(btn6, SeisTemaClaroNormal);
                ControleDeImagens.UmaImagem(btn7, SeteTemaClaroNormal);
                ControleDeImagens.UmaImagem(btn8, OitoTemaClaroNormal);
                ControleDeImagens.UmaImagem(btn9, NoveTemaClaroNormal);
                ControleDeImagens.UmaImagem(btnOposicao, OposicaoTemaClaroNormal);
                ControleDeImagens.UmaImagem(btnSoma, MaisTemaClaroNormal);
                ControleDeImagens.UmaImagem(btnSubtracao, MenosTemaClaroNormal);
                ControleDeImagens.UmaImagem(btnMultiplicacao, VezesTemaClaroNormal);
                ControleDeImagens.UmaImagem(btnDivisao, DividirTemaClaroNormal);
                ControleDeImagens.UmaImagem(btnIgual, IgualTemaClaroNormal);
            } else {
                if (virgula) ControleDeImagens.UmaImagem(btnSeparadorDecimal, VirgulaTemaEscuroNormal);
                else ControleDeImagens.UmaImagem(btnSeparadorDecimal, PontoTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btn0, ZeroTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btn1, UmTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btn2, DoisTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btn3, TresTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btn4, QuatroTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btn5, CincoTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btn6, SeisTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btn7, SeteTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btn8, OitoTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btn9, NoveTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btnOposicao, OposicaoTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btnSoma, MaisTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btnSubtracao, MenosTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btnMultiplicacao, VezesTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btnDivisao, DividirTemaEscuroNormal);
                ControleDeImagens.UmaImagem(btnIgual, IgualTemaEscuroNormal);
            }
        }

        private void TemaBotoesMemoria(bool claro, bool funcao2) {
            if (claro) {
                if (!funcao2) {
                    ControleDeImagens.DuasImagens(btnMemoriaAdicionar, MemoriaMaisTemaClaroNormal,
                                                    btnMemoriaSubtrair, MemoriaMenosTemaClaro);
                    ControleDeImagens.DuasImagens(btnMemoriaRecuperar, MemoriaRecuperarTemaClaroNormal,
                                                    btnMemoriaLimpar, MemoriaLimparTemaClaro);
                    ControleDeImagens.DuasImagens(btnMemoriaSubstituir, MemoriaSubstituirTemaClaroNormal,
                                                    btnRandom, RandomTemaClaro);
                } else {
                    ControleDeImagens.DuasImagens(btnMemoriaAdicionar, MemoriaMenosTemaClaroNormal,
                                                    btnMemoriaSubtrair, MemoriaMaisTemaClaro);
                    ControleDeImagens.DuasImagens(btnMemoriaRecuperar, MemoriaLimparTemaClaroNormal,
                                                    btnMemoriaLimpar, MemoriaRecuperarTemaClaro);
                    ControleDeImagens.DuasImagens(btnMemoriaSubstituir, RandomTemaClaroNormal,
                                                    btnRandom, MemoriaSubstituirTemaClaro);
                }
            } else {
                if (!funcao2) {
                    ControleDeImagens.DuasImagens(btnMemoriaAdicionar, MemoriaMaisTemaEscuroNormal,
                                                    btnMemoriaSubtrair, MemoriaMenosTemaEscuro);
                    ControleDeImagens.DuasImagens(btnMemoriaRecuperar, MemoriaRecuperarTemaEscuroNormal,
                                                    btnMemoriaLimpar, MemoriaLimparTemaEscuro);
                    ControleDeImagens.DuasImagens(btnMemoriaSubstituir, MemoriaSubstituirTemaEscuroNormal,
                                                    btnRandom, RandomTemaEscuro);
                } else {
                    ControleDeImagens.DuasImagens(btnMemoriaAdicionar, MemoriaMenosTemaEscuroNormal,
                                                    btnMemoriaSubtrair, MemoriaMaisTemaEscuro);
                    ControleDeImagens.DuasImagens(btnMemoriaRecuperar, MemoriaLimparTemaEscuroNormal,
                                                    btnMemoriaLimpar, MemoriaRecuperarTemaEscuro);
                    ControleDeImagens.DuasImagens(btnMemoriaSubstituir, RandomTemaEscuroNormal,
                                                    btnRandom, MemoriaSubstituirTemaEscuro);
                }
            }
        }

        private void TemaBotoesEstatistica(bool claro, bool funcao2) {
            if (claro) {
                if (!funcao2) {
                    ControleDeImagens.DuasImagens(btnInserirDados, InserirDadosTemaClaroNormal,
                                                    btnLimparDados, LimparDadosTemaClaro);
                    ControleDeImagens.DuasImagens(btnDesvioAmostral, DesvioAmostralTemaClaroNormal,
                                                    btnDesvioPopulacional, DesvioPopulacionalTemaClaro);
                    ControleDeImagens.DuasImagens(btnMediaAritmetica, MediaAritmeticaTemaClaroNormal,
                                                    btnSomaQuadradosValores, SomatoriaXQuadradoTemaClaro);
                    ControleDeImagens.DuasImagens(btnNumeroDados, NumeroDadosTemaClaroNormal,
                                                    btnSomaValores, SomatoriaXTemaClaro);
                } else {
                    ControleDeImagens.DuasImagens(btnInserirDados, LimparDadosTemaClaroNormal,
                                                    btnLimparDados, InserirDadosTemaClaro);
                    ControleDeImagens.DuasImagens(btnDesvioAmostral, DesvioPopulacionalTemaClaroNormal,
                                                    btnDesvioPopulacional, DesvioAmostralTemaClaro);
                    ControleDeImagens.DuasImagens(btnMediaAritmetica, SomatoriaXQuadradoTemaClaroNormal,
                                                    btnSomaQuadradosValores, MediaAritmeticaTemaClaro);
                    ControleDeImagens.DuasImagens(btnNumeroDados, SomatoriaXTemaClaroNormal,
                                                    btnSomaValores, NumeroDadosTemaClaro);
                }
            } else {
                if (!funcao2) {
                    ControleDeImagens.DuasImagens(btnInserirDados, InserirDadosTemaEscuroNormal,
                                                    btnLimparDados, LimparDadosTemaEscuro);
                    ControleDeImagens.DuasImagens(btnDesvioAmostral, DesvioAmostralTemaEscuroNormal,
                                                    btnDesvioPopulacional, DesvioPopulacionalTemaEscuro);
                    ControleDeImagens.DuasImagens(btnMediaAritmetica, MediaAritmeticaTemaEscuroNormal,
                                                    btnSomaQuadradosValores, SomatoriaXQuadradoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnNumeroDados, NumeroDadosTemaEscuroNormal,
                                                    btnSomaValores, SomatoriaXTemaEscuro);
                } else {
                    ControleDeImagens.DuasImagens(btnInserirDados, LimparDadosTemaEscuroNormal,
                                                    btnLimparDados, InserirDadosTemaEscuro);
                    ControleDeImagens.DuasImagens(btnDesvioAmostral, DesvioPopulacionalTemaEscuroNormal,
                                                    btnDesvioPopulacional, DesvioAmostralTemaEscuro);
                    ControleDeImagens.DuasImagens(btnMediaAritmetica, SomatoriaXQuadradoTemaEscuroNormal,
                                                    btnSomaQuadradosValores, MediaAritmeticaTemaEscuro);
                    ControleDeImagens.DuasImagens(btnNumeroDados, SomatoriaXTemaEscuroNormal,
                                                    btnSomaValores, NumeroDadosTemaEscuro);
                }
            }
        }

        private void TemaBotoesFuncoes(bool claro, bool funcao2) {
            if (claro) {
                if (!funcao2) {
                    ControleDeImagens.DuasImagens(btnLogaritmoNeperiano, LogaritmoNeperianoTemaClaroNormal,
                                                    btnPotenciaNeperiana, PotenciaNeperianaTemaClaro);
                    ControleDeImagens.DuasImagens(btnLogaritmoDecimal, LogaritmoDecimalTemaClaroNormal,
                                                    btnPotenciaDecimal, PotenciaDecimalTemaClaro);
                    ControleDeImagens.DuasImagens(btnInversao, InversaoTemaClaroNormal,
                                                    btnRaizCubica, RaizCubicaTemaClaro);
                    ControleDeImagens.DuasImagens(btnRaizQuadrada, RaizQuadradaTemaClaroNormal,
                                                    btnXQuadrado, XQuadradoTemaClaro);
                    ControleDeImagens.DuasImagens(btnPotenciacao, PotenciacaoTemaClaroNormal,
                                                    btnRadiciacao, RadiciacaoTemaClaro);
                    ControleDeImagens.DuasImagens(btnExponencial, ExponencialTemaClaroNormal,
                                                    btnPi, PiTemaClaro);
                    ControleDeImagens.DuasImagens(btnDecimalCientifico, DecimalCientificoTemaClaroNormal,
                                                    btnFatorial, FatorialTemaClaro);
                    ControleDeImagens.DuasImagens(btnSeno, SenoTemaClaroNormal,
                                                    btnSenoInverso, SenoInversoTemaClaro);
                    ControleDeImagens.DuasImagens(btnCosseno, CossenoTemaClaroNormal,
                                                    btnCossenoInverso, CossenoInversoTemaClaro);
                    ControleDeImagens.DuasImagens(btnTangente, TangenteTemaClaroNormal,
                                                    btnTangenteInversa, TangenteInversaTemaClaro);
                    ControleDeImagens.DuasImagens(btnRemover, RemoverTemaClaroNormal,
                                                    btnPorcentagem, PorcentagemTemaClaro);
                } else {
                    ControleDeImagens.DuasImagens(btnLogaritmoNeperiano, PotenciaNeperianaTemaClaroNormal,
                                                    btnPotenciaNeperiana, LogaritmoNeperianoTemaClaro);
                    ControleDeImagens.DuasImagens(btnLogaritmoDecimal, PotenciaDecimalTemaClaroNormal,
                                                    btnPotenciaDecimal, LogaritmoDecimalTemaClaro);
                    ControleDeImagens.DuasImagens(btnInversao, RaizCubicaTemaClaroNormal,
                                                    btnRaizCubica, InversaoTemaClaro);
                    ControleDeImagens.DuasImagens(btnRaizQuadrada, XQuadradoTemaClaroNormal,
                                                    btnXQuadrado, RaizQuadradaTemaClaro);
                    ControleDeImagens.DuasImagens(btnPotenciacao, RadiciacaoTemaClaroNormal,
                                                    btnRadiciacao, PotenciacaoTemaClaro);
                    ControleDeImagens.DuasImagens(btnExponencial, PiTemaClaroNormal,
                                                    btnPi, ExponencialTemaClaro);
                    ControleDeImagens.DuasImagens(btnDecimalCientifico, FatorialTemaClaroNormal,
                                                    btnFatorial, DecimalCientificoTemaClaro);
                    ControleDeImagens.DuasImagens(btnSeno, SenoInversoTemaClaroNormal,
                                                    btnSenoInverso, SenoTemaClaro);
                    ControleDeImagens.DuasImagens(btnCosseno, CossenoInversoTemaClaroNormal,
                                                    btnCossenoInverso, CossenoTemaClaro);
                    ControleDeImagens.DuasImagens(btnTangente, TangenteInversaTemaClaroNormal,
                                                    btnTangenteInversa, TangenteTemaClaro);
                    ControleDeImagens.DuasImagens(btnRemover, PorcentagemTemaClaroNormal,
                                                    btnPorcentagem, RemoverTemaClaro);
                }
            } else {
                if (!funcao2) {
                    ControleDeImagens.DuasImagens(btnLogaritmoNeperiano, LogaritmoNeperianoTemaEscuroNormal,
                                                    btnPotenciaNeperiana, PotenciaNeperianaTemaEscuro);
                    ControleDeImagens.DuasImagens(btnLogaritmoDecimal, LogaritmoDecimalTemaEscuroNormal,
                                                    btnPotenciaDecimal, PotenciaDecimalTemaEscuro);
                    ControleDeImagens.DuasImagens(btnInversao, InversaoTemaEscuroNormal,
                                                    btnRaizCubica, RaizCubicaTemaEscuro);
                    ControleDeImagens.DuasImagens(btnRaizQuadrada, RaizQuadradaTemaEscuroNormal,
                                                    btnXQuadrado, XQuadradoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnPotenciacao, PotenciacaoTemaEscuroNormal,
                                                    btnRadiciacao, RadiciacaoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnExponencial, ExponencialTemaEscuroNormal,
                                                    btnPi, PiTemaEscuro);
                    ControleDeImagens.DuasImagens(btnDecimalCientifico, DecimalCientificoTemaEscuroNormal,
                                                    btnFatorial, FatorialTemaEscuro);
                    ControleDeImagens.DuasImagens(btnSeno, SenoTemaEscuroNormal,
                                                    btnSenoInverso, SenoInversoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnCosseno, CossenoTemaEscuroNormal,
                                                    btnCossenoInverso, CossenoInversoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnTangente, TangenteTemaEscuroNormal,
                                                    btnTangenteInversa, TangenteInversaTemaEscuro);
                    ControleDeImagens.DuasImagens(btnRemover, RemoverTemaEscuroNormal,
                                                    btnPorcentagem, PorcentagemTemaEscuro);
                } else {
                    ControleDeImagens.DuasImagens(btnLogaritmoNeperiano, PotenciaNeperianaTemaEscuroNormal,
                                                    btnPotenciaNeperiana, LogaritmoNeperianoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnLogaritmoDecimal, PotenciaDecimalTemaEscuroNormal,
                                                    btnPotenciaDecimal, LogaritmoDecimalTemaEscuro);
                    ControleDeImagens.DuasImagens(btnInversao, RaizCubicaTemaEscuroNormal,
                                                    btnRaizCubica, InversaoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnRaizQuadrada, XQuadradoTemaEscuroNormal,
                                                    btnXQuadrado, RaizQuadradaTemaEscuro);
                    ControleDeImagens.DuasImagens(btnPotenciacao, RadiciacaoTemaEscuroNormal,
                                                    btnRadiciacao, PotenciacaoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnExponencial, PiTemaEscuroNormal,
                                                    btnPi, ExponencialTemaEscuro);
                    ControleDeImagens.DuasImagens(btnDecimalCientifico, FatorialTemaEscuroNormal,
                                                    btnFatorial, DecimalCientificoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnSeno, SenoInversoTemaEscuroNormal,
                                                    btnSenoInverso, SenoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnCosseno, CossenoInversoTemaEscuroNormal,
                                                    btnCossenoInverso, CossenoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnTangente, TangenteInversaTemaEscuroNormal,
                                                    btnTangenteInversa, TangenteTemaEscuro);
                    ControleDeImagens.DuasImagens(btnRemover, PorcentagemTemaEscuroNormal,
                                                    btnPorcentagem, RemoverTemaEscuro);
                }
            }
        }

        private void TemaBotaoLimpeza(bool claro, bool funcao2) {
            if (claro) {
                if (!funcao2) {
                    ControleDeImagens.DuasImagens(btnApagarVisor, ApagarVisorTemaClaroNormal,
                                                    btnLimparTudo, LimparTudoTemaClaro);
                } else {
                    ControleDeImagens.DuasImagens(btnApagarVisor, LimparTudoTemaClaroNormal,
                                                    btnLimparTudo, ApagarVisorTemaClaro);
                }
            } else {
                if (!funcao2) {
                    ControleDeImagens.DuasImagens(btnApagarVisor, ApagarVisorTemaEscuroNormal,
                                                    btnLimparTudo, LimparTudoTemaEscuro);
                } else {
                    ControleDeImagens.DuasImagens(btnApagarVisor, LimparTudoTemaEscuroNormal,
                                                    btnLimparTudo, ApagarVisorTemaEscuro);
                }
            }            
        }
        #endregion
    }
}
