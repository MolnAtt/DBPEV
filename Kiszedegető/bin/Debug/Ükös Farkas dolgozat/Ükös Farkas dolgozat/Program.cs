using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ükös_Farkas_dolgozat
{
    class Program
    {
        static void Main(string[] args)
        {
            //I. feladat----------------------------------------------------------------
            Console.WriteLine("I. feladat:");
            StreamReader r1 = new StreamReader("input-I.txt", Encoding.Default);

            int szám1;
            double db1 = 0;
            double összeg1 = 0;

            while (!r1.EndOfStream)
            {
                szám1 = int.Parse(r1.ReadLine());

                db1++;

                összeg1 = +szám1;

            }

            //1.Feladat------------------------------
            StreamWriter w1 = new StreamWriter("output1.txt");
            Console.WriteLine("A sorozatban {0} db szám található", db1);
            w1.WriteLine(db1);
            Console.WriteLine();
            w1.Close();
            //2.Feladat------------------------------
            StreamWriter w2 = new StreamWriter("output2.txt");
            Console.WriteLine("A sorozat számainak összege " + összeg1);
            w2.WriteLine(összeg1);
            Console.WriteLine();
            w2.Close();
            //3.Feladat------------------------------
            StreamWriter w3 = new StreamWriter("output3.txt");
            Console.WriteLine("A sorozat átlaga {0:0.00}", összeg1 / db1);
            w3.WriteLine(összeg1 / db1);
            Console.WriteLine();
            w3.Close();

            //II. feladat----------------------------------------------------------------
            Console.WriteLine("II. feladat:");
            StreamReader r2 = new StreamReader("input-II.txt", Encoding.Default);
            StreamWriter w4a = new StreamWriter("output4a.txt");
            StreamWriter w4b = new StreamWriter("output4b.txt");


            int szám2;
            bool párosnegatív = false;
            string párosnegatívkiirás = "";
            while (!r2.EndOfStream)
            {
                szám2 = int.Parse(r2.ReadLine());

                if (szám2<0&&szám2%2==0)
                {
                    párosnegatív = true;
                    párosnegatívkiirás += szám2 + ", ";
                    w4b.WriteLine(szám2);

                }
            }
            //4.Feladat a)------------------------------
            Console.WriteLine(párosnegatív?"Igen, van ilyen szám":"Nem, nincs ilyen szám");
            Console.WriteLine();
            //4.Feladat b)------------------------------
            if(párosnegatív==true)
            {
                w4a.WriteLine(párosnegatív);
                Console.WriteLine("A páros és egyben negatív számok: " + párosnegatívkiirás);
                Console.WriteLine();
            }
            else
            {
                w4a.WriteLine(párosnegatív);
                w4b.WriteLine(párosnegatív);
            }
            w4b.Close();
            w4a.Close();

            //III. feladat---------------------------------------------------------------
            Console.WriteLine("III. feladat:");
            StreamReader r3 = new StreamReader("input-III.txt", Encoding.Default);
            StreamWriter w5a = new StreamWriter("output5a.txt");
            StreamWriter w5b = new StreamWriter("output5b.txt");

            int szám3;
            int ötvenésszázközöttdb = 0;
            int ötvenésszázközöttösszeg = 0;
            bool vaneilyen = false;
            while (!r3.EndOfStream)
            {
                szám3 = int.Parse(r3.ReadLine());

                if (szám3>49&&szám3<101)
                {
                    vaneilyen = true;
                    ötvenésszázközöttdb++;

                    ötvenésszázközöttösszeg +=szám3;
                }
            }

            Console.WriteLine(vaneilyen?"A fáljban 50 és 100 közé eső számok darabszáma: "+ ötvenésszázközöttdb:"Nincs olyan szám ami 50 és 100 közés esik");
            Console.WriteLine();
            if (vaneilyen==true)
            {
                w5a.WriteLine(ötvenésszázközöttdb);
                Console.WriteLine("Az összes 50 és 100 közé eső számok összege: " + ötvenésszázközöttösszeg);
                w5b.WriteLine(ötvenésszázközöttösszeg);
                Console.WriteLine();
            }
            else
            {
                w5a.WriteLine(vaneilyen);
                w5b.WriteLine(vaneilyen);

            }
            w5b.Close();
            w5a.Close();
            //IV. feladat---------------------------------------------------------------
            Console.WriteLine("IV. feladat:");
            StreamReader r4 = new StreamReader("input-IV.txt", Encoding.Default);
            StreamWriter w6 = new StreamWriter("output6.txt");

            int szám4;
            int min = 0;
            while (!r4.EndOfStream)
            {
                szám4 = int.Parse(r4.ReadLine());

                if (szám4<min)
                {
                    min = szám4;
                }
            }
            Console.WriteLine("A sorozat legkisebb eleme a(z) "+min);
            Console.WriteLine();
            w6.WriteLine(min);
            w6.Close();
            r4.Close();

            //V. feladat---------------------------------------------------------------
            Console.WriteLine("V. feladat:");
            StreamReader r5 = new StreamReader("input-V.txt", Encoding.Default);
            StreamWriter w7 = new StreamWriter("output7.txt");
            StreamWriter w8 = new StreamWriter("output8.txt");
            StreamWriter w9 = new StreamWriter("output9.txt");

            int szám5;
            bool elsőhuszonöt = false;
            int huszontöt = 0;
            int index = -1;
            int huszonötindex = 0;
            int max25 = 0;
            while (!r5.EndOfStream)
            {
                szám5 = int.Parse(r5.ReadLine());

                index++;
                if (szám5 % 25 == 0&&elsőhuszonöt==false)
                {
                    huszontöt = szám5;

                    huszonötindex = index;
                    elsőhuszonöt = true;
                }

                if (szám5%25==0&&max25<szám5)
                {
                    max25 = szám5;
                }
            }
            Console.WriteLine(elsőhuszonöt?"Az első 25-el oszthazó szám: "+huszontöt:"Nincs 25-el osztható szám");
            Console.WriteLine();
            if (elsőhuszonöt==true)
            {
                w7.WriteLine(huszontöt);
                Console.WriteLine("Az első 25-el osztható szám indexe: " + huszonötindex);
                Console.WriteLine();
                w8.WriteLine(huszonötindex);
                Console.WriteLine("A legnagyobb 25-el osztható szám: " + max25);
                Console.WriteLine();
                w9.WriteLine(max25);
            }
            else
            {
                w7.WriteLine(elsőhuszonöt);
                w8.WriteLine(elsőhuszonöt);
                w9.WriteLine(elsőhuszonöt);
            }

            w7.Close();
            w8.Close();
            w9.Close();
            r5.Close();
            //VI. feladat---------------------------------------------------------------
            Console.WriteLine("VI. feladat:");
            StreamReader r6  = new StreamReader("input-VI.txt", Encoding.Default);
            StreamWriter w10 = new StreamWriter("output10.txt");
            StreamWriter w11 = new StreamWriter("output11.txt");
            StreamWriter w12 = new StreamWriter("output12.txt");

            int szám6;
            int utolsóhuszontöt = 0;
            int index6 = -1;
            int utolsóhuszonötindex = 0;
            int Max25 = 0;
            bool van25 = false;
            int legnagyhuzsonötindex = 0;
            while (!r6.EndOfStream)
            {
                szám6 = int.Parse(r6.ReadLine());

                index6++;
                if (szám6 % 25 == 0)
                {
                    utolsóhuszontöt = szám6;

                    utolsóhuszonötindex = index;
                    van25 = true;
                }

                if (szám6 % 25 == 0 && Max25 < szám6)
                {
                    Max25 = szám6;
                    legnagyhuzsonötindex = index6;
                }
            }
            Console.WriteLine(van25 ? "Az utolsó 25-el oszthazó szám: " + utolsóhuszontöt : "Nincs 25-el osztható szám a sorozatban");
            Console.WriteLine();
            if (van25 == true)
            {
                w10.WriteLine(utolsóhuszontöt);
                Console.WriteLine("Az utolsó 25-el osztható szám indexe: " + utolsóhuszonötindex);
                Console.WriteLine();
                w11.WriteLine(utolsóhuszonötindex);
                Console.WriteLine("A legnagyobb 25-el osztható szám: " + legnagyhuzsonötindex);
                Console.WriteLine();
                w12.WriteLine(legnagyhuzsonötindex);
            }
            else
            {
                w10.WriteLine(van25);
                w11.WriteLine(van25);
                w12.WriteLine(van25);
            }

            w10.Close();
            w11.Close();
            w12.Close();
            r6.Close();

        }
    }
}
