using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Dolgozat_Faludy_Gergő
{
    class Program
    {
        static void Main(string[] args)
        {   //I.
            //1. feladat: Hány szám található a megadott fájlban?

            StreamReader r1 = new StreamReader("output1.txt", Encoding.UTF8);
            StreamWriter w1 = new StreamWriter("input-I.txt");
            Console.WriteLine("1. Hány szám található a megadott fájlban?");
            int i1 = 0;
            while (!r1.EndOfStream)
            {
                r1.ReadLine();
                i1++;
            }
            Console.WriteLine("A fáljban {0} db szám van", i1);
            w1.WriteLine(i1);
            w1.Close();
            r1.Close();

            //I.
            //2. feladat: Mennyi a megadott fájlban található számok összege











            //I.
            //3. feladat: Mennyi a megadott fájlban található számok átlaga?
            Console.WriteLine();
            StreamReader r8 = new StreamReader("output2.txt", Encoding.UTF8);
            StreamWriter w8 = new StreamWriter("input-I.txt");
            Console.WriteLine("3. Mennyi a megadott fájlban található számok átlaga?");

            double prod8 = 0;
            double db8 = 0;
            while (!r8.EndOfStream)
            {
                prod8 += int.Parse(r8.ReadLine());
                db8++;
            }

            Console.WriteLine("A megadott fájlban található számok átlaga: {0:0.00}", prod8 / db8);
            w8.WriteLine(prod8 / db8);
            w8.Close();
            r8.Close();

            //-------------------------------------------------------------------------------------------------------------------------------------------------

            //II.
            //4. feladat

            //-------------------------------------------------------------------------------------------------------------------------------------------------

            //III.
            //5. feladat



            //-------------------------------------------------------------------------------------------------------------------------------------------------



            //IV.
            //6. feladat: a) Add meg a megadott fájlban található legkisebb számot!
            Console.WriteLine();
            StreamReader r3 = new StreamReader("output6.txt", Encoding.Default);
            StreamWriter w3 = new StreamWriter("input-IV.txt");
            Console.WriteLine("6. Mennyi a sorozatban található legkisebb szám? ");

            int szám3;
            int legkisebb3 = 0;
            while (!r3.EndOfStream)
            {
                szám3 = int.Parse(r3.ReadLine());
                if (szám3 < legkisebb3)
                {
                    legkisebb3 = szám3;
                }
            }

            Console.WriteLine("A sorozatban található legkisebb szám a(z) {0}", legkisebb3);
            w3.WriteLine(legkisebb3);
            w3.Close();
            r3.Close();
            //--------------------------------------------------------------------------------------------------------------------------------------------------

            //V.






            //V.
            //8. feladat: Mi az első 25-tel osztható szám indexe?
            Console.WriteLine();
            StreamReader r6 = new StreamReader("output8.txt", Encoding.UTF8);
            StreamWriter w6 = new StreamWriter("input-V.txt");
            Console.WriteLine("8. Mi az első 25-tel osztható szám indexe? ");

            bool megvan6 = false;
            int sorszám6 = -1;
            int szám6;
            while (!megvan6 && !r6.EndOfStream)
            {
                szám6 = int.Parse(r6.ReadLine());
                sorszám6++;
                if (szám6 != 0 && szám6 % 25 == 0)
                {
                    megvan6 = true;
                }
            }

            Console.WriteLine(megvan6 ? "Az első 25-tel oszható szám indexe: " + sorszám6 : "Nincs 25-tel osztható szám a sorozatban!");
            if (megvan6 == true) 
            {
                w6.WriteLine(sorszám6);
            }
            else
            {
                w6.WriteLine();
            }
            w6.Close();
            r6.Close();

            //------------------------------------------------------------------------------------------------------------------------------------------------

            //VI.
            //11. feladat: Mi az utolsó 25-tel osztható szám indexe?
            Console.WriteLine();
            StreamReader r10 = new StreamReader("output11.txt", Encoding.UTF8);
            StreamWriter w10 = new StreamWriter("input-VI.txt");
            Console.WriteLine("11.feladat: Írjuk ki az utolsó 25-tel osztható szám indexét!");

            int index10 = -1;
            int osztható25el = 0;
            bool vane = false;
            int szám10;
            while (!r10.EndOfStream)
            {
                szám10 = int.Parse(r10.ReadLine());
                index10++;
                if (szám10 != 0 && szám10 % 25 == 0)
                {
                    osztható25el = index10;
                    vane = true;
                }
            }

            Console.WriteLine(vane ? "Az utoló 25-tel osztható szám indexe a(z)" + osztható25el : "Nincs 25-tel osztható szám a sorozatban!");
            if (vane == true)
            {
                w10.WriteLine(osztható25el);
            }
            else
            {
                w10.WriteLine();
            }
            w10.Close();
            r10.Close();

        }
    }
}
