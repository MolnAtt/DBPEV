using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Diagnostics; //Processhez
using System.Data;
using System.Data.OleDb;


namespace AdatbázisJavító
{
	class Program
	{
		static class Színes
		{
			private static Dictionary<string, ConsoleColor> színszotár = new Dictionary<string, ConsoleColor>();
			public static void Init()
			{
				színszotár.Add("blue", ConsoleColor.Blue);
				színszotár.Add("white", ConsoleColor.White);
				színszotár.Add("red", ConsoleColor.Red);
				színszotár.Add("green", ConsoleColor.Green);
				színszotár.Add("yellow", ConsoleColor.Yellow);
			}
			private static string Intervallum(string s, int a, int b)
			{
				return s.Substring(a + 1, b - a - 3);
			}
			private static void Színtvált(string szín)
			{
				Console.ForegroundColor = színszotár[szín];
				try
				{
					Console.ForegroundColor = színszotár[szín];
				}
				catch (Exception)
				{
					Console.ForegroundColor = ConsoleColor.Magenta;
				}
			}
			public static void WriteLine(string s)
			{
				Write(s);
				Console.WriteLine();
			}
			public static void Write(string s)
			{
				int i = s.IndexOf('[');
				int j = s.IndexOf(']');
				int l = s.IndexOf('}');
				if (i == -1 || j == -1 || l == -1)
				{
					Console.Write(s);
				}
				else
				{
					if (i > 0)
					{
						Console.Write(s.Substring(0, i));
					}
					Színtvált(s.Substring(i + 1, j - i - 1
						));
					Console.Write(s.Substring(j + 2, l - j
						- 2
						));
					Színtvált("white");
					if (l < s.Length - 1)
					{
						Színes.Write(s.Substring(l + 1));
					}
				}
			}
			public static string Be(string megj = "")
			{
				if (megj != "") { Színes.WriteLine(megj); }
				Színes.Write("[green]{>> }");
				return Console.ReadLine();
			}
			public static string Fehérítő(string str)
			{
				foreach (string szín in színszotár.Keys)
				{
					str = str.Replace($"[{szín}]", "");
				}
				return str.Replace("{", "").Replace("}", "");
			}
		}
		static class Fájlkezelés
		{
			static bool léptetés = true;
			/// <summary>
			/// lefuttatja az adott helyen az adott fájlt. A fájl az inputokat a megadott helyről szerzi be. A megjegyzést kiírja.
			/// </summary>
			/// <param name="hely"></param>
			/// <param name="file"></param>
			/// <param name="megjegyzés"></param>
			public static void Fájl_Futtatása(string hely, string file)
			{
				using (Process process = new Process())
				{
					process.StartInfo.UseShellExecute = false;
					process.StartInfo.CreateNoWindow = false;
					process.StartInfo.WorkingDirectory = hely; // azért kell, mert a futtatandó file ebben a könyvtárban keres majd inputot.
					process.StartInfo.FileName = file;
					process.Start();
					process.WaitForExit();
				}
				Console.WriteLine("Nyomj meg egy gombot a továbbhaladáshoz!");
				if (léptetés)
				{
					Színes.WriteLine("[green]{--- Ahhoz, hogy léptetésben maradjon a program, nyomd meg a Space-t! ---}");
					léptetés = Console.ReadKey().Key == ConsoleKey.Spacebar;
				}
				//Thread.Sleep(1000);

			}
			/// <summary>
			/// Egy fájl elérési útvonaláról levágja a fájlnév előtti részt és csak a fájl nevét és kiterjesztését adja vissza.
			/// </summary>
			/// <param name="path"></param>
			/// <returns></returns>
			public static string Path2Név(string path)
			{
				return path.Split('\\').Last();
			}
			/// <summary>
			/// Visszalépéses kereséssel megkeresi a könyvtárat.
			/// </summary>
			/// <param name="path">ahol keres</param>
			/// <param name="könyvtár">amit keres</param>
			/// <returns></returns>
			public static bool Könyvtár_Keresése(ref string path, string könyvtár)
			{
				IEnumerable<string> könyvtárszerkezet = Directory.EnumerateDirectories(path);

				bool reménytelen = könyvtárszerkezet.Count() == 0;
				if (reménytelen)
				{
					return false;
				}
				else // ha nem reménytelen, azaz vannak könyvtárak...
				{
					string könyvtáraspath = path + @"\" + könyvtár; // nem írható be ide le, mert ref-es
					bool megvan = könyvtárszerkezet.Where(x => x == könyvtáraspath).Count() != 0;
					if (megvan)
					{
						return true;
					}
					else // vannak könyvtárak, de még egyik sem a bin...
					{
						bool result = false; // nem engedi enélkül a VS.
						for (int i = 0; i < könyvtárszerkezet.Count() && !megvan; i++)
						{
							string talánez = könyvtárszerkezet.ElementAt(i); // nem kell a 'path +', mivel tartalmazza mindegyik...
							if (Könyvtár_Keresése(ref talánez, könyvtár))
							{
								path = talánez;
								result = true;
							}
							// else { result = false; } // VS miatt, bár így lenne áttekinthetőbb.
						}
						return result;
					}
				}
			}
			/// <summary>
			/// Visszalépéses kereséssel megkeresi a fájlt (első előfordulás).
			/// </summary>
			/// <param name="holkeres">ahol keres</param>
			/// <param name="fájl">amit keres</param>
			/// <param name="eredmény">az eredményt az ezen címen található stringbe rakja be</param>
			/// <returns></returns>
			public static bool Fájl_Keresése(string holkeres, string fájl, string regkif, ref string eredmény)
			{
				IEnumerable<string> könyvtárakitt = Directory.EnumerateDirectories(holkeres);
				IEnumerable<string> fájlokitt = Directory.EnumerateFiles(holkeres);
				IEnumerable<string> találatok = fájlokitt.Where(x => (regkif != "" ? (Regex.IsMatch(Path2Név(x), regkif)) : (Path2Név(x) == fájl)));

				if (találatok.Count() > 0)
				{
					eredmény = találatok.First();
					return true;
				}

				if (könyvtárakitt.Count() == 0) return false;

				bool megvan = false; // nem engedi enélkül a VS.
				for (int i = 0; i < könyvtárakitt.Count() && !megvan; i++)
				{
					megvan = Fájl_Keresése(könyvtárakitt.ElementAt(i), fájl, regkif, ref eredmény);
				}
				return megvan;

			}
		}
		class Multihalmaz<T>
		{
			protected bool debug;
			protected Dictionary<T, int> szótár = new Dictionary<T, int>();
			protected int count = 0;
			public Multihalmaz(bool debug = false) { this.debug = debug; }
			public Multihalmaz(IEnumerable<T> collection)
			{
				foreach (T item in collection)
				{
					Add(item);
				}
			}
			public void Add(T elem)
			{
				if (elem < this)
				{
					szótár[elem]++;
				}
				else
				{
					szótár[elem] = 1;
				}
			}
			public void Remove(T elem)
			{
				if (elem < this)
				{
					if (szótár[elem] == 1)
					{
						szótár.Remove(elem);
					}
					else szótár[elem]--;
				}
				else if (debug) Console.WriteLine("nincs ilyen elem, amit el kéne távolítani.");
			}
			public void Kiír()
			{
				string str = "{";
				foreach (T item in szótár.Keys)
				{
					for (int i = 0; i < szótár[item]; i++)
					{
						str += item + "; ";
					}
				}
				string result = str.Substring(0, str.Length - 1);
				Console.WriteLine(result + "}");
			}
			public void Diagnosztika()
			{
				foreach (T item in szótár.Keys)
				{
					Console.WriteLine("{0} -> {1}", item, szótár[item]);
				}
			}
			public static bool operator ==(Multihalmaz<T> A, Multihalmaz<T> B)
			{
				return A <= B && B <= A;
			}
			public static bool operator <(T elem, Multihalmaz<T> A)
			{
				return A.szótár.Keys.Contains(elem);
			}
			public static bool operator >(T elem, Multihalmaz<T> A)
			{
				return false;
			}
			public static bool operator <=(Multihalmaz<T> A, Multihalmaz<T> B)
			{
				(T hiba, int k, int l) = Részhalmaz_Első_Hibával(A, B);
				return (hiba == null || hiba.Equals(default(T))) && k == 0 && l == 0;
			}
			public static (T hiba, int k, int l) Részhalmaz_Első_Hibával(Multihalmaz<T> A, Multihalmaz<T> B)
			{
				foreach (T item in A.szótár.Keys)
				{
					if (!(item < B)) return (item, A.szótár[item], 0);
					if (A.szótár[item] > B.szótár[item]) return (item, A.szótár[item], B.szótár[item]);
				}
				return (default(T), 0, 0);
			}

