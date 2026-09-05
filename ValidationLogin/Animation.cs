namespace ValidationLogin
{
    //Usaremos uma classe estatica
    //pois ela nao precisa ser instanciada
    //podemos chamar os métodos diretamente
    //toda classe estatica obrigatoriamente
    //os seus métodos e funções
    //tambem seram estaticos
    //pode deixar uma classe estatica
    //basta usar a palavra reservada static
    public static class Animation
    {
        //Criar um método generico
        //que ira receber um componente como parametro
        //iremos aplciar uma animção de tremor
        //no componenete visual para chamar a atenção
        //do usuario
        //Obs: podemos aplicar essa animação
        //em qualquer componente visual da tela
        //Entry(textbox), labe, image, datapicker, etc...
        public static async void Tremer(
            VisualElement componente)
        {
            //Vaidar se o compoenente não é nullo
            if(componente == null)
                return;//Abortar a execução

            //Definir um tempo para animação
            //UINT é um inteiro curto
            //ou seja um inteiro normal
            //aceita até 7 casa
            //o utin aceita até 4 casa
            uint tempo = 50;

            //Listar os deslocamentos
            //Colocar na lista na ordem desejada
            //da animção
            var deslocamento =
                new[] { -15, 15, -10, 10, -5, 5 };

            //Loop para ler cada deslocamento
            //e aplicar a animação
            foreach(var movimento in deslocamento)
            {
                //Primeiro é movimento em pixel horarizontal
                //Segundo é movimento em pixel vertical
                //Terceiro é o tempo da animação
                await componente.TranslateTo(movimento, 0, tempo);
            }
            //Pro ultimo resetamos o movimento em x
            componente.TranslationX = 0;
        }
    }
}
