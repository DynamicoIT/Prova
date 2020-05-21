using Prova.Analisadores;
using Prova.Modelos;

namespace Prova.Validadores
{
    internal class Analisador002 : Analisador
    {
        public Analisador002(string linha) : base(linha)
        {

        }


        public override QuatroPartes Analisar()
        {
            return Analisar(new ValidadorMaiusculoECaractereAnteriores());
        }
    }
}