using Prova.Modelos;
using Prova.Validadores;
using Prova.Analisadores;


internal class Analisador003 : Analisador
    {
        public Analisador003(string linha) :  base(linha)
        {
           
        }

        public override QuatroPartes Analisar()
        {
            return Analisar(new ValidadorColcheteAnterior());
        }
}