			public static bool operator >=(Multihalmaz<T> A, Multihalmaz<T> B)
			{
				return B <= A;
			}
			public static bool operator <(Multihalmaz<T> A, Multihalmaz<T> B)
			{
				return A <= B && A != B;
			}
			public static bool operator >(Multihalmaz<T> A, Multihalmaz<T> B)
			{
				return B <= A;
			}
			public static bool operator !=(Multihalmaz<T> A, Multihalmaz<T> B)
			{
				return !(A == B);
			}
		}
		class StringMultihalmaz : Multihalmaz<string>
		{
			public StringMultihalmaz(string[,] mátrix, int sor, int oszlop)
			{
				string sum;
				for (int i = 0; i < sor; i++)
				{
					sum = "";
					for (int j = 0; j < oszlop; j++)
					{
						sum += "\t" + mátrix[i, j];
					}
					Add(sum);
				}
			}
		}
		static class Kicsomagoló
		{
			public static string Main(string[] args)
			{
				Console.WriteLine("nyomj egy \"mehet\"-et, és kitömörít minden könyvtárat:");
				Console.Write("--> ");
				if (Console.ReadLine() == "mehet")
				{
					Console.WriteLine("Mondj egy új könyvtárnevet, hogy hova pakoljam a kicsomagolt fájlokat:");
					Console.Write("--> ");
					string könyvtárnév = Console.ReadLine();
					string ezakönyvtár = Directory.GetCurrentDirectory();
					string ittlesz = $"{ezakönyvtár}\\{könyvtárnév}";
					Directory.CreateDirectory(ittlesz);
					string ide;
					foreach (string zipfile in Directory.EnumerateFiles(ezakönyvtár).Where(x => new Regex(@".*\.zip").IsMatch(x)))
					{

						ide = $"{ittlesz}\\{zipfile.Split('\\').Last().Split('.').First()}";
						Directory.CreateDirectory(ide);
						ZipFile.ExtractToDirectory(zipfile, ide);
					}
					return ittlesz;
				}
				return "nem mehetett";
			}
		}
		static class Kiszedegető
		{
			static void Main(string[] args)
			{
				Színes.WriteLine("A program működése:");
				Színes.WriteLine("Legyen [blue]{D} azon könyvtár neve, amiben ezt a programot futtatod.");
				Színes.WriteLine("Legyenek továbbá [blue]{D_1}, [blue]{D_2}, ... [blue]{D_i}, ... a [blue]{D} könyvtárban található közvetlen könyvtárak nevei. (Tehát csak a gyerekek.)");
				Színes.WriteLine("A program be fog kérni");
				Színes.WriteLine("--\tegy [blue]{R} reguláris kifejezést. Ha nem így akarsz keresni, hagyd üresen.");
				Színes.WriteLine("--\tegy [blue]{F} fájlnevet (elérési útvonal nélkül). Ha nem így akarsz keresni, hagyd üresen.");
				Színes.WriteLine("--\tegy [blue]{C} könyvtárnevet,");
				Színes.WriteLine("--\tegy [blue]{O} opciót, amely a következők valamelyikét jelenti:");
				Színes.WriteLine("\tA [blue]{D_1}, [blue]{D_2}, ... [blue]{D_i}, ... könyvtárban található alkönyvtárban mélységi kereséssel fellelhető [blue]{F} nevű fájlokat bemásolja");
				Színes.WriteLine("\t [green]{1}: egy új [blue]{C} nevű könyvtárba úgy, hogy a fájlok a [blue]{D_1}, [blue]{D_2}, ... [blue]{D_i}, ... könyvtárakról lesznek elnevezve.");
				Színes.WriteLine("\t\tTehát a [blue]{C} tartalma [blue]{D_1}-[blue]{F}, [blue]{D_2}-[blue]{F}, ..., [blue]{D_i}-[blue]{F}, ... fájlok lesznek. ");
				Színes.WriteLine("\t [green]{2}: egy új, [blue]{C} nevű könyvtárban létrehozott [blue]{D_i} könyvtárba az eredeti [blue]{F} néven (reguláris kifejezés esetén a saját nevén).");
				Színes.WriteLine("\t\tTehát a [blue]{C} tartalma a [blue]{D_1}, [blue]{D_2}, ..., [blue]{D_i}, ... könyvtárak lesznek, melyeknek egyetlen tartalmuk egy [blue]{F} fájl. ");
				Színes.WriteLine("\t [green]{sok2}[red]{n}: sok új, [blue]{C_1}, [blue]{C_2}..., [blue]{C_n} nevű könyvtárban létrehozott [blue]{D_i} könyvtárba az eredeti [blue]{F} néven (reguláris kifejezés esetén a saját nevén).");
				Színes.WriteLine("\t\tTehát minden [blue]{C_i} tartalma a [blue]{D_1}, [blue]{D_2}, ..., [blue]{D_i}, ... könyvtárak lesznek, melyeknek egyetlen tartalmuk egy [blue]{F} fájl. ");
				Színes.WriteLine("[yellow]{---------------------------------------}");
				Színes.Write("[blue]{R} = ");
				string R = Console.ReadLine();
				Színes.Write("[blue]{F} = ");
				string F = Console.ReadLine();
				Színes.Write("[blue]{C} = ");
				string C = Console.ReadLine();
				Színes.Write("[blue]{O} = ");
				string O;
				List<string> options = new List<string> { "1", "2" };
				int cardinality;
				do { O = Console.ReadLine(); } while (!options.Contains(O) && !(O.StartsWith("sok2") && int.TryParse(O.Substring(4), out cardinality)));

				Színes.WriteLine("[yellow]{---------------------------------------}");

				string ezakönyvtár = Directory.GetCurrentDirectory();
				IEnumerable<string> könyvtárakitt = Directory.EnumerateDirectories(ezakönyvtár);
				string eredménykönyvtár = ezakönyvtár + "\\" + C;
				Directory.CreateDirectory(eredménykönyvtár);
				List<string> másolandófájlok = new List<string>();
				string találtfájl = "";
				foreach (string D_i in könyvtárakitt)
				{
					if (D_i != eredménykönyvtár)
					{
						if (Fájlkezelés.Fájl_Keresése(D_i, F, R, ref találtfájl))
						{
							if (O == "1")
							{
								File.Copy(találtfájl, eredménykönyvtár + "\\" + Fájlkezelés.Path2Név(D_i) + "-" + Fájlkezelés.Path2Név(találtfájl));
								Színes.WriteLine("A [green]{" + D_i + "} könyvtárban a(z) [blue]{" + (R == "" ? F : R) + "} fájlt megtaláltam, bemásoltam a [blue]{" + C + "} könyvtárba.");
							}
							else if (O == "2")
							{
								Directory.CreateDirectory(eredménykönyvtár + "\\" + Fájlkezelés.Path2Név(D_i));
								File.Copy(találtfájl, eredménykönyvtár + "\\" + Fájlkezelés.Path2Név(D_i) + "\\" + Fájlkezelés.Path2Név(találtfájl));
								Színes.WriteLine("A [green]{" + D_i + "} könyvtárban a(z) [blue]{" + (R == "" ? F : R) + "} fájlt megtaláltam, bemásoltam a [blue]{" + C + "} könyvtárban létrehozott [blue]{" + Fájlkezelés.Path2Név(D_i) + "} könyvtárba.");
							}
							else if (O.StartsWith("sok2"))
							{
								int n = int.Parse(O.Substring(4));
								string célkönyvtárindexnélkül = eredménykönyvtár + "\\" + C + "_";
								string célkönyvtár;
								for (int i = 0; i < n; i++)
								{
									célkönyvtár = célkönyvtárindexnélkül + (i + 1).ToString() + "\\";
									Directory.CreateDirectory(célkönyvtár + Fájlkezelés.Path2Név(D_i));
									File.Copy(találtfájl, célkönyvtár + Fájlkezelés.Path2Név(D_i) + "\\" + Fájlkezelés.Path2Név(találtfájl));
								}
								Színes.WriteLine("A [green]{" + D_i + "} könyvtárban a(z) [blue]{" + (R == "" ? F : R) + "} fájlt megtaláltam, bemásoltam a [blue]{" + C + "} kezdetű könyvtárakban létrehozott [blue]{" + Fájlkezelés.Path2Név(D_i) + "} könyvtárba.");
							}
						}
						else
						{
							Színes.WriteLine("A [green]{" + D_i + "} könyvtárban a(z) [blue]{" + F + "} fájlt [red]{nem találtam meg :(}.");
						}
					}
				}
				Színes.WriteLine("[yellow]{A program befejeződött. Nyomd meg a q-t a kilépéshez.}");

				while (Console.ReadKey().KeyChar != 'q') { }
			}
		}
		static class accdb2txt
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
						lekérdezés = sorvektor[1].Split('.')[0];
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
							string sor = f.ReadLine();
							if (sor[0] != '%') // megjegyzés, nem mentjük el
							{
								setuplist.Add(new NNT(sor));
							}
						}
					}
					Konzol.WriteLine(debug, setupdirpath + @"\" + setupfilename + " beolvasva");
					Console.WriteLine("{0}\\{1}\t -> \t{2}", "adatbázis neve", "lekérdezés neve", "lekérdezés típusa");
					Console.WriteLine("---------------------------");
					foreach (NNT nnt in setuplist)
					{
						Console.WriteLine("{0}\\{1}\t -> \t{2}", nnt.adatbázis, nnt.lekérdezés, nnt.tipus);
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

				public static void Write(string debug, string k)
				{
					Színes.Write($"[blue]{{{debug}}}");
					Színes.Write(k);
				}
				public static void WriteLine(string debug, string k)
				{
					Write(debug, k + "\n");
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
					string szín;
					foreach (string hiba in hibajegyzék)
					{
						szín = hiba.Contains("LIKE") ? "yellow" : "red";
						Konzol.WriteLine(debug, $"[{szín}]{{{hiba}}}");
					}
					if (hibajegyzék.Any(x => x.Contains("LIKE")))
					{
						Színes.WriteLine("\t[yellow]{Ha vannak indokolatlanul üres táblák, akkor ennek egy valószínű oka az, hogy az OLEDB, amit ez a program használ, nem tudja értelmezni az Access-ben használatos \"LIKE\" parancs \"*\" és \"?\" regex-szerű változójeleit. Ehhez az eredeti fájlokban sajnos egyelőre át kell írni a parancsokat \"ALIKE\" parancsokra és a szokásos mysql és sql-szerver \"%\" és \"_\" karaktereket használni. Így az Access és az OLEDB is lefut és ugyanazt az eredményt produkálja. }");
					}
				}
				public static void Setup(string debug)
				{
					debug += "Tanuló.Setup" + Konzol.dbj;
					foreach (string könyvtárnév in Directory.EnumerateDirectories(root))
					{
						if (könyvtárnév.Split('\\').Last()[0] != '-') // A "-"-szal kezdődő könyvtárnevekről nem vesz tudomást.
						{
							lista.Add(new Tanuló(könyvtárnév));
						}
						Konzol.Write(debug, $"[green]{{{Path2név(könyvtárnév)}}}");
						Konzol.WriteLine("", " tanulókönyvtár észlelve.");
					}
				}
				private void lekérdezés2txt(string debug, Feladat.NNT nnt)
				{
					debug += "lekérdezés2txt" + Konzol.dbj;
					string szín;
					try
					{
						con = new OleDbConnection();
						con.ConnectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dirpath}\\{nnt.adatbázis}";
						cmd = new OleDbCommand();
						cmd.Connection = con;
						cmd.CommandText = "SELECT * FROM " + nnt.lekérdezés;
						con.Open();
						reader = cmd.ExecuteReader();
						string sorstring;
						int sorokszáma = reader.FieldCount;
						Console.WriteLine("+-------------- START --------------");
						Console.Write("|\t");
						Konzol.Write("", $"[green]{{{név}}} ");
						Konzol.Write("", $"[blue]{{{nnt.lekérdezés}}}");
						Console.WriteLine(" lekérdezése:");
						Console.WriteLine("+-----------------------------------");
						using (StreamWriter w = new StreamWriter($"{dirpath}\\output_{nnt.adatbázisnév}_{nnt.lekérdezés}.txt"))
						{
							int i = 0;
							while (reader.Read())
							{
								sorstring = "";

								for (int j = 0; j < sorokszáma; j++)
								{
									sorstring += reader[j] + (j < sorokszáma - 1 ? "\t" : "");
								}
								Console.Write("| ");
								Konzol.Write("", $"[blue]{{{++i}}}");
								Console.WriteLine("\t" + sorstring);
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
						szín = hiba.Contains("LIKE") ? "yellow" : "red";
						Konzol.WriteLine(debug, $"[{szín}]{{{hiba}}}");
						//                    Konzol.WriteLine(debug, $"[red]{{{hiba}}}");
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
				Színes.Init();
				string debug = " ";
				root = Directory.GetCurrentDirectory();
				Tanuló.Setup(debug);
				Feladat.Setup(debug);

				Tanuló.Allaccdb2txt(debug);
				//accdbfile = "cukraszda.accdb";
				//Console.WriteLine("====================================");
				//GetLekérdezés("3db");

				Tanuló.HibákKiírása(debug);
				Színes.WriteLine("[green]{A program lefutott}. \n\t[blue]{A tanulók könyvtáraiban} (azaz a nem kötőjellel kezdődő könyvtárakban) [blue]{megtalálhatók a megadott lekérdezések és táblák lekérdezései tsv formátumban .txt kiterjesztéssel.}");
				Színes.WriteLine("\tAz összehasonlításhoz futtass egy ellenőrzőprogramot, pl az [blue]{Összehasonlító.exe}-t");
				Színes.WriteLine("\tNyomj meg egy gombot a befejezéshez!");
				Console.ReadKey();
			}
		}
		static class Összehasonlító
		{
			static bool debugmode = false;
			static string nemválaszolt = "NEM VÁLASZOLT";
			/*	Ez az OutputComparer alapján készült, ahhoz ezek voltak a kapcsolódó programok: 
			 *	- (Random) Input Generátor
			 *	- JavítóSegéd (ez régi, ebből ki lettek szedve a dolgok)
			 *	- accdb2txts (Ez csinál accdb-kből output_stb.txt-ket)
			 *	
			 *	Aztán ebből a Kiszedegető és InputokSzétosztásaÉsAFuttatás programok egybegyúrásával készül a mostani.
			*/


			class Teszt
			{
				public static string root;
				public static Dictionary<string, Teszt> szótár = new Dictionary<string, Teszt>();
				public string path;
				public string név;
				// eredmény;
				public Teszt(string p)
				{
					path = p;
					név = Path2name(path);
					szótár.Add(név, this);
				}
				public void Eredmények_Kiírása(string debug)
				{
					debug += "Teszt.Eredmények_Kiírása" + dbj;

					Színes.WriteLine("---------------- " + debug + " ----------------------");
					Színes.WriteLine($"A [blue]{{{név}}} teszt eredményeinek összefoglalása:");
					int p;

					Console.Write("\t");
					string result = "\t";
					foreach (ALT alt in ALT.szótár.Values)
					{
						Színes.Write("\t[blue]{" + alt.lekérdezésfájl.Substring(0, Math.Min(7, alt.lekérdezésfájl.Length)) + "}");
						result += "\t" + alt.lekérdezésfájl.Substring(0, Math.Min(7, alt.lekérdezésfájl.Length));
					}
					Console.WriteLine();
					Console.Write("\t");
					result += "\r\n\t";
					foreach (ALT alt in ALT.szótár.Values)
					{
						Színes.Write($"\t[blue]{{{Monogram(alt.tipus)}}}");
						result += "\t" + Monogram(alt.tipus);
					}
					Console.WriteLine();
					result += "\r\n";
					int sum;
					foreach (Tanuló tanuló in Tanuló.szótár.Values)
					{
						Színes.Write($"[green]{{{Monogram(tanuló.név)}}}");
						result += Monogram(tanuló.név);

						// tanuló erre a tesztre kapott összes pontja
						sum = 0;
						foreach (ALT alt in ALT.szótár.Values)
						{
							sum += tanuló.tesztenkénti_pontjai[alt][this];
						}
						Színes.Write($"\t[blue]{{{sum}}} <-");

						result += "\t" + sum;
						foreach (ALT alt in ALT.szótár.Values)
						{
							Console.Write("\t");
							result += "\t";
							p = tanuló.tesztenkénti_pontjai[alt][this];
							switch (p)
							{
								case 1:
									Színes.Write($"[green]{{{p}}}");
									break;
								case 0:
									Színes.Write($"[yellow]{{{p}}}");
									break;
								case -1:
									Színes.Write($"[red]{{{p}}}");
									break;
								case -2:
									Színes.Write($"[magenta]{{{p}}}");
									break;
							}
							result += p.ToString();
						}
						Console.WriteLine();
						result += "\r\n";
					}
					// ITT ezt kéne megcsinálni, minden tesztenkénti mo-t kiírni külön fájlba

					string outputfájlnév = "testresult_" + this.név + ".txt";
					using (StreamWriter output = new StreamWriter(outputfájlnév))
					{
						output.WriteLine(result);
					}

				}
				public static void Eredmények_Összesítésének_Kiírása(string debug)
				{
					debug += "Teszt.Eredmények_Összesítésének_Kiírása" + dbj;

					Színes.WriteLine("---------------- " + debug + " ----------------------");
					Színes.WriteLine("A tesztek összesítése:");
					int p;

					Console.Write("\t");
					string result = "\t";
					foreach (ALT alt in ALT.szótár.Values)
					{
						Színes.Write("\t[blue]{" + alt.lekérdezésfájl.Substring(0, Math.Min(7, alt.lekérdezésfájl.Length)) + "}");
						result += "\t" + alt.lekérdezésfájl.Substring(0, Math.Min(7, alt.lekérdezésfájl.Length));
					}
					Console.WriteLine();
					Console.Write("\t");
					result += "\r\n\t";
					foreach (ALT alt in ALT.szótár.Values)
					{
						Színes.Write($"\t[blue]{{{Monogram(alt.tipus)}}}");
						result += "\t" + Monogram(alt.tipus);
					}
					Console.WriteLine();
					result += "\r\n";
					int sum;
					foreach (Tanuló tanuló in Tanuló.szótár.Values)
					{
						Színes.Write($"[green]{{{Monogram(tanuló.név)}}}");
						result += Monogram(tanuló.név);

						// tanuló összes pontja
						sum = 0;
						foreach (ALT alt in ALT.szótár.Values)
						{
							sum += tanuló.pontjai[alt];
						}
						Színes.Write($"\t[blue]{{{sum}}} <- ");

						result += "\t" + sum;
						foreach (ALT alt in ALT.szótár.Values)
						{
							Console.Write("\t");
							result += "\t";
							p = tanuló.pontjai[alt];

							if (tanuló.pontjai[alt] == Tanuló.megoldókulcs.pontjai[alt])
								Színes.Write($"[green]{{{p}}}");
							else if (tanuló.pontjai[alt] > 0)
								Színes.Write($"[yellow]{{{p}}}");
							else
								Színes.Write($"[red]{{{p}}}");
							result += p.ToString();
						}
						Console.WriteLine();
						result += "\r\n";
					}

					string eredménykönyvtárnév = "Results";
					string hibakönyvtár = $"{Directory.GetCurrentDirectory()}\\{eredménykönyvtárnév}";
					Directory.CreateDirectory(hibakönyvtár);

					Console.WriteLine("Add meg a fájlnevet (kiterjesztés nélkül), ahova menteni szeretnéd az eredményeket!");
					string outputfájlnév = $"{hibakönyvtár}\\table.txt";
					using (StreamWriter output = new StreamWriter(outputfájlnév))
					{
						output.WriteLine(result);
					}
					Színes.WriteLine($"A kapott pontok kiírva a [blue]{{{eredménykönyvtárnév}}} könyvtár tabulátorokkal tagolt [blue]{{table.txt}} állományba.");
					//				Clipboard.SetText(result);
					//			Console.WriteLine("Táblázat kimásolva a vágólapra.");

					StreamWriter tanulóhibakiíró;
					string hibafájlnév;

					// tanulónként külön fájlokba a hibák kiírása
					foreach (Tanuló tanuló in Tanuló.szótár.Values)
					{
						if (tanuló.hibalista.Count != 0)
						{
							hibafájlnév = $"{hibakönyvtár}\\Hibalista_{tanuló.név}.txt";
							using (tanulóhibakiíró = new StreamWriter(hibafájlnév))
							{
								foreach (string hiba in tanuló.hibalista)
								{
									tanulóhibakiíró.WriteLine(Színes.Fehérítő(hiba));
								}
							}
							Színes.WriteLine($"[green]{{{tanuló.név}}} hibái kiírva a [blue]{{{eredménykönyvtárnév}\\{hibafájlnév}}} fáljba [blue]{{({tanuló.hibalista.Count} db)}}.");
						}
					}

					// összes tanuló hibájának egy közös fájlba való kiírása
					Színes.WriteLine("[red]{+}  [blue]{---------------------------------}");
					hibafájlnév = $"{hibakönyvtár}\\!Hibalista_összesített.txt";
					using (tanulóhibakiíró = new StreamWriter(hibafájlnév))
					{
						foreach (Tanuló tanuló in Tanuló.szótár.Values)
						{
							foreach (string hiba in tanuló.hibalista)
							{
								tanulóhibakiíró.WriteLine(Színes.Fehérítő(hiba));
							}
						}
					}
					Színes.WriteLine($"[green]{{Tanulók}} hibái kiírva a [blue]{{{eredménykönyvtárnév}\\{hibafájlnév}}} fáljba [blue]{{({Tanuló.szótár.Values.Sum(x => x.hibalista.Count)} db)}}.");
				}
			}
			class Tanuló
			{
				#region Válasz class
				/// <summary>
				/// Egy válasz lényegében egy tábla txt-ben. És a hozzá kapcsolódó függvények, pl összehasonlítás, stb.
				/// </summary>
				class Válasz
				{
					readonly StreamReader f;
					readonly string adatbázis;
					readonly string lekérdezés;
					readonly Tanuló tulajdonos;
					public readonly Teszt teszt;
					public readonly ALT alt;
					readonly public string feladatnév;
					readonly string[,] tábla;
					readonly StringMultihalmaz halmaz;
					int[] Size = new int[2];
					public Válasz(string path, Tanuló tanuló, Teszt test, ALT a)
					{
						alt = a;
						teszt = test;
						tulajdonos = tanuló;
						feladatnév = Path2name(path);
						if (feladatnév.Split('_').Length >= 3) // adatbázisok esetéen egy feladatnév mindig így néz ki: output_cukraszda_4laktozmentes.txt
						{
							adatbázis = feladatnév.Split('_')[1];
							lekérdezés = feladatnév.Split('_')[2].Split('.')[0];
						}
						else // programok outputjai esetében nincsen adatbázisnév és lekérdezésnév, ott az csak így néz ki: output4.txt
						{
							adatbázis = "";
							lekérdezés = feladatnév.Split('.')[0];
						}

						List<string[]> beolvasástartalma = new List<string[]>();

						#region beolvasás: beolvasástartalma
						try
						{
							using (f = new StreamReader(path, Encoding.UTF8))
							{
								while (!f.EndOfStream)
								{
									beolvasástartalma.Add(f.ReadLine().Split('\t'));
								}
							}
						}
						catch (Exception)
						{
							Színes.WriteLine($"[red]{{{path}}} nem található.");
							beolvasástartalma.Add(new string[1] { nemválaszolt });
						}



						#endregion

						#region tábla kialakítása
						Size[0] = beolvasástartalma.Count;
						if (Size[0] != 0)
						{
							Size[1] = beolvasástartalma[0].Length;
							tábla = new string[Size[0], Size[1]];

							for (int i = 0; i < Size[0]; i++)
							{
								for (int j = 0; j < Size[1]; j++)
								{
									tábla[i, j] = beolvasástartalma[i][j];
								}
							}
						}
						else
						{
							tábla = new string[1, 1];
							tábla[0, 0] = "Üres a tábla!";
						}
						#endregion

						halmaz = new StringMultihalmaz(tábla, Size[0], Size[1]);

					}
					string[] Sort(int i)
					{
						string[] sor = new string[Size[1]];
						for (int j = 0; j < Size[1]; j++)
						{
							sor[j] = tábla[i, j];
						}
						return sor;
					}
					bool Tartalmazza(string[] sor)
					{
						bool megvan = false;
						for (int i = 0; i < Size[0] && !megvan; i++)
						{
							megvan = true;
							for (int j = 0; j < Size[1] && megvan; j++)
							{
								if (tábla[i, j] != sor[j])
								{
									megvan = false;
								}
							}
						}
						return megvan;
					}
					public static bool operator !=(Válasz v, Válasz w) { return !(v == w); }
					public static bool operator ==(Válasz v, Válasz m)
					{
						string hiba;
						if (v.tábla[0, 0].StartsWith("HIÁNYZIK"))
						{
							hiba = $"[red]{{Hiányzási hiba a [green]{{{v.tulajdonos.név}}} tanuló [blue]{{{v.teszt.név}}} tesztjének [blue]{{{v.lekérdezés}}} válaszában: {{{v.tábla[0, 0]}}}";
							Színes.WriteLine(hiba);
							v.tulajdonos.hibalista.Add(hiba);
							return false;
						}

						if (v.tábla[0, 0] == nemválaszolt)
						{
							hiba = $"[red]{{Nem válaszolt}}: [green]{{{v.tulajdonos.név}}} tanuló [blue]{{{v.teszt.név}}} tesztjének [blue]{{{v.lekérdezés}}} kérdésére nem válaszolt.";
							Színes.WriteLine(hiba);
							v.tulajdonos.hibalista.Add(hiba);
							return false;
						}


						if (v.Size[0] < m.Size[0]) // precautions
						{
							hiba = $"[red]{{Mérethiba (X<):}} [green]{{{v.tulajdonos.név}}} tanuló [blue]{{{v.teszt.név}}} tesztjének [blue]{{{v.lekérdezés}}} válaszában hiányzik [blue]{{{(m.Size[0] - v.Size[0]).ToString()}}} db sor.\n";
							Színes.WriteLine(hiba);
							v.tulajdonos.hibalista.Add(hiba);
							return false;
						}

						if (v.Size[0] > m.Size[0]) // precautions
						{
							hiba = $"[red]{{Mérethiba (X>):}} [green]{{{v.tulajdonos.név}}} tanuló [blue]{{{v.teszt.név}}} tesztjének [blue]{{{v.lekérdezés}}} válaszában több  ([blue]{{{(v.Size[0] - m.Size[0]).ToString()}}} db) sor van a kelleténél.\n";
							Színes.WriteLine(hiba);
							v.tulajdonos.hibalista.Add(hiba);
							return false;
						}

						if (v.Size[1] < m.Size[1]) // precautions
						{
							hiba = $"[red]{{Mérethiba (Y<):}} [green]{{{v.tulajdonos.név}}} tanuló [blue]{{{v.teszt.név}}} tesztjének [blue]{{{v.lekérdezés}}} válaszában hiányzik [blue]{{{(m.Size[1] - v.Size[1]).ToString()}}} db oszlop.\n";
							Színes.WriteLine(hiba);
							v.tulajdonos.hibalista.Add(hiba);
							return false;
						}

						if (v.Size[1] > m.Size[1]) // precautions
						{
							hiba = $"[red]{{Mérethiba (Y>):}} [green]{{{v.tulajdonos.név}}} tanuló [blue]{{{v.teszt.név}}} tesztjének [blue]{{{v.lekérdezés}}} válaszában több  ([blue]{{{(v.Size[1] - m.Size[1]).ToString()}}} db) sor van a kelleténél.\n";
							Színes.WriteLine(hiba);
							v.tulajdonos.hibalista.Add(hiba);
							return false;
						}

						string típus = ALT.szótár[v.lekérdezés].tipus;

						if (Regex.IsMatch(típus, @"^szám-\d*$"))
						{
							double mx = 0, vx = 0;
							int pontosság = int.Parse(típus.Split('-')[1]);

							if (v.tábla[0, 0] == m.tábla[0, 0]) return true; // erre csak azért van szükség, hogy ha pl. a keresés esetében "nincs a listában" lenne a válasz, akkor ne húzza ki az ilyen válaszokat.
							try
							{
								vx = Math.Round(double.Parse(v.tábla[0, 0]), pontosság);
								mx = Math.Round(double.Parse(m.tábla[0, 0]), pontosság);
							}
							catch (Exception)
							{
								hiba = $"[red]{{Típuseltérési hiba}}: [green]{{{v.tulajdonos.név}}} tanuló [blue]{{{v.teszt.név}}} tesztjének [blue]{{{v.lekérdezés}}} válaszában nem számmal válaszolt.";
								Színes.WriteLine(hiba);
								v.tulajdonos.hibalista.Add(hiba);
								return false;
							}

							if (mx != vx)
							{
								hiba = $"[red]{{rossz számérték}}: [green]{{{v.tulajdonos.név}}} tanuló [blue]{{{v.teszt.név}}} tesztjének [blue]{{{v.lekérdezés}}} válaszában rosszul számolt.";
								Színes.WriteLine(hiba);
								v.tulajdonos.hibalista.Add(hiba);
								return false;
							}

						}

						if (típus == "logikai")
						{
							if ((m.tábla[0, 0] != v.tábla[0, 0]))
							{
								hiba = $"[red]{{rossz logikai érték}}: [green]{{{v.tulajdonos.név}}} tanuló [blue]{{{v.teszt.név}}} tesztjének [blue]{{{v.lekérdezés}}} válaszában rosszul döntött.";
								Színes.WriteLine(hiba);
								v.tulajdonos.hibalista.Add(hiba);
								return false;
							}
						}

						if (típus == "rendezett halmaz")
						{
							for (int i = 0; i < v.Size[0]; i++)
							{
								for (int j = 0; j < v.Size[1]; j++)
								{
									if (v.tábla[i, j] != m.tábla[i, j])
									{
										hiba = $"[red]{{Rekord- vagy sorrendhiba:}} " +
											$"[green]{{{v.tulajdonos.név}}} tanuló a " +
											$"[blue]{{{v.teszt.név}}} teszt " +
											$"[blue]{{{v.lekérdezés}}} feladatában a(z) " +
											$"[blue]{{{i.ToString()}}}.sor " +
											$"[blue]{{{j.ToString()}}}.oszlopában: " +
											$"[green]{{{m.tábla[i, j]}}} helyett " +
											$"[red]{{{v.tábla[i, j]}}} szerepel.\n";
										Színes.WriteLine(hiba);
										v.tulajdonos.hibalista.Add(hiba);
										return false;
									}
								}
							}
						}

						if (típus == "multihalmaz" || típus == "halmaz")
						{
							if (v.halmaz == m.halmaz) return true;
							if (v.halmaz < m.halmaz || v.halmaz > m.halmaz)
							{
								(string hibácska, int k, int l) = Multihalmaz<string>.Részhalmaz_Első_Hibával(v.halmaz, m.halmaz);
								hiba = $"[red]{{Rekordhiba (multiplicitás):}} " +
										$"[green]{{{v.tulajdonos.név}}} tanuló " +
										$"[blue]{{{v.teszt.név}}} tesztre adott " +
										$"[blue]{{{v.lekérdezés}}} válaszában a " +
										$"[red]{{{hibácska}}} csak  " +
										$"[red]{{{k}}} alkalommal szerepel " +
										$"[blue]{{{l}}} helyett.\n";
								Színes.WriteLine(hiba);
								v.tulajdonos.hibalista.Add(hiba);
								return false;
							}
							hiba = $"[red]{{Rekordhiba (részhalmaz):}} " +
								$"[green]{{{v.tulajdonos.név}}} tanuló " +
									$"[blue]{{{v.teszt.név}}} tesztre adott " +
									$"[blue]{{{v.lekérdezés}}} válasza " +
									"és a megoldókulcs válasza közül egyik sem részhalmaza a másiknak.\n";
							Színes.WriteLine(hiba);
							v.tulajdonos.hibalista.Add(hiba);

							return false;
						}

						return true;
					}
				}
				#endregion

				public static Tanuló megoldókulcs;
				readonly bool ezamegoldókulcs;
				readonly string dirpath;
				public readonly string név;
				public static Dictionary<string, Tanuló> szótár = new Dictionary<string, Tanuló>();
				public List<string> hibalista = new List<string>();
				public Tanuló(string dp)
				{
					dirpath = dp;
					név = Path2name(dp);
					ezamegoldókulcs = név[0] == '!';
					if (ezamegoldókulcs) { megoldókulcs = this; } // Egyszerűsítés: ezamegoldókulcsot ki lehetne esetleg cserélni mindenhol Megoldókulcs.Equals(this)-re.
					szótár.Add(név, this);

				}
				private Dictionary<ALT, Dictionary<Teszt, Válasz>> Válaszai()
				{
					Dictionary<ALT, Dictionary<Teszt, Válasz>> válaszlista = new Dictionary<ALT, Dictionary<Teszt, Válasz>>();
					foreach (ALT alt in ALT.szótár.Values)
					{
						Dictionary<Teszt, Válasz> teszt_válaszai = new Dictionary<Teszt, Válasz>();
						foreach (Teszt teszt in Teszt.szótár.Values)
						{
							//						teszt_válaszai.Add(teszt, new Válasz(teszt.path + "\\" + this.név + "\\" + alt.adatbázisfájl.Split('.').First() + "_" + alt.lekérdezés + ".txt", this));
							teszt_válaszai.Add(teszt, new Válasz($"{teszt.path}\\{this.név}\\output_{alt.adatbázis}_{alt.lekérdezés}.txt", this, teszt, alt));
							if (debugmode)
							{
								Színes.WriteLine($"[green]{{{this.név}}} [blue]{{{teszt.név}}} tesztre adott [blue]{{{teszt_válaszai[teszt].feladatnév}}} válasza beolvasva.");
							}
						}
						válaszlista.Add(alt, teszt_válaszai);
					}
					return válaszlista;
				}
				public Dictionary<ALT, Dictionary<Teszt, int>> tesztenkénti_pontjai = new Dictionary<ALT, Dictionary<Teszt, int>>();
				public Dictionary<ALT, int> pontjai = new Dictionary<ALT, int>();
				//			static Dictionary<Tanuló, Dictionary<ALT, int>> ponttábla = new Dictionary<Tanuló, Dictionary<ALT, int>>();
				/// <summary>
				/// Minden tanulót lepontoz a megoldókulcs segítségével. (A megoldókulcs az utolsó !-jellel kezdődő tanulókönyvtár)
				/// </summary>
				/// <param name="debug"></param>
				public static void Pontozás(string debug)
				{
					debug += "Tanuló.Pontozás" + dbj;
					int sum = 0;
					Console.WriteLine("-----------------------------------------");
					Dictionary<ALT, Dictionary<Teszt, Válasz>> megoldás_válaszai = megoldókulcs.Válaszai(); // itt olvassa be a megoldókulcs összes kérdésre adott összes válaszát!
					foreach (Tanuló tanuló in Tanuló.szótár.Values)
					{
						Színes.Write("[green]{=====================}");
						Színes.Write("[green]{" + tanuló.név + "}");
						Színes.Write("[green]{=====================\n}");
						Dictionary<ALT, Dictionary<Teszt, Válasz>> tanuló_válaszai = tanuló.Válaszai(); // itt olvassa be az összes kérdésre az összes választ!
						foreach (ALT alt in tanuló_válaszai.Keys)
						{
							Dictionary<Teszt, int> tesztre_kapott_pont = new Dictionary<Teszt, int>();
							sum = 0;
							foreach (Teszt teszt in tanuló_válaszai[alt].Keys)
							{
								tesztre_kapott_pont.Add(teszt, (tanuló_válaszai[alt][teszt] == (megoldás_válaszai[alt][teszt])) ? 1 : 0);
								sum += tesztre_kapott_pont[teszt];
							}
							tanuló.tesztenkénti_pontjai.Add(alt, tesztre_kapott_pont);
							tanuló.pontjai[alt] = sum;
						}
					}
				}

				public static void Setup(string debug)
				{
					debug += "Tanuló.Setup" + dbj;

					Színes.WriteLine("Add meg, hogy mely könyvtárba lettek kiválogatva a dolgozatok! (A readme-ben az [green]{ide} könyvtár.)");
					Teszt.root = Színes.Be();

					#region Teszt-objektumok létrehozása
					Színes.WriteLine(debug + dbj + "[blue]{Teszt-objektumok létrehozása}");
					foreach (string path in Directory.EnumerateDirectories(Directory.GetCurrentDirectory() + "\\" + Teszt.root).Where(x => !Path2name(x).StartsWith("-")))
					{
						new Teszt(path);
					}
					#endregion

					#region Tanuló-objektumok létrehozása
					Színes.WriteLine(debug + dbj + "[blue]{Tanuló-objektumok létrehozása}");
					Tanuló t;
					foreach (string tanulópath in Directory.EnumerateDirectories(Teszt.szótár.Values.First().path))
					{
						if (tanulópath.Split('\\').Last()[0] != '-') // a kötőjellel kezdődőeket nem veszi figyelembe.
						{
							t = new Tanuló(tanulópath);
							Színes.Write(debug + $"[green]{{{t.név}}}");
							Console.Write(" tanuló inicializálva");
							if (t.ezamegoldókulcs)
							{
								Színes.Write(" [blue]{<-- ez a megoldókulcs!}");
							}
							Console.WriteLine();
						}
					}

					#endregion

					// létrehozza az ALT-okat.
					#region ALT (Adatbázis-Lekérdezés-Típus) rendezett hármasok beolvasása a setup.exe-ből.
					Színes.WriteLine(debug + dbj + "[blue]{ALT-objektumok létrehozása} (Adatbázis-Lekérdezés-Típus: rendezett hármasok beolvasása a setup.exe-ből.)");
					using (StreamReader f = new StreamReader("setup.txt", Encoding.UTF8))
					{
						while (!f.EndOfStream)
						{
							string sor = f.ReadLine();
							if (sor[0] != '%') // megjegyzés, nem mentjük el
							{
								new ALT(sor);
							}
						}
					}
					Színes.WriteLine(debug + "setup.txt beolvasva:");
					Színes.WriteLine("[blue]{adatbázis neve}\t[blue]{lekérdezés neve}\t -> \t[blue]{lekérdezés típusa}");
					Színes.WriteLine("---------------------------");
					foreach (ALT nnt in ALT.szótár.Values)
					{
						Console.WriteLine("{0}\t{1}\t -> \t{2}", nnt.adatbázisfájl, nnt.lekérdezésfájl, nnt.tipus);
					}
					#endregion
				}
			}
			static string Path2name(string s) { return s.Split('\\').Last(); }
			static string Monogram(string név)
			{
				string result = "";
				string[] névrészek = név.Split(' ');
				for (int i = 0; i < névrészek.Length; i++)
				{
					result += névrészek[i].Substring(0, 2);
				}
				return result;
			}
			static string dbj = " > ";

			public class ALT // Adatbázis-Lekérdezés-Típus hármasok
			{
				public string adatbázis;
				public string adatbázisfájl;
				public string lekérdezésfájl;
				public string lekérdezés;
				public string tipus;
				static string[] sorvektor;
				public static Dictionary<string, ALT> szótár = new Dictionary<string, ALT>();
				public ALT(string sor)
				{
					sorvektor = sor.Split('\t');
					adatbázisfájl = sorvektor[0];
					adatbázis = adatbázisfájl.Split('.')[0];
					lekérdezésfájl = sorvektor[1];
					lekérdezés = lekérdezésfájl.Split('.')[0];
					tipus = sorvektor[2];
					szótár.Add(lekérdezés, this);
				}
			}

			static void ReadmeP()
			{
				Színes.WriteLine("[red]{--------------------------------------------------------------}");
				Színes.WriteLine("\t [red]{README: PROGRAMTESZTELÉSHEZ} ");
				Színes.WriteLine("[red]{--------------------------------------------------------------}");
				Színes.WriteLine("[red]{E)\t Előkészületek}");
				Színes.WriteLine("[red]{--------------------------------------------------------------}");
				Színes.WriteLine("[red]{E-1)}\t Válassz egy [blue]{R} könyvtárat, ahova az összes tanuló és a megoldókulcs könyvtárát bemásolod. Mindegy, hogy mi a könyvtárak belső szerkezete. Figyelj viszont arra, hogy}");
				Színes.WriteLine("[red]{E-1.1}\t A tanulók könyvtárainak a neve legyen [red]{\"vezetéknév keresztnév\"}, tehát más szöveg (vagy 2-nél több szóköz) ne legyen benne, mert ronda lesz a vége.}");
				Színes.WriteLine("[red]{E-1.2}\t A megoldókulcs könyvtárneve kezdődjön felkiáltójellel ([red]{!}).");
				Színes.WriteLine("[red]{E-2)}\t A következő exe fájlokat gyűjtsd ki valahova: [blue]{Kiszedegető.exe}, [blue]{InputokSzétosztásaÉsAFuttatás.exe}, [blue]{Összehasonlító.exe}");
				Színes.WriteLine("[red]{E-3)}\t A programok teszteléséhez szükséges inputfájlok könyvtáraiból álló inputfájlrendszert gyűjtsd ki egy [blue]{I} könyvtárba.");
				Színes.WriteLine("[red]{E-4)}\t Hozz létre egy [green]{setup.exe}-t, amely néhány %-kal kezdődő sor (komment) után egy 3 oszlopos tabulátorokkal tagolt táblázatot tartalmaz. Az oszlopok tartalma: ");
				Színes.WriteLine("\t[red]{E-4.1) 1. oszlop:}\t A dolgozat címe. (Programteszteléskor ennek nincs jelentősége.)  ");
				Színes.WriteLine("\t[red]{E-4.2) 2. oszlop:}\t Az elemzendő outputfájl neve kiterjesztéssel együtt. ");
				Színes.WriteLine("\t[red]{E-4.3) 3. oszlop:}\t A tartalom típusa, ami az elemzéshez szükséges. A következő opciók állnak jelenleg rendelkezésre:");
				Színes.WriteLine("\t\t[red]{E-4.3.1) logikai:}\t A megoldás egy logikai érték, a [blue]{true}/[blue]{false} értékek valamelyike.");
				Színes.WriteLine("\t\t[red]{E-4.3.2) szám-}[green]{n}[red]{:}\t A megoldás egy szám, amelynek pontossága a megoldókulccsal [green]{n} tizedesjegyig meg kell egyezzen.");
				Színes.WriteLine("\t\t[red]{E-4.3.3) rendezett halmaz:}\t A megoldás egy tabulátorokkal tagolt táblázat, amelyben a rekordok sorrendje és multiplicitása számít.");
				Színes.WriteLine("\t\t[red]{E-4.3.4) multihalmaz:}\t a megoldás egy tabulátorokkal tagolt táblázat, amelyben a rekordok multiplicitása számít, de a sorrendjük nem.");
				Színes.WriteLine("\t\t[red]{E-4.3.5) halmaz:}\t ugyanaz, mint a multihalmaz, de ha a megoldókulcs megoldásában nincs multiplicitás, akkor nyilván ez lesz megkövetelve a tanulók megoldásaival szemben is.");
				Színes.WriteLine("[red]{E-5)}\t Figyeljünk oda arra, hogy a setup.txt-ben ne legyenek hibák. A vizsgálandó outputfájlokat és az összevetés módját is innen olvassa ki a program.");
				Színes.WriteLine("[red]{--------------------------------------------------------------}");
				Színes.WriteLine("[red]{K)\t Kiszedegetés:}");
				Színes.WriteLine("[red]{--------------------------------------------------------------}");
				Színes.WriteLine("[red]{K-1)}\t Tedd a [blue]{Kiszedegető.exe}-t az [blue]{R} könyvtárba.");
				Színes.WriteLine("[red]{K-2)}\t Ha pl. [red]{17} inputfájllal akarsz tesztelni, akkor futtasd le a [blue]{Kiszedegető.exe}-t a következő paraméterekkel:");
				Színes.WriteLine("[blue]{R} = [green]{.*\\.exe}, [blue]{F} = [green]{}, [blue]{C} = [green]{ide}, [blue]{O} = [green]{sok2}[red]{17} ");
				Színes.WriteLine("(Az [green]{ide} könyvtár ne kezdődjön kötőjellel ([red]{-}), mert attól összeakad a tesztelőprogram!)");
				Színes.WriteLine("[red]{--------------------------------------------------------------}");
				Színes.WriteLine("[red]{T)\t Tesztelés:}");
				Színes.WriteLine("[red]{--------------------------------------------------------------}");
				Színes.WriteLine("[red]{T-1)}\t Tedd az inputfájlos könyvtárakat tartalmazó könyvtárat (könyvtárak könyvtára!) az [green]{ide} könyvtárba. Mindenképp kötőjellel ([red]{-}) kezdődjön a fájlnév!");
				Színes.WriteLine("[red]{T-2)}\t Tedd a [blue]{InputokSzétosztásaÉsAFuttatás.exe}-t az [green]{ide} könyvtárba és futtasd le!");
				Színes.WriteLine("[red]{--------------------------------------------------------------}");
				Színes.WriteLine("[red]{Ö)\t Összehasonlítás a megoldókulccsal}");
				Színes.WriteLine("[red]{--------------------------------------------------------------}");
				Színes.WriteLine("[red]{Ö-1)}\t Futtassuk le az [blue]{Összehasonlító.exe}-t.");
				Színes.WriteLine("[red]{Ö-2)}\t A végén bekér majd egy fájlnevet, ahova elmentheti az eredményeket.");
				Színes.WriteLine("[red]{--------------------------------------------------------------}");
			}
			static void ReadmeAB()
			{
				Színes.WriteLine("\t [red]{README: ACCDB ADATBÁZISOK LEKÉRDEZÉSEINEK ÉS TÁBLÁINAK ELLENŐRZÉSÉHEZ} ");
				Színes.WriteLine("[red]{--------------------------------------------------------------}");
				Színes.WriteLine("[red]{------------- UNDER CONSTRUCTION ------------------------------}");
				Színes.WriteLine("[red]{--------------------------------------------------------------}");
				{

				}
			}
			[STAThreadAttribute]
			static void Main(string[] args)
			{
				Színes.Init();
				Színes.WriteLine("[red]{Adatbázisokat} szeretnél összevetni vagy [blue]{Programokat} tesztelni?");
				Színes.WriteLine("[red]{a}: Adatbázisok");
				Színes.WriteLine("[blue]{más}: Programtesztelés");

				if (Console.ReadKey().Key == ConsoleKey.A)
				{
					ReadmeAB();
				}
				else
				{
					ReadmeP();
				}

				debugmode = Színes.Be("\nNyomj egy entert, ha készen állsz! (debug-módhoz írd be azt is, hogy [blue]{debug}!)") == "debug";


				string debug = "";
				Tanuló.Setup(debug);
				Tanuló.Pontozás(debug);

				foreach (Teszt teszt in Teszt.szótár.Values)
				{
					teszt.Eredmények_Kiírása(debug);
				}
				Teszt.Eredmények_Összesítésének_Kiírása(debug);

				Színes.Be("A program futása véget ért, nyomj egy entert az ablak bezárásához!");
			}
		}

		static void Main(string[] args)
		{
			#region hogy működik
			/*
			 *	Ha nincs itt a megoldókulcs, 
			 *		szól.
			 *	Ha nincsenek itt az exe-k, 
  			 *	idemásolja őket.
  			 *	Lefuttatja a Kicsomagoló.exe-t.
			 *	
			 *	bemásolja a Kiszedegető.exe-t a megadott könyvtárba.
			 *	Lefuttatja a Kiszedegető.exe-t. Ez persze létrehoz majd egy könyvtárat és odapakolja az adatbázisokat tanulóstul.
			 *	Minden más könyvtárat törlünk.
			 *	Ebbe az új könyvtárba bemásolja az accdb2txt.exe-t
			 *	Ha nincsen setup.txt odakint
			 *		akkor megíratja a setup.txt-t odakintre.
			 *	Lemásolja erre a szintre a setup.txt-t.
			 *	Figyelmeztet, hogy ha vannak Like-ok, akkor baj lehet
			 *	Lefuttatja az accdb2txt.exe-t. 
			 *	Ha adódtak Like-os hibák, akkor azt mondja, hogy adódtak LIKE-ALIKE-hibák, és megkérdezi, hogy menjünk-e tovább mindenképp
			 *		kér egy "mehet"-et
			 *	Törli a setup.txt-t az alsó szintről.
			 *	Lefuttatja odafent a DBPEV.exe-t.
			 */
			#endregion

			string root = Directory.GetCurrentDirectory();
			if (!Directory.EnumerateFiles(root).Any(x => new Regex(@".*\![^\\]*\.zip").IsMatch(x)))
			{
				Console.WriteLine("Nincs megoldókulcs! Csinálj egy !-vel kezdődő zip-fájlt, amiben szerepel a megoldás!");
				return;
			}

			string ide_van_kicsomagolva = Kicsomagoló.Main(new string[0]);


		}
	}
}
