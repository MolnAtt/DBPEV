using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Németh_Balázs_Programozási_Tételek
{
	class Program
	{
		static void Main(string[] args)
		{
			StreamReader SR1 = new StreamReader("input-I.txt", Encoding.UTF8);
			StreamWriter SW1 = new StreamWriter("output1.txt");

			Console.WriteLine("Mennyi szám van a input-I.txt fajlban?");

			int elemekszáma = 0;

			while (!SR1.EndOfStream)
			{
				elemekszáma++;
				SR1.ReadLine();
			}

			Console.WriteLine("{0} szám van a input-I.txt fájlvan", elemekszáma);

			SW1.WriteLine(elemekszáma);
			SW1.Close();
			SR1.Close();

			Console.WriteLine("--------------------------------------------------------------------------------");
			/*
			StreamReader SR2 = new StreamReader("input-I.txt", Encoding.UTF8);
			StreamWriter SW2 = new StreamWriter("output2.txt");

			Console.WriteLine("Mennyi az elemek összege az input-I.txt fajlban?");

			double sum = 0;
			int mostani = 0;
			int tár = 0;

			while (!SR2.EndOfStream)
			{
				SR2.ReadLine();
				tár = int.Parse(SR2.ReadLine());
				mostani = tár;
				sum += mostani;
			}

			Console.WriteLine(sum);

			SW2.Close();
			SR2.Close();

			Console.WriteLine("--------------------------------------------------------------------------------");

			*/

			StreamReader SR3 = new StreamReader("input-II.txt", Encoding.UTF8);
			StreamWriter SW3a = new StreamWriter("output4a.txt");
			StreamWriter SW3b = new StreamWriter("output4b.txt");

			Console.WriteLine("Van-e negatív páros szám a megadott fájlban?");
			Console.WriteLine("Mennyi negatív páros szám van a megadott fájlban?");

			bool vanepárosneg = false;
			int párosnegszáma = 0;

			while (!SR3.EndOfStream)
			{
				SR3.ReadLine();
				if (int.Parse(SR3.ReadLine()) < 0 && int.Parse(SR3.ReadLine()) % 2 == 0)
				{
					vanepárosneg = true;
				}
				if (vanepárosneg)
				{
					párosnegszáma++;
				}

			}
			Console.WriteLine(vanepárosneg ? "van olyan szám" : "nincs olyan szám");
			SW3a.WriteLine(vanepárosneg);
			SW3a.Close();
			Console.WriteLine("{0} páros negatív szám van a megadott fájlban",párosnegszáma);
			if (!vanepárosneg)
			{
				SW3b.WriteLine(0);
			}
			else
			{
				SW3b.WriteLine(párosnegszáma);
			}
			SW3b.Close();

			Console.WriteLine("--------------------------------------------------------------------------------");

			/*StreamReader SR4 = new StreamReader("input-III.txt", Encoding.UTF8);
			StreamWriter SW4a = new StreamWriter("output4a.txt");

			Console.WriteLine("Mennyi 100 és 50 közötti szám van az adott fájlban?");

			int százésötvenközötti = 0;

			while (!SR4.EndOfStream)
			{
				SR4.ReadLine();
				if (int.Parse(SR4.ReadLine()) < 101 && int.Parse(SR4.ReadLine()) > 49)
				{
					százésötvenközötti++;
				}
			}
			Console.WriteLine(százésötvenközötti);

			Console.WriteLine("--------------------------------------------------------------------------------");

			*/
			/*
			StreamReader SR6 = new StreamReader("input-IV.txt", Encoding.UTF8);
			StreamWriter SW6a = new StreamWriter("output6a.txt");

			int mostani = int.Parse(SR6.ReadLine());
			int legkisebb = 0;

			while (!SR6.EndOfStream)
			{
				SR6.ReadLine();
				if (mostani < legkisebb)
				{
					legkisebb = mostani;
				}
			}
			Console.WriteLine(legkisebb);

			*/

			/*
			StreamReader SR10 = new StreamReader("input-VI.txt", Encoding.UTF8);
			StreamWriter SW10 = new StreamWriter("output10.txt");

			Console.WriteLine("Mi az utolsó 25-tel osztható szám?");

			int első25elsothatószám = 0;
			bool huszonötteloszthatószám = false;

			while (huszonötteloszthatószám && !SR10.EndOfStream)
			{
				SR10.ReadLine();
				if (int.Parse(SR10.ReadLine()) % 25 == 0)
				{
					első25elsothatószám = int.Parse(SR10.ReadLine());
					huszonötteloszthatószám = true;
				}
			}

			Console.WriteLine(első25elsothatószám);

			SW10.WriteLine(első25elsothatószám);
			*/
			
			StreamReader SR13 = new StreamReader("input-VII.txt", Encoding.UTF8);
			StreamWriter SW13a = new StreamWriter("output13a.txt");
			StreamWriter SW13b = new StreamWriter("output13b.txt");

			int index = 0;
			bool hárommaloszthatóttízzeloszthatókövet = false;

			while (!SR13.EndOfStream)
			{
				SR13.ReadLine();
				index++;
				if (int.Parse(SR13.ReadLine()) % 3 == 0)
				{
					SR13.ReadLine();
					index++;
					if (int.Parse(SR13.ReadLine()) % 10 == 0)
					{
						hárommaloszthatóttízzeloszthatókövet = true;
					}
				}
			}
			Console.WriteLine(hárommaloszthatóttízzeloszthatókövet);
			
		}
	}
}
