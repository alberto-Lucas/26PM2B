using SQLite;

namespace ProjetoMVVM.Models
{
    //Importar o using SQLite;

    //Lembrando q os atributos da classe
    //seram refletidos para a criação da tabela no BD
    public class Carro
    {
        //Precisamos definir o identificador
        //da tabela ou seja o id chave primaria
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
    }
}
