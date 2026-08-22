namespace TelaInicialAnimada
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            IconeAnimado();
        }

        //Criar um método para animar o icone
        async void IconeAnimado()
        {
            //Aplicar um delay de 2 segundos
            //Ou seja deixar a imagem parada 
            //por 2 segundos
            await Task.Delay(2000);
            //Resetar a posição de rotação
            imgIcone.Rotation = 0;
            //Girar por 3 segundos
            imgIcone.RotateTo(360,3000);
            //Resetar a posição de rotação
            imgIcone.Rotation = 0;
            //Aplicar mais 2 segundos de delay
            await Task.Delay(2000);

            //Aplicar escalas
            //Easing.Linear = suavizar a animação
            await imgIcone.ScaleTo(1.5, 2000, Easing.Linear);
            await imgIcone.ScaleTo(1,   1000, Easing.Linear);
            await imgIcone.ScaleTo(0.5, 1500, Easing.Linear);
            await imgIcone.ScaleTo(150, 1500, Easing.Linear);

            //Abri a tela inicial
            Application.Current.MainPage = 
                new NavigationPage(new pgPrincipal());
        }
    }
}
