using ProjetoMVVM.Services;
using ProjetoMVVM.Models;
using System.Windows.Input;
using ProjetoMVVM.Views;

namespace ProjetoMVVM.ViewsModels
{
    //Importar as camadas Views, Models e Services;
    //using Nome_Projeto.Models;
    //using Nome_Projeto.Views;
    //using Nome_Projeto.Services;

    //Classe responsavel por gerenciar 
    //o cadastro do objeto Carro

    //Realizar a herança com a classe BaseViewModel
    public class CarroViewModel : BaseViewModel
    {
        //Instanciar a classe de serviço
        CarroService carroService = new CarroService();

        //Agora devemos criar as propriedades para acesso da tela
        //com a classe Carro gerealmente criamos um espelho
        //da classe de objeto desejado
        //esse formato de propriedade se chama encapsulamento

        private int _id;

        public int Id
        {
            get { return _id; } //Retornar dado gravado
            set
            {
                _id = value; //gravar os dados
                OnPropertyChanged(); //disparar a notificação
            }
        }

        //Cria a variavel privada para armazenar os dados
        private string _marca;
        //Criar a propriedade de manipulação
        public string Marca
        {
            get { return _marca; } //Retornar dado gravado
            set
            {
                _marca = value; //gravar os dados
                OnPropertyChanged(); //disparar a notificação
            }
        }

        private string _modelo;

        public string Modelo
        {
            get { return _modelo; } //Retornar dado gravado
            set
            {
                _modelo = value; //gravar os dados
                OnPropertyChanged(); //disparar a notificação
            }
        }

        private string _cor;

        public string Cor
        {
            get { return _cor; } //Retornar dado gravado
            set
            {
                _cor = value; //gravar os dados
                OnPropertyChanged(); //disparar a notificação
            }
        }

        //Propriedade com os registros q seram
        //exibidos na listagem da tela
        //como teremos varios carros usamos uma List
        private List<Carro> _carros;

        public List<Carro> Carros
        {
            get { return _carros; } //Retornar dado gravado
            set
            {
                _carros = value; //gravar os dados
                OnPropertyChanged(); //disparar a notificação
            }
        }

        //Propriedade com o item selecionado na listagem
        //Ou seja quando o usuario clicar em um item da lista
        //a propria tela grava o carro clicado aqui
        //atraves do SelectedItem
        private Carro _carroSelecionado;

        public Carro CarroSelecionado
        {
            get { return _carroSelecionado; } //Retornar dado gravado
            set
            {
                _carroSelecionado = value; //gravar os dados
                OnPropertyChanged(); //disparar a notificação
            }
        }

        //Implementar a rotina de cadastro]
        //O Command precisa ser publico para ser acessado pelo front
        public ICommand CadastrarCommand { get; set; }
        //O método não precisa ser publico
        //pois apenas o command será acessado
        void Cadastrar()
        {
            //Aplicar uma validação simples se o campos estão preenchidos
            if (string.IsNullOrEmpty(Marca) ||
                string.IsNullOrEmpty(Modelo) ||
                string.IsNullOrEmpty(Cor))
            {
                //Se algum estiver vazio
                //notificamos o usuario
                MsgInfo("Preencha os campos corretamente.");
                return; //abortamos a execução
            }

            //Instanciar a classe do Objeto
            Carro carro = new Carro();
            //popular o objeto com as informações em tela
            carro.Marca = Marca;
            carro.Modelo = Modelo;
            carro.Cor = Cor;

            //Agora podemos salvar o objeto no banco de dados
            //E validar se foi inserido com sucesso
            if (carroService.Insert(carro))
            {
                //Se retorno positivo
                //nofiticamos o usuario e voltamos para a listagem
                MsgInfo("Cadastro salvo com sucesso.");
                Voltar();
            }
            else
                MsgInfo("Falha ao salvar o cadastro.");
        }

        //Rotina para abrir a tela de cadastro
        public ICommand AbrirCadastroCommand { get; set; }
        void AbrirCadastro()
        {
            AbrirView(new CarroCadastroView());
        }

        //Rotina para carregar os dados do BD na lista
        public ICommand AtualizarCommand { get; set; }
        void Atualizar()
        {
            //Carregar todos os registros salvos
            //como estamos alterando a propriedade
            //a tela é notificada e a lista atualiza sozinha
            Carros = carroService.GetAll();
            //Limpar o item selecionado
            //pois a lista foi recarregada
            CarroSelecionado = null;
        }

        //Rotina para visualizar o item selecionado na lista
        public ICommand VisualizarCommand { get; set; }
        void Visualizar()
        {
            //Validar se o usuario selecionou algum item
            //se não tiver nada selecionado abortamos
            if (CarroSelecionado == null)
            {
                MsgInfo("Selecione um carro na lista.");
                return; //abortamos a execução
            }

            //Salvar o registro selecionado na singleton
            //assim a tela de vizualização ira consultar
            //o carro diretamente da singleton
            carroService.AdicionarSingleton(CarroSelecionado);

            //Exibir a tela de vizualização
            AbrirView(new CarroVisualizarView());
        }

        //Rotina para excluir o item selecionado na lista
        //Como o MsgSimNao é assincrono precisamo
        //utilizar o await e adicionar o async no método
        //ex: async void Deletar()
        public ICommand DeletarCommand { get; set; }
        async void Deletar()
        {
            //Mesma validação do visualizar
            if (CarroSelecionado == null)
            {
                MsgInfo("Selecione um carro na lista.");
                return; //abortamos a execução
            }

            //Confirmação de exclusão
            bool validacao =
                await MsgSimNao("Deseja realmente excluir este registro?");

            if (validacao) //se pode excluir o item
            {
                //Removemos o item do banco de dados
                //e recarregamos a lista
                carroService.Delete(CarroSelecionado);
                Atualizar();
            }
        }

        //Implementar a Rotina de Consulta
        //O Command precisa ser publico para ser acessado pelo front
        public ICommand ConsultarCommand { get; set; }
        //O método não precisa ser publico
        //pois apenas o command será acessado
        void Consultar()
        {
            //Popular o objeto carro com o registro
            //salvo na singleton
            Carro carro = carroService.ConsultarSingleton();

            //Mapear o objeto com as propriedades da tela
            Id = carro.Id;
            Marca = carro.Marca;
            Modelo = carro.Modelo;
            Cor = carro.Cor;
        }

        //Vincular os commands
        public CarroViewModel()
        {
            CadastrarCommand = new Command(Cadastrar);
            ConsultarCommand = new Command(Consultar);
            AbrirCadastroCommand = new Command(AbrirCadastro);
            AtualizarCommand = new Command(Atualizar);
            VisualizarCommand = new Command(Visualizar);
            DeletarCommand = new Command(Deletar);
        }
    }
}
