using System;
using System.Text;
using System.IO;

namespace ŠifrovacíProgram
{
    static class Encryption
    {
        public static void Šifrování(string info)
        {
            string klíč;
            string cesta = RozdělInfo(info, out klíč);
            string soubor;
            #region Načtení souboru
            try
            {
                soubor = NačtiSoubor(cesta);
            }
            catch (FileNotFoundException err)
            {
                Konzole.NapišŘádek(err.Message);
                return;
            }            
            #endregion
            string šifrovaný = Zašifruj(soubor, klíč);
            Uložit(šifrovaný, cesta);
            Konzole.NapišŘádek("Šifrování proběhlo úspěšně! Byl vytvořen soubor: " + ZjistiTyp(cesta));
        }

        // pomocné metody

        private static void Uložit(string soubor, string cesta)
        {
            string typ = ZjistiTyp(cesta);
            File.WriteAllText(typ, soubor, Encoding.UTF8);
        }

        private static string Zašifruj(string soubor, string klíč)
        {
            string zašifrovanýText = "";

            for (int i = 0, j = 0; i < soubor.Length; i++, j++)
            {
                if (j >= klíč.Length) j = 0;

                zašifrovanýText += (char)(soubor[i] ^ klíč[j]);
            }
            
            return zašifrovanýText;
        }

        private static string NačtiSoubor(string cesta)
        {
            if (!File.Exists(cesta))
            {
                throw new FileNotFoundException($"File '{cesta}' not found!", cesta);
            }
            else
            {
                return File.ReadAllText(cesta,Encoding.UTF8);
            }
        }

        private static string ZjistiTyp(string cesta)
        {
            FileInfo soubor = new FileInfo(cesta);

            if (soubor.Extension != ".cry" && soubor.Extension != ".desifr") return Path.GetFileNameWithoutExtension(soubor.Name) + ".cry";
            else if (soubor.Extension == ".cry") return Path.GetFileNameWithoutExtension(soubor.Name) + ".cry.desifr";
            else if (soubor.Extension == ".desifr") return Path.GetFileNameWithoutExtension(soubor.Name);
            else return ".err";

            /*
            string[] udaje = cesta.Split('.');
            if (udaje[1] == "txt") return udaje[0] + ".cry";
            else if (udaje.Length > 2 && udaje[1] == "cry" && udaje[2] != "desifr") return udaje[0] + ".cry";
            else if (udaje[1] == "cry") return udaje[0] + ".cry.desifr";
            else return udaje[0] + ".text";
            */
        }

        private static string RozdělInfo(string info, out string klíč)
        {
            string[] udaje = info.Split(" ");
            klíč = udaje[1];
            return udaje[2];
        }
    }
}
