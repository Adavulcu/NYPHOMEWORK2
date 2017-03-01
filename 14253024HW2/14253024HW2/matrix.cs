using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14253024HW2
{
    class matrix
    {
        // 0 =) matris teki bos yerler
        // 1 =) matris teki vezirin bulundugu yerler
        // 2 =) matris teki engellenen yerler
        int[,] mt = new int[8, 8];
        string[,] array = new string[8, 8];
        int row = 0;
       public matrix( int coloum)
        {
            
            matrixModify mm = new matrixModify(mt);
            mm.modify(0,coloum);//ilk veziri burada atadım
            FindMinScreenerIndex FMSI = new FindMinScreenerIndex(mt); 
            createArray();
            for (int i = 1; i < 8; i++)
            {
                System.Threading.Thread.Sleep(1000);
                if (FMSI.emptySpaceControl())
                {
                    FMSI.find(ref row, ref coloum);
                    mm.modify(row, coloum);
                    Console.Clear();
                    createArray();
                }
                else
                    break;
            }


        }
        public void display()// ekrana yazdırma metodu
        {
            Console.WriteLine(" V =>  Vezir\n X =>  Kullanılamayan yerler\n O =>  Boş yerler\n\n");
            Console.Write("   ");
            for (int i = 0; i < 8; i++)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write(i+" ");
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if(array[i,j]=="V")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(" " + array[i, j]);
                    }
                    else if(array[i,j]=="X")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" " + array[i, j]);
                    }
                    else
                        Console.Write(" " + array[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
         
        public void createArray()//ekran cıktısı için olusturugum matrisi metodu
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (mt[i, j] == 1)           
                        array[i, j] = "V";
                    else if (mt[i, j] == 2)                  
                        array[i, j] = "X";
                    else                    
                        array[i, j] = "O";                    
                }
            }
            display();
        }

        
    }
}
