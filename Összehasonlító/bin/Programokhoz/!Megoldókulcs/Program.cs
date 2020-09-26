using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PT1_Megoldókulcs
{
	class Program
	{
		static List<int> Számbeolvasás(string fájl)
		{
			StreamReader f = new StreamReader(fájl);
			List<int> lista = new List<int>();
			while (!f.EndOfStream){ lista.Add(int.Parse(f.ReadLine())); }
			f.Close();
			return lista;
		}

		static int Db<T>(List<T> szám) { return szám.Count; }
		static void Kiír<T>(string fájl, T kiírandó)
		{
			{
				Console.WriteLine(kiírandó);
				StreamWriter f = new StreamWriter(fájl);
				f.WriteLine(kiírandó);
				f.Close();
			}
		}
		static void ListaKiír<T>(string fájl, List<T> kiírandó)
		{
			{
				StreamWriter f = new StreamWriter(fájl);
				foreach (T elem in kiírandó)
				{
					Console.WriteLine(elem);
					f.WriteLine(elem);
				}
				f.Close();
			}
		}
		static void Main(string[] args)
		{
			string k = "";// @"2\";
			// -----------------------
			// I. feladatcsoport
			List<int> ilista1 = Számbeolvasás(k+"input-I.txt");
			// 1. feladat: Count
			Kiír<int>("output1.txt", ilista1.Count);
			// 2. feladat: Összeg
			Kiír<int>("output2.txt", ilista1.Sum());
			// 3. feladat: Átlag
			Kiír<double>("output3.txt", ilista1.Average());
			// -----------------------
			// II. feladatcsoport
			List<int> ilista2 = Számbeolvasás(k + "input-II.txt");
			// 4a. feladat: Eldöntés
			Kiír<bool>("output4a.txt", ilista2.Where(x => x < 0 && x % 2 == 0).Count() > 0);
			// 4b. feladat: Kiválogatás
			ListaKiír<int>("output4b.txt", ilista2.Where(x => x < 0 && x % 2 == 0).ToList());
			// -----------------------
			// III. feladatcsoport
			List<int> ilista3 = Számbeolvasás(k + "input-III.txt");
			// 4a. feladat: Kiválogatás + Count
			Kiír<int>("output5a.txt", ilista3.Where(x => 50 <= x && x <= 100).Count());
			// 4b. feladat: Kiválogatás + Max
			Kiír<int>("output5b.txt", ilista3.Where(x => 50 <= x && x <= 100).Sum());
			// -----------------------
			// IV. feladatcsoport
			List<int> ilista4 = Számbeolvasás(k + "input-V.txt");
			// 4a. feladat: Minimumkiválasztás
			Kiír<int>("output6.txt", ilista4.Min());
			// -----------------------
			// V. feladatcsoport
			List<int> ilista5 = Számbeolvasás(k + "input-V.txt");
			// 5a. feladat: Keresés, ha van
			Kiír<int>("output7.txt", ilista5.Where(x => x % 25 == 0).First());
			// 5b. feladat: Keresés indexszel
			Kiír<int>("output8.txt", ilista5.IndexOf(ilista5.Where(x => x % 25 == 0).First()));
			// 5c. feladat: Kiválogatás + Max
			Kiír<int>("output9.txt", ilista5.Where(x => x % 25 == 0).Max());
			// -----------------------
			// VI. feladatcsoport
			List<int> ilista6 = Számbeolvasás(k + "input-VI.txt");
			// 6a. feladat: Keresés, ha nem biztos, hogy van
			if (ilista6.Where(x => x % 25 == 0).Count() > 0)
			{
				Kiír<int>("output10.txt", ilista6.Where(x => x % 25 == 0).First());
			}
			else 
			{
				Kiír<bool>("output10.txt", false);
			}
			// 6b. feladat: Keresés indexszel
			if (ilista6.Where(x => x % 25 == 0).Count() > 0)
			{
				Kiír<int>("output11.txt", ilista6.IndexOf(ilista6.Where(x => x % 25 == 0).First()));
			}
			else
			{
				Kiír<bool>("output11.txt", false);
			}
			// 6c. feladat: Kiválogatás + Max
			if (ilista6.Where(x => x % 25 == 0).Count() > 0)
			{
				Kiír<int>("output12.txt", ilista6.Where(x => x % 25 == 0).Max());
			}
			else
			{
				Kiír<bool>("output12.txt", false);
			}
			
			// VII. feladatcsoport
			List<int> ilista7 = Számbeolvasás(k + "input-VII.txt");
			// 6a. feladat: részsorozat-eldöntés
			int készültség = 0;
			int ix = -1;
			for (int i = 0; i < ilista7.Count && ix<0; i++)
			{
				if (ilista7[i] % 3 == 0)
				{
					if (készültség == 1 && ilista7[i] % 10 == 0)
					{
						ix = i;
					}
					else
					{
						készültség = 1;
					}
				}
				else if (ilista7[i] % 10 == 0 && készültség == 1)
				{
					ix = i;
				}
				else
				{
					készültség = 0;
				}
			}
			// 13a. feladat: Részsorozat-eldöntés
			Kiír<bool>("output13a.txt", ix > 0);
			// 13b. feladat: Részsorozat-keresés
			Kiír<int>("output13b.txt", ix);
		}
	}
}