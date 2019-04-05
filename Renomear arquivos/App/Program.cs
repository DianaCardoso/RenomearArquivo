using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Test_Le_Arquivos{
    class ReadFromFile{

        static string Leitura(string fileName, string id){
            string line;
            string[] separar;

            System.IO.StreamReader file =
                new System.IO.StreamReader(fileName);

            while ((line = file.ReadLine()) != null){
                separar = line.Split(' ');
                
                if (separar[0] == id){
                    return separar[1];
                }
            }

            file.Close();

            return null;

        }

        static List<string> buscaIds(string[] caminhos) {
            List<string> retorno = new List<string>();
            foreach (string item in caminhos){
                string tmp = item.Split('\\').Last().Split('.').First();
                retorno.Add(tmp);
            }
            return retorno;
        }


        static void Main(){

            string pastaPdf = @"C:\Users\chiqu\Downloads\App C#\";

            List<string> ids = buscaIds(Directory.GetFiles(pastaPdf, "*.pdf", SearchOption.TopDirectoryOnly));

            foreach (var item in ids){
                string idDocumento = Leitura(@"C:\Users\chiqu\Downloads\App C#\documento.txt", item);
                string nomeProduto = Leitura(@"C:\Users\chiqu\Downloads\App C#\produto.txt", idDocumento);
                if (nomeProduto != null ){
                    System.IO.File.Move(@"C:\Users\chiqu\Downloads\App C#\" + item + ".pdf", @"C:\Users\chiqu\Downloads\App C#\" + nomeProduto + ".pdf");
                    //Console.WriteLine(@"C:\Users\chiqu\Downloads\App C#\" + item + @" -> C:\Users\chiqu\Downloads\App C#\" + nomeProduto + ".pdf");
                }
                else{
                    Console.WriteLine("Código " + item + " Não possui nome.");
                }
            }
            Console.WriteLine("Arquivos renomeados");
            Console.ReadLine();
            
        }
    }
}