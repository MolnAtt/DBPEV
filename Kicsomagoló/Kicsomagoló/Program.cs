using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;


namespace Kicsomagoló
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("nyomj egy \"mehet\"-et, és kitömörít minden könyvtárat:");
			Console.Write("--> ");
			if (Console.ReadLine() == "mehet")
			{
				Console.WriteLine("Mondj egy új könyvtárnevet, hogy hova pakoljam a kicsomagolt fájlokat:");
				Console.Write("--> ");
				string könyvtárnév = Console.ReadLine();
				string ezakönyvtár = Directory.GetCurrentDirectory();
				Directory.CreateDirectory($"{ezakönyvtár}\\{könyvtárnév}");
				string ide;
				foreach (string zipfile in Directory.EnumerateFiles(ezakönyvtár).Where(x => new Regex(@".*\.zip").IsMatch(x)))
				{

					ide = $"{ezakönyvtár}\\{könyvtárnév}\\{zipfile.Split('\\').Last().Split('.').First()}";
					Directory.CreateDirectory(ide);
					ZipFile.ExtractToDirectory(zipfile, ide);
				}
			}
		}
	}
}
