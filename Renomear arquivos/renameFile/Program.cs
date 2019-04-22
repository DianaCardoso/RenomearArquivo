using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace testeRename
{
    class Program
    {

        static string Leitura(string fileName, string id)
        {
            string line;
            string[] separar;

            System.IO.StreamReader file =
                new System.IO.StreamReader(fileName);

            while ((line = file.ReadLine()) != null)
            {
                separar = line.Split('\t');
                if (separar[0] == id)
                {
                    return separar[1];
                }
            }

            file.Close();

            return null;

        }

        static List<string> buscaIds(string[] caminhos)
        {
            List<string> retorno = new List<string>();
            foreach (string item in caminhos)
            {
                string tmp = item.Split('/').Last().Split('.').First();
                retorno.Add(tmp);
            }
            return retorno;
        }


        static void Main(string[] args)
        {
            string txt = @"C:/Users/chiqu/Documents/GitHub/RenomearArquivo/";
            string pastaPdf = @"C:/Users/chiqu/Documents/GitHub/RenomearArquivo/folder1/";
            string pastaOut = @"C:/Users/chiqu/Documents/GitHub/RenomearArquivo/folder2/";

            List<string> ids = buscaIds(Directory.GetFiles(pastaPdf, "*.pdf", SearchOption.TopDirectoryOnly));

            foreach (var item in ids)
            {
                string idDocumento = Leitura($"{txt}/documento.txt", item);
                string nomeProduto = Leitura($"{txt}/produto.txt", idDocumento);

                System.Console.WriteLine($"id:{idDocumento} - nome: {nomeProduto} ");
                if (nomeProduto != null)
                {
                    int counter = 0;
                    bool success = false;
                    while (!success)
                    {
                        try
                        {
                            System.IO.File.Copy($"{pastaPdf}/{item}.pdf",
                            $"{pastaOut}/{nomeProduto} [{counter}].pdf");
                            success = true;

                        }
                        catch (Exception)
                        {
                            counter++;
                        }

                    }
                    //Console.WriteLine("${pastaPdf}\" + item + @" - ${pastaPdf}\" + nomeProduto + ".pdf");
                }
                else
                {
                    Console.WriteLine("Código " + item + " Não possui nome.");
                }
            }
            Console.WriteLine("Arquivos renomeados");
            Console.ReadLine();
        }
    }
}