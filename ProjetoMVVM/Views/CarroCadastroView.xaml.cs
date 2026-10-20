using ProjetoMVVM.ViewsModels;

namespace ProjetoMVVM.Views;

public partial class CarroCadastroView : ContentPage
{
	public CarroCadastroView()
	{
		InitializeComponent();
        //Importar a camada de ViewModel
        //using Nome_Projeto.ViewModels;

        //Vincular o front com o back-end
        BindingContext = new CarroViewModel();
    }
}