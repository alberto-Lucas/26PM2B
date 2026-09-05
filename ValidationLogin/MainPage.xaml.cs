namespace ValidationLogin
{
    public partial class MainPage : ContentPage
    {
        //Criar os 2 componentes personalizados
        ValidationComponent email;
        ValidationComponent senha;

        public MainPage()
        {
            InitializeComponent();

            //Instanciar a vincular os componentes tela
            //ao componente personalizado
            email = new ValidationComponent(
                txtEmail, lblEmailValidation);

            senha = new ValidationComponent(
                txtSenha, lblSenhaValidation);
        }

        //Funação para validar o email
        bool ValidarEmail()
        {
            //Iniciar definindo o resultado como falso
            bool resultado = false;

            //Realizar as validações e definir as mensagens
            if (email.IsEmpty())
                email.SetInformation("Informe o email.", true);
            else if (email.GetText() != "admin@")
                email.SetInformation("Email incorreto.", true);
            else if (!email.IsContains("@"))
                email.SetInformation("Informe um email válido.", true);
            else
            {
                //se chegou até aqui está tudo certo
                resultado = true;
                //oculata a label de informação
                email.HideInformation();
            }

            return resultado;
        }

        //Função para validar senha
        bool ValidarSenha()
        {
            bool resultado = false;

            if (senha.IsEmpty())
                senha.SetInformation("Informa a senha.", true);
            else if (senha.GetText() != "admin")
                senha.SetInformation("Senha incorreta.", true);
            else if (!senha.IsSizeFull(5))
                senha.SetInformation("Informe a senha com no " +
                                     "mínimo 5 caracteres.", true);
            else
            {
                resultado = true;
                senha.HideInformation();
            }

            return resultado;
        }

        private void btnEntrar_Clicked(object sender, EventArgs e)
        {
            //Chamar as validações
            //e capturar o retorno delas
            bool bEmail = ValidarEmail();
            bool bSenha = ValidarSenha();

            //Só validar se houve alguma validaçao negativa
            //se sim, aborta a execução
            if (!bEmail || !bSenha)
                return;

            //Se chegou até aqui esta tudo certo
            DisplayAlert("Informação", "Login com sucesso.", "OK");
        }
    }
}
