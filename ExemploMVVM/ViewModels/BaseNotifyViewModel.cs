using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExemploMVVM.ViewModels
{
    //Classe padrão (documentação)
    //do observador
    //escanear os arquivos e notificar
    //quando tiver alteração

    //é precisso importar a biblioteca ComponentModel
    //using System.ComponentModel;
    //Reposanvel pelo observador

    //Transforma a classe e em classe abstrata
    //que ela não pode ser instanciada diretamente
    //ou seja não é possivel criar objetos

    //Nossa clase irá herdar da Interface INotifyPropertyChanged
    //Reponsavel pelo funcionamento do observador
    public abstract class BaseNotifyViewModel : INotifyPropertyChanged
    {
        //Evento public implementado pela interface
        public event PropertyChangedEventHandler? PropertyChanged;

        //Método da observabilidade 
        //ele que vai identificar qual campo teve alteração

        //Precisamos importar a bibliotexa CallerMemberName
        //CallerMenberName: recuperar o nome do atributo
        //que teve alteraçao automaticamente
        //using System.Runtime.CompilerServices;
        public void OnPropertyChanged(
            [CallerMemberName] string propertyName = "")
        {
            //Se a propriedade for alterada dispara 
            //o evento de notificação para atualizar
            //as demais classe e telas
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }

    }
}
