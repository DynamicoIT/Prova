namespace Prova.Modelos
{
    internal class Cliente
    {
        private string cnpj;
        private string nome;
        private string areaNegocio;

        public Cliente(QuatroPartes dados)
        {
            this.cnpj = dados.segunda;
            this.nome = dados.terceira;
            this.areaNegocio = dados.quarta;
        }
    }
}