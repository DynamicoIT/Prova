using Prova.Modelos;
using Prova.Validadores;
using System;
using System.Linq;

namespace Prova.Analisadores
{
    internal abstract class Analisador : IAnalisador
    {
        public string linha;
        public string primeiraParte;
        public string segundaParte;
        public string terceiraParte;
        public string quartaParte;

        public int primeiroSeparador;
        public int segundoSeparador;
        public int ultimoSeparadorFalso;
        public int ultimoSeparadorReal;

        public string[] partes;
       
        public Analisador(string conteudoLinha)
        {
            linha = conteudoLinha;

            if (!isValid())
            {
                throw new Exception("Formato de linha inválido");
            }

            primeiroSeparador = linha.IndexOf("ç");
            segundoSeparador = linha.IndexOf("ç", primeiroSeparador + 1);
            ultimoSeparadorReal = ultimoSeparadorFalso = linha.LastIndexOf("ç");
            
            partes = linha.Split("ç");
            primeiraParte = partes[0];
            segundaParte = partes[1]; 
        }
        

        public abstract QuatroPartes Analisar();

        bool isValid()
        {
            int quantidadeCaracterSeparados = linha.Count(c => c.Equals('ç'));
            return quantidadeCaracterSeparados >= 3;
        }

        public QuatroPartes Analisar(IValidador val)
        {
            if (partes.Length > 4)
            {
                Char[] caracteres = linha.ToCharArray();

                for (int i = ultimoSeparadorFalso; i > 0; i--)
                {   
                    if (val.validar(caracteres, i))
                    {
                        ultimoSeparadorReal = val.posicao();
                        break;
                    }
                }

                terceiraParte = linha.Substring(segundoSeparador + 1, ultimoSeparadorReal - segundoSeparador - 1);

                quartaParte = linha.Substring(ultimoSeparadorReal + 1, linha.Length - ultimoSeparadorReal - 1);
            }
            else
            {
                terceiraParte = partes[2];
                quartaParte = partes[3];
            }

            return new QuatroPartes ( primeira: primeiraParte, segunda: segundaParte, terceira: terceiraParte, quarta:quartaParte );
        }
       
                
    }
}


