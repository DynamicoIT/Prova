namespace Prova.Modelos
{
    public class QuatroPartes
    {
        public QuatroPartes(string primeira, string segunda, string terceira, string quarta)
        {
            this.primeira = primeira;
            this.segunda = segunda;
            this.terceira = terceira;
            this.quarta = quarta;
        }

        public string primeira { get; private set; }
        public string segunda { get; private set; }
        public string terceira { get; private set; }
        public string quarta { get; private set; }
    }
}