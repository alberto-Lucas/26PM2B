namespace ValidationLogin
{
    //Criar um componente personalisado para validação
    //Vamos unit o Entry(textBox) com a Label
    //Usaremos um class tradicional
    //pois iremos armazenar os componete que serão vinculados
    public class ValidationComponent
    {
        //Definir o as propriedades referente
        //ao noss "PAR" de compoenentes
        //Ou seja iremos juntar o Entry e a Label
        //em uma coisa só
        private Entry EntryText { get; set; }
        private Label LabelInformation { get; set; }

        //Criar o construtor da classe para realizar o vinculo
        public ValidationComponent(
            Entry txtCampo, Label lblInformacao)
        {
            //Ou seja, sempre que está classe for instanciada
            //obrigatoriamente sera nescessario informa o 
            //campo e label para vinculo
            EntryText = txtCampo;
            LabelInformation = lblInformacao;
        }

        //Função para retornar o conteudo do campo
        public string GetText()
        {
            return EntryText.Text;
        }

        //Criar um método para definir a mensagem a ser exibida
        //IsTremer = false ou seja pode padrão sera falso
        //se eu não informar o valor na chamada do método
        //automatica seria definido o valor false
        public void SetInformation(
            string MsgInfo, bool IsTremer = false)
        {
            //Aplicar a animação de tremor
            //no campo de texto para chamar atenção do usuário
            //caso o IsTremer seja TRUE
            if (IsTremer)
                Animation.Tremer(EntryText);

            //Atualizar o texto da label 
            LabelInformation.Text = MsgInfo;
            //Exibir a label
            LabelInformation.IsVisible = true;
        }

        //Função para oculatar a label de informação
        public void HideInformation()
        {
            LabelInformation.IsVisible = false;
        }

        //Criar validações personalizadas

        //Funação que retorna se está vazio
        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(EntryText.Text);
        }

        //Função para validar a quantidade de caracteres
        public bool IsSizeFull(int tamanho)
        {
            //Ou seja se o campo possui menos q o
            //tamanho definido retorna false
            //Ex: tamanho igual a 5
            //admin.tamnho < 5
            return EntryText.Text.Length >= tamanho;
        }

        //Funação para validar se o campo contém um caracter
        public bool IsContains(string caracter)
        {
            return EntryText.Text.Contains(caracter);
        }
    }
}
