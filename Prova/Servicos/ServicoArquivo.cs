using Prova;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Prova.Modelos;
using System.Text;

namespace Prova.Servicos
{
    public class ServicoArquivo
    {
        List<Vendedor> vendedores = new List<Vendedor>();
        List<Cliente> clientes = new List<Cliente>();
        List<Venda> vendas = new List<Venda>();
        StringBuilder sbErros;

        public ServicoArquivo()
        {
        }

        public bool LerEntrada(string caminho)
        {
            sbErros = new StringBuilder();
            string[] linhasArquivo; 

            try
            {
                linhasArquivo = File.ReadAllLines(caminho);
            }
            catch (Exception e)
            {
                string erroArquivo = string.Format(string.Format("[{0}]  Não foi possível ler o arquivo {1} — {2}", DateTime.Now.ToString(), caminho, e.Message));
                sbErros.AppendLine(erroArquivo);
                return false;
            }

            ServicoLinha servicoLinha = new ServicoLinha();

            for (int i = 0; i < linhasArquivo.Length; i++)
            {

                Linha linha = new Linha(linhasArquivo[i]);

                try
                {
                    QuatroPartes retornoAnalise = servicoLinha.criarAnalisador(linha).Analisar();

                    switch (linha.tipo)
                    {
                        case "001":
                            this.vendedores.Add(new Vendedor(retornoAnalise));
                            break;
                        case "002":
                            this.clientes.Add(new Cliente(retornoAnalise));
                            break;
                        case "003":
                            this.vendas.Add(new Venda(retornoAnalise));
                            break;
                    }
                }
                catch (Exception e)
                {
                    string erroLinha = string.Format(string.Format("[{0}]  Não foi possível ler a linha {1} do arquivo {2} — {3}", DateTime.Now.ToString(), (i + 1).ToString(), caminho, e.Message));
                    sbErros.AppendLine(erroLinha);
                }
            }

            if(sbErros.Length > 0)
            {
                Console.WriteLine("Erros durante a execução:");
                Console.Write(sbErros.ToString());
            }

            return true;

        }

        public void EscreverSaida(string caminho)
        {
            StringBuilder sbArquivoSaida = new StringBuilder();
            sbArquivoSaida.AppendLine(string.Format("Quantidade de Clientes: {0}", this.clientes.Count));
            sbArquivoSaida.AppendLine(string.Format("Quantidade de Vendedores: {0}", this.vendedores.Count));

            string idVendaMaisCara = this.vendas.OrderByDescending(v => v.valorTotal).Select(x => x.id).FirstOrDefault();
            string piorVendedor = this.vendas.GroupBy(v => v.nome).Select(s => new { nome = s.First().nome, total = s.Sum(v => v.valorTotal) }).OrderBy(o => o.total).FirstOrDefault().nome;

            sbArquivoSaida.AppendLine(string.Format("ID da Venda Mais Cara: {0}", idVendaMaisCara));
            sbArquivoSaida.AppendLine(string.Format("Nome do Pior Vendedor: {0}", piorVendedor));

            using (StreamWriter writer = new StreamWriter(caminho, false))
            {
                writer.WriteLine(sbArquivoSaida.ToString());
                writer.Flush();
                writer.Close();
            }
        }

    }
}