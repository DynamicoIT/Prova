using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prova.Analisadores;
using Prova.Modelos;

namespace Testes
{
    [TestClass]
    public class Analisador003
    {
        [TestMethod]
        public void TesteNomeSimples()
        {
            Linha linha = new Linha("003ç10ç[1-10-100,2-30-2.50,3-40-3.10]çPedro"); 
            Prova.Servicos.ServicoLinha sl = new Prova.Servicos.ServicoLinha();
            QuatroPartes retornoAnalisado = sl.criarAnalisador(linha).Analisar();

            Assert.AreEqual("003", retornoAnalisado.primeira);
            Assert.AreEqual("10", retornoAnalisado.segunda);
            Assert.AreEqual("[1-10-100,2-30-2.50,3-40-3.10]", retornoAnalisado.terceira);
            Assert.AreEqual("Pedro", retornoAnalisado.quarta);
        }

        [TestMethod]
        public void TesteNomeComplexo()
        {
            Linha linha = new Linha("003ç08ç[1-34-10,2-33-1.50,3-40-0.10]çPaulo Moçaço"); // Moçaço : [Botânica] Árvore da África, de folhas simples e flores hermafroditas.
            Prova.Servicos.ServicoLinha sl = new Prova.Servicos.ServicoLinha();
            QuatroPartes retornoAnalisado = sl.criarAnalisador(linha).Analisar();

            Assert.AreEqual("003", retornoAnalisado.primeira);
            Assert.AreEqual("08", retornoAnalisado.segunda);
            Assert.AreEqual("[1-34-10,2-33-1.50,3-40-0.10]", retornoAnalisado.terceira);
            Assert.AreEqual("Paulo Moçaço", retornoAnalisado.quarta);
        }
    }
}
