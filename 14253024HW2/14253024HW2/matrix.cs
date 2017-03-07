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
       public matrix(int row, int coloum)
        {
            
            int vizier = 1;
            matrixModify mm = new matrixModify(mt);
            mm.modify(row,coloum);//ilk veziri burada atadım          
            createArray();
            //burada ilk 4 veziri kendisidin bi alt satırına ve sag tafaına yerleştirdim
            for (int i = 1; i < 4; i++)  
            {
                System.Threading.Thread.Sleep(1000);
                coloum =coloum+2;
                row = row + 1;
                mm.modify((row)%8, (coloum)%8);
               
                vizier++;
                    Console.Clear();
                    createArray();
               
            }
           //burada ise en soldaki sutundan baslayarak aşagıya dogru inerken karsılastıgım ilk uygun yere veziri yerleştirdim
            for (int i = 0; i < mt.GetLength(1); i++)
            {
                for (int j = 0; j < mt.GetLength(0); j++)
                {
                    if (mm.emptySpaceControl())
                    {
                        if (mt[j, i] == 0)
                        {
                            System.Threading.Thread.Sleep(1000);
                            mm.modify(j, i);
                            Console.Clear();
                            createArray();
                            vizier++;
                        }
                    }
                }
            }
            Console.WriteLine("\n\n");
            Console.WriteLine($"{vizier} adet Vezir yerleştirilmiştir");

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
