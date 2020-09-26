using System;
using System.IO;
using System.Collections.Generic;	
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolgozat
{
	class Program
	{
		static void Main(string[] args)
		{
			//I

			StreamReader r1 = new StreamReader("input-I.txt", Encoding.Default);
			StreamWriter w1 = new StreamWriter("output1.txt");
			StreamWriter w2 = new StreamWriter("output2.txt");
			StreamWriter w3 = new StreamWriter("output3.txt");
			int szamok1;
			//1
			int index1 = 0;
			//2
			double összeadás = 0;
			//3
			Double átlag = 0;
			while (!r1.EndOfStream)
			{
				szamok1 = int.Parse(r1.ReadLine());

				//1
				index1++;
				//2
				összeadás = összeadás + szamok1;
				//3
				átlag = (összeadás + szamok1) / index1;
			}
			Console.WriteLine("Hány szám található a megadott fájlban ?");
			Console.WriteLine(index1);
			w1.WriteLine(index1);
			Console.WriteLine(" Mennyi a megadott fájlban található számok összege? ");
			Console.WriteLine(összeadás);
			w2.WriteLine(összeadás);
			Console.WriteLine("Mennyi a megadott fájlban található számok átlaga?");
			Console.WriteLine(átlag);
			w3.WriteLine(átlag);

			w1.Close();
			w2.Close();
			w3.Close();
			r1.Close();


			//II
			StreamReader r2 = new StreamReader("input-II.txt", Encoding.Default);
			StreamWriter w4 = new StreamWriter("output4a.txt");
			StreamWriter w5 = new StreamWriter("output4b.txt");
			int szamok2;
			bool parosésnegativ = false;
			Console.WriteLine(" Válogasd ki / Szűrd ki a negatív páros számokat a fájlból!");

			while (!r2.EndOfStream)
			{
				szamok2 = int.Parse(r2.ReadLine());
				//4
				if (szamok2 % 2 == 0 && szamok2 < 0)
				{
					parosésnegativ = true;
					Console.WriteLine(szamok2);
					w5.WriteLine(szamok2);
				}
			}
			Console.WriteLine(" Van-e negatív páros szám a megadott fájlban?");
			Console.WriteLine(parosésnegativ);
			w4.WriteLine(parosésnegativ);
			w4.Close();
			w5.Close();
			r2.Close();

			//III
			StreamReader r3 = new StreamReader("input-III.txt", Encoding.Default);
			StreamWriter w6 = new StreamWriter("output5a.txt");
			StreamWriter w7 = new StreamWriter("output5b.txt");
			int szamok3;
			//5
			//a
			int index2 = 0;
			//b
			int összeadás2 = 0;
			while (!r3.EndOfStream)
			{
				szamok3 = int.Parse(r3.ReadLine());
				//a
				if (szamok3 > 49 && szamok3 < 101)
				{

					index2++;
					//b
					összeadás2 = szamok3 + összeadás2;
				}
			}
			Console.WriteLine("Hány 50 és 100 közötti (az 50 és a 100 még benne van) szám található a fájlban?");
			Console.WriteLine(index2);
			w6.WriteLine(index2);
			Console.WriteLine(" Mennyi ezen számok összege? (tehát csak az 50 és 100 közé eső számok összege?)");
			Console.WriteLine(összeadás2);
			w7.WriteLine(összeadás2);

			w6.Close();
			w7.Close();
			r3.Close();
			//IV


			StreamReader r4 = new StreamReader("input-IV.txt", Encoding.Default);
			StreamWriter w8 = new StreamWriter("output6.txt");
			int szamok4;
			//6
			int legkisebb = 0;
			while (!r4.EndOfStream)
			{
				szamok4 = int.Parse(r4.ReadLine());

				if (szamok4<legkisebb)
				{
					legkisebb = szamok4;
				}
			}
			Console.WriteLine("Add meg a megadott fájlban található legkisebb számot!");
			Console.WriteLine(legkisebb);
			w8.WriteLine(legkisebb);
			r4.Close();
			w8.Close();


			//V
			StreamReader r5 = new StreamReader("input-V.txt", Encoding.Default);
			StreamWriter w9 = new StreamWriter("output7.txt");
			StreamWriter w10 = new StreamWriter("output8.txt");
			StreamWriter w11 = new StreamWriter("output9.txt");
			int szamok5;
			//7
			bool elso = true;
			int elso25 = 0;
			//8
			int index5 = 0;
			int elsoindex = 0;
			//9
			int legnagyobb25 = 0;

			while (!r5.EndOfStream)
			{
				szamok5 = int.Parse(r5.ReadLine());
				//7
				index5++;
				if (szamok5%25==0&&elso==true)
				{
					elso = false;
					elso25 = szamok5;
					elsoindex = index5;
				}
				//9
				if (szamok5%25==0&&szamok5>legnagyobb25)
				{
					legnagyobb25 = szamok5;
				}

			}
			Console.WriteLine("Mi az első 25 - tel osztható szám ?");
			Console.WriteLine(elso25);
			w9.WriteLine(elso25);
			Console.WriteLine("Mi az első 25-tel osztható szám indexe?");
			Console.WriteLine(elsoindex);
			w10.WriteLine(elsoindex);
			Console.WriteLine("Mi a legnagyobb 25-tel osztható szám?");
			Console.WriteLine(legnagyobb25);
			w11.WriteLine(legnagyobb25);

			w9.Close();
			w10.Close();
			w11.Close();
			r5.Close();

			//VI			
			StreamReader r6 = new StreamReader("input-VI.txt", Encoding.Default);
			StreamWriter w12= new StreamWriter("output10.txt");
			StreamWriter w13 = new StreamWriter("output11.txt");
			StreamWriter w14 = new StreamWriter("output12.txt");
			int szamok6;
			//10
			int utolso25 = 0;
			//11
			int huszonötindex = 0;
			int vegleges25 = 0;
			//12
			int legnagyobbhuszonöt = 0;
			int index25 = 0;
			int veglegesindex25 = 0;

			while (!r6.EndOfStream)
			{
				huszonötindex++;
				szamok6 = int.Parse(r6.ReadLine());
				if (szamok6%25==0)
				{
					utolso25 = szamok6;
					vegleges25 = huszonötindex;
				}

				index25++; 
				if (szamok6>legnagyobb25&&szamok6%25==0)
				{
					legnagyobb25 = szamok6;
					veglegesindex25 = index25;
				}

			}
			//10
			if (utolso25==0)
			{
				Console.WriteLine("Mi az utolsó 25-tel osztható szám?");
				Console.WriteLine(false);
				w12.WriteLine(false);
			}
			else
			{
				Console.WriteLine("Mi az utolsó 25-tel osztható szám?");
				Console.WriteLine(utolso25);
				w12.WriteLine(utolso25);
			}
			//11
			if (vegleges25==0)
			{
				Console.WriteLine("Mi az utolsó 25 - tel osztható szám indexe?");
				Console.WriteLine(false);
				w13.WriteLine(false);
			}
			else
			{
				Console.WriteLine("Mi az utolsó 25 - tel osztható szám indexe?");
				Console.WriteLine(vegleges25);
				w13.WriteLine(vegleges25);
			}
			//12
			if (veglegesindex25==0)
			{
				Console.WriteLine("Mi a legnagyobb 25-tel osztható szám indexe?");
				Console.WriteLine(false);
				w14.WriteLine(false);
			}
			else
			{
				Console.WriteLine("Mi a legnagyobb 25-tel osztható szám indexe?");
				Console.WriteLine(veglegesindex25);
				w14.WriteLine(veglegesindex25);
			}
			r6.Close();
			w12.Close();
			w13.Close();
			w14.Close();


			//VII
			StreamReader r7 = new StreamReader("input-VII.txt", Encoding.Default);
			StreamWriter w15 = new StreamWriter("output13a.txt");
			StreamWriter w16 = new StreamWriter("output13b.txt");
			int szamok7;
			//a
			bool elso1 = false;
			bool masodik = false;
			//b
			int index7 = 0;
			int aharmasindexe = 0;
			while (!r7.EndOfStream)
			{
				index7++;
				szamok7 = int.Parse(r7.ReadLine());
				if (szamok7%3==0)
				{
					elso1 = true;
					
				}
				else
				{
				
					elso1 = false;
				}
				if (szamok7%10==0&&elso1==true)
				{
					masodik = true;
					aharmasindexe = index7;
				}
				
			}
			aharmasindexe= aharmasindexe - 1;
			Console.WriteLine("Előfordul-e olyan a sorozatban, hogy egy 3-mal osztható számot egy 10-zel osztható szám követ?");
			Console.WriteLine(masodik);
			w15.WriteLine(masodik);
			Console.WriteLine("Ha előfordul ilyen, akkor mi ennek az előfordulásnak az indexe (a 3-mal osztható szám indexére gondolunk)");
			Console.WriteLine(aharmasindexe);
			w16.WriteLine(aharmasindexe);

			w15.Close();
			w16.Close();
			r7.Close();
		}
	}
}

