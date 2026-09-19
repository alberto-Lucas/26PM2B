using ExemploMVVM.ViewModels;

namespace ExemploMVVM.Views;

public partial class pgPessoaVisualizar : ContentPage
{
	public pgPessoaVisualizar()
	{
		InitializeComponent();
		BindingContext = new PessoaViewModel();
	}
}