using System;

namespace ŠifrovacíProgram
{
    static class Konzole
    {
        private const string nápověda = @"
    Nápověda:

- help/? ~ nápověda
- crypto ~ šifrování
    > crypto [klíč] [soubor]
    > stejný příkaz dešifruje i šifruje
- clear ~ vyčištění konzole
- end/exit ~ ukončení aplikace
- file ~ práce se soubory
    > file create [soubor] ~ vytvoří soubor 
    > file delete [soubor] ~ smaže soubor
    > file read [soubor] ~ vypíše obsah souboru
    > file write [soubor] [text] ~ zapíše text do souboru
 - dir show ~ ukáže obsah složky

";

        public static void Nápověda()
        {
            Console.WriteLine(nápověda);
        }

        public static void Úvod()
        {
            Console.Title = "Šifrovací program";
            //Console.WindowWidth = 100;
            Console.WindowHeight = 50;
            //Console.WindowLeft += 50;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("                     Výtej v aplikaci pro šifrování!");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine();
            Console.Write("Booting");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(200);
            }
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
        }

        public static void Konec()
        {
            Console.Clear();
            Console.Write("Shuting down");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(150);
            }
        }

        public static void NapišŘádek(string text = "")
        {
            Console.WriteLine("Encrypt> " + text);
        }

        public static void Napiš(string text = "")
        {
            Console.Write("Encrypt> " + text);
        }
    }
}
