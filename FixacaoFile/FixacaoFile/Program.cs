using System;
using System.IO;
using System.Globalization;
using FixacaoFile.Entities;

namespace Fixacaofile
{
    class Program
    {

        static void Main(string[] args)
        {
            // Tenho que ler um caminho de um arquivo que contém os dados de itens vendidos
            // Cada Item tem , nome , preço, quantitidade.
            // Gerar um novo arquvo chamado"summary.txt" , que estará localizado em um subpasta chamada "out" da pasta atual.
            // Nesse arquivo irá conter todos os itens , porém com o valor total. ( preço * quantidade) 

            Console.WriteLine("Enter file full path: ");
            string path = Console.ReadLine();

            try
            {
                string[] lines = File.ReadAllLines(path);

                string source_folder_path = Path.GetDirectoryName(path);

                string target_folder_path = source_folder_path + "\\out";

                string target_file_path = target_folder_path + "\\summary.txt";

                Directory.CreateDirectory(target_folder_path);


                using (StreamWriter sw = File.AppendText(target_file_path))
                {
                    foreach (string line in lines)
                    {
                        string[] element = line.Split(",");
                        string name = element[0];
                        double price = double.Parse(element[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(element[2]);

                        Product product = new Product(name, price, quantity);

                        sw.WriteLine(product);

                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error format: ");
                Console.WriteLine(e.Message);
            }

        }

    }

}