using System;

namespace Prova.Validadores
{
    class ValidadorMaiusculoECaractereAnteriores : Validador
    {
        public override bool validar(char[] caracteres, int i)
        {
            if (Char.IsUpper(caracteres[i - 1]) && (caracteres[i - 2]).Equals('ç') && !Char.IsDigit(caracteres[i - 3]))
            {
                pos = i - 2;
                return true;
            }
            
            return false;
        }
    }
}


