using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace accdb2txtdir
{
	class Program
	{
        class Feladat
        {
            public class NNT
            {
                public string adatbázisnév;
                public string adatbázis;
                public string lekérdezés;
                public string tipus;
                static string[] sorvektor;
                public NNT(string sor)
                {
                    sorvektor = sor.Split('\t');
                    adatbázis = sorvektor[0];
                    adatbázisnév = adatbázis.Split('.')[0];
                    lekérdezés = sorvektor[1];
                    tipus = sorvektor[2];
                }
            }
            public static List<NNT> setuplist = new List<NNT>();
            const string setupfilename = "setup.txt";
            const string setupdirpath = "";
            public static void Setup(string debug)
            {
                debug += "Feladat.Setup" + Konzol.dbj;
                using (StreamReader f = new StreamReader(setupfilename, Encoding.Default))
                {
                    while (!f.EndOfStream)
                    {
                        string sor=f.ReadLine();
                        if (sor[0] != '%') // megjegyzés, nem mentjük el
                        {
                            setuplist.Add(new NNT(sor));
                        }
                    }
                }
                Konzol.WriteLine(debug, setupdirpath + @"\" + setupfilename + " beolvasva", ConsoleColor.White);
                Console.WriteLine("{0}\\{1}\t -> \t{2}", "adatbázis neve", "lekérdezés neve", "lekérdezés típusa");
                Console.WriteLine("---------------------------");
                foreach (NNT nnt in setuplist)
                {
                    Console.WriteLine("{0}\\{1}\t -> \t{2}", nnt.adatbázis, nnt.lekérdezés,nnt.tipus);
                }
            }
        }

        static string root;
        static string Path2név(string path)
        {
            return path.Split('\\').Last();
        }
        static class Konzol
        {
            public static string dbj = " > ";
            public static ConsoleColor debugszín = ConsoleColor.Blue;

            public static void Write(string debug, string k, ConsoleColor szín)
            {
                Console.ForegroundColor = debugszín;
                Console.Write(debug);
                Console.ForegroundColor = szín;
                Console.Write(k);
                Console.ForegroundColor = ConsoleColor.White;
            }
            public static void WriteLine(string debug, string k, ConsoleColor szín = ConsoleColor.White)
            {
                Write(debug, k+"\n", szín);
            }
        }
        class Tanuló
        {
            static OleDbConnection con;
            static OleDbCommand cmd;
            static OleDbDataReader reader;
            bool megoldókulcs = false;
            string név;
            string dirpath;
            public Tanuló(string dp)
            {
                dirpath = dp;
                név = Path2név(dp);
                megoldókulcs = név[0] == '!';
            }
            static List<Tanuló> lista = new List<Tanuló>();
            static List<string> hibajegyzék = new List<string>();
            public static void HibákKiírása(string debug)
            {
                debug += "Tanuló.hibajegyzék" + Konzol.dbj;
                foreach (string hiba in hibajegyzék)
                {
                    Konzol.WriteLine(debug, hiba, ConsoleColor.Red);
                }
            }
            public static void Setup(string debug)
            {
                debug += "Tanuló.Setup" + Konzol.dbj;
                foreach (string könyvtárnév in Directory.EnumerateDirectories(root))
                {
                    if (könyvtárnév.Split('\\').Last()[0]!='-') // A "-"-szal kezdődő könyvtárnevekről nem vesz tudomást.
                    {
                        lista.Add(new Tanuló(könyvtárnév));
                    }
                    Konzol.Write(debug, Path2név(könyvtárnév), ConsoleColor.Green);
                    Konzol.WriteLine("", " tanulókönyvtár észlelve.");
                }
            }
            private void lekérdezés2txt(string debug, Feladat.NNT nnt)
            {
                debug += "lekérdezés2txt" + Konzol.dbj;
                try
                {
                    con = new OleDbConnection();
                    con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dirpath + "\\" + nnt.adatbázis;
                    cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM " + nnt.lekérdezés;
                    con.Open();
                    reader = cmd.ExecuteReader();
                    string sorstring;
                    int sorokszáma = reader.FieldCount;
                    Console.WriteLine("+-------------- START --------------");
                    Console.Write("|\t");
                    Konzol.Write("", név + " ", ConsoleColor.Green);
                    Konzol.Write("", nnt.lekérdezés, ConsoleColor.Blue);
                    Console.WriteLine(" lekérdezése:");
                    Console.WriteLine("+-----------------------------------");
                    using (StreamWriter w = new StreamWriter(dirpath + "\\output_" + nnt.adatbázisnév + "_" + nnt.lekérdezés + ".txt"))
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            sorstring = "";

                            for (int j = 0; j < sorokszáma; j++)
                            {
                                sorstring += reader[j] + (j<sorokszáma-1?"\t":"");
                            }
                            Console.Write("| ");
                            Konzol.Write("", (++i).ToString(), ConsoleColor.Blue);
                            Console.WriteLine("\t"+sorstring);
                            w.WriteLine(sorstring);
                        }
                        if (i == 0)
                        {
                            hibajegyzék.Add("Üres? Ha nem, fix: LIKE => ALIKE ? " + név + ": " + nnt.adatbázisnév + "/" + nnt.lekérdezés);
                        }
                    }
                    con.Close();
                   // Console.WriteLine("------------------------------------");
                   // Konzol.Write("", név+" ", ConsoleColor.Green);
                   //  Konzol.Write("", nnt.lekérdezés, ConsoleColor.Blue);
                   // Console.WriteLine(" lekérdezésének vége");
                    Console.WriteLine("+--------------- END ---------------");
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    string hiba = "HIÁNYZIK? " + név + ": " + nnt.adatbázisnév + "/" + nnt.lekérdezés + " -- " + e.Message; //+" ("+debug+")";
                    hibajegyzék.Add(hiba);
                    Konzol.WriteLine(debug, hiba, ConsoleColor.Red);
                    using (StreamWriter w = new StreamWriter(dirpath + "\\output_" + nnt.adatbázisnév + "_" + nnt.lekérdezés + ".txt"))
                    {
                        w.WriteLine(hiba);
                    }
                    //throw;
                }
            }
            private static void accdb2txts(string debug, Tanuló tanuló)
            {
                debug += "accdb2txts" + Konzol.dbj;
                foreach (Feladat.NNT nnt in Feladat.setuplist)
                {
                    tanuló.lekérdezés2txt(debug, nnt);
                }
            }
            public static void Allaccdb2txt(string debug)
            {
                debug += "Allaccdb2txt" + Konzol.dbj;
                foreach (Tanuló tanuló in lista)
                {
                    accdb2txts(debug, tanuló);
                }
            }
        }
        static void Main(string[] args)
        {
            string debug = " ";
            root = Directory.GetCurrentDirectory();
            Tanuló.Setup(debug);
            Feladat.Setup(debug);

            Tanuló.Allaccdb2txt(debug);
            //accdbfile = "cukraszda.accdb";
            //Console.WriteLine("====================================");
            //GetLekérdezés("3db");

            Tanuló.HibákKiírása(debug);
            Console.WriteLine("A program lefutott, a tanulók könyvtáraiban (azaz a nem kötőjellel kezdődő könyvtárakban) megtalálhatók a megadott lekérdezések és táblák lekérdezései tsv formátumban .txt kiterjesztéssel.)");
            Console.WriteLine("\tHa vannak indokolatlanul üres táblák, akkor ennek egy valószínű oka az, hogy az OLEDB, amit ez a program használ, nem tudja értelmezni az Access-ben használatos \"LIKE\" parancs \"*\" és \"?\" regex-es változójeleit. Ehhez az eredeti fájlokban sajnos egyelőre át kell írni a parancsokat \"ALIKE\" parancsokra és a szokásos mysql és sql-szerver \"%\" és \"_\" karaktereket használni. Így az Access és az OLEDB is lefut és ugyanazt az eredményt produkálja. ");
            Console.WriteLine("\tAz összehasonlításhoz futtass egy ellenőrzőprogramot, pl az outputcomparer.exe-t");
            Console.WriteLine("\tNyomj meg egy gombot a befejezéshez!");
            Console.ReadKey();
        }
    }
}
