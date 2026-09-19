using ExemploMVVM.ViewModels;

namespace ExemploMVVM.Views;

public partial class pgPessoa : ContentPage
{
	//Importar a camada de ViewModel
	//using NomeProjeto.ViewModels;
	public pgPessoa()
	{
		InitializeComponent();
		//Vincular o Binding da tela ao ViewModel desejado
		BindingContext = new PessoaViewModel();
	}
}