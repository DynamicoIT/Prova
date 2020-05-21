using System.Globalization;

namespace Prova.Modelos
{
    internal class Vendedor
    {
        private string cpf;
        private string nome;
        private double salario;

        public Vendedor(QuatroPartes dados)
        {
            this.cpf = dados.segunda;
            this.nome = dados.terceira;
            this.salario = double.Parse(dados.quarta, CultureInfo.InvariantCulture);
        }
    }
}