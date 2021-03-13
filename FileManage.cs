using System;
using System.Text;
using System.IO;

namespace ŠifrovacíProgram
{
    static class FileManage
    {
        public static void Smazat(string command)
        {
            string soubor = RozdělPříkaz(command);
            if (!File.Exists(soubor))
            {
                Konzole.NapišŘádek($"Soubor '{soubor}' nenalezen!");
            }
            else
            {
                do
                {
                    try
                    {
                        File.Delete(soubor);
                    }
                    catch (IOException e)
                    {
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine(e.Message);
                    } 
                } while (File.Exists(soubor));

                Konzole.NapišŘádek($"Soubor '{soubor}' byl smazán.");
            }
        }

        public static void Vytvořit(string command)
        {
            string soubor = RozdělPříkaz(command);
            if (File.Exists(soubor))
            {
                Konzole.NapišŘádek($"Soubor '{soubor}' již existuje!");
            }
            else
            {
                do
                {
                    try
                    {
                        File.Create(soubor).Close();
                    }
                    catch (IOException e)
                    {
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine(e.Message);
                    } 
                } while (!File.Exists(soubor));

                Konzole.NapišŘádek($"Soubor '{soubor}' byl vytvořen.");
            }
        }

        public static void Přečti(string command)
        {
            string soubor = RozdělPříkaz(command);
            if (!File.Exists(soubor))
            {
                Konzole.NapišŘádek($"Soubor '{soubor}' nenalezen!");
            }
            else
            {
                Console.WriteLine();
                do
                {
                    try
                    {
                        Console.Write(File.ReadAllText(soubor));
                        break;
                    }
                    catch (IOException e)
                    {
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine(e.Message);
                        continue;
                    } 
                } while (true);
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public static void Zapiš(string command)
        {
            string soubor = RozdělPříkaz(command);
            if (!File.Exists(soubor))
            {
                Konzole.NapišŘádek($"Soubor '{soubor}' nenalezen!");
            }
            else
            {
                string text = "";

                string[] slova = command.Split(' ');

                for (int i = 3; i < slova.Length; i++)
                {
                    text += slova[i];
                    text += " ";
                }

                do
                {
                    try
                    {
                        File.WriteAllText(soubor, text, Encoding.UTF8);
                        break;
                    }
                    catch (IOException e)
                    {
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine(e.Message);
                        continue;
                    } 
                } while (true);
                Konzole.NapišŘádek($"Text zapsáno do souboru '{soubor}'.");
            }
        }

        public static void VypišSložky()
        {
            DirectoryInfo složka = new DirectoryInfo(Directory.GetCurrentDirectory());
            Console.WriteLine();
            Console.WriteLine($"Obsah složky '{složka.Name}':");
            int i = 1;
            Console.WriteLine();
            foreach (string jedenSoubor in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt", SearchOption.AllDirectories))
            {
                Console.WriteLine(i + ") " + jedenSoubor);
                i++;
            }
            foreach (string jedenSoubor in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.cry", SearchOption.AllDirectories))
            {
                Console.WriteLine(i + ") " + jedenSoubor);
                i++;
            }
            foreach (string jedenSoubor in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.desifr", SearchOption.AllDirectories))
            {
                Console.WriteLine(i + ") " + jedenSoubor);
                i++;
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private static string RozdělPříkaz(string command)
        {
            return command.Split(' ')[2];
        }
    }
}