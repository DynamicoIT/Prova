using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Prova.Modelos
{
    internal class Venda
    {
        public string id;
        public string nome;
        private List<ItemVenda> Itens = new List<ItemVenda>();
        public double valorTotal
        { 
            get { return this.Itens.Select(i=> i.valorTotal).Sum(); } 
        }

        public Venda(QuatroPartes dados)
        {
            this.id = dados.segunda;
            this.nome = dados.quarta;

            string itensVenda = removerColchetes(dados.terceira);
            string[] dadosItensVenda = itensVenda.Split(",");

            foreach (string iv in dadosItensVenda)
            {
                string[] div = iv.Split('-');
                this.Itens.Add(new ItemVenda(itemId: div[0], itemQuantidade: double.Parse(div[1], CultureInfo.InvariantCulture), itemPreco: double.Parse(div[2], CultureInfo.InvariantCulture)));
            }
        }

        string inverter(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        string removerColchetes(string s)
        {
            return inverter(inverter(s).Remove(0, 1)).Remove(0, 1);
        }
    }
}