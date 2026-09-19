namespace ExemploMVVM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Chamada da tela desejada
            MainPage = new NavigationPage(new Views.pgPessoa());
        }
    }
}