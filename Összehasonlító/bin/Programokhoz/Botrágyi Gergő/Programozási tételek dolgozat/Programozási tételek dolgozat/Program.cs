using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Programozási_tételek_dolgozat
{
	class Program
	{
		static void Main(string[] args)
		{
			// I. feladatok
			Console.WriteLine("1.Hány szám található a megadott fájlban ?");
			StreamReader rI1 = new StreamReader("input-I.txt", Encoding.UTF8);
			StreamWriter wI1 = new StreamWriter("output1.txt");
			int dbI1 = 0;
			int iI1 = 0;
			while (!rI1.EndOfStream)
			{
				iI1 = int.Parse(rI1.ReadLine());
				dbI1++;
			}
			Console.WriteLine("A fájlban {0} szám található", dbI1);
			wI1.WriteLine(dbI1);
			wI1.Close();
			rI1.Close();

			//-----------------------------------------------------------------------------------------------

			Console.WriteLine("2. Mennyi a megadott fájlban található számok összege?");
			StreamReader rI2 = new StreamReader("input-I.txt", Encoding.UTF8);
			StreamWriter wI2 = new StreamWriter("output2.txt");
			int iI2 = 0;
			int sumI1 = 0;
			while (!rI2.EndOfStream)
			{
				iI2 = int.Parse(rI2.ReadLine());
				sumI1 = sumI1 + iI2;
			}
			Console.WriteLine("A fájlban található számok összege: {0}", sumI1);			
			wI2.WriteLine(sumI1);
			wI2.Close();
			rI2.Close();

			//-----------------------------------------------------------------------------------------------

			Console.WriteLine("3.Mennyi a megadott fájlban található számok átlaga ?");
			StreamReader rI3 = new StreamReader("input-I.txt", Encoding.UTF8);
			StreamWriter wI3 = new StreamWriter("output3.txt");
			int iI3 = 0;
			double sumI2 = (double)sumI1;
			double dbI2 = (double)dbI1; 
			Console.WriteLine("A fájlban található számok átlaga: {0:0.00}", sumI2/dbI2);
			wI3.WriteLine("{0:0.00}", sumI2/dbI2);
			wI3.Close();
			rI3.Close();

			//-----------------------------------------------------------------------------------------------
			// II. feladatok

			Console.WriteLine("4a) Van-e negatív páros szám a megadott fájlban?");
			StreamReader rII1 = new StreamReader("input-II.txt", Encoding.UTF8);
			StreamWriter wII1 = new StreamWriter("output4a.txt");
			int iII1 = 0;
			bool megvanII1 = false;
			while (!megvanII1 && !rII1.EndOfStream)
			{
				iII1 = int.Parse(rII1.ReadLine());
				if (iII1 < 0 && iII1 %2==0)
				{
					megvanII1 = true;
				}
			}
			Console.WriteLine(megvanII1 ? "Van!":"Nincs!");
			wII1.WriteLine(megvanII1);
			wII1.Close();
			rII1.Close();

			//-----------------------------------------------------------------------------------------------

			Console.WriteLine("4b) Válogasd ki / Szűrd ki a negatív páros számokat a fájlból!");
			StreamReader rII2 = new StreamReader("input-II.txt", Encoding.UTF8);
			StreamWriter wII2 = new StreamWriter("output4b.txt");
			int iII2 = 0;
			Console.WriteLine("A negatív páros számok:");
			while (!rII2.EndOfStream)
			{
				iII2 = int.Parse(rII2.ReadLine());
				if (iII2 < 0 && iII2 % 2 == 0)
				{
					Console.WriteLine(iII2);
					wII2.WriteLine(iII2);
				}				
			}					
			wII2.Close();
			rII2.Close();

			//-----------------------------------------------------------------------------------------------
			// III. feladatok

			Console.WriteLine("5a) Hány 50 és 100 közötti (az 50 és a 100 még benne van) szám található a fájlban?");
			StreamReader rIII1 = new StreamReader("input-III.txt", Encoding.UTF8);
			StreamWriter wIII1 = new StreamWriter("output5a.txt");
			int iIII1 = 0;
			int dbIII1 = 0;
			while (!rIII1.EndOfStream)
			{
				iIII1 = int.Parse(rIII1.ReadLine());
				if (iIII1 > 49 && iIII1 < 101)
				{
					dbIII1++;
				}
			}
			if (dbIII1 > 0)
			{
				Console.WriteLine("A fájlban {0} db 50 és 100 közé eső szám van.", dbIII1);
			}
			else
			{
				Console.WriteLine("Nincs ilyen szám!");
			}

			if (dbIII1>0)
			{
				wIII1.WriteLine(dbIII1);
			}
			else
			{
				wIII1.WriteLine("False");
			}
			wIII1.Close();
			rIII1.Close();

			//-----------------------------------------------------------------------------------------------

			Console.WriteLine("5b) Mennyi ezen számok összege? (tehát csak az 50 és 100 közé eső számok összege?)");
			StreamReader rIII2 = new StreamReader("input-III.txt", Encoding.UTF8);
			StreamWriter wIII2 = new StreamWriter("output5b.txt");
			int iIII2 = 0;
			int sumIII2 = 0;
			while (!rIII2.EndOfStream)
			{
				iIII2 = int.Parse(rIII2.ReadLine());
				if (iIII2 > 49 && iIII2 < 101)
				{
					sumIII2 = sumIII2 + iIII2;
				}
			}
			if (sumIII2 > 0)
			{
				Console.WriteLine("Ezen számok összege: {0}", sumIII2);
			}
			else
			{
				Console.WriteLine("Nincs ilyen szám");
			}

			if (sumIII2 > 0)
			{
				wIII2.WriteLine(sumIII2);
			}
			else
			{
				wIII2.WriteLine("False");
			}
			wIII2.Close();
			rIII2.Close();

			//-----------------------------------------------------------------------------------------------
			// IV. fealdatok

			Console.WriteLine("6a) Add meg a megadott fájlban található legkisebb számot!");
			StreamReader rIV = new StreamReader("input-IV.txt", Encoding.UTF8);
			StreamWriter wIV = new StreamWriter("output6.txt");
			int iIV = 0;
			int legkisebbIV = 0;			
			while (!rIV.EndOfStream)
			{
				iIV = int.Parse(rIV.ReadLine());
				if (iIV < legkisebbIV)
				{
					legkisebbIV = iIV;
				}
			}
			Console.WriteLine("A legkisebb szám a/az: {0}", legkisebbIV);
			wIV.WriteLine(legkisebbIV);
			wIV.Close();
			rIV.Close();

			//-----------------------------------------------------------------------------------------------
			// V. fealdatok

			Console.WriteLine("7. Mi az első 25-tel osztható szám?");
			StreamReader rV1 = new StreamReader("input-V.txt", Encoding.UTF8);
			StreamWriter wV1 = new StreamWriter("output7.txt");
			int iV1 = 0;			
			bool megvanV1 = false;
			while (!megvanV1 && !rV1.EndOfStream)
			{
				iV1 = int.Parse(rV1.ReadLine());
				if (iV1 %25 == 0)
				{
					megvanV1 = true;
				}
			}
			Console.WriteLine(megvanV1 ? "Az első 25-tel osztható szám a {0}":"Nincs ilyen szám", iV1);
			wV1.WriteLine(megvanV1? "{0}":"False", iV1);
			wV1.Close();
			rV1.Close();

			//-----------------------------------------------------------------------------------------------

			Console.WriteLine("8. Mi az első 25-tel osztható szám indexe?");
			StreamReader rV2 = new StreamReader("input-V.txt", Encoding.UTF8);
			StreamWriter wV2 = new StreamWriter("output8.txt");
			int iV2 = 0;
			bool megvanV2 = false;
			int indexiV2 = 0;
			while (!megvanV2&& !rV2.EndOfStream)
			{
				iV2 = int.Parse(rV2.ReadLine());
				indexiV2++;
				if (iV2 % 25 == 0)
				{
					megvanV2 = true;
				}
			}
			Console.WriteLine(megvanV2 ? "Az első 25-tel osztható szám indexe: {0}":"Nincs ilyen szám!", indexiV2);
			wV2.WriteLine(megvanV2 ? "{0}":"False", indexiV2);
			wV2.Close();
			rV2.Close();

			//-----------------------------------------------------------------------------------------------

			Console.WriteLine("9. Mi a legnagyobb 25-tel osztható szám?");
			StreamReader rV3 = new StreamReader("input-V.txt", Encoding.UTF8);
			StreamWriter wV3 = new StreamWriter("output9.txt");
			int iV3 = 0;
			int legnagyobb25 = 0;
			while (!rV3.EndOfStream)
			{
				iV3 = int.Parse(rV3.ReadLine());				
				if (iV3 % 25 == 0)
				{
					legnagyobb25 = iV3;
				}
			}
			Console.WriteLine("A legnagyobb 25-tel osztható szám a {0}", legnagyobb25);
			wV3.WriteLine(legnagyobb25);
			wV3.Close();
			rV3.Close();

			//-----------------------------------------------------------------------------------------------
			// VI. feladatok

			Console.WriteLine("10. Mi az utolsó 25-tel osztható szám?");
			StreamReader rVI1 = new StreamReader("input-VI.txt", Encoding.UTF8);
			StreamWriter wVI1 = new StreamWriter("output10.txt");
			int iVI1 = 0;
			int utolsó25 = 0;
			while (!rVI1.EndOfStream)
			{
				iVI1 = int.Parse(rVI1.ReadLine());
				if (iVI1 % 25 == 0)
				{
					utolsó25 = iV1;
				}
			}
			if (utolsó25 > 0)
			{
				Console.WriteLine("Az utolsó 25-tel osztható szám a {0}", utolsó25);
			}
			else
			{
				Console.WriteLine("Nincs ilyen szám!");
			}

			if (utolsó25 > 0)
			{
				wVI1.WriteLine(utolsó25);
			}
			else
			{
				wVI1.WriteLine("False");
			}
			wVI1.Close();
			rVI1.Close();

			//-----------------------------------------------------------------------------------------------

			Console.WriteLine("11. Mi az utolsó 25-tel osztható szám indexe?");
			StreamReader rVI2 = new StreamReader("input-VI.txt", Encoding.UTF8);
			StreamWriter wVI2 = new StreamWriter("output11.txt");
			int iVI2 = 0;
			int indexiVI2 = 0;
			int utolsó25indexe = 0;
			while (!rVI2.EndOfStream)
			{
				iVI2 = int.Parse(rVI2.ReadLine());
				indexiVI2++;
				if (iVI2 % 25 == 0)
				{
					utolsó25indexe = indexiVI2;
				}
			}
			if (utolsó25indexe > 0)
			{
				Console.WriteLine("Az utolsó 25-tel osztható indexe: {0}", utolsó25indexe);
			}
			else
			{
				Console.WriteLine("Nincs ilyen szám!");
			}

			if (utolsó25indexe>0)
			{
				wVI2.WriteLine(utolsó25indexe);
			}
			else
			{
				wVI2.WriteLine("False");
			}			
			wVI2.Close();
			rVI2.Close();

			//-----------------------------------------------------------------------------------------------

			Console.WriteLine("12. Mi a legnagyobb 25-tel osztható szám indexe?");
			StreamReader rVI3 = new StreamReader("input-VI.txt", Encoding.UTF8);
			StreamWriter wVI3 = new StreamWriter("output12.txt");
			int iVI3 = 0;
			int legnagyobb25indexe = 0;
			int indexVI3 = 0;
			while (!rVI3.EndOfStream)
			{
				iVI3 = int.Parse(rVI3.ReadLine());
				indexVI3++;
				if (iVI3 % 25 == 0)
				{
					legnagyobb25indexe = indexVI3;
				}
			}
			if (legnagyobb25indexe > 0)
			{
				Console.WriteLine("A legnagyobb 25-tel osztható szám indexe {0}", legnagyobb25indexe);
			}
			else
			{
				Console.WriteLine("Nincs ilyen szám!");
			}

			if (legnagyobb25indexe > 0)
			{
				wVI3.WriteLine(legnagyobb25indexe);
			}
			else
			{
				wVI3.WriteLine(legnagyobb25indexe);
			}
			
			wVI3.Close();
			rVI3.Close();

			//-----------------------------------------------------------------------------------------------
			//VII. feladatok

			Console.WriteLine("13. a) Előfordul-e olyan a sorozatban, hogy egy 3-mal osztható számot egy 10-zel osztható szám követ? ");
			StreamReader rVII1 = new StreamReader("input-VII.txt", Encoding.UTF8);
			StreamWriter wVII1 = new StreamWriter("output13a.txt");
			int iVII1 = 0;
			int készültségVII1 = 0;
			bool megvanVII1 = false;
			while (!megvanVII1 && !rVII1.EndOfStream)
			{
				iVII1 = int.Parse(rVII1.ReadLine());
				if (iVII1 %3 == 0)
				{
					készültségVII1 = 1;
				}

				if (készültségVII1 == 1)
				{
					if (iVII1 %10 == 0)
					{
						készültségVII1 = 2;
					}
				}
				megvanVII1 = készültségVII1 == 2;
			}
			Console.WriteLine(megvanVII1 ? "Előfordul":"Nem fordul elő!");
			wVII1.WriteLine(megvanVII1);
			wVII1.Close();
			rVII1.Close();

			//-----------------------------------------------------------------------------------------------

			Console.WriteLine("13.b) Ha előfordul ilyen, akkor mi ennek az előfordulásnak az indexe (a 3-mal osztható szám indexére gondolunk)");
			StreamReader rVII2 = new StreamReader("input-VII.txt", Encoding.UTF8);
			StreamWriter wVII2 = new StreamWriter("output13b.txt");
			int iVII2 = 0;
			int készültségVII2 = 0;
			int indexVII2 = 0;
			int azilyenszámindexe = 0;
			bool megvanVII2 = false;
			while (!megvanVII2 && !rVII2.EndOfStream)
			{				
				iVII2 = int.Parse(rVII2.ReadLine());
				indexVII2++;
				if (iVII2 % 3 == 0)
				{
					készültségVII2 = 1;					
				}

				if (készültségVII2 == 1)
				{
					if (iVII1 % 10 == 0)
					{
						készültségVII2 = 2;
						azilyenszámindexe = indexVII2;
					}
				}
				
				megvanVII2 = készültségVII2 == 2;
			}
			Console.WriteLine(megvanVII2 ? "Ennek az előfordulásnak az indexe: {0}" : "Nincs fordul elő!", azilyenszámindexe);
			wVII2.WriteLine();
			wVII2.Close();
			rVII2.Close();
		}
	}
}
