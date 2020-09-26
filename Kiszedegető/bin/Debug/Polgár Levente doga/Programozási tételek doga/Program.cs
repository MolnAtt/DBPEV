using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Programozási_tételek_doga
{
	class Program
	{
		static void Main(string[] args)
		{
			StreamReader beolvasó = new StreamReader("input-I.txt", Encoding.Default);
			StreamWriter Kiír1 = new StreamWriter("output1.txt");
			StreamWriter Kiír2 = new StreamWriter("output2.txt");
			StreamWriter Kiír3 = new StreamWriter("output3.txt");

			double db = 0;
			double összeg = 0;
			double átlag = 0;

			while (!beolvasó.EndOfStream)
			{
				int szám = int.Parse(beolvasó.ReadLine());

				//1. Hány szám található a megadott fájlban?
				db++;
				//-------------------------------

				//2. Mennyi a megadott fájlban található számok összege?
				összeg += szám;
				//-------------------------------

				//3. Mennyi a megadott fájlban található számok átlaga? 

				//----------------------


			}
			//3.
			átlag = összeg / db;
			//-------------------

			Console.WriteLine("A sorozatban " +db+ " szám található");
			Kiír1.WriteLine(db);
			Console.WriteLine("A sorozatban található számok összege: "+összeg+"");
			Kiír2.WriteLine(összeg);
			Console.WriteLine("Az átlag: "+átlag+"");
			Kiír3.WriteLine(átlag);

			Kiír1.Close();
			Kiír2.Close();
			Kiír3.Close();



			StreamReader beolvasó2 = new StreamReader("input-II.txt", Encoding.Default);
			StreamWriter Kiír4 = new StreamWriter("output4a.txt");
			StreamWriter Kiír5 = new StreamWriter("output4b.txt");

			bool negatívpáros = false;
			string negatív = "";

			while (!beolvasó2.EndOfStream)
			{
				int szám2 = int.Parse(beolvasó2.ReadLine());

				//4. 	a) Van-e negatív páros szám a megadott fájlban? ("output4a.txt")
				if (szám2 < 0 && szám2 % 2 == 0)
				{
					negatívpáros = true;
				}
				
				//------------------

				//b) Válogasd ki / Szűrd ki a negatív páros számokat a fájlból! ("output4b.txt")
				if (szám2 < 0)
				{
					if (szám2 % 2 == 0)
					{
						negatív += szám2 + ", ";
					}
					

				}
				//-----------------------------
			}
			Console.WriteLine(negatívpáros ? "van ilyen szám" : "nincs ilyen szám");
			Kiír4.WriteLine(negatívpáros);
			Console.WriteLine("A negatív páros számok a következők: "+negatív+ "");
			Kiír5.WriteLine(negatív);

			Kiír4.Close();
			Kiír5.Close();
			beolvasó2.Close();




			StreamReader beolvasó3 = new StreamReader("input-III.txt", Encoding.Default);
			StreamWriter Kiír6 = new StreamWriter("output5a.txt");
			StreamWriter Kiír7 = new StreamWriter("output5b.txt");

			int ötvenszáz = 0;
			double összegötvenszáz = 0;

			while (!beolvasó3.EndOfStream)
			{
				int szám3 = int.Parse(beolvasó3.ReadLine());

				//a) Hány 50 és 100 közötti (az 50 és a 100 még benne van) szám található a fájlban?
				if (szám3 > 50 && szám3 < 100)
				{
					ötvenszáz++;
				}
				//----------------------------------

				//b) Mennyi ezen számok összege?
				összegötvenszáz += ötvenszáz;
			}

			Console.WriteLine("Ötven és száz közötti számokból "+ötvenszáz+" van");
			Kiír6.WriteLine(ötvenszáz);
			Console.WriteLine("összegük: "+összegötvenszáz+ "");
			Kiír7.WriteLine(összegötvenszáz);


			Kiír6.Close();
			Kiír7.Close();
			beolvasó3.Close();


			StreamReader beolvasó4 = new StreamReader("input-IV.txt", Encoding.Default);
			StreamWriter Kiír8 = new StreamWriter("output6a.txt");
			int legkisebb = int.MaxValue;

			while (!beolvasó4.EndOfStream)
			{
				int szám5 = int.Parse(beolvasó4.ReadLine());

				//a) Add meg a megadott fájlban található legkisebb számot! 
				if (szám5 < legkisebb)
				{
					legkisebb = szám5;
				}
				//--------------------------

			}
			Console.WriteLine("A legkisebb szám: "+legkisebb+"");
			Kiír8.WriteLine(legkisebb);

			Kiír8.Close();
			beolvasó4.Close();


			StreamReader beolvasó5 = new StreamReader("input-V.txt", Encoding.Default);
			StreamWriter Kiír9 = new StreamWriter("output7.txt");
			StreamWriter Kiír10 = new StreamWriter("output8.txt");
			StreamWriter Kiír11 = new StreamWriter("output9.txt");

			
			int i = 0;
			int huszonindex = -1;
			string huszonöt = "";
			int legnagyobbhuszonöt = int.MinValue;
			int legkisebbhuszonöt = int.MaxValue;

			while (!beolvasó5.EndOfStream)
			{
				int szám6 = int.Parse(beolvasó5.ReadLine());

				//7. Mi az első 25-tel osztható szám?
				if (szám6 % 25 == 0)
				{
					huszonöt += szám6 + " ";
					
				}
				

				//8. Mi az első 25-tel osztható szám indexe? 
				if (szám6 % 25 == 0)
				{
					huszonindex = i;
				}

				//9. Mi a legnagyobb 25-tel osztható szám? 
				if (szám6 % 25 == 0)
				{
					if (szám6 < legnagyobbhuszonöt)
					{
						legnagyobbhuszonöt = szám6;
					}
				}
			}
			i++;

			Console.WriteLine("A huszonöttl osztható számok: "+huszonöt+"");
			Kiír9.WriteLine(huszonöt);
			Console.WriteLine(huszonindex);
			Console.WriteLine(legnagyobbhuszonöt);

			Kiír9.Close();
			Kiír10.Close();
			Kiír11.Close();
			beolvasó5.Close();


			StreamReader beolvasó6 = new StreamReader("input-VI.txt", Encoding.Default);
			StreamWriter Kiír12 = new StreamWriter("output10.txt");
			StreamWriter Kiír13 = new StreamWriter("output11.txt");
			StreamWriter Kiír14 = new StreamWriter("output12.txt");
			int huszonötös = 0;

			while (!beolvasó6.EndOfStream)
			{
				int szám7 = int.Parse(beolvasó6.ReadLine());

				//10. Mi az utolsó 25-tel osztható szám? 
				if (szám7 % 25 == 0)
				{
					huszonötös = szám7;
				}

				Kiír12.WriteLine(huszonötös);
			}




			StreamReader beolvasó7 = new StreamReader("input-VII.txt", Encoding.Default);
			StreamWriter Kiír15 = new StreamWriter("output13a.txt");

			int hárommal = 0;
			int tízzel = 0;
			bool hároméstízzel = false;
			int i2 = 0;

			while (!beolvasó7.EndOfStream)
			{
				int szám8 = int.Parse(beolvasó7.ReadLine());
				//a) Előfordul-e olyan a sorozatban, hogy egy 3-mal osztható számot egy 10-zel osztható szám követ? 
				if (szám8 % 3 == 0)
				{
					if (szám8 % 10 == 0)
					{
						hároméstízzel = true;
					}
				}

				//b) Ha előfordul ilyen, akkor mi ennek az előfordulásnak az indexe
			}
			i2++;

			Console.WriteLine(hároméstízzel? "Előfordul ilyen szám" : "nem fordul elő ilyen szám");
			Kiír15.WriteLine(hároméstízzel);

			beolvasó7.Close();
			Kiír15.Close();
		}
	}
}
