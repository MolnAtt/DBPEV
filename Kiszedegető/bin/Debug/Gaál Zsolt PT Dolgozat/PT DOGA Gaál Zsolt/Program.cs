using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PT_DOGA_Gaál_Zsolt
{
	class Program
	{
		static void Main(string[] args)
		{
			// I. feladat
			StreamReader beolvasó = new StreamReader("input-I.txt", Encoding.UTF8);

			int i = 0;
			int sum = 0;

			while (!beolvasó.EndOfStream)
			{
				int aktuális = int.Parse(beolvasó.ReadLine());
				sum += aktuális;
				i++;
			}
			beolvasó.Close();

			Console.WriteLine("\n1. Hány szám található a megadott fájlban?");
			StreamWriter w1 = new StreamWriter("output1.txt");
			Console.WriteLine(i + " db szám van");
			w1.WriteLine(i);
			w1.Close();


			Console.WriteLine("\n2. Mennyi a megadott fájlban található számok összege?");
			StreamWriter w2 = new StreamWriter("output2.txt");
			Console.WriteLine(sum);
			w2.WriteLine(sum);
			w2.Close();


			Console.WriteLine("\n3. Mennyi a megadott fájlban található számok átlaga?");
			StreamWriter w3 = new StreamWriter("output3.txt");
			Console.WriteLine("átlag: {0:0.00}", sum / i);
			w3.WriteLine(sum / i);
			w3.Close();

			// II. feladat______________________________________________________________________________________________________________________

			StreamReader beolvasó2 = new StreamReader("input-II.txt", Encoding.UTF8);
			bool válasz = false;


			Console.WriteLine("\n4. Válogasd ki / Szűrd ki a negatív páros számokat a fájlból!");
			StreamWriter w5 = new StreamWriter("output4b.txt");

			while (!beolvasó2.EndOfStream)
			{
				int aktuális = int.Parse(beolvasó2.ReadLine());

				if (aktuális < 0 && aktuális % 2 == 0)
				{
					válasz = true;

					Console.Write(aktuális + " ,");
					w5.WriteLine(aktuális);

				}
			}
			beolvasó2.Close();

			if (válasz == false)
			{
				Console.WriteLine("nincs iylen szám");
				w5.WriteLine(válasz);
			}

			Console.WriteLine("\n\n5. Van-e negatív páros szám a megadott fájlban?");
			StreamWriter w4 = new StreamWriter("output4a.txt");
			Console.WriteLine(válasz? "igen, van" : "nem, nincs");
			w4.WriteLine(válasz);
			w4.Close();

			w5.Close();

			// III. feladat______________________________________________________________________________________________

			StreamReader beolvasó3 = new StreamReader("input-III.txt", Encoding.UTF8);

			int darabszám = 0;
			int sum2 = 0;

			while (!beolvasó3.EndOfStream)
			{
				int aktuális = int.Parse(beolvasó3.ReadLine());

				if (50 <= aktuális && aktuális <= 100)
				{
					darabszám++;
					sum2 += aktuális;
				}

			}
			beolvasó3.Close();

			Console.WriteLine("\n6. Hány 50 és 100 közötti (az 50 és a 100 még benne van) szám található a fájlban?");
			StreamWriter w6 = new StreamWriter("output5a.txt");
			Console.WriteLine(darabszám);
			w6.WriteLine(darabszám);
			w6.Close();


			Console.WriteLine("\n7. Mennyi ezen számok összege? (tehát csak az 50 és 100 közé eső számok összege?)");
			StreamWriter w7 = new StreamWriter("output5b.txt");
			Console.WriteLine(sum2);
			w7.WriteLine(sum2);
			w7.Close();



			// IV. feladat__________________________________________________________________________________________________________________

			StreamReader beolvasó4 = new StreamReader("input-IV.txt", Encoding.UTF8);

			int legkisebb = int.Parse(beolvasó4.ReadLine());

			while (!beolvasó4.EndOfStream)
			{
				int aktuális = int.Parse(beolvasó4.ReadLine());

				if (aktuális < legkisebb)
				{
					legkisebb = aktuális;
				}

			}
			beolvasó4.Close();

			Console.WriteLine("\n8. Add meg a megadott fájlban található legkisebb számot!");
			StreamWriter w8 = new StreamWriter("output6.txt");
			Console.WriteLine(legkisebb);
			w8.WriteLine(legkisebb);
			w8.Close();


			// V. feladat_________________________________________________________________________________________________________________
			StreamReader beolvasó5 = new StreamReader("input-V.txt", Encoding.UTF8);

			int i2 = 0;
			int első25osztható = 1;
			int első25oszthatóindex = -1;
			int legnagyobb25 = 1;

			bool állj = false;

			while (!beolvasó5.EndOfStream)
			{
				int aktuális = int.Parse(beolvasó5.ReadLine());
				if (!állj && aktuális % 25 == 0)
				{
					első25osztható = aktuális;
					első25oszthatóindex = i2;
					állj = true;
				}
				if (aktuális % 25 == 0 && legnagyobb25 < aktuális)
				{
					legnagyobb25 = aktuális;
				}


				i2++;
			}
			beolvasó5.Close();

			Console.WriteLine("\n9. Mi az első 25-tel osztható szám?");
			StreamWriter w9 = new StreamWriter("output7.txt");
			Console.WriteLine(első25osztható);
			w9.WriteLine(első25osztható);
			w9.Close();


			Console.WriteLine("\n10. Mi az első 25-tel osztható szám indexe?");
			StreamWriter w10 = new StreamWriter("output8.txt");
			Console.WriteLine(első25oszthatóindex);
			w10.WriteLine(első25oszthatóindex);
			w10.Close();


			Console.WriteLine("\n11. Mi a legnagyobb 25-tel osztható szám?");
			StreamWriter w11 = new StreamWriter("output9.txt");
			Console.WriteLine(legnagyobb25);
			w11.WriteLine(legnagyobb25);
			w11.Close();


			// VI. feladat_____________________________________________________________________________________________________

			StreamReader beolvasó6 = new StreamReader("input-VI.txt", Encoding.UTF8);

			int utolsó25osztható = 1;
			int utolsó25oszthatóindex = -1;
			int legnagyobb25b = 1;
			int legnagyobb25index = -1;

			int i3 = 0;

			while (!beolvasó6.EndOfStream)
			{
				int aktuális = int.Parse(beolvasó6.ReadLine());

				if (aktuális % 25 == 0)
				{
					utolsó25osztható = aktuális;
					utolsó25oszthatóindex = i3;
				}

				if (aktuális % 25 == 0 && legnagyobb25b < aktuális)
				{
					legnagyobb25b = aktuális;
					legnagyobb25index = i3;
				}


				i3++;
			}
			beolvasó6.Close();

			Console.WriteLine("\n12. Mi az utolsó 25-tel osztható szám?");
			StreamWriter w12 = new StreamWriter("output10.txt");
			if (utolsó25osztható == 1)
			{
				Console.WriteLine("nincs ilyen szám");
				bool válasz3 = false;
				w12.WriteLine(válasz3);
			}
			else
			{
				Console.WriteLine(utolsó25osztható);
				w12.WriteLine(utolsó25osztható);
			}
			
			w12.Close();


			Console.WriteLine("\n13. Mi az utolsó 25-tel osztható szám indexe?");
			StreamWriter w13 = new StreamWriter("output11.txt");
			if (utolsó25oszthatóindex == -1)
			{
				Console.WriteLine("nincs ilyen szám");
				bool válasz4 = false;
				w13.WriteLine(válasz4);
			}
			else
			{
				Console.WriteLine(utolsó25oszthatóindex);
				w13.WriteLine(utolsó25oszthatóindex);
			}
			w13.Close();


			Console.WriteLine("\n14. Mi a legnagyobb 25-tel osztható szám indexe?");
			StreamWriter w14 = new StreamWriter("output12.txt");
			if (legnagyobb25index == -1)
			{
				Console.WriteLine("nincs ilyen szám");
				bool válasz2 = false;
				w14.WriteLine(válasz2);
			}
			else
			{
				Console.WriteLine(legnagyobb25index);
				w14.WriteLine(legnagyobb25index);
			}
			w14.Close();


			// VII. feladat______________________________________________________________________________________________________


			StreamReader beolvasó7 = new StreamReader("input-VII.txt", Encoding.UTF8);

			bool válasz5 = false;
			int i4 = 0;
			int előző = 1111111;
			int aktuális2 = 1111111;
			int előfordulásindex = -1;

			while (!beolvasó7.EndOfStream)
			{
				if (i != 0)
				{
					előző = aktuális2;
					aktuális2 = int.Parse(beolvasó7.ReadLine());

					if (aktuális2 % 10 == 0 && előző % 3 == 0)
					{
						válasz5 = true;
						előfordulásindex = i4-1;
					}
				}
				

				i4++;
			}
			beolvasó7.Close();

			Console.WriteLine("\n15. Előfordul-e olyan a sorozatban, hogy egy 3-mal osztható számot egy 10-zel osztható szám követ?");
			StreamWriter w15 = new StreamWriter("output13a.txt");
			Console.WriteLine(válasz5? "igen" : "nem");
			w15.WriteLine(válasz5);
			w15.Close();


			Console.WriteLine("\n16. Ha előfordul ilyen, akkor mi ennek az előfordulásnak az indexe (a 3-mal osztható szám indexére gondolunk)");
			StreamWriter w16 = new StreamWriter("output13b.txt");
			if (előfordulásindex == -1)
			{
				Console.WriteLine("nem fordul elő");
				bool válasz6 = false;
				w16.WriteLine(válasz6);
			}
			else
			{
				Console.WriteLine(előfordulásindex);
				w16.WriteLine(előfordulásindex);
			}
			w16.Close();



		}
	}
}
