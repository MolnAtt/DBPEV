using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Csato_Csege_Károly
{
	class Program
	{
		static void Main(string[] args)
		{
			//1. feladat
			Console.WriteLine(" Hány szám található a megadott fájlban?");
			StreamReader r = new StreamReader("input-I.txt", Encoding.Default);
			StreamWriter w = new StreamWriter("output1.txt");
			int darab = 0;
			while(!r.EndOfStream)
			{
				r.ReadLine();
				darab++;
			}
			w.WriteLine(darab);
			Console.WriteLine(darab);
			w.Close();
			r.Close();
			//2. feladat
			Console.WriteLine("Mennyi a megadott fájlban található számok összege?");
			StreamReader r1 = new StreamReader("input-I.txt", Encoding.Default);
			StreamWriter w1 = new StreamWriter("output2.txt");
			int összeg1 = 0;
			int számok1 = 0;
			while (!r1.EndOfStream)
			{
				számok1 = int.Parse(r1.ReadLine());
				összeg1 = összeg1 + számok1;
			}
			w1.WriteLine(összeg1);
			Console.WriteLine(összeg1);
			w1.Close();
			r1.Close();
			//3. feladat
			Console.WriteLine("Mennyi a megadott fájlban található számok átlaga?");
			StreamReader r2 = new StreamReader("input-I.txt", Encoding.Default);
			StreamWriter w2 = new StreamWriter("output3.txt");
			double darab2 = 0;
			double összeg2 = 0;
			int számok2 = 0;
			double átlag1 = 0;
			while (!r2.EndOfStream)
			{
				számok2 = int.Parse(r2.ReadLine());
				összeg2 = összeg2 + számok2;
				darab2++;
			}
			átlag1 = összeg2 / darab2;
			w2.WriteLine(átlag1);
			Console.WriteLine(átlag1);
			w2.Close();
			r2.Close();
			//4. feladat
			//Van-e negatív páros szám a megadott fájlban?
			//Válogasd ki / Szűrd ki a negatív páros számokat a fájlból!
			Console.WriteLine("Van-e negatív páros szám a megadott fájlban?.Szűrd ki a negatív páros számokat a fájlból!");
			StreamReader r3 = new StreamReader("input-II.txt", Encoding.Default);
			StreamWriter w3a = new StreamWriter("output4a.txt");
			StreamWriter w3b = new StreamWriter("output4b.txt");
			int számok3 = 0;
			bool minusz = false;
			bool van = false;
			bool vane1 = false;
			while (!r3.EndOfStream)
			{
				van = false;
				számok3 = int.Parse(r3.ReadLine());
				if (számok3 < 0)
				{
					minusz = true;
				}
				if (számok3 % 2 == 0 && minusz == true)
				{
					van = true;
					vane1 = true;
				}
				minusz = false;
				//
				if (van == true)
				{
					w3b.WriteLine(számok3);
					Console.WriteLine(számok3);
				}
			}
			Console.WriteLine(vane1);
			w3a.WriteLine(vane1);
			w3a.Close();
			w3b.Close();
			r3.Close();
			// 5. feladat (input-III.txt)
			// Hány 50 és 100 közötti (az 50 és a 100 még benne van) szám található a fájlban? ("output5a.txt")
			// Mennyi ezen számok összege? (tehát csak az 50 és 100 közé eső számok összege?) ("output5b.txt")
			Console.WriteLine("Hány 50 és 100 közötti (az 50 és a 100 még benne van) szám található a fájlban?.Mennyi ezen számok összege? (tehát csak az 50 és 100 közé eső számok összege?");
			StreamReader r4 = new StreamReader("input-III.txt", Encoding.Default);
			StreamWriter w4a = new StreamWriter("output5a.txt");
			StreamWriter w4b = new StreamWriter("output5b.txt");
			int szamok4 = 0;
			int összeg4 = 0;
			bool nagyobb = false;
			bool kisebb = false;
			bool van4 = false;
			int darab4 = 0;
			while (!r4.EndOfStream)
			{
				szamok4 = int.Parse(r4.ReadLine());
				nagyobb = false;
				if (szamok4 > 49)
				{
					nagyobb = true;
				}
				kisebb = false;
				if (szamok4 < 101 && nagyobb == true)
				{
					kisebb = true;
					darab4++;
					összeg4 = összeg4 + szamok4;
				}
			}
			if (darab4 == 0)
			{
				Console.WriteLine(van4);
				w4a.WriteLine(van4);
			}
			if (darab4 > 0)
			{
				Console.WriteLine(darab4);
				w4a.WriteLine(darab4);
			}
			Console.WriteLine(összeg4);
			w4b.WriteLine(összeg4);
			r4.Close();
			w4a.Close();
			w4b.Close();
			//6. feladat
			//Add meg a megadott fájlban található legkisebb számot! ("output6.txt")
			Console.WriteLine("Add meg a megadott fájlban található legkisebb számot!");
			StreamReader r5 = new StreamReader("input-IV.txt", Encoding.Default);
			StreamWriter w5 = new StreamWriter("output6.txt");
			int szám5 = 0;
			int adottszám5 = 0;
			bool elsőbeolvasás5 = false;
			while (!r5.EndOfStream)
			{
				if (elsőbeolvasás5 == false)
				{
					szám5 = int.Parse(r5.ReadLine());
					elsőbeolvasás5 = true;
				}
				adottszám5 = int.Parse(r5.ReadLine());
				if (adottszám5 < szám5)
				{
					szám5 = adottszám5;
				}
			}
			if (elsőbeolvasás5 == false)
			{
				Console.WriteLine(elsőbeolvasás5);
				w5.WriteLine(elsőbeolvasás5);
			}
			if (elsőbeolvasás5 == true)
			{
				Console.WriteLine("A legkisebb szám:{0}", szám5);
				w5.WriteLine(szám5);
			}
			w5.Close();
			r3.Close();
			// 7,8,9 feladat
			// Mi az első 25-tel osztható szám?
			// Mi az első 25-tel osztható szám indexe?
			// Mi a legnagyobb 25-tel osztható szám?
			Console.WriteLine("Mi az első 25-tel osztható szám?. Mi az első 25-tel osztható szám indexe?.Mi a legnagyobb 25-tel osztható szám?");
			StreamReader r6 = new StreamReader("input-V.txt", Encoding.Default);
			StreamWriter w6 = new StreamWriter("output7.txt");
			StreamWriter w7 = new StreamWriter("output8.txt");
			bool mergvan6 = false;
			int szam6 = 0;
			int index6 = 0;
			int elsőindex = 0;
			while (!r6.EndOfStream && !mergvan6)
			{
				szam6 = int.Parse(r6.ReadLine());
				if (szam6 % 25 == 0)
				{
					
					Console.WriteLine(szam6);
					w6.WriteLine(szam6);
					elsőindex = index6;
					w7.WriteLine(elsőindex);
					Console.WriteLine(elsőindex);
					
					mergvan6 = true;
				}
				index6++;
			}
			r6.Close();
			w6.Close();
			StreamWriter w8 = new StreamWriter("output9.txt");
			StreamReader r7 = new StreamReader("input-V.txt", Encoding.Default);
			int szam7 = 0;
			int legnagyobbszam7 = 0;
			while (!r7.EndOfStream)
			{
				szam7 = int.Parse(r7.ReadLine());
				if (szam7 % 25 == 0)
				{
					legnagyobbszam7 = szam7;
				}
			}
			Console.WriteLine(legnagyobbszam7);
			w8.WriteLine(legnagyobbszam7);
			w8.Close();
			r7.Close();
		}
	}
}
