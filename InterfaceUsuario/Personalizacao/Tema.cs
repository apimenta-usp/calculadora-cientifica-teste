using System.Drawing;
using System.Windows.Forms;

namespace InterfaceUsuario.Personalizacao {
    public class Tema {
        public static void Menu(bool temaGeral, MenuStrip menuPrincipal, ToolStripMenuItem arquivo,
                                ToolStripMenuItem copiarVisor, ToolStripMenuItem sair,
                                ToolStripMenuItem personalizar, ToolStripMenuItem separadorDecimal,
                                ToolStripMenuItem ponto, ToolStripMenuItem virgula,
                                ToolStripMenuItem tema, ToolStripMenuItem claro, ToolStripMenuItem escuro,
                                ToolStripMenuItem ajuda, ToolStripMenuItem manual, ToolStripMenuItem sobre) {
            if (temaGeral) {
                // BackColor
                menuPrincipal.BackColor = Color.White;
                arquivo.BackColor = Color.White;
                copiarVisor.BackColor = Color.White;
                sair.BackColor = Color.White;
                personalizar.BackColor = Color.White;
                separadorDecimal.BackColor = Color.White;
                ponto.BackColor = Color.White;
                virgula.BackColor = Color.White;
                tema.BackColor = Color.White;
                claro.BackColor = Color.White;
                escuro.BackColor = Color.White;
                ajuda.BackColor = Color.White;
                manual.BackColor = Color.White;
                sobre.BackColor = Color.White;
                // ForeColor
                menuPrincipal.ForeColor = Color.Black;
                arquivo.ForeColor = Color.Black;
                copiarVisor.ForeColor = Color.Black;
                sair.ForeColor = Color.Black;
                personalizar.ForeColor = Color.Black;
                separadorDecimal.ForeColor = Color.Black;
                ponto.ForeColor = Color.Black;
                virgula.ForeColor = Color.Black;
                tema.ForeColor = Color.Black;
                claro.ForeColor = Color.Black;
                escuro.ForeColor = Color.Black;
                ajuda.ForeColor = Color.Black;
                manual.ForeColor = Color.Black;
                sobre.ForeColor = Color.Black;
            } else {
                // BackColor
                menuPrincipal.BackColor = Color.Black;
                arquivo.BackColor = Color.Black;
                copiarVisor.BackColor = Color.Black;
                sair.BackColor = Color.Black;
                personalizar.BackColor = Color.Black;
                separadorDecimal.BackColor = Color.Black;
                ponto.BackColor = Color.Black;
                virgula.BackColor = Color.Black;
                tema.BackColor = Color.Black;
                claro.BackColor = Color.Black;
                escuro.BackColor = Color.Black;
                ajuda.BackColor = Color.Black;
                manual.BackColor = Color.Black;
                sobre.BackColor = Color.Black;
                // ForeColor
                menuPrincipal.ForeColor = Color.White;
                arquivo.ForeColor = Color.White;
                copiarVisor.ForeColor = Color.White;
                sair.ForeColor = Color.White;
                personalizar.ForeColor = Color.White;
                separadorDecimal.ForeColor = Color.White;
                ponto.ForeColor = Color.White;
                virgula.ForeColor = Color.White;
                tema.ForeColor = Color.White;
                claro.ForeColor = Color.White;
                escuro.ForeColor = Color.White;
                ajuda.ForeColor = Color.White;
                manual.ForeColor = Color.White;
                sobre.ForeColor = Color.White;
            }
            claro.Checked = temaGeral;
            escuro.Checked = !temaGeral;
        }
        public static void ComponentesNoButton(bool temaGeral, TextBox visor, CheckBox funcao2, Label angulo, 
                                RadioButton grau, RadioButton radiano, RadioButton grado, Label estatistica) {
            if (temaGeral) {
                // Visor
                visor.BackColor = Color.White;
                visor.ForeColor = Color.Black;
                // 2ª Função
                funcao2.BackColor = Color.Transparent;
                funcao2.ForeColor = Color.Black;
                // Ângulos
                angulo.BackColor = Color.Transparent;
                angulo.ForeColor = Color.Black;
                grau.BackColor = Color.Transparent;
                grau.ForeColor = Color.Black;
                radiano.BackColor = Color.Transparent;
                radiano.ForeColor = Color.Black;
                grado.BackColor = Color.Transparent;
                grado.ForeColor = Color.Black;
                // Estatística
                estatistica.BackColor = Color.Transparent;
                estatistica.ForeColor = Color.Black;
            } else {
                // Visor
                visor.BackColor = Color.Black;
                visor.ForeColor = Color.White;
                // 2ª Função
                funcao2.BackColor = Color.Transparent;
                funcao2.ForeColor = Color.White;
                // Ângulos
                angulo.BackColor = Color.Transparent;
                angulo.ForeColor = Color.White;
                grau.BackColor = Color.Transparent;
                grau.ForeColor = Color.White;
                radiano.BackColor = Color.Transparent;
                radiano.ForeColor = Color.White;
                grado.BackColor = Color.Transparent;
                grado.ForeColor = Color.White;
                // Estatística
                estatistica.BackColor = Color.Transparent;
                estatistica.ForeColor = Color.White;
            }
        }
    }
}
