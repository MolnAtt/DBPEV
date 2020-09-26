using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace agfaymatedoga
{
    class Program
    {
        static void Main(string[] args)
        {
            //I
            StreamReader r1 = new StreamReader("input-I.txt", Encoding.Default);
            StreamWriter w1 = new StreamWriter("output1.txt");
            StreamWriter w2 = new StreamWriter("output2.txt");
            StreamWriter w3 = new StreamWriter("output3.txt");

            

            int adottszam = 0;
            //I. 
            //1
            int szamok1 = 0;

            //2
            int szamösszeg1 = 0;
        
            //3
            int szamatlag = 0;

            



            while (!r1.EndOfStream)
            {


                adottszam = int.Parse(r1.ReadLine());
                
                //I
                
                //1.
                szamok1++;

                //2.
                szamösszeg1 += adottszam;

                //3. 
                szamatlag = szamösszeg1 / szamok1;


            }

            Console.WriteLine("I");
            Console.WriteLine(szamok1);
            w1.WriteLine(szamok1);
            Console.WriteLine(szamösszeg1);
            w2.WriteLine(szamösszeg1);
            Console.WriteLine(szamatlag);
            w3.WriteLine(szamatlag);

            w1.Close();
            w2.Close();
            w3.Close();
            r1.Close();
            //--------------------------------------------------

            //II
            StreamReader r2 = new StreamReader("input-II.txt", Encoding.Default);
            StreamWriter w1II = new StreamWriter("output4a.txt");
            StreamWriter w2II = new StreamWriter("output4b.txt");

            //II
            int adottszam2 = 0;
            //a
            bool negyativparose = false;
            //b
            string parosnegativak = "";
            while (!r2.EndOfStream)
            {
                adottszam2 = int.Parse(r2.ReadLine());
                //a
                if (adottszam2 % 2 == 0 && adottszam2 < 0 && negyativparose != true)
                {
                    negyativparose = true;
                }

                //b
                if (adottszam2 % 2 == 0 && adottszam2 < 0)
                {
                    parosnegativak += adottszam2 + ", ";
                    w2II.WriteLine(adottszam2);
                }
            }
            Console.WriteLine("");
            Console.WriteLine("II");

            Console.WriteLine(negyativparose);
            w1II.WriteLine(negyativparose);

            Console.WriteLine(parosnegativak);

            w1II.Close();
            w2II.Close();
            
            r2.Close();


            //-----------------------------------------------

            //III

            StreamReader r3 = new StreamReader("input-III.txt", Encoding.Default);
            StreamWriter w1III = new StreamWriter("output5a.txt");
            StreamWriter w2III = new StreamWriter("output5b.txt");

            //III
            int adottszam3 = 0;

            //a 
            int ötvenszazközött = 0;

            //b
            int ötvenszazközöttösszeg = 0;

            while (!r3.EndOfStream)
            {
                adottszam3 = int.Parse(r3.ReadLine());
                //a,b
                if (adottszam3 >= 50 && adottszam3 <= 100)
                {
                    //a
                    ötvenszazközött++;
                    //b
                    ötvenszazközöttösszeg += adottszam;
                }
                

            }
            Console.WriteLine("");
            Console.WriteLine("III");

            Console.WriteLine(ötvenszazközött);
            w1III.WriteLine(ötvenszazközött);
            Console.WriteLine(ötvenszazközöttösszeg);
            w2III.WriteLine(ötvenszazközöttösszeg);

            w1III.Close();
            w2III.Close();

            r3.Close();

            //----------------------------------------------------

            //IV
            StreamReader r4 = new StreamReader("input-IV.txt", Encoding.Default);
            StreamWriter w1IV = new StreamWriter("output6.txt");


            //IV
            int adottszam4 = 0;
            //a
            int legkisebb = 0;
            bool elsőszám = false;
            while (!r4.EndOfStream)
            {
                adottszam4 = int.Parse(r4.ReadLine());
                if (elsőszám == false)
                {
                    elsőszám = true;
                    legkisebb = adottszam4;
                }
                else
                {
                    if (legkisebb > adottszam4)
                    {
                        legkisebb = adottszam4;
                    }
                }
            }
            Console.WriteLine("");
            Console.WriteLine("IV");
            

            Console.WriteLine(legkisebb);
            w1IV.WriteLine(legkisebb);

            r4.Close();
            w1IV.Close();

            //-------------------------------------------------------

            StreamReader r5 = new StreamReader("input-V.txt", Encoding.Default);
            StreamWriter w1V = new StreamWriter("output7.txt");
            StreamWriter w2V = new StreamWriter("output8.txt");
            StreamWriter w3V = new StreamWriter("output9.txt");

            //V
            int adottszam5 = 0;
            int index5 = 0;
            //7
            int huszonöttel = 0;
            bool vanehuszonöttel = false;

            //8
            int huszonöttelindex = 0;

            //9
            int legnagyobbhuszonöttel = 0;
            bool elsőhuszonöttel = false;
            while (!r5.EndOfStream)
            {
                adottszam5 = int.Parse(r5.ReadLine());
                //7
                if (adottszam5 % 25 ==0 && vanehuszonöttel == false)
                {
                    huszonöttel = adottszam;
                    //8
                    huszonöttelindex = index5;
                    vanehuszonöttel = true;

                }
                //9
                if (adottszam5 % 25 == 0 && adottszam > legnagyobbhuszonöttel && elsőhuszonöttel == false)
                {
                    legnagyobbhuszonöttel = adottszam5;
                    elsőhuszonöttel = true;
                }
                else
                {
                    if (adottszam5 % 25 == 0 && adottszam > legnagyobbhuszonöttel)
                    {
                        legnagyobbhuszonöttel = adottszam5;
                    }
                }
                index5++;
            }

            Console.WriteLine("");
            Console.WriteLine("V");
            //V


            Console.WriteLine(huszonöttel);
            w1V.WriteLine(huszonöttel);

            Console.WriteLine(huszonöttelindex);
            w2V.WriteLine(huszonöttelindex);

            Console.WriteLine(legnagyobbhuszonöttel);
            w3V.WriteLine(legnagyobbhuszonöttel);

            r5.Close();
            w1V.Close();
            w2V.Close();
            w3V.Close();

            //----------------------------------------------------

            

            StreamReader r6 = new StreamReader("input-VI.txt", Encoding.Default);
            StreamWriter w1VI = new StreamWriter("output10.txt");
            StreamWriter w2VI = new StreamWriter("output11.txt");
            StreamWriter w3VI = new StreamWriter("output12.txt");

            //VI

            int adottszam6 = 0;
            int index6 = 0;
            bool vanehuszonöttelb = false;
            //10
            int huszonöttel2 = 1;
            bool vanehuszonöttel2 = false;
            //11
            int huszonöttelindex2 = 0;
            //12
            int legnagyobbhuszonöttel2 = 1;
            int legnagyobbhuszonöttelindex = 0;

            while (!r6.EndOfStream)
            {
                adottszam6 = int.Parse(r6.ReadLine());
                //10
                if (adottszam6 % 25 == 0)
                {
                    huszonöttel2 = adottszam6;
                    vanehuszonöttel2 = true;
                    //11
                    huszonöttelindex2 = index6;
                }
                
                //12
                if (vanehuszonöttelb = false && adottszam6 % 25 == 0 && adottszam6 > legnagyobbhuszonöttel2)
                {
                    vanehuszonöttelb = true;
                    legnagyobbhuszonöttelindex = index6;
                }
                else
                {
                    if (adottszam6 % 25 == 0 && adottszam6 > legnagyobbhuszonöttel2)
                    {
                        legnagyobbhuszonöttelindex = index6;
                    }
                }
                
                index6++;
            }


            Console.WriteLine("");
            Console.WriteLine("VI");

            if (huszonöttel2 != 1)
            {
                Console.WriteLine(huszonöttel2);
                w1VI.WriteLine(huszonöttel2);
            }
            else
            {
                Console.WriteLine(vanehuszonöttel2);
                w1VI.WriteLine(vanehuszonöttel2);
            }



            if (huszonöttel2 != 1)
            {
                Console.WriteLine(huszonöttelindex2);
                w2VI.WriteLine(huszonöttelindex2);
            }
            else
            {
                Console.WriteLine(vanehuszonöttel2);
                w2VI.WriteLine(vanehuszonöttel2);
            }

            

            if (legnagyobbhuszonöttel2 != 1)
            {
                Console.WriteLine(legnagyobbhuszonöttel2);
                w3VI.WriteLine(legnagyobbhuszonöttel2);
            }
            else
            {
                Console.WriteLine(vanehuszonöttel2);
                w3VI.WriteLine(vanehuszonöttel2);
            }
            

            r6.Close();
            w1VI.Close();
            w2VI.Close();
            w3VI.Close();

            
            //---------------------------------------------------------------------------------------

            //VII

            StreamReader r7 = new StreamReader("input-VI.txt", Encoding.Default);
            StreamWriter w1VII = new StreamWriter("output13a.txt");
            StreamWriter w2VII = new StreamWriter("output13b.txt");

            //VII
            int adottszam7 = 0;
            int index7 = 0;
            //a
            bool harommal = false;
            bool tizzel = false;

            //b
            int harom_majd_tiz_index = 0;


            while (!r7.EndOfStream)
            {
                adottszam7 = int.Parse(r7.ReadLine());
                if (adottszam7 % 3 == 0)
                {
                    harommal = true;

                    if (harommal == true && adottszam7 % 10 == 0)
                    {
                        tizzel = true;
                        harom_majd_tiz_index = index7;
                        harom_majd_tiz_index -= 0;
                    }
                    else
                    {
                        harommal = false;
                    }
                }
                else
                {
                    harommal = false;
                }

                

                index7++;
            }

            Console.WriteLine("");
            Console.WriteLine("VII");

            
            Console.WriteLine(tizzel);
            w1VII.WriteLine(tizzel);

            if (tizzel == true)
            {
                Console.WriteLine(harom_majd_tiz_index);
                w2VII.WriteLine(harom_majd_tiz_index);
            }
            else
            {
                Console.WriteLine(tizzel);
                w2VII.WriteLine(tizzel);
            }

            r7.Close();
            w1VII.Close();
            w2VII.Close();

        }
    }
}
