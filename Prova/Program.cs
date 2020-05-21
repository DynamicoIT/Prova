using System;
using System.IO;
using Prova.Servicos;

namespace Prova
{
    class Program
    {
        static ServicoArquivo arquivo;
        static System.IO.FileSystemWatcher observadorEventoCriacao;

        static void Main(string[] args)
        {
            IniciarMonitoramento();
        }

        static void IniciarMonitoramento()
        {      
            string caminhoLeitura = string.Format("{0}\\{1}", AppDomain.CurrentDomain.BaseDirectory, "data\\in");
            
            arquivo = new ServicoArquivo();

            observadorEventoCriacao = new FileSystemWatcher();
            observadorEventoCriacao.Path = caminhoLeitura;
            observadorEventoCriacao.Created += Evento_Criacao;
            observadorEventoCriacao.EnableRaisingEvents = true;
        }

        private static void Evento_Criacao(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Created)
            {
                try
                {
                    if (arquivo.LerEntrada(e.FullPath))
                    {
                        string caminhoSaida = string.Format("{0}\\{1}", AppDomain.CurrentDomain.BaseDirectory, "data\\out");
                        arquivo.EscreverSaida(string.Format("{0}\\{1}", caminhoSaida, e.Name));
                    }   
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERRO: " + ex.Message);
                }
            }

        }
    }
}

