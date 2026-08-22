using System.Threading.Tasks;

namespace AppAnimacao
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnGirarDireita(object sender, EventArgs e)
        {
            //Aplicar uma animação de giro no componente
            //imagem realizando o giro no sentido do relogio
            //neste será em sentido horario
            //Para isso iremos determinar o quanto sera o giro
            //em grau 0-360 e por quanto tempo durara a animação
            //o tempo será em milisegundos, ou seja 
            //1 segundo é igual a 1000 milisegundos
            //OBS: é recomendando resetar a rotação do componente
            //antes de aplicar uma nova

            imgTeste.Rotation = 0;
            imgTeste.RotateTo(360, 2000);
        }

        private void btnGirarEsquerda(object sender, EventArgs e)
        {
            //Para aplicar o giro no sentido anti-horario
            //basta declar os graus em negativo

            imgTeste.Rotation = 0;
            imgTeste.RotateTo(-360, 3000);
        }

        private void btnGirarHorizontal(object sender, EventArgs e)
        {
            //As rotações orizontais e verticais 
            //seguem o plano cartesiano(x e y)
            //portante basta indicar qual plano sera usado

            imgTeste.RotationX = 0;
            imgTeste.RotateXTo(360, 1000);
        }

        private void btnGirarVertical(object sender, EventArgs e)
        {
            imgTeste.RotationY = 0;
            imgTeste.RotateYTo(360, 4000);
        }

        private void btnZoomMais(object sender, EventArgs e)
        {
            //Na animação de Escala(zoom) o calculo
            //sempre será com base no tamanho original 
            //da imagem ou seja se aplica 2x de zoom
            //ira duplicar o tamanho da imagem
            //Ex: 100px x 2x = 200
            //Ex: 100px x 3x = 300
            //Ele não aplica o calcular sobre o tamanho atual
            //Então se for 100 apliquei 2x foi pra 200
            //se aplicar 3x ele ira para 300 e nao para 600
            //pois considera o tamanho original da imagem
            //Para efeito de zoom continuo é preciso
            //aplicar o zoom sobre a nova escala
            imgTeste.ScaleTo(imgTeste.Scale + 0.5, 250);
        }

        private void btnZoomMenos(object sender, EventArgs e)
        {
            imgTeste.ScaleTo(imgTeste.Scale - 0.5, 250);
        }

        private async void btnTremer(object sender, EventArgs e)
        {
            //Para o efeito de tremida
            //iremos deslocar o componente 
            //para direita e para esquerda
            //a cada clico iremos diminuir 
            //o espaço de deslocamento

            //Usando o método Transalate 
            //precisamo de 3 parametros
            //o valor em x
            //o valor em y
            //tempo

            //As animações ocorrem de maneira assincrona
            //ou seja se tiver 10 animações do mesmo
            //todas serão executadas ao mesmo tempo
            //logo uma cancela-ra a outra
            //para isso é preciso sincronizar as animações
            //usando o awai, assim ira esperar a execução 
            //da animação anterior antes de ir para proxima
            //para isso basta adicionar o async no método acima
            //EX: private async void

            await imgTeste.TranslateTo(15, 0, 50);
            await imgTeste.TranslateTo(-15, 0, 50);
            await imgTeste.TranslateTo(10, 0, 50);
            await imgTeste.TranslateTo(-10, 0, 50);
            await imgTeste.TranslateTo(5, 0, 50);
            await imgTeste.TranslateTo(-5, 0, 50);
            imgTeste.TranslationX = 0;
        }

        private async void btnFade(object sender, EventArgs e)
        {
            //O efeito de opacidade tem apenas 2 valores
            //1 = totalmente solido
            //0 = totalmente transparente

            imgTeste.Opacity = 1;
            await imgTeste.FadeTo(0, 1000);

            imgTeste.Opacity = 0;
            await imgTeste.FadeTo(1, 1000);
        }

        private async void btnCombo(object sender, EventArgs e)
        {
            imgTeste.Rotation = 0;

            await Task.WhenAny<bool>
            (
                imgTeste.RotateTo(360, 2000),
                imgTeste.RotateTo(2, 1000)
            );
            await imgTeste.ScaleTo(1, 1000);
        }
    }
}
