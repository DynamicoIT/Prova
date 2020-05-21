namespace Prova.Modelos
{
    public class Linha
    {
        public string conteudoLinha { get; set; }

        public Linha(string linha)
        {
            this.conteudoLinha = linha;
        }

        public string tipo
        {
            get { return conteudoLinha.Substring(0, 3); }
        }

       

        
    }
}