using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
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

			while(!beolvasó.EndOfStream)
			{
				int szám = int.Parse(beolvasó.ReadLine());

				//1.Feladat
				db++;

				//2.Feladat
				összeg += szám;

				//3.Feladat
				átlag = összeg / 2;
			}
			

			Console.WriteLine(db);
			//kiír1.WriteLine(db);
			Console.WriteLine(összeg);
			//kiír2.WriteLine(összeg);
			Console.WriteLine(átlag);
			//kiír3.WriteLine(átlag);





			
			StreamReader beolvasó2 = new StreamReader("input-II.txt", Encoding.Default);
			StreamWriter Kiír4 = new StreamWriter("output4a.txt");
			StreamWriter Kiír5 = new StreamWriter("output4b.txt");

			double szam = 0;

			while (!beolvasó2.EndOfStream)
			{
				int szám2 = int.Parse(beolvasó2.ReadLine());
				//4a

				//szam < 0;
				
			}
			
			StreamReader beolvasó3 = new StreamReader("input-III.txt", Encoding.Default);
			StreamWriter Kiír6 = new StreamWriter("output5a.txt");
			StreamWriter Kiír7 = new StreamWriter("output5b.txt");

			
			int ötvenszáz = 0;
			double ötvenszazosszeg = 0;

			while(!beolvasó3.EndOfStream)
			{
				int szám3 = int.Parse(beolvasó3.ReadLine());
				//a
				if(szám3 > 50 && szám3 < 100)
				{
					ötvenszáz++;
				}
				//b
				ötvenszáz += ötvenszáz;

			}
			Console.WriteLine(ötvenszáz);
			Kiír6.WriteLine(ötvenszáz);
			Console.WriteLine(ötvenszazosszeg);
			Kiír7.WriteLine(ötvenszazosszeg);

			
		    StreamReader beolvasó4 = new StreamReader("input-IV.txt", Encoding.Default);
			StreamWriter Kiír8 = new StreamWriter("output5a.txt");
			
			int minertek = 1000;
			while(!beolvasó4.EndOfStream)
			{
				int szam4 = int.Parse(beolvasó4.ReadLine());

				if (minertek > szam4)
				{
					minertek = szam4;
				}

			}
			Console.WriteLine(minertek + "EZAZ");
			Kiír8.WriteLine(minertek);

			StreamReader beolvasó5 = new StreamReader("input-V.txt", Encoding.Default);
			StreamWriter Kiír10 = new StreamWriter("output7.txt");
			StreamWriter Kiír11 = new StreamWriter("output8.txt");
			StreamWriter Kiír12 = new StreamWriter("output9.txt");

			int huszonöttel = 0;
			int i = 0;
			int huszonindex = -1;

			while (!beolvasó3.EndOfStream)
			{
				int szám6 = int.Parse(beolvasó5.ReadLine());



				if(szám6 % 25 == 0)
				{

				}


				if (szám6 % 25 == 0)
				{
					huszonindex = i;
				}



			}

			Console.WriteLine(huszonindex);
			

			StreamReader beolvasó7 = new StreamReader("input-VII.txt", Encoding.Default);
			StreamWriter Kiír15 = new StreamWriter("output13a.txt");
			int hárommal = 0;
			int tízzel = 0;
			bool haromestizzel = false;

			while (!beolvasó7.EndOfStream)
			{
				int szám8 = int.Parse(beolvasó7.ReadLine());

				if(szám8 % 3 == 0)
				{
					if (szám8 % 10 == 0)
					{
						haromestizzel = true;
					}

				}
			}

			Console.WriteLine(haromestizzel);


		}
	}
}
