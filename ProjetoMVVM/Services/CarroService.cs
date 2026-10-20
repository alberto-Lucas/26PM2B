using SQLite;
using ProjetoMVVM.Models;

namespace ProjetoMVVM.Services
{
    //Importar o using SQLite;
    //Importar a camada Model

    //No MVVM a camada de serviço q fica responsavel
    //pelo acesso aos dados, seja ele na singleton
    //ou no banco de dados
    public class CarroService
    {
        CarroSingleton dbSingleton = CarroSingleton.Instancia;

        //Criar as variaveis globais para uso na classe
        //Variavel para a classe de conexão
        //Variavel para a conexão com o BD em si
        //OBS: o uso do underline _ indica que a variavel é privada
        DatabaseService _database;
        SQLiteConnection _connection;

        //Método construtor
        //Executado automaticamente ao instanciar a classe
        public CarroService()
        {
            //Intanciar a classe de conexão
            _database = new DatabaseService();

            //Recuperar a conexão com o BD
            _connection = _database.GetConnection();

            //Mapear a tabela do BD com base na classe Model
            //o método CreateTable possui tanto a função
            //de criar (Create Table) quanto a função de
            //atualizar (Alter Table) ou seja, sempre que mapear
            //ira criar ou alterar o banco de acordo com o objeto
            _connection.CreateTable<Carro>();
        }

        //Rotinas da Singleton
        public void AdicionarSingleton(Carro value)
        {
            dbSingleton.Carro = value;
        }

        public Carro ConsultarSingleton()
        {
            return dbSingleton.Carro;
        }

        //Rotinas do Banco de Dados

        //Agora iremos implementar os métodos
        //de manipulação Insert, Update e Delete
        //Seram do tipo boolean pois iremos retornar
        //se a execução foi com sucesso ou não
        //e sempre recebera o objeto como parametro
        public bool Insert(Carro value)
        {
            //é retornado a quantidade de linhas afetadas
            //0 - Nenhuma linha afetada
            //1 - uma linha afetada
            //como inserimos um registro por vez
            //sempre será 0 ou 1
            return _connection.Insert(value) > 0;
        }

        public bool Update(Carro value)
        {
            return _connection.Update(value) > 0;
        }

        public bool Delete(Carro value)
        {
            return _connection.Delete(value) > 0;
        }

        //Métodos de Consulta (SELECT)

        //Método filtrando por Id possuindo apenas um retorno
        public Carro GetById(int value)
        {
            //SELECT * FROM Carro WHERE Id = value
            //Find exclusivo para chave primaria
            return _connection.Find<Carro>(value);
        }

        //Método para consultar todos os registros
        public List<Carro> GetAll()
        {
            //Semelhante ao SELECT * FROM Carro
            //Lendo de tras pra frente
            //quero a lista com todos os registros
            //da tabela Carro q está na conexão
            return _connection.Table<Carro>().ToList();
        }
    }
}
