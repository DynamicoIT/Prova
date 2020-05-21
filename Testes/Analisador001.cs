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
            Linha linha = new Linha("001ç3245678865434çPauloç40000.99");
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
            Linha linha = new Linha("001ç1234567891234çPedro Ortaçaç50000");
            Prova.Servicos.ServicoLinha sl = new Prova.Servicos.ServicoLinha();
            QuatroPartes retornoAnalisado = sl.criarAnalisador(linha).Analisar();

            Assert.AreEqual("001", retornoAnalisado.primeira);
            Assert.AreEqual("1234567891234", retornoAnalisado.segunda);
            Assert.AreEqual("Pedro Ortaça", retornoAnalisado.terceira);
            Assert.AreEqual("50000", retornoAnalisado.quarta);
        }
    }
}
