using ProjetoMVVM.ViewsModels;

namespace ProjetoMVVM.Views;

public partial class CarroVisualizarView : ContentPage
{
	public CarroVisualizarView()
	{
        //Importar a camada ViewModel
        //using Nome_Projeto.ViewModels;

        InitializeComponent();
        //Como queremos carregar os dados automaticamente
        //ao abrir a tela, precisamo acessar a rotina de
        //consulta diretamente
        //Para isso precisamos instanciar a nossa ViewModel
        var carroViewModel = new CarroViewModel();
        //Irei fazer o vincular do Binding
        BindingContext = carroViewModel;
        //Agora iremos chamar o ConsultarCommand diretamente
        carroViewModel.ConsultarCommand.Execute(null);
        //Um outra forma será, acessar o método Consultar 
        //diretamente o deixando publico
        //carroViewModel.Consultar();
    }
}