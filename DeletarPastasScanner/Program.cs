using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DeletarPastasScannerss
{
    class Program
    {
        static void Main(string[] args)
        {
            var logErros = new List<string>();

            Console.WriteLine("Digite o nome das pastas a serem deletadas, caso seja mais de uma pasta separe por virgula.");
            var nomesArquivos = Convert.ToString(Console.ReadLine());
            var pastas = nomesArquivos.Split(',');

            Console.WriteLine("Digite o diretório das pastas que deseja deletar.");
            var caminho = Convert.ToString(Console.ReadLine());

            var files = Directory.GetDirectories(caminho);

            foreach (var nomePasta in pastas)
            {
                var caminhoPasta = files.Where(p => p.ToUpper().Contains(nomePasta.ToUpper())).ToList();

                if (caminhoPasta.Count > 0)
                {
                    caminhoPasta.ForEach((string caminhoDelete) =>
                    {
                        try
                        {
                            Directory.Delete(caminhoDelete, true);
                            Console.WriteLine("Pasta deletada " + caminhoDelete);
                        }
                        catch (Exception)
                        {
                            logErros.Add(caminhoDelete);
                        }
                    });
                }
                else
                {
                    Console.WriteLine($"Pasta com o nome {nomePasta} não foi encontrada.");
                }
            }


            Console.WriteLine("\n\r");
            Console.WriteLine(logErros.Count > 0 ? logErros.Aggregate((A, B) => A + " | " + B) : "Todos arquivos deletados com sucesso!!");


            Console.ReadKey();
        }
    }
}
