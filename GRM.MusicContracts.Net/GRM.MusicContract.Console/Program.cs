using System;
using System.Linq;
using GRM.MusicContract.Music;
using GRM.MusicContract.Music.Provider.Data;
using GRM.MusicContract.Music.Provider.Stream;

namespace GRM.MusicContract.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo exit;

            do
            {
                System.Console.WriteLine(Environment.NewLine);
                System.Console.WriteLine("Please enter supplier reference");
                var reference = System.Console.ReadLine();
                var musicStream = new MusicStream(new TextReader());
                var supplier = new Supplier(musicStream);
                var result = supplier.Get(reference);

                System.Console.WriteLine(Environment.NewLine);
                System.Console.WriteLine("The Output is");
                System.Console.WriteLine(Environment.NewLine);
                if (result.Any())
                {
                    foreach (var contract in result)
                    {
                        System.Console.WriteLine(contract);
                    }
                }
                else
                {
                    System.Console.WriteLine("Data not found.");
                }
                System.Console.WriteLine(Environment.NewLine);
                System.Console.WriteLine(Environment.NewLine);
                System.Console.WriteLine(Environment.NewLine);
                System.Console.WriteLine("Press 0 to exit, Any key to continue");
                exit = System.Console.ReadKey();

            } while (exit.KeyChar != 48);
        }
    }
}
