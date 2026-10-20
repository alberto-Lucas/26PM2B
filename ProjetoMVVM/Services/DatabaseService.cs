using SQLite;
using PCLExt.FileStorage.Folders;

namespace ProjetoMVVM.Services
{
    //Classe para gerenciar a conexão
    //com o Banco de Dados

    //Importar as bibiotecas SQLite e PCLExt
    //using SQLite;
    //using PCLExt.FileStorage.Folders;

    //Deixar a classe publica
    public class DatabaseService
    {
        //Método que retorna a conexão com o BD
        public SQLiteConnection GetConnection()
        {
            //Acessar a pasta raiz da aplicação
            var pasta = new LocalRootFolder();

            //Gerenciar o arquivo fisico do BD
            //caso o arquivo não exista sera criado
            //se ja existir apenas abrimos ele
            var arquivo =
                pasta.CreateFile("projetomvvm",
                    PCLExt.FileStorage.
                    CreationCollisionOption.OpenIfExists);

            //Abre e retorna a conexão com o BD
            return new SQLiteConnection(arquivo.Path);
        }
    }
}
