using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prova.Analisadores;
using Prova.Modelos;

namespace Testes
{
    [TestClass]
    public class Analisador002
    {
        [TestMethod]
        public void TesteNomeSimples()
        {
            Linha linha = new Linha("002ç2345675434544345çJose da SilvaçRural");
            Prova.Servicos.ServicoLinha sl = new Prova.Servicos.ServicoLinha();
            QuatroPartes retornoAnalisado = sl.criarAnalisador(linha).Analisar();

            Assert.AreEqual("002", retornoAnalisado.primeira);
            Assert.AreEqual("2345675434544345", retornoAnalisado.segunda);
            Assert.AreEqual("Jose da Silva", retornoAnalisado.terceira);
            Assert.AreEqual("Rural", retornoAnalisado.quarta);
        }

        [TestMethod]
        public void TesteNomeComplexo()
        {
            Linha linha = new Linha("002ç2345675433444345çMaria da GraçaçAdministração");
            Prova.Servicos.ServicoLinha sl = new Prova.Servicos.ServicoLinha();
            QuatroPartes retornoAnalisado = sl.criarAnalisador(linha).Analisar();

            Assert.AreEqual("002", retornoAnalisado.primeira);
            Assert.AreEqual("2345675433444345", retornoAnalisado.segunda);
            Assert.AreEqual("Maria da Graça", retornoAnalisado.terceira);
            Assert.AreEqual("Administração", retornoAnalisado.quarta);
        }
    }
}
