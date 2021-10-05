using InterfaceUsuario.Personalizacao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            // Demais componentes
            Tema.ComponentesNoButton(Claro, txtVisor, chk2Funcao, lblAngulo, optGrau, optRadiano,
                                        optGrado, lblEstatistica);
        }
        #endregion
    }
}
