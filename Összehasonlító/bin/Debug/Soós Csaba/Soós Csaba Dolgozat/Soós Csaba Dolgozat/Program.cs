using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Soós_Csaba_Dolgozat
{
    class Program
    {
        static void Main(string[] args)
        {
            // input I:
            //1. feladat
            Console.WriteLine("1. Hány szám található a megadott fájlban?");
            StreamReader r = new StreamReader("input-I.txt");
            StreamWriter w = new StreamWriter("output1.txt");

            int darab = 0;
            while (!r.EndOfStream)
            {
                int.Parse(r.ReadLine());
                darab++;
            }
            Console.WriteLine("A fájlban {0} szám található.", darab);

            w.WriteLine(darab);
            w.Close();
            r.Close();

            // 2. feladat
            Console.WriteLine("2. Mennyi a megadott fájlban található számok összege?");
            StreamReader r2 = new StreamReader("input-I.txt");
            StreamWriter w2 = new StreamWriter("output2.txt");

            int osszeg = 0;
            int szam = 0;
            while (!r2.EndOfStream)
            {
                szam = int.Parse(r2.ReadLine());
                osszeg += szam;
            }

            Console.WriteLine("A számok összege {0}", osszeg);
            w2.WriteLine(osszeg);
            w2.Close();
            r2.Close();

            // 3. feladat
            Console.WriteLine("3. Mennyi a megadott fájlban található számok átlaga?");
            StreamReader r3 = new StreamReader("input-I.txt");
            StreamWriter w3 = new StreamWriter("output3.txt");

            int i3 = 0;
            int sum = 0;
            int db = 0;
            while (!r3.EndOfStream)
            {
                i3 = int.Parse(r3.ReadLine());
                sum = sum + i3;
                db++;
            }
            double sum2 = (double)sum;
            double db2 = (double)db;
            double átlag = sum2 / db2;
            Console.WriteLine("A számok átlaga {0:0.00}", átlag);

            w3.WriteLine("0:0.00", átlag);
            w3.Close();
            r3.Close();

            //input 2:
            // 4. feladat:
            StreamReader r4 = new StreamReader("input-II.txt");
            StreamWriter w4a = new StreamWriter("output4a.txt");
            StreamWriter w4b = new StreamWriter("output4b.txt");
            bool negavtiv4 = false;
            bool paros4 = false;
            int i4 = 0;
            bool megvan4 = false;
            
            while (!r4.EndOfStream)
            {
                negavtiv4 = false;
                paros4 = false;
                i4 = int.Parse(r4.ReadLine());
                if (i4 % 2 == 0)
                {
                    paros4 = true;
                }
                if (i4 < 0)
                {
                    negavtiv4 = true;
                }
                if (paros4 && negavtiv4)
                {
                    w4b.WriteLine(i4);
                }
            }
            //a
            Console.WriteLine("4. a) Van-e negatív páros szám a megadott fájlban?");
            if (negavtiv4 && paros4)
            {
                megvan4 = true;
                Console.WriteLine("Van negatív páros szám a fájlban.");
                w4a.WriteLine(megvan4);
            }
            else
            {
                megvan4 = false;
                Console.WriteLine("Nincs negatív páros szám a fájlban.");
                w4a.WriteLine(megvan4);
            }
            w4a.Close();

            //b
            Console.WriteLine("4. b) Válogasd ki / Szűrd ki a negatív páros számokat a fájlból!");

            w4b.Close();
            r4.Close();


            //input III:
            //5. feladat:
            StreamReader r5 = new StreamReader("input-III.txt");
            StreamWriter w5a = new StreamWriter("output5a.txt");
            StreamWriter w5b = new StreamWriter("output5b.txt");
            int kozott5 = 0;
            int i5 = 0;
            int osszeg5 = 0;
            while (!r5.EndOfStream)
            {
                i5 = int.Parse(r5.ReadLine());
                if (i5 >= 50 && i5 <= 100)
                {
                    kozott5++;
                    osszeg5 += i5;
                }
            }
            // a
            Console.WriteLine("5. a) Hány 50 és 100 közötti (az 50 és a 100 még benne van) szám található a fájlban?");
            Console.WriteLine("A fájlban {0} db 50 és 100 közötti szám található.", kozott5);
            w5a.WriteLine(kozott5);
            //b
            Console.WriteLine("5. b) Mennyi ezen számok összege? (tehát csak az 50 és 100 közé eső számok összege?");
            Console.WriteLine("Ezen számok összege :{0}", osszeg5);
            w5b.WriteLine(osszeg5);

            w5b.Close();
            w5b.Close();
            r5.Close();

            //inputIV
            //6. feladat

            Console.WriteLine("6. a) Add meg a megadott fájlban található legkisebb számot!");
            StreamReader r6 = new StreamReader("input-IV.txt");
            StreamWriter w6 = new StreamWriter("output6.txt");

            int i6 = 0;
            int legkisebbszám = 0;
            while (!r6.EndOfStream)
            {
                i6 = int.Parse(r6.ReadLine());
                if (i6 < legkisebbszám)
                {
                    legkisebbszám = i6;
                }
            }
            Console.WriteLine("A legkisebb szám a {0}", legkisebbszám);

            w6.WriteLine(legkisebbszám);
            w6.Close();
            r6.Close();

            // inputV
            //7.feladat:
            Console.WriteLine("7. Mi az első 25-tel osztható szám?");
            StreamReader r7 = new StreamReader("input-V.txt");
            StreamWriter w7 = new StreamWriter("output7.txt");
            int i7 = 0;
            bool megvan7 = false;
            while (!megvan4 && !r7.EndOfStream)
            {
                i7 = int.Parse(r7.ReadLine());
                if (i7 % 25 == 0)
                {
                    megvan7 = true;
                }
            }
            Console.WriteLine("Az első 25-tel osztható szám a {0}", i7);
            w7.WriteLine(i7);
            w7.Close();
            r7.Close();

            //8.feladat:
            Console.WriteLine("8. Mi az első 25-tel osztható szám indexe?");
            StreamReader r8 = new StreamReader("input-V.txt");
            StreamWriter w8 = new StreamWriter("output8.txt");
            int i8 = 0;
            int index8 = 0;
            bool megvan8 = false;
            while (!megvan8 && !r8.EndOfStream)
            {
                i8 = int.Parse(r8.ReadLine());
                index8++;
                if (i8 % 25 == 0)
                {
                    megvan8 = true;
                }
            }
            Console.WriteLine("Az első 25-tel osztható szám indexe: {0}", index8);

            w8.WriteLine(index8);
            w8.Close();
            r8.Close();

            //9.feladat:
            Console.WriteLine("9. Mi a legnagyobb 25-tel osztható szám?");
            StreamReader r9 = new StreamReader("input-V.txt");
            StreamWriter w9 = new StreamWriter("output9.txt");
            int i9 = 0;
            int legnagyobb9 = 0;
            
            while (!r9.EndOfStream)
            {
                i9 = int.Parse(r9.ReadLine());
                if (i9 % 25 == 0 && i9 > legnagyobb9)
                {
                    legnagyobb9 = i9;
                }
            }
            Console.WriteLine("A legnagyobb 25-tel osztható szám a {0}", legnagyobb9);
            w9.WriteLine(legnagyobb9);
            w9.Close();
            r9.Close();

            //VI input
            // 10 feladat:
            Console.WriteLine("10. Mi az utolsó 25-tel osztható szám?");
            StreamReader r10 = new StreamReader("input-VI.txt");
            StreamWriter w10 = new StreamWriter("output10.txt");
            int i10 = 0;
            int utolso10 = 0;
            while (!r10.EndOfStream)
            {
                i10 = int.Parse(r10.ReadLine());
                if (i10 % 25 == 0)
                {
                    utolso10 = i10;
                }
            }
            Console.WriteLine("Az utolsó 25-tel osztható szám a {0}", utolso10);
            w10.WriteLine(utolso10);
            w10.Close();
            r10.Close();

            /*//11 feladat
            Console.WriteLine("11. Mi az utolsó 25-tel osztható szám indexe?");
            StreamReader r11 = new StreamReader("input-VI.txt");
            StreamWriter w11 = new StreamWriter("output11.txt");
            int i11 = 0;
            int index11a = 0;
            
            int index11b = 0;

            while (!r11.EndOfStream)
            {
                i11 = int.Parse(r11.ReadLine());
                index11a++;
                if (i11 % 25 == 0)
                {                    
                    index11b++;
                }
                if (i11 % 25 !== 0)
                {

                }
            }
            Console.WriteLine("Az utolsó 25-tel osztható szám indexe: {0}", );

            w11.WriteLine();
            w11.Close();
            r11.Close();

            //*/
        }
    }
}
