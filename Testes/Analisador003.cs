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
            Linha linha = new Linha("003�10�[1-10-100,2-30-2.50,3-40-3.10]�Pedro"); 
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
            Linha linha = new Linha("003�08�[1-34-10,2-33-1.50,3-40-0.10]�Paulo Mo�a�o"); // Mo�a�o : [Bot�nica] �rvore da �frica, de folhas simples e flores hermafroditas.
            Prova.Servicos.ServicoLinha sl = new Prova.Servicos.ServicoLinha();
            QuatroPartes retornoAnalisado = sl.criarAnalisador(linha).Analisar();

            Assert.AreEqual("003", retornoAnalisado.primeira);
            Assert.AreEqual("08", retornoAnalisado.segunda);
            Assert.AreEqual("[1-34-10,2-33-1.50,3-40-0.10]", retornoAnalisado.terceira);
            Assert.AreEqual("Paulo Mo�a�o", retornoAnalisado.quarta);
        }
    }
}
