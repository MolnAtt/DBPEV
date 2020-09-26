using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Kiszedegető
{
	#region Fájlkezelés class
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
	#endregion
	#region Színes class
	static class Színes
	{
		private static string Intervallum(string s, int a, int b)
		{
			return s.Substring(a + 1, b - a - 3);
		}
		private static void Színtvált(string szín)
		{
			switch (szín)
			{
				case "blue":
					Console.ForegroundColor = ConsoleColor.Blue;
					break;
				case "white":
					Console.ForegroundColor = ConsoleColor.White;
					break;
				case "red":
					Console.ForegroundColor = ConsoleColor.Red;
					break;
				case "green":
					Console.ForegroundColor = ConsoleColor.Green;
					break;
				case "yellow":
					Console.ForegroundColor = ConsoleColor.Yellow;
					break;
				default:
					Console.ForegroundColor = ConsoleColor.DarkRed;

					break;
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
	}
	#endregion
	class Program
	{	
		#region Main method
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
			List<string> options = new List<string> { "1", "2"};
			int cardinality;
			do { O = Console.ReadLine(); } while (!options.Contains(O) && !(O.StartsWith("sok2")&& int.TryParse(O.Substring(4),out cardinality)));
			
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
								célkönyvtár = célkönyvtárindexnélkül +(i + 1).ToString() + "\\";
								Directory.CreateDirectory( célkönyvtár + Fájlkezelés.Path2Név(D_i));
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
		#endregion
	}
}
