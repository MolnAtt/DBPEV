using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szabó_Bence_Programozási_tételek
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamReader r1 = new StreamReader("input-I.txt", Encoding.UTF8);



            int Aktuáliselem = 0;
            string BeolvasottElem;
            int Hányelemevan = 0;
            int Összesszámösszege = 0;
            double Összesszámátlaga = 0;

            while ((BeolvasottElem = r1.ReadLine()) != null)
            {
                Aktuáliselem = Int32.Parse(BeolvasottElem);
                //1-----------------------------------------

                Hányelemevan++;

                //2---------------------------------------

                Összesszámösszege += Aktuáliselem;

                //2---------------------------------------

                Összesszámátlaga = Összesszámösszege / Hányelemevan;
            }

            //I/1-------------------------------------------------------------------
            StreamWriter w1 = new StreamWriter("output-I.txt");
            Console.WriteLine("A fáljban {0} db szám van", Hányelemevan);
            Console.WriteLine();
            w1.WriteLine(Hányelemevan);
            //I/2-------------------------------------------------------------------

            StreamWriter w2 = new StreamWriter("output-II.txt");
            Console.WriteLine("A megadott fájlban található számok összege:" + Összesszámösszege);
            Console.WriteLine();
            w1.WriteLine(Összesszámösszege);

            //I/3-------------------------------------------------------------------

            StreamWriter w3 = new StreamWriter("output-III.txt");
            Console.WriteLine("A megadott fájlban található számok átlaga:" + (double)Összesszámátlaga);
            Console.WriteLine();
            w1.WriteLine(Összesszámátlaga);




            //--------------------------------------------------------------------------



            StreamReader r2 = new StreamReader("input-II.txt", Encoding.UTF8);

            bool Vanenegatívparos = false;
            int Negativparosszamok = 0;
            int Paratlanszamok = 0;

            while ((BeolvasottElem = r2.ReadLine()) != null)
            {
                Aktuáliselem = Int32.Parse(BeolvasottElem);

                //1--------------------------------------------

                int maradek1 = Aktuáliselem % 2;
                if (maradek1 != 0 && Vanenegatívparos == false)
                {
                    Paratlanszamok++;
                    if (Paratlanszamok > 0 && Aktuáliselem < 0)
                    {
                        Vanenegatívparos = true;
                    }
                }

                //2--------------------------------------------

                int maradek2 = Aktuáliselem % 2;
                if (maradek2 == 0)
                {

                    //Negativparosszamok += BeolvasottElem += ", ";

                }

            }

            //II/1-------------------------------------------------------------------

            StreamWriter w4 = new StreamWriter("output4a.txt");
            Console.WriteLine("Van-e negatív páros szám a megadott fájlban?" + Vanenegatívparos);
            Console.WriteLine();
            w1.WriteLine(Vanenegatívparos);

            //II/2-------------------------------------------------------------------

            StreamWriter w5 = new StreamWriter("output4b.txt");
            Console.WriteLine("A fájlban található negatív páros számok:" + Negativparosszamok);
            Console.WriteLine();
            w1.WriteLine(Negativparosszamok);

           

            //III----------------------------------------------------------------------------------

            StreamReader r3 = new StreamReader("input-III.txt", Encoding.UTF8);

            int Az50és100kösöttiszamok = 0;

            while ((BeolvasottElem = r3.ReadLine()) != null)
            {
                Aktuáliselem = Int32.Parse(BeolvasottElem);

                //III/1
                if (Aktuáliselem >= 50 && Aktuáliselem <= 100)
                {
                    Az50és100kösöttiszamok = Aktuáliselem;
                }





            }

            StreamWriter w6 = new StreamWriter("output5a.txt");
            Console.WriteLine("A  fájlban található 50 és 100 közti számok:" + Az50és100kösöttiszamok);
            Console.WriteLine();
            w1.WriteLine(Az50és100kösöttiszamok);


            //IV-----------------------------------------------

            StreamReader r4 = new StreamReader("input-IV.txt", Encoding.UTF8);

            int Legkisebbszam = 0;
            while ((BeolvasottElem = r4.ReadLine()) != null)
            {
                //IV/1------------------------------------------------------------

                if (Legkisebbszam > Aktuáliselem && Legkisebbszam != Aktuáliselem)
                {
                    Legkisebbszam = Aktuáliselem;
                }




            }

            StreamWriter w7 = new StreamWriter("output6.txt");
            Console.WriteLine("A fájlban található legkiseb szám:" + Legkisebbszam);
            Console.WriteLine();
            w1.WriteLine(Legkisebbszam);

            //-----------------------------------------------------------------------

            StreamReader r5 = new StreamReader("input-IV.txt", Encoding.UTF8);

            int elsö25teloszthato = 0;
           
            while ((BeolvasottElem = r4.ReadLine()) != null)
            {
                int maradek3 = Aktuáliselem % 25;
                if (maradek3 == 0)
                {
                    elsö25teloszthato = Aktuáliselem;
                }
               




            }

            StreamWriter w8 = new StreamWriter("output7a.txt");
            Console.WriteLine("A fájlban található elsö25teloszthato osztható elsö szám:" + elsö25teloszthato);
            Console.WriteLine();
            w1.WriteLine(elsö25teloszthato);
        }
    }
}
