namespace Prova.Validadores
{
    class ValidadorColcheteAnterior : Validador
    {
        public override bool validar(char[] caracteres, int i)
        {
            if ((caracteres[i - 1]).Equals(']') && (caracteres[i]).Equals('ç'))
            {
                pos = i;
                return true;
            }

            return false;
        }
        
    }
}


