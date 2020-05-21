namespace Prova.Modelos
{
    internal class ItemVenda
    {
        private string itemId;
        private double itemQuantidade;
        private double itemPreco;

        public ItemVenda(string itemId, double itemQuantidade, double itemPreco)
        {
            this.itemId = itemId;
            this.itemQuantidade = itemQuantidade;
            this.itemPreco = itemPreco;
        }

        public double valorTotal 
        {
            get { return itemPreco * itemQuantidade; }
        }
    }
}