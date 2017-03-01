using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Emoji;



namespace _14253024HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] path = new string[70];
            string[] pathRabbit = new string[70];
            string[] pathTurtle = new string[70];
            string[] pathOuch = new string[70];
            
            Random rnd = new Random();
            race rc = new race();
             //olusturdugum emoji kütüphanesinin nesnesi
            int random;
            int rabbit = 0;
            int turtle = 0;
           
            rc.createPath(pathRabbit);
            rc.createPath(pathTurtle);
            rc.createPath(pathOuch);
            while (true)
            {
                random = rnd.Next(0, 10);//tavsan için random sayı olusturma
                rabbit = rc.moveRabbit(rabbit, random);//tavsanın yeni yerinin belirlenecegi methotu cagırdım
                Thread.Sleep(10);//random komutu aynı degeri olusrmasın diye kısa bir aralık olusturdum
                random = rnd.Next(0, 10);//kamlumbaga için random sayı
                turtle = rc.moveTurtle(turtle, random);//kamplumbaganın yeni yerinin belirlenecegi methotu cagırdım
                rc.createPath(path);//yolun kare degerlerini yeniden olsturdum
              
                if (rabbit == turtle)//eger aynı yerlderlerse yola OUCH yazdırdım
                {
                    path[rabbit] = "OUCH";
                    pathOuch[rabbit] = "OUCH";
                }
                else
                {
                    path[rabbit] = "T";
                    path[turtle] = "K";
                    pathRabbit[rabbit] = "T";
                    pathTurtle[turtle] = "K";
                }
                Console.Clear();
                Console.Write("START ");
                for (int i = 0; i < path.Length; i++)//yolun görüntülendigi yer
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    switch (path[i])
                    {
                        case "OUCH":
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case "T":
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case "K":
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                    }                 
                    Console.Write(path[i]);
                    
                }
                Console.ResetColor();
                Console.Write(" FINISH");
                Thread.Sleep(1000);//bir saniyelik gecikme
               
                if (rabbit >= 69 || turtle >= 69)//yarısın tamamlandıgını tepit ettirdigim yer
                {
                    Console.ResetColor();
                    Console.WriteLine("\n\n\n");
                    if (rabbit > turtle)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("TAVŞAN KAZANDI . YUH");
                        Emojies.angry();
                    }
                    else if (turtle > rabbit)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("KAPLUMBAĞA KAZANDI!!! OLEY!!");
                        Emojies.happy();
                    }
                    else
                    {
                        Console.WriteLine("BERABERE");
                        Emojies.suprised();
                    }
                    Console.ResetColor();
                
                    Console.WriteLine("\n\n\nTavsanın katettigi tüm yol\n\n");
                    Console.Write("START ");
                    for (int i = 0; i < pathRabbit.Length; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        if (pathRabbit[i] == "T")
                            Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(pathRabbit[i]);
                       
                    }
                    Console.ResetColor();
                    Console.Write(" FINISH");
                    Console.WriteLine();
                    Console.WriteLine("\n\n\nkaplumbaganın katettigi tüm yol\n\n");
                    Console.Write("START ");
                    for (int i = 0; i < pathTurtle.Length; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        if (pathTurtle[i] == "K")
                            Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(pathTurtle[i]);
                        
                    }
                    Console.ResetColor();
                    Console.Write(" FINISH");
                    Console.WriteLine();
                    Console.WriteLine("\n\n\nOUCH noktaları \n\n");
                    Console.Write("START ");
                    for (int i = 0; i < pathRabbit.Length; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        if (pathOuch[i] == "OUCH")
                            Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(pathOuch[i]);
                        
                    }
                    Console.ResetColor();
                    Console.Write(" FINISH");
                    Console.WriteLine();
                    break;
                    
                }
               
            }
           
         
        }
    }
}
