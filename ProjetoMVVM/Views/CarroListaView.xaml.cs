using ProjetoMVVM.ViewsModels;

namespace ProjetoMVVM.Views;

public partial class CarroListaView : ContentPage
{
    //Variavel global da ViewModel
    //pois iremos usar ela tambem no OnAppearing
    CarroViewModel _carroViewModel;

	public CarroListaView()
	{
		InitializeComponent();
        //Importar a camada de ViewModel
        //using Nome_Projeto.ViewModels;

        //Intanciar a ViewModel
        _carroViewModel = new CarroViewModel();
        //Vincular o front com o back-end
        BindingContext = _carroViewModel;
    }

    //O OnAppearing é executado sempre q a tela aparece
    //ou seja, ao abrir o app e ao voltar do cadastro
    //ou da vizualização, assim a lista sempre estara atualizada
    protected override void OnAppearing()
    {
        base.OnAppearing();
        //Chamar o AtualizarCommand diretamente
        //igual fizemos com o Consultar na tela de vizualização
        _carroViewModel.AtualizarCommand.Execute(null);
    }
}
