using System.Drawing;
using System.Windows.Forms;

namespace InterfaceUsuario.Personalizacao {
    public class ControleDeImagens {
        public static void InserirImagens(Button botaoPrincipal, Bitmap imagemPrincipal,
                            Button botaoSecundario, Bitmap imagemSecundaria) {
            botaoPrincipal.BackgroundImage = imagemPrincipal;
            botaoPrincipal.BackgroundImageLayout = ImageLayout.Zoom;

            botaoSecundario.BackgroundImage = imagemSecundaria;
            botaoSecundario.BackgroundImageLayout = ImageLayout.Zoom;
        }

        public static void TrocarImagem(Button botao, Bitmap imagem) {
            botao.BackgroundImage = imagem;
            botao.BackgroundImageLayout = ImageLayout.Zoom;
        }
    }
}
