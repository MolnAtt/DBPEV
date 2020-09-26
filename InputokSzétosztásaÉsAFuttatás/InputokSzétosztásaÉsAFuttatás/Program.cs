using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace InputokSzétosztásaÉsAFuttatás
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
		static void Main(string[] args)
		{
			Színes.WriteLine("[red]{Input} Egy programhoz tartozó [blue]{I_i} input nem más, \n\tmint egy könyvtár, amiben az adott program által igényelt inputfájlok vannak. \n\t(Lehetséges ugyanis, hogy több inputot is igényel ugyanaz a dolgozatprogram.)");
			Színes.WriteLine("[red]{Inputkönyvtár:} Egy programhoz tartozó [blue]{I} inputkönyvtár tehát nem más, \n\tmint azonos nevű inputfájlokat tartalmazó [red]{könyvtárak könyvtára}.");
			Színes.WriteLine("[red]{Kiszedegetés után:} Futtasd le a [green]{Kiszedegetés.exe} programot a [blue]{sok2}[red]{n} funkcióval. \n\tÍgy kapsz egy [blue]{D} könyvtárat, benne a [blue]{D_1}, ..., [blue]{D_n} tanulók neveiről elnevezett könyvtárakkal, \n\tamikben egy-egy .exe fájlt fognak tartalmazni.");
			Színes.WriteLine("[red]{Előkészítés} Másold be a [blue]{D} könyvtárba az [blue]{I} könyvtárat, \n\tés ha nem [red]{-} jellel kezdődne, írj elé egyet. \n\t(Ez jelzi a programnak, hogy itt lesznek az inputfájlok. Csak egy inputkönyvtárad legyen itt.)");
			Színes.WriteLine("[red]{Inputok elhelyezése} Nyomj egy entert.");


			while (Console.ReadKey().Key != ConsoleKey.Enter) { }
			#region Inputok elhelyezése
			string itt = Directory.GetCurrentDirectory();
			string inputkönyvtár = Directory.EnumerateDirectories(itt).Where(x => Fájlkezelés.Path2Név(x).StartsWith("-")).First();
			List<string> inputkönyvtárak = Directory.EnumerateDirectories(inputkönyvtár).ToList();
			List<string> tesztkönyvtárak = Directory.EnumerateDirectories(itt).Where(x => !Fájlkezelés.Path2Név(x).StartsWith("-")).ToList();
			if (inputkönyvtárak.Count() > tesztkönyvtárak.Count())
			{
				Színes.WriteLine("[red]{Több input van, mint ahány tesztkönyvtár! Törölj inputokat vagy hozz létre több könyvtárat és próbáld újra! }");
			}
			else
			{
				if (inputkönyvtárak.Count() < tesztkönyvtárak.Count())
				{
					Színes.WriteLine("[red]{Kevesebb input van, mint ahány tesztkönyvtár! Néhány tesztkönvytár üresen fog maradni! }");
					Console.ReadKey();
				}

				for (int i = 0; i < inputkönyvtárak.Count(); i++)
				{
					foreach (string tanulópath in Directory.EnumerateDirectories(tesztkönyvtárak[i]))
					{
						foreach (string inputfájl in Directory.EnumerateFiles(inputkönyvtárak[i]))
						{
							// Színes.WriteLine(inputfájl + " [red]{->} " + tanulópath);
							File.Copy(inputfájl, tanulópath + "//" + Fájlkezelés.Path2Név(inputfájl), true);							
						}
					}
				}

				#endregion
				Színes.WriteLine("[red]{Programok futtatása} Nyomj egy entert.");
				while (Console.ReadKey().Key != ConsoleKey.Enter) { }
				foreach (string tesztkönyvtár in tesztkönyvtárak)
				{
					foreach (string tanulókönyvtár in Directory.EnumerateDirectories(tesztkönyvtár))
					{
						Színes.WriteLine("--------- " + Fájlkezelés.Path2Név(tanulókönyvtár) + " következik --------- ");
						Fájlkezelés.Fájl_Futtatása(tanulókönyvtár, Directory.EnumerateFiles(tanulókönyvtár).Where(x => Regex.IsMatch(x, @".*\.exe$")).First());
						Színes.WriteLine("--------- " + Fájlkezelés.Path2Név(tanulókönyvtár) + " programjának vége --------- ");
					}
				}
				#region Programok futtatása

				#endregion
				Színes.WriteLine("[red]{Továbbiak} Menj át az Összehasonlítás.exe-re. ");
			}

			Színes.WriteLine("[red]{Kilépés} Nyomj egy q-t a kilépéshez. ");
			while (Console.ReadKey().Key != ConsoleKey.Q) { }


		}
	}
}
