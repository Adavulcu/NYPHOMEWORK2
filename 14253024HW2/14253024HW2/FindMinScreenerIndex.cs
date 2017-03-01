using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace _14253024HW2
{
    class FindMinScreenerIndex
    {
        int[,] matrix;
        int counter = 0, minCounter;
        public int counter1,row1,coloum1;
       
        public FindMinScreenerIndex(int row,int coloum,int counter)
        {
            row1 = row;
            coloum1 = coloum;
            counter1 = counter;
        }
        public FindMinScreenerIndex(int[,] matrix)
        {
            this.matrix = matrix;
        }
        public void find(ref int row,ref int coloum)
        {
            ArrayList array = new ArrayList();
            minCounter = 0;          
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        row = i;coloum = j;
                        top(i, j);//yukarı kösegen
                        bot(i, j);//asagı kösegen
                        rowsAndColoums(i, j);//satır ve sutunlar                       
                        array.Add(new FindMinScreenerIndex(i, j, counter));
                       //Console.WriteLine(i+" "+j+" counter "+counter);
                                 
                        counter = 0;
                    }
                }
            }
            minCounter = ((FindMinScreenerIndex)array[0]).counter1;
            for (int k = 1; k < array.Count; k++)
            {
                if (((FindMinScreenerIndex)array[k]).counter1 < minCounter)
                {
                    minCounter = ((FindMinScreenerIndex)array[k]).counter1;
                    row = ((FindMinScreenerIndex)array[k]).row1;
                    coloum = ((FindMinScreenerIndex)array[k]).coloum1;
                }
            }
            //Console.WriteLine("min row= " + row + " min colum= " + coloum);
            //Console.ReadKey();


        }
        private void top(int row, int coloum)//matristeki vezir indisinin yukarı bölgesindeki köşgenlerin sayısın tespit edildigi metot
        {
            int tempRow = row, tempColoum = coloum; ;
            while (true)//vezirin yukarı sol köşegeni
            {
                if (tempRow < 1 || tempColoum < 1)
                    break;
                tempRow -= 1;
                tempColoum -= 1;
                if (matrix[tempRow, tempColoum] == 0 &&tempColoum!=coloum && tempRow!=row)
                    counter++;
            }
            tempRow = row; tempColoum = coloum;
            while (true)//vezirin yukarı sag köşegeni
            {
                if (tempRow < 1 || tempColoum > 6)
                    break;
                tempRow -= 1;
                tempColoum += 1;
                if (matrix[tempRow, tempColoum] == 0 && tempColoum != coloum && tempRow != row)
                    counter++;
            }
        }
        private void bot(int row, int coloum)//matristeki vezir indisinin asagı bölgesindeki köşgenlerin sayısın tespit edildigi metot
        {
            int tempRow = row, tempColoum = coloum; ;
            while (true)//vezirin asagı sol köşegeni
            {
                if (tempRow > 6 || tempColoum < 1)
                    break;
                tempRow += 1;
                tempColoum -= 1;
                if (matrix[tempRow, tempColoum] == 0 && tempColoum != coloum && tempRow != row)
                    counter++;
            }
            tempRow = row; tempColoum = coloum;
            while (true)//vezirin yukarı sag köşegeni
            {
                if (tempRow > 6 || tempColoum > 6)
                    break;
                tempRow += 1;
                tempColoum += 1;
                if (matrix[tempRow, tempColoum] == 0 && tempColoum != coloum && tempRow != row)
                    counter++;
            }
        }
        private void rowsAndColoums(int row, int coloum)//matristeki vezir indisinin satır ve sutunlarının tespit edildigi metot
        {
            matrix[row, coloum] = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    if (j == coloum && matrix[i, j] == 0)
                        counter++;
                    else if (i == row && matrix[i, j] == 0)
                        counter++;
                    else
                        continue;

                }

            }
            matrix[row, coloum] = 0;
        }

        public bool emptySpaceControl()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(matrix[i,j]==0)
                        return true;
                }
            }
            return false;
        }
    }
}
