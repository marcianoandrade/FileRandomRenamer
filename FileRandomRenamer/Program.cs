using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRandomRenamer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 1) {
                string[] files = Directory.GetFiles(args[0], args[1]);
                Random ran = new Random();
                int randomAnterior = 0;
                for (int i = 0; i < files.Length; i++)
                {
                    string arquivo = files[i];
                    string[] arquivoDetails = arquivo.Split('\\');
                    arquivo = arquivoDetails[arquivoDetails.Length - 1];
                    string caminhoArquivo = "";
                    for (int j = 0; j < arquivoDetails.Length - 1; j++)
                    {
                        caminhoArquivo += arquivoDetails[j] + "\\";
                    }
                    int randomAtual = ran.Next(2000);
                    while (randomAnterior == randomAtual)
                    {
                        randomAtual = ran.Next(2000);
                    }
                    randomAnterior = randomAtual;
                    string extensao = arquivo.Split('.').Length > 1 ? arquivo.Split('.')[arquivo.Split('.').Length - 1] : "";
                    System.IO.File.Move(files[i], caminhoArquivo + randomAtual.ToString() + arquivo + "." + extensao);
                    Console.WriteLine("Renomeado! Arquivo número:" + i.ToString());
                }
                Console.WriteLine("Pressione qualquer tecla para finalizar!");
                Console.ReadKey();
            }
        }
    }
}
