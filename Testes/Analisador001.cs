using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prova.Analisadores;
using Prova.Modelos;

namespace Testes
{
    [TestClass]
    public class Analisador001
    {
        [TestMethod]
        public void TesteNomeSimples()
        {
            Linha linha = new Linha("001�3245678865434�Paulo�40000.99");
            Prova.Servicos.ServicoLinha sl = new Prova.Servicos.ServicoLinha();
            QuatroPartes retornoAnalisado = sl.criarAnalisador(linha).Analisar();

            Assert.AreEqual("001", retornoAnalisado.primeira);
            Assert.AreEqual("3245678865434", retornoAnalisado.segunda);
            Assert.AreEqual("Paulo", retornoAnalisado.terceira);
            Assert.AreEqual("40000.99", retornoAnalisado.quarta);
        }

        [TestMethod]
        public void TesteNomeComplexo()
        {
            Linha linha = new Linha("001�1234567891234�Pedro Orta�a�50000");
            Prova.Servicos.ServicoLinha sl = new Prova.Servicos.ServicoLinha();
            QuatroPartes retornoAnalisado = sl.criarAnalisador(linha).Analisar();

            Assert.AreEqual("001", retornoAnalisado.primeira);
            Assert.AreEqual("1234567891234", retornoAnalisado.segunda);
            Assert.AreEqual("Pedro Orta�a", retornoAnalisado.terceira);
            Assert.AreEqual("50000", retornoAnalisado.quarta);
        }
    }
}
