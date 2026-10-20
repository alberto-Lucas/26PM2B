namespace ProjetoMVVM.Models
{
    public sealed class CarroSingleton
    {
        static CarroSingleton _instancia;

        public static CarroSingleton Instancia
        {
            get
            {
                return _instancia ??
                    (_instancia = new CarroSingleton());
            }
        }

        public Carro Carro { get; set; }
    }
}
