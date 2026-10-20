using System.Windows.Input;

namespace ProjetoMVVM.ViewsModels
{
    //Classe com rotinas genericas e compartilhadas entre telas
    //Iremos herdar da classe de notificação
    public class BaseViewModel : BaseNotifyViewModel
    {
        //Iremos implementar a rotina de Voltar para tela anterior
        //Importar a biblioteca
        //using System.Windows.Input;
        public ICommand VoltarCommand { get; set; }
        public async void Voltar()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        //Implementar a rotina de abertura de tela
        //A rotina de AbrirTela não possui command
        //pois não pode ser executada diretamente do front
        //ela será chamada diretamente pelo back-end
        //devido o parametro(tela q será aberta)
        public async void AbrirView(ContentPage view)
        {
            await Application.Current.MainPage.Navigation.PushAsync(view);
        }

        //Rotina para nofiticar o usuario
        //assim não precisamos repetir o DisplayAlert em todo lugar
        public async void MsgInfo(string conteudo)
        {
            await Application.Current.MainPage.
                DisplayAlert("Informação", conteudo, "OK");
        }

        //Rotina de confirmação SIM ou NÃO
        //Quando utilizar async e esperar um tipo de dado
        //como retorno, é preciso utilizar o Task
        //Task<tipo_dado> ex: Task<bool>....
        public async Task<bool> MsgSimNao(string conteudo)
        {
            //Lembrando q o primeiro botão sempre retorna true
            //ou seja a ordem sempre deve começar pelo SIM
            return
                await Application.Current.MainPage.
                    DisplayAlert("Confirmação", conteudo, "Sim", "Não");
        }

        //Vincular o método ao command
        public BaseViewModel()
        {
            VoltarCommand = new Command(Voltar);
        }
    }
}
