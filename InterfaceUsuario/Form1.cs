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

namespace InterfaceUsuario {
    public partial class FrmCalculadoraCientifica : Form {
        public bool Virgula { get; private set; }
        public bool Claro { get; private set; }

        public FrmCalculadoraCientifica() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        #region Outros Métodos
        private void TemaClaro() {
            // Tema
            Claro = true;
            // Formulário
            BackColor = Color.Moccasin;
            // Menu Principal
            Tema.Menu(Claro, mnsMenuPrincipal, mnsArquivo, mnsCopiarVisor, mnsSair, mnsPersonalizar,
                        mnsSeparadorDecimal, mnsPonto, mnsVirgula, mnsTema, mnsClaro, mnsEscuro,
                        mnsAjuda, mnsManual, mnsSobre);
            // Botões
            TemaBotoes(Claro, Virgula);
            // Demais componentes
            Tema.ComponentesNoButton(Claro, txtVisor, chk2Funcao, lblAngulo, optGrau, optRadiano,
                            optGrado, lblEstatistica);
        }

        private void TemaEscuro() {
            // Tema
            Claro = false;
            // Formulário
            BackColor = Color.FromArgb(24, 23, 23);
            // Menu Principal
            Tema.Menu(Claro, mnsMenuPrincipal, mnsArquivo, mnsCopiarVisor, mnsSair, mnsPersonalizar, 
                        mnsSeparadorDecimal, mnsPonto, mnsVirgula, mnsTema, mnsClaro, mnsEscuro, 
                        mnsAjuda, mnsManual, mnsSobre);
            // Botões
            TemaBotoes(Claro, Virgula);
            // Demais componentes
            Tema.ComponentesNoButton(Claro, txtVisor, chk2Funcao, lblAngulo, optGrau, optRadiano,
                                        optGrado, lblEstatistica);
        }

