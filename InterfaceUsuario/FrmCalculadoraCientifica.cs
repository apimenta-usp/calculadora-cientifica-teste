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

namespace InterfaceUsuario {
    public partial class FrmCalculadoraCientifica : Form {
        public bool Virgula { get; private set; }
        public bool Claro { get; private set; }

        public FrmCalculadoraCientifica() {
            InitializeComponent();
        }

        private double numero1;
        private double numero2;
        private double memoria;
        private string operacao;
        private bool pressionouIgual;
        private bool pressionouPotenciacao;
        private bool pressionouMemoria;
        globalKeyboardHook gkh = new globalKeyboardHook();

        private void FrmCalculadoraCientifica_Load(object sender, EventArgs e) {
            Claro = true;
            Virgula = false;
            mnsClaro.Checked = true;
            mnsPonto.Checked = true;
            chk2Funcao.Checked = false;
            memoria = 0;
            pressionouMemoria = false;            
            //TemaClaro();
            TemaPrincipal(Claro, Virgula);
            gkh.HookedKeys.Add(Keys.Enter);
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
        }

        void gkh_KeyDown(object sender, KeyEventArgs e) {
            e.Handled = true;
        }

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
        #endregion

        #region Evento CheckedChanged
        private void chk2Funcao_CheckedChanged(object sender, EventArgs e) {
            TemaBotoesMemoria(Claro, chk2Funcao);
            TemaBotoesEstatistica(Claro, chk2Funcao);
            TemaBotoesFuncoes(Claro, chk2Funcao);
            TemaBotaoLimpeza(Claro, chk2Funcao);
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
            TemaBotoes(claro, virgula, chk2Funcao);
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
        //    TemaBotoes(Claro, Virgula, chk2Funcao);
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
        //    TemaBotoes(Claro, Virgula, chk2Funcao);
        //}

        private void TemaMenu(bool claro) {
            if (claro) {
                // BackColor
                mnsMenuPrincipal.BackColor = Color.White;
                mnsArquivo.BackColor = Color.White;
                mnsCopiarVisor.BackColor = Color.White;
                mnsSair.BackColor = Color.White;
                mnsPersonalizar.BackColor = Color.White;
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

        private void TemaBotoes(bool claro, bool virgula, CheckBox funcao2) {
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

        private void TemaBotoesMemoria(bool claro, CheckBox funcao2) {
            if (claro) {
                if (!funcao2.Checked) {
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
                if (!funcao2.Checked) {
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

        private void TemaBotoesEstatistica(bool claro, CheckBox funcao2) {
            if (claro) {
                if (!funcao2.Checked) {
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
                if (!funcao2.Checked) {
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

        private void TemaBotoesFuncoes(bool claro, CheckBox funcao2) {
            if (claro) {
                if (!funcao2.Checked) {
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
                if (!funcao2.Checked) {
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

        private void TemaBotaoLimpeza(bool claro, CheckBox funcao2) {
            if (claro) {
                if (!funcao2.Checked) {
                    ControleDeImagens.DuasImagens(btnApagarVisor, ApagarVisorTemaClaroNormal,
                                                    btnLimparTudo, LimparTudoTemaClaro);
                } else {
                    ControleDeImagens.DuasImagens(btnApagarVisor, LimparTudoTemaClaroNormal,
                                                    btnLimparTudo, ApagarVisorTemaClaro);
                }
            } else {
                if (!funcao2.Checked) {
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
