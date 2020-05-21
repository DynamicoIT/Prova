using Prova;
using Prova.Analisadores;
using Prova.Validadores;
using Prova.Modelos;

namespace Prova.Servicos
{
    public class ServicoLinha
    {

        public ServicoLinha()
        {
        }  

        public IAnalisador criarAnalisador(Linha linha)
        {
            IAnalisador analisador;

            switch (linha.tipo)
            {
                case "001":
                    analisador = new Analisador001(linha.conteudoLinha);
                    break;
                case "002":
                    analisador = new Analisador002(linha.conteudoLinha);
                    break;
                case "003":
                    analisador = new Analisador003(linha.conteudoLinha);
                    break;
                default:
                    throw new System.Exception("Tipo de Linha Inválido");
            }

            return analisador;
        }
    }
}