        private void TemaBotoes(bool claro, bool virgula) {
            if (claro) {
                    // Botões principais
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
                if (!chk2Funcao.Checked) {
                    // Botões de memória
                    ControleDeImagens.DuasImagens(btnMemoriaAdicionar, MemoriaMaisTemaClaroNormal,
                                                    btnMemoriaSubtrair, MemoriaMenosTemaClaro);
                    ControleDeImagens.DuasImagens(btnMemoriaRecuperar, MemoriaRecuperarTemaClaroNormal,
                                                    btnMemoriaLimpar, MemoriaLimparTemaClaro);
                    ControleDeImagens.DuasImagens(btnMemoriaSubstituir, MemoriaSubstituirTemaClaroNormal,
                                                    btnRandom, RandomTemaClaro);
                    // Botões de estatística
                    ControleDeImagens.DuasImagens(btnInserirDados, InserirDadosTemaClaroNormal,
                                                    btnLimparDados, LimparDadosTemaClaro);
                    ControleDeImagens.DuasImagens(btnDesvioAmostral, DesvioAmostralTemaClaroNormal,
                                                    btnDesvioPopulacional, DesvioPopulacionalTemaClaro);
                    ControleDeImagens.DuasImagens(btnMediaAritmetica, MediaAritmeticaTemaClaroNormal,
                                                    btnSomaQuadradosValores, SomatoriaXQuadradoTemaClaro);
                    ControleDeImagens.DuasImagens(btnNumeroDados, NumeroDadosTemaClaroNormal,
                                                    btnSomaValores, SomatoriaXTemaClaro);
                    // Botões de funções
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
                    // Botão de limpeza
                    ControleDeImagens.DuasImagens(btnApagarVisor, ApagarVisorTemaClaroNormal,
                                                    btnLimparTudo, LimparTudoTemaClaro);
                } else {
                    // Botões de memória
                    ControleDeImagens.DuasImagens(btnMemoriaSubtrair, MemoriaMenosTemaClaroNormal,
                                                    btnMemoriaAdicionar, MemoriaMaisTemaClaro);
                    ControleDeImagens.DuasImagens(btnMemoriaLimpar, MemoriaLimparTemaClaroNormal,
                                                    btnMemoriaRecuperar, MemoriaRecuperarTemaClaro);
                    ControleDeImagens.DuasImagens(btnRandom, RandomTemaClaroNormal,
                                                    btnMemoriaSubstituir, MemoriaSubstituirTemaClaro);
                    // Botões de estatística
                    ControleDeImagens.DuasImagens(btnLimparDados, LimparDadosTemaClaroNormal,
                                                    btnInserirDados, InserirDadosTemaClaro);
                    ControleDeImagens.DuasImagens(btnDesvioPopulacional, DesvioPopulacionalTemaClaroNormal,
                                                    btnDesvioAmostral, DesvioAmostralTemaClaro);
                    ControleDeImagens.DuasImagens(btnSomaQuadradosValores, SomatoriaXQuadradoTemaClaroNormal,
                                                    btnMediaAritmetica, MediaAritmeticaTemaClaro);
                    ControleDeImagens.DuasImagens(btnSomaValores, SomatoriaXTemaClaroNormal,
                                                    btnNumeroDados, NumeroDadosTemaClaro);
                    // Botões de funções
                    ControleDeImagens.DuasImagens(btnPotenciaNeperiana, PotenciaNeperianaTemaClaroNormal,
                                                    btnLogaritmoNeperiano, LogaritmoNeperianoTemaClaro);
                    ControleDeImagens.DuasImagens(btnPotenciaDecimal, PotenciaDecimalTemaClaroNormal,
                                                    btnLogaritmoDecimal, LogaritmoDecimalTemaClaro);
                    ControleDeImagens.DuasImagens(btnRaizCubica, RaizCubicaTemaClaroNormal,
                                                    btnInversao, InversaoTemaClaro);
                    ControleDeImagens.DuasImagens(btnXQuadrado, XQuadradoTemaClaroNormal,
                                                    btnRaizQuadrada, RaizQuadradaTemaClaro);
                    ControleDeImagens.DuasImagens(btnRadiciacao, RadiciacaoTemaClaroNormal,
                                                    btnPotenciacao, PotenciacaoTemaClaro);
                    ControleDeImagens.DuasImagens(btnPi, PiTemaClaroNormal,
                                                    btnExponencial, ExponencialTemaClaro);
                    ControleDeImagens.DuasImagens(btnFatorial, FatorialTemaClaroNormal,
                                                    btnDecimalCientifico, DecimalCientificoTemaClaro);
                    ControleDeImagens.DuasImagens(btnSenoInverso, SenoInversoTemaClaroNormal,
                                                    btnSeno, SenoTemaClaro);
                    ControleDeImagens.DuasImagens(btnCossenoInverso, CossenoInversoTemaClaroNormal,
                                                    btnCosseno, CossenoTemaClaro);
                    ControleDeImagens.DuasImagens(btnTangenteInversa, TangenteInversaTemaClaroNormal,
                                                    btnTangente, TangenteTemaClaro);
                    ControleDeImagens.DuasImagens(btnPorcentagem, PorcentagemTemaClaroNormal,
                                                    btnRemover, RemoverTemaClaro);
                    // Botão de limpeza
                    ControleDeImagens.DuasImagens(btnLimparTudo, LimparTudoTemaClaroNormal,
                                                    btnApagarVisor, ApagarVisorTemaClaro);
                }
            } else {
                // Botões principais
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
                if (!chk2Funcao.Checked) {
                    // Botões de memória
                    ControleDeImagens.DuasImagens(btnMemoriaAdicionar, MemoriaMaisTemaEscuroNormal,
                                                    btnMemoriaSubtrair, MemoriaMenosTemaEscuro);
                    ControleDeImagens.DuasImagens(btnMemoriaRecuperar, MemoriaRecuperarTemaEscuroNormal,
                                                    btnMemoriaLimpar, MemoriaLimparTemaEscuro);
                    ControleDeImagens.DuasImagens(btnMemoriaSubstituir, MemoriaSubstituirTemaEscuroNormal,
                                                    btnRandom, RandomTemaEscuro);
                    // Botões de estatística
                    ControleDeImagens.DuasImagens(btnInserirDados, InserirDadosTemaEscuroNormal,
                                                    btnLimparDados, LimparDadosTemaEscuro);
                    ControleDeImagens.DuasImagens(btnDesvioAmostral, DesvioAmostralTemaEscuroNormal,
                                                    btnDesvioPopulacional, DesvioPopulacionalTemaEscuro);
                    ControleDeImagens.DuasImagens(btnMediaAritmetica, MediaAritmeticaTemaEscuroNormal,
                                                    btnSomaQuadradosValores, SomatoriaXQuadradoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnNumeroDados, NumeroDadosTemaEscuroNormal,
                                                    btnSomaValores, SomatoriaXTemaEscuro);
                    // Botões de funções
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
                    // Botão de limpeza
                    ControleDeImagens.DuasImagens(btnApagarVisor, ApagarVisorTemaEscuroNormal,
                                                    btnLimparTudo, LimparTudoTemaEscuro);
                } else {
                    // Botões de memória
                    ControleDeImagens.DuasImagens(btnMemoriaSubtrair, MemoriaMenosTemaEscuroNormal,
                                                    btnMemoriaAdicionar, MemoriaMaisTemaEscuro);
                    ControleDeImagens.DuasImagens(btnMemoriaLimpar, MemoriaLimparTemaEscuroNormal,
                                                    btnMemoriaRecuperar, MemoriaRecuperarTemaEscuro);
                    ControleDeImagens.DuasImagens(btnRandom, RandomTemaEscuroNormal,
                                                    btnMemoriaSubstituir, MemoriaSubstituirTemaEscuro);
                    // Botões de estatística
                    ControleDeImagens.DuasImagens(btnLimparDados, LimparDadosTemaEscuroNormal,
                                                    btnInserirDados, InserirDadosTemaEscuro);
                    ControleDeImagens.DuasImagens(btnDesvioPopulacional, DesvioPopulacionalTemaEscuroNormal,
                                                    btnDesvioAmostral, DesvioAmostralTemaEscuro);
                    ControleDeImagens.DuasImagens(btnSomaQuadradosValores, SomatoriaXQuadradoTemaEscuroNormal,
                                                    btnMediaAritmetica, MediaAritmeticaTemaEscuro);
                    ControleDeImagens.DuasImagens(btnSomaValores, SomatoriaXTemaEscuroNormal,
                                                    btnNumeroDados, NumeroDadosTemaEscuro);
                    // Botões de funções
                    ControleDeImagens.DuasImagens(btnPotenciaNeperiana, PotenciaNeperianaTemaEscuroNormal,
                                                    btnLogaritmoNeperiano, LogaritmoNeperianoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnPotenciaDecimal, PotenciaDecimalTemaEscuroNormal,
                                                    btnLogaritmoDecimal, LogaritmoDecimalTemaEscuro);
                    ControleDeImagens.DuasImagens(btnRaizCubica, RaizCubicaTemaEscuroNormal,
                                                    btnInversao, InversaoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnXQuadrado, XQuadradoTemaEscuroNormal,
                                                    btnRaizQuadrada, RaizQuadradaTemaEscuro);
                    ControleDeImagens.DuasImagens(btnRadiciacao, RadiciacaoTemaEscuroNormal,
                                                    btnPotenciacao, PotenciacaoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnPi, PiTemaEscuroNormal,
                                                    btnExponencial, ExponencialTemaEscuro);
                    ControleDeImagens.DuasImagens(btnFatorial, FatorialTemaEscuroNormal,
                                                    btnDecimalCientifico, DecimalCientificoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnSenoInverso, SenoInversoTemaEscuroNormal,
                                                    btnSeno, SenoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnCossenoInverso, CossenoInversoTemaEscuroNormal,
                                                    btnCosseno, CossenoTemaEscuro);
                    ControleDeImagens.DuasImagens(btnTangenteInversa, TangenteInversaTemaEscuroNormal,
                                                    btnTangente, TangenteTemaEscuro);
                    ControleDeImagens.DuasImagens(btnPorcentagem, PorcentagemTemaEscuroNormal,
                                                    btnRemover, RemoverTemaEscuro);
                    // Botão de limpeza
                    ControleDeImagens.DuasImagens(btnLimparTudo, LimparTudoTemaEscuroNormal,
                                                    btnApagarVisor, ApagarVisorTemaEscuro);
                }
            }
        }
        #endregion
    }
}
