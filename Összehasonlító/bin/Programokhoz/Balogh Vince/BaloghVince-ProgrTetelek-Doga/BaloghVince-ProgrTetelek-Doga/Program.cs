using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BaloghVince_ProgrTetelek_Doga
{
	class Program
	{
		static void Main(string[] args)
		{
			// I. Feladat

			Console.WriteLine("I. feladat:");

			StreamReader I = new StreamReader("input-I.txt", Encoding.UTF8);
			StreamWriter w1 = new StreamWriter("output1.txt");
			StreamWriter w2 = new StreamWriter("output2.txt");
			StreamWriter w3 = new StreamWriter("output3.txt");

			int index = 0;
			int adottszam;
			int I1 = 0;

			while (!I.EndOfStream)
			{
				adottszam = int.Parse(I.ReadLine());

				I1 += adottszam;

				index++;
			}

			//1. feladat:
			Console.WriteLine("\n1. feladat:");
			Console.WriteLine("{0} darab szám található a sorozatban.", index);
			w1.WriteLine(index);

			//2. feladat:
			Console.WriteLine("\n2. feladat:");
			Console.WriteLine("A sorozatban található számok összege {0}.", I1);
			w2.WriteLine(I1);

			// 3. feladat:
			Console.WriteLine("\n3. Feladat");
			Console.WriteLine("A sorozatban található számok átlaga {0}.", I1 / index);
			w3.WriteLine(I1 / index);

			Console.WriteLine("\n-----------------------------------------------------------\n");

			I.Close();
			w1.Close();
			w2.Close();
			w3.Close();

			// ---------------------------------------------------------------------

			// II. Feladat:

			Console.WriteLine("II. feladat:");

			StreamReader II = new StreamReader("input-II.txt", Encoding.UTF8);
			StreamWriter w4a = new StreamWriter("output4a.txt");
			StreamWriter w4b = new StreamWriter("output4b.txt");

			// 4. feladat:

			bool II1 = false;
			string II2 = "";

			while (!II.EndOfStream)
			{
				adottszam = int.Parse(II.ReadLine());
				if (adottszam < 0 && adottszam % 2 == 0)
				{
					II1 = true;
					II2 += adottszam + ", ";
					w4b.WriteLine(adottszam);
				}
			}

			Console.WriteLine("\n4. a feladat:");
			Console.WriteLine(II1? "Van a sorozatban negatív páros szám." : "Sajnos a sorozatban nincs negatív páros szám.");
			w4a.WriteLine(II1);

			Console.WriteLine("\n 4. b feladat:");
			if (!II1)
			{
				Console.WriteLine("Sajnos a sorozatban nincs negatív páros szám.");
				w4b.WriteLine(II1);
			}
			else
			{
				Console.WriteLine("A sorozatba ntalálható negatív páros számok:\n{0}", II2);
			}

			Console.WriteLine("\n-----------------------------------------------------------\n");


			II.Close();
			w4a.Close();
			w4b.Close();

			// ---------------------------------------------------------------------

			// III. feladat:

			Console.WriteLine("III. feladat:");

			StreamReader III = new StreamReader("input-III.txt", Encoding.UTF8);
			StreamWriter w5a = new StreamWriter("output5a.txt");
			StreamWriter w5b = new StreamWriter("output5b.txt");

			int III1 = 0;
			int III2 = 0;

			while (!III.EndOfStream)
			{
				adottszam = int.Parse(III.ReadLine());

				if (50 <= adottszam && adottszam <= 100)
				{
					III1++;
					III2 += adottszam;
				}
			}

			// 5. b
			Console.WriteLine("\n5. a feladat:");
			Console.WriteLine("A sorozatban {0} darab 50 és 100 közötti szám van.", III1);
			w5a.WriteLine(III1);

			//5. a
			Console.WriteLine("\n5. b feladat:");
			Console.WriteLine("A sorozatban található 50 és 100 közötti számok összega {0},", III2);
			w5b.WriteLine(III2);

			Console.WriteLine("\n-----------------------------------------------------------\n");

			III.Close();
			w5a.Close();
			w5b.Close();

			// ---------------------------------------------------------------------

			// IV. feladat:

			Console.WriteLine("IV. feladat:");

			StreamReader IV = new StreamReader("input-IV.txt", Encoding.UTF8);
			StreamWriter w6 = new StreamWriter("output6.txt");

			int IV1 = 0;
			index = 0;

			while (!IV.EndOfStream)
			{
				adottszam = int.Parse(IV.ReadLine());
				if (index == 0)
				{
					IV1 = adottszam;
				}
				if (adottszam < IV1)
				{
					IV1 = adottszam;
				}
				index++;
			}

			Console.WriteLine("\n 6. Feladat");
			Console.WriteLine("A sorozatban található legkisebb szám {0}.", IV1);
			w6.WriteLine(IV1);

			Console.WriteLine("\n-----------------------------------------------------------\n");

			IV.Close();
			w6.Close();

			// ---------------------------------------------------------------------

			// V. feladat:

			Console.WriteLine("V. feladat:");

			StreamReader V = new StreamReader("input-V.txt", Encoding.UTF8);
			StreamWriter w7 = new StreamWriter("output7.txt");
			StreamWriter w8 = new StreamWriter("output8.txt");
			StreamWriter w9 = new StreamWriter("output9.txt");

			int V1 = 0;
			int V2 = 0;
			int V3 = 0;
			index = 0;

			while (!V.EndOfStream)
			{
				adottszam = int.Parse(V.ReadLine());

				if (V1 == 0 && adottszam % 25 == 0)
				{
					V1 = adottszam;
					V2 = index;
					if (adottszam < V3)
					{
						V3 = adottszam;
					}
				}
				index++;
			}

			// 7. feladat:
			Console.WriteLine("\n7. feladat:");
			Console.WriteLine("A sorozatban található első 25-tel osztható szám {0}.", V1);
			w7.WriteLine(V1);

			//8. feladat:
			Console.WriteLine("\n8. feladat:");
			Console.WriteLine("A sorozatban található első 25-tel osztható szám indexe {0}.", V2);
			w8.WriteLine(V2);

			//9. feladat:
			Console.WriteLine("\n9. feladat:");
			Console.WriteLine("A sorozatban található legnagyobb 25-tel osztható szám {0}.", V3);
			w9.WriteLine(V3);

			Console.WriteLine("\n-----------------------------------------------------------\n");

			V.Close();
			w7.Close();
			w8.Close();
			w9.Close();

			// ---------------------------------------------------------------------

			// VI. feladat:
			Console.WriteLine("VI. feldat:");

			StreamReader VI = new StreamReader("input-VI.txt", Encoding.UTF8);
			StreamWriter w10 = new StreamWriter("output10.txt");
			StreamWriter w11 = new StreamWriter("output11.txt");
			StreamWriter w12 = new StreamWriter("output12.txt");

			int VI1 =-1;
			int VI2 = 0;
			int VI3 = -1;
			index = 0;

			while (!VI.EndOfStream)
			{
				adottszam = int.Parse(VI.ReadLine());

				if (VI1 == -1 && adottszam % 25 == 0)
				{
					VI1 = adottszam;
					VI2 = index;
					if (adottszam < V3)
					{
						VI3 = adottszam;
					}
				}
				index++;
			}

			
			if (VI1 == -1)
			{
				Console.WriteLine();
				Console.WriteLine("Sajnos nincs a sorozatban 25-tel osztható szám;");
				w10.WriteLine(false);
				w11.WriteLine(false);
				w12.WriteLine(false);
			}
			else
			{
				// 10. feladat:
				Console.WriteLine("\n 10. feladat:");
				Console.WriteLine("A sorozatban található első 25-tel osztható szám {0}.", V1);
				w10.WriteLine(V1);

				// 11. feladat:
				Console.WriteLine("\n11. feladat:");
				Console.WriteLine("A sorozatban található első 25-tel osztható szám indexe {0}.", V2);
				w11.WriteLine(V2);

				// 12. feladat:
				Console.WriteLine("\n12. feladat:");
				Console.WriteLine("A sorozatban található legnagyobb 25-tel osztható szám {0}.", V3);
				w12.WriteLine(V3);
			}



			Console.WriteLine("\n-----------------------------------------------------------\n");

			VI.Close();
			w10.Close();
			w11.Close();
			w12.Close();

			// ---------------------------------------------------------------------

			// VII. feladat:

			Console.WriteLine("VI. feldat:");

			StreamReader VII = new StreamReader("input-VII.txt", Encoding.UTF8);
			StreamWriter w13a = new StreamWriter("output13a.txt");
			StreamWriter w13b = new StreamWriter("output13b.txt");

			int VII1 = 0;
			bool VII2 = false;
			int VII3 = 0;
			index = 0;
			adottszam = 0;
			bool megvane = false;

			while (!VII.EndOfStream && !megvane)
			{
				VII1 = adottszam;
				adottszam = int.Parse(VII.ReadLine());

				if (VII1 % 3 == 0 && adottszam % 10 == 0)
				{
					VII2 = true;
					VII3 = index - 1;
					megvane = true;
				}

				index++;
			}

			if (VII2)
			{
				// 13. a feladat:
				Console.WriteLine("13. a feladat:");
				Console.WriteLine("Van a sorozatban olyan 3-mal osztható szám, melyte egy 10-zel osztható szám követ.");
				w13a.WriteLine(VII2);

				// 13. b feladat:
				Console.WriteLine("13. b feladat:");
				Console.WriteLine("Az első olyan 3-mal osztható szám indexe, melyet egy 10-zel osztahtó szám követ {0}.", VII3);
				w13b.WriteLine(VII3);
			}
			else
			{
				Console.WriteLine("Sajnos nincs a sorozatban olyan 3-mal osztható szám, melyet egy 10-zel osztahtó szám követ.");
				w13a.WriteLine(false);
				w13b.WriteLine(false);
			}

			VII.Close();
			w13a.Close();
			w13b.Close();
		}
	}
}
