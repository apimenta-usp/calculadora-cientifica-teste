using System.Drawing;
using System.Windows.Forms;

namespace InterfaceUsuario.Personalizacao {
    public class ControleDeImagens {
        public static void UmaImagem(Button botao, Bitmap imagem) {
            botao.BackColor = Color.Transparent;
            botao.BackgroundImage = imagem;
            botao.BackgroundImageLayout = ImageLayout.Zoom;
            botao.ForeColor = Color.Transparent;
        }

        public static void DuasImagens(Button botaoPrincipal, Bitmap imagemPrincipal,
                            Button botaoSecundario, Bitmap imagemSecundaria) {
            botaoPrincipal.BackColor = Color.Transparent;
            botaoPrincipal.BackgroundImage = imagemPrincipal;
            botaoPrincipal.BackgroundImageLayout = ImageLayout.Zoom;
            botaoPrincipal.ForeColor = Color.Transparent;

            botaoSecundario.BackColor = Color.Transparent;
            botaoSecundario.BackgroundImage = imagemSecundaria;
            botaoSecundario.BackgroundImageLayout = ImageLayout.Zoom;
            botaoSecundario.ForeColor = Color.Transparent;
        }
    }
}
