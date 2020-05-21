using Prova.Validadores;
using Prova.Modelos;

namespace Prova.Analisadores
{
    class Analisador001 : Analisador
    {
        public Analisador001(string linha) : base(linha)
        {

        }

        public override QuatroPartes Analisar()
        {
            return Analisar(new ValidadorMaiusculoECaractereAnteriores());
        }
    }
}