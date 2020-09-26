using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProgramozásiTételek
{
	class Program
	{
		static void Main(string[] args)
		{
			StreamReader r1 = new StreamReader("input-I.txt", Encoding.Default);
			StreamWriter w1 = new StreamWriter("output1.txt");
			Console.WriteLine("1. Hány szám található a megadott fájlban?");

			int i1 = 0;
			while (!r1.EndOfStream)
			{
				r1.ReadLine();
				i1++;
			}

			Console.WriteLine("A fájlban {0} db szám van.", i1);
			w1.WriteLine(i1);

			w1.Close();
			r1.Close();



			StreamReader r2 = new StreamReader("input-I.txt", Encoding.Default);
			StreamWriter w2 = new StreamWriter("output2.txt");
			Console.WriteLine("2. Mennyi a megadott fájlban a számok összege?");

			int összeg2 = 0;
			int szam2 = 0;
			while (!r2.EndOfStream)
			{
				szam2 = int.Parse(r2.ReadLine());
				összeg2 += szam2;
			}
			Console.WriteLine("A fájlban a számok összege: {0}", összeg2);
			w2.WriteLine(összeg2);

			w2.Close();
			r2.Close();



			StreamReader r3 = new StreamReader("input-I.txt", Encoding.Default);
			StreamWriter w3 = new StreamWriter("output3.txt");
			Console.WriteLine("3. Mennyi a megadott fájlban található számok átlaga?");

			double átlag3 = 0;
			int összeg3 = 0;
			int szam3 = 0;
			int mennyiség3 = 0;
			while (!r3.EndOfStream)
			{
				szam3 = int.Parse(r3.ReadLine());
				összeg3 += szam3;
				mennyiség3++;
			}
			átlag3 = (double)összeg3 / mennyiség3;
			Console.WriteLine("A fájlban a számok átlaga: {0:0.00}", átlag3);
			w3.WriteLine(átlag3);

			w3.Close();
			r3.Close();


			StreamReader r4 = new StreamReader("input-II.txt", Encoding.Default);
			StreamWriter w4a = new StreamWriter("output4a.txt");
			StreamWriter w4b = new StreamWriter("output4b.txt");
			Console.WriteLine("4a. Van-e negatív páros szám a megadott fájlban?");
			Console.WriteLine("4b. Negatív, páros számok:");

			bool megvan4 = false;
			int i4 = 0;
			while (!megvan4 && !r4.EndOfStream)
			{
				if (int.Parse(r4.ReadLine()) < 0 && int.Parse(r4.ReadLine()) % 2 == 0)
				{
					megvan4 = true;
			        Console.WriteLine(megvan4 ? "4a: Van a sorozatban negatív, páros szám." : "4a: Nincs a sorozatban negatív, páros szám.");
				}

				i4 = int.Parse(r4.ReadLine());
				if (i4 < 0 && i4 % 2 == 0)
				{
					Console.WriteLine(i4);
				}
			}
			
			w4a.WriteLine(megvan4);
			w4b.WriteLine(i4);

			w4a.Close();
			w4b.Close();
			r4.Close();



			StreamReader r5 = new StreamReader("input-III.txt", Encoding.Default);
			StreamWriter w5a = new StreamWriter("output5a.txt");
			StreamWriter w5b = new StreamWriter("output5b.txt");
			Console.WriteLine("5a. Hány 50 és 100 közötti (az 50 és a 100 még benne van) szám található a fájlban?");
			Console.WriteLine("5b. Írjuk ki az 50 és 100 közötti számokat:");

			int i5 = 0;
			while (!r5.EndOfStream && i5 < 101 && i5 > 49)
			{
				if (i5 < 101 && i5 > 49)
				{
					i5++;
				}

				i5 = int.Parse(r5.ReadLine());
				if (i5 < 101 && i5 > 49)
				{
					Console.WriteLine(i5);
				}

			}
			Console.WriteLine("5a: {0} db szám található 50 és 100 között.", i5);
			Console.WriteLine("50 és 100 közötti számok:", i5);
			w5a.WriteLine(i5);
			w5b.WriteLine();
			
			w5a.Close();
			w5b.Close();
			r5.Close();



			StreamReader r6 = new StreamReader("input-IV.txt", Encoding.Default);
			StreamWriter w6 = new StreamWriter("output6.txt");
			Console.WriteLine("6. Írjuk ki a legkisebb számot:");
			int jelenlegi_legkisebb = 0;
			int lehetséges_legkisebb = 0;
			bool elsőbeolvasas = false;
			while (!r6.EndOfStream)
			{
				if (elsőbeolvasas == false)
				{
					jelenlegi_legkisebb = int.Parse(r6.ReadLine());
					elsőbeolvasas = true;
				}
				lehetséges_legkisebb = int.Parse(r6.ReadLine());
				if (lehetséges_legkisebb < jelenlegi_legkisebb)
				{
					jelenlegi_legkisebb = lehetséges_legkisebb;
				}
			}
			Console.WriteLine("A legkisebb szám: {0}", jelenlegi_legkisebb);
			w6.WriteLine(jelenlegi_legkisebb);

			r6.Close();
			w6.Close();



			StreamReader r7 = new StreamReader("input-V.txt", Encoding.Default);
			StreamWriter w7 = new StreamWriter("output7.txt");
			Console.WriteLine("7. Mi az első 25-tel osztható szám?");

			int o25 = 0;
			bool megvan7 = false;
			while (!r7.EndOfStream && !megvan7)
			{
				o25 = int.Parse(r7.ReadLine());
				if (o25 % 25 == 0)
				{					
					megvan7 = true;
				}			
			}
			Console.WriteLine("Az első 25-tel osztható szám: {0}", o25);
			w7.WriteLine(o25);

			w7.Close();
			r7.Close();



			StreamReader r8 = new StreamReader("input-V.txt", Encoding.Default);
			StreamWriter w8 = new StreamWriter("output8.txt");
			Console.WriteLine("8. Mi az első 25-tel osztható szám indexe?");

			int o25i = 0;
			int i8 = 0;
			bool megvan8 = false;
			while (!r8.EndOfStream && !megvan8)
			{
				o25i = int.Parse(r8.ReadLine());
				if (o25i % 25 == 0)
				{
					megvan8 = true;
				}
				i8++;
			}
			Console.WriteLine("Az első 25-tel osztható szám indexe: {0}", i8);
			w8.WriteLine(i8);

			w8.Close();
			r8.Close();



			StreamReader r9 = new StreamReader("input-V.txt", Encoding.Default);
			StreamWriter w9 = new StreamWriter("output9.txt");
			Console.WriteLine("9. Mi az első 25-tel osztható szám indexe?");

			int eo25 = 0;
			int jelenlegi_legnagyobb = 0;
			int lehetséges_legnagyobb = 0;
			bool elsőbeolvasas2 = false;
			while (!r9.EndOfStream)
			{
				if (elsőbeolvasas2 == false)
				{
					jelenlegi_legnagyobb = int.Parse(r9.ReadLine());
					elsőbeolvasas2 = true;
				}
				lehetséges_legnagyobb = int.Parse(r9.ReadLine());
				if (lehetséges_legnagyobb < jelenlegi_legnagyobb)
				{
					if (eo25 % 25 == 0)
					{
						jelenlegi_legnagyobb = lehetséges_legnagyobb;
					}
				}
			}
			Console.WriteLine("A legnagyobb 25-tel osztható szám: {0}", jelenlegi_legnagyobb);
			w9.WriteLine(jelenlegi_legnagyobb);

			w9.Close();
			r9.Close();



			StreamReader r10 = new StreamReader("input-VI.txt", Encoding.Default);
			StreamWriter w10 = new StreamWriter("output10.txt");
			Console.WriteLine("10. Mi az utolsó 25-tel osztható szám?");

			bool nincs = false;
			int u25 = 1;
			int adottszam10 = 0;
			while (!r10.EndOfStream)
			{
				adottszam10 = int.Parse(r10.ReadLine());
				if (adottszam10 % 25 == 0)
				{
					u25 = adottszam10;
				}
			}
			if (u25 == 1)
			{
				Console.WriteLine("Nincs ilyen elem.");
				w10.WriteLine(nincs);
			}
			else
			{
				Console.WriteLine("Az utolsó ilyen szám: {0}", u25);
				w10.WriteLine(u25);
			}

			r10.Close();
			w10.Close();



			StreamReader r11 = new StreamReader("input-VI.txt", Encoding.Default);
			StreamWriter w11 = new StreamWriter("output11.txt");
			Console.WriteLine("11. Mi az utolsó 25-tel osztható szám indexe?");

			bool nincs2 = false;
			int u252 = 1;
			int adottszam11 = 0;
			int i11 = 0;
			int veglegesindex = 0;
			while (!r11.EndOfStream)
			{
				i11++;
				adottszam11 = int.Parse(r11.ReadLine());
				if (adottszam11 % 25 == 0)
				{
					u252 = adottszam11;
					veglegesindex = i11;
				}
			}
			if (u252 == 1)
			{
				Console.WriteLine("Nincs ilyen elem.");
				w11.WriteLine(nincs);
			}
			else
			{
				Console.WriteLine("Az utolsó ilyen szám indexe: {0}", veglegesindex);
				w11.WriteLine(veglegesindex);
			}

			r11.Close();
			w11.Close();



			StreamReader r12 = new StreamReader("input-VI.txt", Encoding.Default);
			StreamWriter w12 = new StreamWriter("output12.txt");
			Console.WriteLine("12. ?");

			bool nincs3 = false;
			int u253 = 1;
			int adottszam12 = 0;
			int jelenlegi_legnagyobb2 = 0;
			int lehetséges_legnagyobb2 = 0;
			bool elsőbeolvasas3 = false;
			while (!r12.EndOfStream)
			{
				if (elsőbeolvasas3 == false)
				{
					jelenlegi_legnagyobb2 = int.Parse(r12.ReadLine());
					elsőbeolvasas3 = true;
				}
				lehetséges_legnagyobb2 = int.Parse(r12.ReadLine());
				if (lehetséges_legnagyobb2 < jelenlegi_legnagyobb2)
				{
					if (eo25 % 25 == 0)
					{
						jelenlegi_legnagyobb2 = lehetséges_legnagyobb2;
					}
				}		
			
				adottszam12 = int.Parse(r12.ReadLine());
				if (adottszam11 % 25 == 0)
				{
					u253 = adottszam12;
				}
			}
			if (u253 == 1)
			{
				Console.WriteLine("Nincs ilyen elem.");
				w12.WriteLine(nincs3);
			}
			else
			{
				Console.WriteLine("Az utolsó ilyen szám indexe: {0}", veglegesindex);
				w12.WriteLine(veglegesindex);
			}

			r12.Close();
			w12.Close();



			StreamReader r13 = new StreamReader("input-VII.txt", Encoding.Default);
			StreamWriter w13 = new StreamWriter("output13.txt");
			Console.WriteLine("13. Előfordul-e olyan a sorozatban, hogy egy 3-mal osztható számot egy 10-zel osztható szám követ?");

			bool megvan13 = false;
			int szam13 = 0;
			bool három = false;
			bool tíz = false;
			while (!r13.EndOfStream && !megvan13)
			{
				szam13 = int.Parse(r13.ReadLine());
				if (szam13 %3 == 0)
				{
					három = true;

				}

				if (három == true && szam13 %10 == 0)
				{
					tíz = true;
				}
				else
				{
					három = false;
				}
				if (tíz = true)
				{
					megvan13 = true;
				}
			}
			if (tíz = true)
			{
				Console.WriteLine("Előfordul.");
				w13.WriteLine(tíz);
			}
			else
			{
				Console.WriteLine("Nem fordul elő.");
				w13.WriteLine(tíz);
			}

			w13.Close();
			r13.Close();
		}
	}
}
