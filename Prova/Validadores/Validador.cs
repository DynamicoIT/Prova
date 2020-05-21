namespace Prova.Validadores
{
    abstract class Validador : IValidador
    {
        public int pos = -1;

        public abstract bool validar(char[] zebra, int i);

        public int posicao()
        {
            return pos;
        }
    }
}


