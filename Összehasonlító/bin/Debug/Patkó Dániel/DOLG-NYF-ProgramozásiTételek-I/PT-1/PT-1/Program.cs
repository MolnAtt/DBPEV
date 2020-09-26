using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PT_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //I. 
            StreamReader r = new StreamReader("input-I.txt", Encoding.UTF8);
            //1.
            string Beolvasottelem;
            int Elem = 0, Elemek_index = 0, Elemekösszege = 0;
            double Atlag = 0;
            while ((Beolvasottelem = r.ReadLine()) != null)
            {
                Elem = Int32.Parse(Beolvasottelem);
                //Console.Write(Beolvasottelem + ", ");
                //Elemek szama
                Elemek_index++;
                // osszege
                Elemekösszege += Elem;
                //atlaga

            }
            // I 1.
            Console.WriteLine("I.");
            Console.WriteLine("1. Hány szám található a megadott fájlban? " + Elemek_index);
            StreamWriter w = new StreamWriter("output1.txt");
            w.WriteLine(Elemek_index);
            w.Close();
            // I 2.
            Console.WriteLine("2. Mennyi a megadott fájlban található számok összege? " + Elemekösszege);
            StreamWriter w2 = new StreamWriter("output2.txt");
            w2.WriteLine(Elemekösszege);
            w2.Close();
            // I 3.
            Atlag = (double)Elemekösszege / Elemek_index;
            Console.WriteLine("3. Mennyi a megadott fájlban található számok átlaga? " + Atlag);
            StreamWriter w3 = new StreamWriter("output3.txt");
            w3.WriteLine(Atlag);
            w3.Close();
            Console.WriteLine("--------------------------------------------------------------------");

            // II
            StreamReader r2 = new StreamReader("input-II.txt", Encoding.UTF8);
            // II 4.
            string Beolvasottelem2, negativszamok = "b) Válogasd ki / Szűrd ki a negatív páros számokat a fájlból! Ezek a negativ paros szamok: ";
            int Elem2 = 0;
            bool vanenegativparos = false;
            StreamWriter w4b = new StreamWriter("output4b.txt");
            while ((Beolvasottelem2 = r2.ReadLine()) != null)
            {
                Elem2 = Int32.Parse(Beolvasottelem2);
                //Console.Write(Beolvasottelem2 + ", ");
                // 4.
               
                int maradék = Elem2 % 2;
                if (Elem2 < 0 && maradék == 0)
                {
                    vanenegativparos = true;
                    negativszamok += Beolvasottelem2 + ", ";
                    
                    w4b.WriteLine(Beolvasottelem2);
                }
            }
            w4b.Close();
            // 4. a
            Console.WriteLine("II.");
            Console.WriteLine(vanenegativparos ? "4. a) Van-e negatív páros szám a megadott fájlban? Van." : "4. a) Van-e negatív páros szám a megadott fájlban? Nincs.");
            StreamWriter w4a = new StreamWriter("output4b.txt");
            w4a.WriteLine(vanenegativparos);
            w4a.Close();
            // 4. b
            Console.WriteLine(negativszamok);
            Console.WriteLine("--------------------------------------------------------------------");

            // III.
            StreamReader r3 = new StreamReader("input-III.txt", Encoding.UTF8);
            string Beolvasottelem3;
            int Elem3 = 0, otvenesszazkozeeesok = 0, otvenes100kozottiosszege = 0;

            while ((Beolvasottelem3 = r3.ReadLine()) != null)
            {
                Elem3 = Int32.Parse(Beolvasottelem3);
                //Console.Write(Beolvasottelem3 + ", ");
                // 5. a
                if (Elem3 < 100 && Elem3 > 50)
                {
                    otvenesszazkozeeesok++;
                    otvenes100kozottiosszege += Elem3;
                }
            }
            // 5a
            Console.WriteLine("III.");
            Console.WriteLine("5.a) Hány 50 és 100 közötti (az 50 és a 100 még benne van) szám található a fájlban? " + otvenesszazkozeeesok);
            StreamWriter w5a = new StreamWriter("output5a.txt");
            w5a.WriteLine(otvenesszazkozeeesok);
            w5a.Close();
            Console.WriteLine("5.b) Mennyi ezen számok összege? (tehát csak az 50 és 100 közé eső számok összege?) " + otvenes100kozottiosszege);
            StreamWriter w5b = new StreamWriter("output5b.txt");
            w5b.WriteLine(otvenes100kozottiosszege);
            w5b.Close();
            Console.WriteLine("--------------------------------------------------------------------");

            //IV
            // 6.
            StreamReader r4 = new StreamReader("input-IV.txt", Encoding.UTF8);
            string Beolvasottelem4;
            int Elem4 = 0, legkisebbszam = 0;
            while ((Beolvasottelem4 = r4.ReadLine()) != null)
            {
                Elem4 = Int32.Parse(Beolvasottelem4);
               //Console.Write(Beolvasottelem4 + ", ");
                if (legkisebbszam > Elem4)
                {
                    legkisebbszam = Elem4;
                }
            }
            // 6
            Console.WriteLine("6. a) Add meg a megadott fájlban található legkisebb számot! " + legkisebbszam);
            StreamWriter w6 = new StreamWriter("output6.txt");
            w6.WriteLine(legkisebbszam);
            w6.Close();
            Console.WriteLine("--------------------------------------------------------------------");

            //V
            StreamReader r5 = new StreamReader("input-V.txt", Encoding.UTF8);
            string Beolvasottelem5;
            int Elem5 = 0, elsohuszon5eloszhato = 0, huszon5eloszthatoindexe = 0, index = 0, legnagyobb25eloszhato = 0;
            bool vanhuszon5eloszhato = false;
            while ((Beolvasottelem5 = r5.ReadLine()) != null)
            {
                Elem5 = Int32.Parse(Beolvasottelem5);
                index++;
                //Console.Write(Beolvasottelem5 + ", ");
                int maradék5 = Elem5 % 25;
                if (maradék5 == 0 && vanhuszon5eloszhato == false)
                {
                    elsohuszon5eloszhato = Elem5;
                    huszon5eloszthatoindexe = index;
                    vanhuszon5eloszhato = true;
                }
                if (maradék5 == 0 && Elem5 > legnagyobb25eloszhato)
                {
                    legnagyobb25eloszhato = Elem5;
                }
            }
            //7
            Console.WriteLine("V.");
            Console.WriteLine("7. Mi az első 25-tel osztható szám? " + elsohuszon5eloszhato);
            StreamWriter w7 = new StreamWriter("output7.txt");
            w7.WriteLine(elsohuszon5eloszhato);
            w7.Close();
            // 8
            Console.WriteLine("8. Mi az első 25-tel osztható szám indexe? " + huszon5eloszthatoindexe);
            StreamWriter w8 = new StreamWriter("output8.txt");
            w8.WriteLine(huszon5eloszthatoindexe);
            w8.Close();
            // 9
            Console.WriteLine("9. Mi a legnagyobb 25-tel osztható szám? " + legnagyobb25eloszhato);
            StreamWriter w9 = new StreamWriter("output9.txt");
            w9.WriteLine(legnagyobb25eloszhato);
            w9.Close();
            Console.WriteLine("--------------------------------------------------------------------");

            // VI
            // 10.
            StreamReader r6 = new StreamReader("input-VI.txt", Encoding.UTF8);
            string Beolvasottelem6;
            bool vanhuszon5eloszhato2 = false;
            int Elem6 = 0, huszon5eloszhato = 0, huszon5eloszthatoindexe2 = 0, index2 = 0, legnagyobb25eloszhato2 = 0, legnagyobbindexe = 0;
            while ((Beolvasottelem6 = r6.ReadLine()) != null)
            {
                Elem6 = Int32.Parse(Beolvasottelem6);
                index2++;
                //Console.Write(Beolvasottelem6 + ", ");
                int maradék6 = Elem6 % 25;
                if (maradék6 == 0)
                {
                    huszon5eloszhato = Elem6;
                    huszon5eloszthatoindexe2 = index2;
                    vanhuszon5eloszhato2 = true;
                }
                if (maradék6 == 0 && Elem6 > legnagyobb25eloszhato)
                {
                    legnagyobbindexe = index2;
                }
            }
            //
            Console.WriteLine("VI");
            Console.WriteLine(vanhuszon5eloszhato2 ? "10.  Mi az utolsó 25-tel osztható szám? " + huszon5eloszhato : "Nincs ebben a fájlban 25-tel osztható szám");
            StreamWriter w10 = new StreamWriter("output10.txt");
            if (vanhuszon5eloszhato2)
            {
                w10.WriteLine(huszon5eloszhato);
            }
            else
            {
                w10.WriteLine(vanhuszon5eloszhato2);
            }
            w10.Close();
            //
            Console.WriteLine(vanhuszon5eloszhato2 ? "11. Mi az utolsó 25-tel osztható szám indexe? " + huszon5eloszthatoindexe2 : "Nincs ebben a fájlban 25-tel osztható szám");
            StreamWriter w11 = new StreamWriter("output11.txt");
            if (vanhuszon5eloszhato2)
            {
                w11.WriteLine(huszon5eloszthatoindexe2);
            }
            else
            {
                w11.WriteLine(vanhuszon5eloszhato2);
            }
            w11.Close();
            //
            Console.WriteLine(vanhuszon5eloszhato2 ? "Mi a legnagyobb 25-tel osztható szám indexe? " + legnagyobbindexe : "Nincs ebben a fájlban 25-tel osztható szám");
            StreamWriter w12 = new StreamWriter("output12.txt");
            if (vanhuszon5eloszhato2)
            {
                w12.WriteLine(legnagyobbindexe);
            }
            else
            {
                w12.WriteLine(vanhuszon5eloszhato2);
            }
            w12.Close();
            Console.WriteLine("--------------------------------------------------------------------");

            // VII
            StreamReader r7 = new StreamReader("input-VII.txt", Encoding.UTF8);
            string Beolvasottelem7;
            int Elem7 = 0, Elozoelem7 = 0, haromindexe = 0, index7 = 0;
            bool vane3es10eloszthato = false;
            while ((Beolvasottelem7 = r7.ReadLine()) != null)
            {
                Elem7 = Int32.Parse(Beolvasottelem7);
                index7++;
                //Console.Write(Beolvasottelem7 + ", ");
                int maradek3 = Elozoelem7 % 3, maradek10 = Elem7 % 10;
                if (maradek10 == 0 && maradek3 == 0)
                {
                    vane3es10eloszthato = true;
                    haromindexe = index7;
                }


                Elozoelem7 = Elem7;
            }
            //
            Console.WriteLine("VII");
            Console.Write("13. a) Előfordul-e olyan a sorozatban, hogy egy 3-mal osztható számot egy 10-zel osztható szám követ? ");
            Console.WriteLine(vane3es10eloszthato ? "Igen, van" : "Nem, nincs");
            StreamWriter w13a = new StreamWriter("output13a.txt");
            w13a.WriteLine(vane3es10eloszthato);
            w13a.Close();
            //
            Console.Write("b) Ha előfordul ilyen, akkor mi ennek az előfordulásnak az indexe (a 3-mal osztható szám indexére gondolunk)");
            Console.WriteLine(vane3es10eloszthato ? " " + haromindexe : "Nincs 3-mal oszhato amelyet 10-zel osztható követ!");
            StreamWriter w13b = new StreamWriter("output13b.txt");
            if (vane3es10eloszthato)
            {
                w13b.WriteLine(haromindexe);
            }
            else
            {
                w13b.WriteLine(vane3es10eloszthato);
            }
            w13b.Close();

        }
    }
}
