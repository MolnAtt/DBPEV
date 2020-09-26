using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace programoz
{
	class Program
	{
		static void Main(string[] args)
		{
			// I.
			StreamReader r1 = new StreamReader("input-I.txt", Encoding.UTF8);
			StreamWriter w1 = new StreamWriter("output1.txt");
			StreamWriter w2 = new StreamWriter("output2.txt");
			StreamWriter w3 = new StreamWriter("output3.txt");

			double i1 = 0;
			double i2 = 0;
			while (!r1.EndOfStream)
			{

				i2 += int.Parse(r1.ReadLine());
				i1++;
			}
			double i3 = i2 / i1;
			r1.Close();

			Console.WriteLine("\n1.Hány szám található a megadott fájlban ?");
			Console.WriteLine("{0} szám található a fájlban", i1);
			w1.WriteLine(i1);
			w1.Close();
			Console.WriteLine("\n2.Mennyi a megadott fájlban található számok összege ?");
			Console.WriteLine("{0} a fájban található számok összege", i2);
			w2.WriteLine(i2);
			w2.Close();
			Console.WriteLine("\n3. Mennyi a megadott fájlban található számok átlaga?");
			Console.WriteLine(i3);
			w3.WriteLine(i3);
			w3.Close();

			// II.

			StreamReader r2 = new StreamReader("input-II.txt", Encoding.UTF8);
			StreamWriter w4a = new StreamWriter("output4a.txt");
			StreamWriter w4b = new StreamWriter("output4b.txt");

			bool v4a = false;

			Console.WriteLine("\n4.");
			Console.WriteLine("b) Válogasd ki / Szűrd ki a negatív páros számokat a fájlból!");
			while (!r2.EndOfStream)
			{
				int beO = int.Parse(r2.ReadLine());
				if (beO < 0 && beO % 2 == 0)
				{
					if (v4a == false)
					{
						v4a = true;
					}
					Console.Write("{0},", beO);
					w4b.WriteLine(beO);
				}
			}
			r2.Close();
			w4b.Close();

			Console.WriteLine("\na) Van-e negatív páros szám a megadott fájlban?");
			Console.WriteLine(v4a ? "Van negatív páros szám a fájlban" : "Nincs negatív páros szám a fájlban");
			w4a.WriteLine(v4a);
			w4a.Close();

			// III.

			StreamReader r3 = new StreamReader("input-III.txt", Encoding.UTF8);
			StreamWriter w5a = new StreamWriter("output5a.txt");
			StreamWriter w5b = new StreamWriter("output5b.txt");

			int i5a = 0;
			int i5b = 0;

			Console.WriteLine("\n5.");
			while (!r3.EndOfStream)
			{
				int beO = int.Parse(r3.ReadLine());
				if (50 < beO && beO <= 100)
				{
					i5a++;
					i5b += beO;
				}
			}
			r3.Close();

			Console.WriteLine("a) Hány 50 és 100 közötti (az 50 és a 100 még benne van) szám található a fájlban?");
			Console.WriteLine("{0} 50 és 100 közötti szám van", i5a);
			w5a.WriteLine(i5a);
			w5a.Close();
			Console.WriteLine("b) Mennyi ezen számok összege? (tehát csak az 50 és 100 közé eső számok összege?)");
			Console.WriteLine("{0} ezen számok összege", i5b);
			w5b.WriteLine(i5b);
			w5b.Close();

			// IV.

			StreamReader r4 = new StreamReader("input-VI.txt", Encoding.UTF8);
			StreamWriter w6 = new StreamWriter("output6.txt");

			int i6 = int.Parse(r4.ReadLine());
			while (!r4.EndOfStream)
			{
				int lk6 = int.Parse(r4.ReadLine());
				if (lk6 < i6)
				{
					i6 = lk6;
				}

			}
			r4.Close();

			Console.WriteLine("\n6. Add meg a megadott fájlban található legkisebb számot!");
			Console.WriteLine("{0} a legkisebb szám a fájlban", i6);
			w6.WriteLine(i6);
			w6.Close();

			// V.

			StreamReader r5 = new StreamReader("input-V.txt", Encoding.UTF8);
			StreamWriter w7 = new StreamWriter("output7.txt");
			StreamWriter w8 = new StreamWriter("output8.txt");
			StreamWriter w9 = new StreamWriter("output9.txt");

			bool v7 = false;
			int i7 = 1;
			int ind8 = 0;
			int i8 = -1;
			int i9 = 1;
			while (!r5.EndOfStream)
			{
				int beO = int.Parse(r5.ReadLine());
				if (beO % 25 == 0)
				{
					if (v7 == false)
					{
						v7 = true;
						i7 = beO;
						i8 = ind8;
					}
					if (i9 < beO)
					{
						i9 = beO;
					}
				}
				ind8++;
			}
			r5.Close();

			Console.WriteLine("\n7. Mi az első 25-tel osztható szám?");
			Console.WriteLine(i7);
			w7.WriteLine(i7);
			w7.Close();
			Console.WriteLine("\n8. Mi az első 25-tel osztható szám indexe?");
			Console.WriteLine(i8);
			w8.WriteLine(i8);
			w8.Close();
			Console.WriteLine("\n9. Mi a legnagyobb 25-tel osztható szám?");
			Console.WriteLine(i9);
			w9.WriteLine(i9);
			w9.Close();

			// VI.

			StreamReader r6 = new StreamReader("input-VI.txt", Encoding.UTF8);
			StreamWriter w10 = new StreamWriter("output10.txt");
			StreamWriter w11 = new StreamWriter("output11.txt");
			StreamWriter w12 = new StreamWriter("output12.txt");

			bool v10 = false;
			int i10 = 1;
			int ind11 = -1;
			int i11 = -1;
			int i12 = 1;
			while (!r6.EndOfStream)
			{
				int beO = int.Parse(r6.ReadLine());
				if (beO % 25 == 0)
				{
					if (!v10)
					{
						v10 = true;
						i10 = beO;
						i11 = ind8;
					}
					if (i12 < beO)
					{
						i12 = beO;
					}
				}
				ind11++;
			}
			r6.Close();

			Console.WriteLine("\n10. Mi az utolsó 25-tel osztható szám?");
			Console.WriteLine(v10 ? "{0} az első 25-tel osztható szám" : "Nincs 25-tel osztható szám", i10);
			w10.WriteLine(v10 ? "{0}" : "{1}", i10, v10);
			w10.Close();
			Console.WriteLine("\n11. Mi az utolsó 25-tel osztható szám indexe?");
			Console.WriteLine(v10 ? "{0} az első 25-tel osztható szám indexe" : "Nincs 25-tel osztható szám", i11);
			w11.WriteLine(v10 ? "{0}" : "{1}", i11, v10);
			w11.Close();
			Console.WriteLine("\n12. Mi a legnagyobb 25-tel osztható szám indexe?");
			Console.WriteLine(v10 ? "{0} a legnagyobb 25-tel osztható szám" : "Nincs 25-tel osztható szám", i12);
			w12.WriteLine(v10 ? "{0}" : "{1}", i12, v10);
			w12.Close();


			// VII.

			StreamReader r7 = new StreamReader("input-VII.txt", Encoding.UTF8);
			StreamWriter w13a = new StreamWriter("output13a.txt");
			StreamWriter w13b = new StreamWriter("output13b.txt");

			bool v13a = false;
			bool oszt3 = false;
			int i13b = 0;
			int ind13b = -1;

			Console.WriteLine("\n13. ");
			while (!v13a && !r7.EndOfStream)
			{
				int beO = int.Parse(r7.ReadLine());
				if (oszt3 && beO % 10 == 0)
				{
					v13a = true;
					i13b = ind13b--;
				}
				else
				{
					oszt3 = !oszt3;
				}
				if (!oszt3 && beO % 3 == 0)
				{
					oszt3 = true;
				}
				ind13b++;
			}
			r7.Close();

			Console.WriteLine("a) Előfordul-e olyan a sorozatban, hogy egy 3-mal osztható számot egy 10-zel osztható szám követ?");
			Console.WriteLine(v13a ? "Igen, előfordul ilyen szám" : "Nincs ilyen szám");
			w13a.WriteLine(v13a);
			w13a.Close();
			Console.WriteLine("b) Ha előfordul ilyen, akkor mi ennek az előfordulásnak az indexe (a 3-mal osztható szám indexére gondolunk)");
			if (v13a)
			{
				Console.WriteLine(i13b);
				w13b.WriteLine(i13b);
			}
			else
			{
				Console.WriteLine(v13a);
				w13b.WriteLine(v13a);
			}
			w13b.Close();

		}
	}
}
