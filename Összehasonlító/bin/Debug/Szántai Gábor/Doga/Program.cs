using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Doga
{
	class Program
	{
		static void Main(string[] args)
		{
			StreamReader beolvasó = new StreamReader("input-I.txt", Encoding.UTF8);
			int szám = 0, összeg=0;
			double átlag = 0;

			//I.
			while (!beolvasó.EndOfStream)
			{
				int szám1 = int.Parse(beolvasó.ReadLine());

				szám++;

				összeg += szám1;

				
			}
			átlag = összeg;
			átlag /= szám;

			//II.
			StreamReader beolvasó2 = new StreamReader("input-II.txt", Encoding.UTF8);
			bool negatívpáros = false;
			string negativpárosok = "";
			while (!beolvasó2.EndOfStream)
			{
				int szám2 = int.Parse(beolvasó2.ReadLine());

				if (szám2 < 0 && szám2 % 2 == 0)
				{
					negatívpáros = true;

					negativpárosok += szám + " ";
				}
			}

			//III
			StreamReader beolvasó3 = new StreamReader("input-III.txt", Encoding.UTF8);

			int ötvenszázas = 0, ötvenszázasösszeg=0;
			while (!beolvasó3.EndOfStream)
			{
				int szám3 = int.Parse(beolvasó3.ReadLine());

				if (szám3 >= 50 && szám <= 100)
				{
					ötvenszázas++;

					ötvenszázasösszeg += szám3;
				}
				
			}

			//IV.
			StreamReader beolvasó4 = new StreamReader("input-IV.txt", Encoding.UTF8);
			int legkisseb = int.MaxValue;
			while (!beolvasó4.EndOfStream)
			{
				int szám4 = int.Parse(beolvasó4.ReadLine());

				if (szám4 < legkisseb)
					legkisseb = szám4;
			}

			//V.
			StreamReader beolvasó5 = new StreamReader("input-V.txt", Encoding.UTF8);

			int első25ős=0, első25ösindex =-1, i =0, legnagyobb25összám=int.MinValue;
			while (!beolvasó5.EndOfStream)
			{
				int szám5 = int.Parse(beolvasó5.ReadLine());
				i++;

				if (szám5 % 25 == 0)
					első25ős = szám5;

				if (szám5 % 25 == 0)
					első25ösindex = i;

				if (szám5 % 25 == 0 && szám5 > legnagyobb25összám)
					legnagyobb25összám = szám5;

			}

			//VI
			StreamReader beolvasó6 = new StreamReader("input-VI.txt", Encoding.UTF8);

			int r = 0, legnagyobb25ösindex =-1, utsó25ös =0, legnagyobb25összám2 =int.MinValue, utsó25összám = 0, utsó25összámindex =-1;
			while (!beolvasó6.EndOfStream)
			{
				int szám6= int.Parse(beolvasó6.ReadLine());
				r++;

				if (szám6 % 25 == 0 && szám6 > legnagyobb25összám2)
					legnagyobb25összám = szám6;


				if (szám6 % 25 == 0 && szám6 > legnagyobb25összám2)
					legnagyobb25ösindex = r;

				if (szám6 % 25 == 0)
				{
					utsó25összám = szám6;
					utsó25összámindex = r;
				}
			}
			

			//VII
			StreamReader beolvasó7 = new StreamReader("input-VII.txt", Encoding.UTF8);
			bool hármasutízes = false;
			int tizeshármasindex = -2, d = 0, hármastizesindex = -1;

			while (!beolvasó7.EndOfStream)
			{
				int szám7 = int.Parse(beolvasó7.ReadLine());
				d++;

				if (szám7 % 3 == 0 && tizeshármasindex % 10 == 0)
				{ hármasutízes = true;
					hármastizesindex = d;
				}
			}



			Console.WriteLine("1.: "+szám);
			StreamWriter első = new StreamWriter("output1.txt");
			első.Write(szám);
			első.Close();
			Console.WriteLine("2.: "+ összeg);
			StreamWriter második = new StreamWriter("output2.txt");
			második.Write(összeg);
			második.Close();
			Console.WriteLine("3.: "+átlag);
			StreamWriter harmadik = new StreamWriter("output3.txt");
			harmadik.Write(átlag);
			harmadik.Close();


			Console.WriteLine("4a.: "+ negatívpáros);
			StreamWriter negyedika = new StreamWriter("output4a.txt");
			negyedika.Write(negatívpáros);
			negyedika.Close();
			Console.WriteLine("4b.: "+ negativpárosok);
			StreamWriter negyedikb = new StreamWriter("output4b.txt");
			negyedikb.WriteLine(negativpárosok);
			negyedikb.Close();

			Console.WriteLine("5a.: "+ ötvenszázas);
			StreamWriter ötödika = new StreamWriter("output5a.txt");
			ötödika.Write(ötvenszázas);
			ötödika.Close();
			Console.WriteLine("5b.: " + ötvenszázasösszeg);
			StreamWriter ötödikb = new StreamWriter("output5b.txt");
			ötödikb.Write(ötvenszázasösszeg);
			ötödikb.Close();

			Console.WriteLine("6a.: "+ legkisseb);
			StreamWriter hatodika = new StreamWriter("output6.txt");
			hatodika.Write(legkisseb);
			hatodika.Close();

			Console.WriteLine("7.: "+ első25ős);
			StreamWriter hetedik = new StreamWriter("output7.txt");
			hetedik.Write(első25ős);
			hetedik.Close();
			Console.WriteLine("8.: "+ első25ösindex);
			StreamWriter nyolcadik = new StreamWriter("output8.txt");
			nyolcadik.Write(első25ösindex);
			nyolcadik.Close();
			Console.WriteLine("9.: " + legnagyobb25összám);
			StreamWriter kilencedik = new StreamWriter("output9.txt");
			kilencedik.Write(legnagyobb25összám);
			kilencedik.Close();

			Console.WriteLine("10.: "+ utsó25ös);
			StreamWriter tizedik = new StreamWriter("output10.txt");
			tizedik.Write(utsó25ös);
			tizedik.Close();
			Console.WriteLine("11.: " + utsó25összám);
			StreamWriter tizenegy = new StreamWriter("output11.txt");
			tizenegy.Write(legnagyobb25ösindex);
			tizenegy.Close();
			Console.WriteLine("12.: " + utsó25összámindex);
			StreamWriter tizenkettő = new StreamWriter("output12.txt");
			tizenkettő.Write(legnagyobb25ösindex);
			tizenkettő.Close();


			Console.WriteLine("13a.: "+ hármasutízes);
			StreamWriter tizenharmadika = new StreamWriter("output13a.txt");
			tizenharmadika.Write(hármasutízes);
			tizenharmadika.Close();
			Console.WriteLine("13b.: "+ hármastizesindex);
			StreamWriter tizenharmadikb = new StreamWriter("output13b.txt");
			tizenharmadikb.Write(hármastizesindex);
			tizenharmadikb.Close();



			beolvasó.Close();
			beolvasó2.Close();
			beolvasó3.Close();
			beolvasó4.Close();
			beolvasó5.Close();
			beolvasó6.Close();
			beolvasó7.Close();
		}
	}
}
