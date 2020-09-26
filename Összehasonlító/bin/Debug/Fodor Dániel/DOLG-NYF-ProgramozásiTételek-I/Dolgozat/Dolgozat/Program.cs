using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Dolgozat
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader rI = new StreamReader("input-I.txt", Encoding.UTF8);
            StreamReader rII = new StreamReader("input-II.txt", Encoding.UTF8);
            StreamReader rIII = new StreamReader("input-III.txt", Encoding.UTF8);
            StreamReader rIV = new StreamReader("input-IV.txt", Encoding.UTF8);
            StreamReader rV = new StreamReader("input-V.txt", Encoding.UTF8);
            StreamReader rVI = new StreamReader("input-VI.txt", Encoding.UTF8);
            StreamReader rVII = new StreamReader("input-VII.txt", Encoding.UTF8);

            StreamWriter w1 = new StreamWriter("output1.txt");
            StreamWriter w2 = new StreamWriter("output2.txt");
            StreamWriter w3 = new StreamWriter("output3.txt");
            StreamWriter w4a = new StreamWriter("output4a.txt");
            StreamWriter w4b = new StreamWriter("output4b.txt");
            StreamWriter w5a = new StreamWriter("output5a.txt");
            StreamWriter w5b = new StreamWriter("output5b.txt");
            StreamWriter w6 = new StreamWriter("output6.txt");
            StreamWriter w7 = new StreamWriter("output7.txt");
            StreamWriter w8 = new StreamWriter("output8.txt");
            StreamWriter w9 = new StreamWriter("output9.txt");
            StreamWriter w10 = new StreamWriter("output10.txt");
            StreamWriter w11 = new StreamWriter("output11.txt");
            StreamWriter w12 = new StreamWriter("output12.txt");
            StreamWriter w13a = new StreamWriter("output13a.txt");
            StreamWriter w13b = new StreamWriter("output13b.txt");
            
            int beolvasottérték;

            int számokszáma1 = 0;
            int összeg2 = 0;
            int összeg3 = 0;
            int szám3 = 0;

            while (!rI.EndOfStream)
            {
                beolvasottérték = int.Parse(rI.ReadLine());

                // 1. Hány szám található a megadott fájlban?

                számokszáma1++;
                
                // 2. Mennyi a megadott fájlban található számok összege?
                
                összeg2 += beolvasottérték;

                // 3. Mennyi a megadott fájlban található számok átlaga?

                összeg3 += beolvasottérték;

                szám3++;
            }

            Console.WriteLine("------------------------------");
            Console.WriteLine("1. Hány szám található a megadott fájlban?");
            Console.WriteLine("A sorozatban {0} szám található.", számokszáma1);
            w1.WriteLine(számokszáma1);

            Console.WriteLine("------------------------------");
            Console.WriteLine("2. Mennyi a megadott fájlban található számok összege?");
            Console.WriteLine("A fájlban található számok összege: {0}", összeg2);
            w2.WriteLine(összeg2);

            Console.WriteLine("------------------------------");
            Console.WriteLine("3. Mennyi a megadott fájlban található számok átlaga?");
            Console.WriteLine("A fájlban található számok átlaga: {0}", összeg3 / szám3);
            w3.WriteLine(összeg3 / szám3);

            bool megvan4 = false;

            while (!rII.EndOfStream)
            {
                beolvasottérték = int.Parse(rII.ReadLine());


                if (beolvasottérték < 0 && beolvasottérték % 2 == 0)
                {
                    // 4. a) Van-e negatív páros szám a megadott fájlban?

                    megvan4 = true;

                    // 4. b) Válogasd ki / Szűrd ki a negatív páros számokat a fájlból!	

                    Console.Write("{0}, ", beolvasottérték);
                    w4b.WriteLine(beolvasottérték);
                }
            }

            Console.WriteLine("------------------------------");
            Console.WriteLine("4. a) Van-e negatív páros szám a megadott fájlban?");
            Console.WriteLine(megvan4 ? "Van." : "Nincs.");
            w4a.WriteLine(megvan4);

            Console.WriteLine("------------------------------");
            Console.WriteLine("4. b) Válogasd ki / Szűrd ki a negatív páros számokat a fájlból!");
            
            int darab5 = 0;
            int összeg5 = 0;

            while (!rIII.EndOfStream)
            {
                beolvasottérték = int.Parse(rIII.ReadLine());                

                if (beolvasottérték >=50 && beolvasottérték <= 100)
                {
                    // 5. a) Hány 50 és 100 közötti (az 50 és a 100 még benne van) szám található a fájlban? 

                    darab5++;

                    // 5. b) Mennyi ezen számok összege? (tehát csak az 50 és 100 közé eső számok összege?) 

                    összeg5 += beolvasottérték;
                }
            }

            Console.WriteLine("------------------------------");
            Console.WriteLine("5. a) Hány 50 és 100 közötti (az 50 és a 100 még benne van) szám található a fájlban?");
            Console.WriteLine(darab5);
            w5a.WriteLine(darab5);

            Console.WriteLine("------------------------------");
            Console.WriteLine("5. b) Mennyi ezen számok összege? (tehát csak az 50 és 100 közé eső számok összege?)");
            Console.WriteLine(összeg5);
            w5b.WriteLine(összeg5);

            int legkisebb = 0;

            while (!rIV.EndOfStream)
            {
                beolvasottérték = int.Parse(rIV.ReadLine());

                legkisebb = beolvasottérték;

                // 6. Add meg a megadott fájlban található legkisebb számot!

                if (beolvasottérték < legkisebb)
                {
                    legkisebb = beolvasottérték;
                }                
            }

            Console.WriteLine("------------------------------");
            Console.WriteLine("6. Add meg a megadott fájlban található legkisebb számot!");
            Console.WriteLine("A legkisebb szám: {0}", legkisebb);
            w6.WriteLine(legkisebb);
            
            bool megvan7 = false;
            int index8 = 0;
            int első25teloszthatószám7 = 0;
            int első25teloszthatószámindexe8 = 0;
            int előző25teloszthatószám9 = 0;
            int legnagyobb25teloszthatószám9 = 0;

            while (!rV.EndOfStream)
            {
                beolvasottérték = int.Parse(rV.ReadLine());

                // 7. Mi az első 25-tel osztható szám?

                if (megvan7 == false && beolvasottérték % 25 == 0)
                {
                    első25teloszthatószám7 = beolvasottérték;
                }

                // 8. Mi az első 25-tel osztható szám indexe?

                if (megvan7 == false && beolvasottérték % 25 == 0)
                {
                    Console.WriteLine(index8);
                    w8.WriteLine(első25teloszthatószámindexe8);
                }

                // 9. Mi a legnagyobb 25-tel osztható szám?

                if (beolvasottérték % 25 == 0)
                {
                    előző25teloszthatószám9 = beolvasottérték;
                    if (előző25teloszthatószám9 > legnagyobb25teloszthatószám9)
                    {
                        legnagyobb25teloszthatószám9 = előző25teloszthatószám9;
                    }
                }

                index8++;
            }

            Console.WriteLine("------------------------------");
            Console.WriteLine("7. Mi az első 25-tel osztható szám?");
            Console.WriteLine("Az első 25-tel osztható szám: {0}", első25teloszthatószám7);
            w7.WriteLine(első25teloszthatószám7);

            Console.WriteLine("------------------------------");
            Console.WriteLine("8. Mi az első 25-tel osztható szám indexe?");

            Console.WriteLine("------------------------------");
            Console.WriteLine("9. Mi a legnagyobb 25-tel osztható szám?");
            Console.WriteLine("A legnagyobb 25-tel osztható szám: {0}", legnagyobb25teloszthatószám9);
            w9.WriteLine(legnagyobb25teloszthatószám9);
                                    
            int index11és12 = 0;
            int utolsó25teloszthatószám10 = 0;
            int utolsó25teloszthatószámindexe11 = 0;
            int előző25teloszthatószám12 = 0;
            int legnagyobb25teloszthatószám12 = 0;
            int legnagyobb25teloszthatószámindexe12 = 0;

            while (!rVI.EndOfStream)
            {
                beolvasottérték = int.Parse(rVI.ReadLine());

                // 10. Mi az utolsó 25-tel osztható szám?

                if (beolvasottérték % 25 == 0)
                {
                    utolsó25teloszthatószám10 = beolvasottérték;
                }

                // 11. Mi az utolsó 25-tel osztható szám indexe?

                if (beolvasottérték % 25 == 0)
                {
                    utolsó25teloszthatószámindexe11 = index11és12;
                }

                // 12. Mi a legnagyobb 25-tel osztható szám indexe?

                if (beolvasottérték % 25 == 0)
                {
                    előző25teloszthatószám12 = beolvasottérték;
                    if (előző25teloszthatószám12 > legnagyobb25teloszthatószám12)
                    {
                        legnagyobb25teloszthatószám12 = előző25teloszthatószám12;
                        legnagyobb25teloszthatószámindexe12 = index11és12;
                    }
                }

                index11és12++;
            }

            Console.WriteLine("------------------------------");
            Console.WriteLine("10. Mi az utolsó 25-tel osztható szám?");
            Console.WriteLine("Az utolsó 25-tel osztható szám: {0}", utolsó25teloszthatószám10);
            w10.WriteLine(utolsó25teloszthatószám10);

            Console.WriteLine("------------------------------");
            Console.WriteLine("11. Mi az utolsó 25-tel osztható szám indexe?");
            Console.WriteLine(utolsó25teloszthatószámindexe11);
            w11.WriteLine(utolsó25teloszthatószámindexe11);

            Console.WriteLine("------------------------------");
            Console.WriteLine("12. Mi a legnagyobb 25-tel osztható szám indexe?");
            Console.WriteLine("A legnagyobb 25-tel osztható szám indexe: {0}", legnagyobb25teloszthatószámindexe12);
            w12.WriteLine(legnagyobb25teloszthatószámindexe12);
            
            bool vane13 = false;
            int előzőszám13 = 1;
            int index13 = 0;
            int indexe13 = 0;

            while (!rVII.EndOfStream)
            {
                beolvasottérték = int.Parse(rVII.ReadLine());

                if (beolvasottérték % 10 == 0 && előzőszám13 % 3 == 0)
                {
                    // 13. a) Előfordul-e olyan a sorozatban, hogy egy 3-mal osztható számot egy 10-zel osztható szám követ?

                    vane13 = true;

                    // 13. b) Ha előfordul ilyen, akkor mi ennek az előfordulásnak az indexe (a 3-mal osztható szám indexére gondolunk)

                    indexe13 = index13;
                    
                    Console.WriteLine(indexe13);
                    w13b.WriteLine(indexe13);
                }

                előzőszám13 = beolvasottérték;

                index13++;
            }

            Console.WriteLine("------------------------------");
            Console.WriteLine("13. a) Előfordul-e olyan a sorozatban, hogy egy 3-mal osztható számot egy 10-zel osztható szám követ?");
            Console.WriteLine(vane13 ? "Igen" : "Nem");
            w13a.WriteLine(vane13);

            Console.WriteLine("------------------------------");
            Console.WriteLine("13. b) Ha előfordul ilyen, akkor mi ennek az előfordulásnak az indexe (a 3-mal osztható szám indexére gondolunk)");
            
            rII.Close();
            rIII.Close();
            rIV.Close();
            rV.Close();
            rVI.Close();
            rVII.Close();
            w1.Close();
            w2.Close();
            w3.Close();
            w4a.Close();
            w4b.Close();
            w5a.Close();
            w5b.Close();
            w6.Close();
            w7.Close();
            w8.Close();
            w9.Close();
            w10.Close();
            w11.Close();
            w12.Close();
            w13a.Close();
            w13b.Close();
        }
    }
}
