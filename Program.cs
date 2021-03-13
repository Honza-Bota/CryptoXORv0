using System;
using System.Text.RegularExpressions;

namespace ŠifrovacíProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Konzole.Úvod();                                // úvodní informace
            
            do                                             // opakující se tělo programu
            {
                Konzole.Napiš();                           // výpis operačního programu
                string command = Console.ReadLine();       // načtení příkazu

                //rozhrodnutí jaký příkaz byl zadán
                if (new Regex("help").IsMatch(command) || command == "?") Konzole.Nápověda();                                 // vypsání nápovědy příkazů
                else if (new Regex("clear").IsMatch(command)) Console.Clear();                                                // vyčištění konzole
                else if (new Regex("end").IsMatch(command) || command == "exit" || command == "e" || command == "k") break;   // ukončení programu
                else if (new Regex("dir show").IsMatch(command)) FileManage.VypišSložky();                                    // vypsání obsahu složky
                //else if (command.Length >= 7 && command.Substring(0, 7) == "crypto ") Encryption.Šifrování(command);        // zašifrování souboru
                else if (new Regex("crypto .{1,50} .{1,40}.{1,10}").IsMatch(command)) Encryption.Šifrování(command);          // zašifrování souboru
                else if (new Regex("file create .{1,50}.{1,10}").IsMatch(command)) FileManage.Vytvořit(command);              // vytvoření souboru
                else if (new Regex("file delete .{1,50}.{1,10}").IsMatch(command)) FileManage.Smazat(command);                // smazání souboru
                else if (new Regex("file read .{1,50}.{1,10}").IsMatch(command)) FileManage.Přečti(command);                  // vypsání obsahu souboru
                else if (new Regex("file write .{1,50}.{1,10}").IsMatch(command)) FileManage.Zapiš(command);                  // zapsání do souboru
                else if (command == "") continue;                                                                             // udělání odskočení (prázdný řádek)
                else Konzole.NapišŘádek("   Wrong command!  ");                                                               // chyba > špatné zadání příkazu

            } while (true);

            Konzole.Konec();                               // konečné informace
        }
    }
}
