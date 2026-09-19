using System.Windows.Input;

namespace ExemploMVVM.ViewModels
{
    //Primeira coisa a ser feita é realizar a herança
    //com a classe base de notificação
    public class PessoaViewModel : BaseNotifyViewModel
    {
        //Podemos definir os atributos e propriedades
        //que comunicaram com a tela

        //Atributo que ira apenas receber os dados da tela
        //ou seja ele não sera monitorado
        //Atributo simples
        public string Nome { get; set; }

        //Criar a propriedade que sera monitorada
        //ou seja sempre que ele for alterada
        //o observador ira disparar a notificação para atualizar
        //a informação em todos os lugares compativeis com ela
        //ou seja que possui a mesma nomenclatura
        private string _retorno;
        public string Retorno
        {
            //Get será retornado a informação salva na variavel privada
            get { return _retorno; }
            //No Set iremos salvar a informação setada na variavel privada
            //e ativir o observador
            set
            {
                _retorno = value;
                //Configurar que está propriedade será observada
                OnPropertyChanged();
            }
        }

        //Programas as funções e os comandos de ação
        //ou seja o eventos dos botões
        //para isso iremos separar em 2 partes
        //o método que irá executar a ação
        //e o comando que será disponibilizado para vinculo com a tela
        private void Executar()
        {
            //Método simples que irá capturar a informação
            //digitada no campo nome
            //e criar uma concatenação para popular em retorno
            Retorno = "Olá, " + Nome;
        }

        //Agora precisamos criar uma propriedade de comando
        //para que a tela consiga disparar o método
        //ou seja é equivalente ao evento do botão
        public ICommand CommandExecutar { get; set; }

        //Criar método para chamar a tela de visualização
        private async void Visualizar()
        {
            await Application.Current.MainPage.
                Navigation.PushAsync(new Views.pgPessoaVisualizar());
        }
        public ICommand CommandVisualizar { get; set; }

        //Criar o construtor da tela onde iremos realizar
        //o vinculo da propriedade command com o método
        public PessoaViewModel()
        {
            CommandExecutar = new Command(Executar);
            CommandVisualizar = new Command(Visualizar);
        }
    }
}
