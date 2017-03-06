using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14253024HW2
{
    class matrixModify
    {
        int[,] matrix;
      
        // 0 =) matris teki bos yerler
        // 1 =) matris teki vezirin bulundugu yerler
        // 2 =) matris teki engellenen yerler
     
        public matrixModify(int[,] matrix)//constructer
        {
            this.matrix = matrix;
                  
        }
        public void modify(int row,int coloum)
        {
            matrix[row, coloum] = 1;
            top(row, coloum);//yukarı kösegen
            bot(row, coloum);//asagı kösegen
            rowsAndColoums(row, coloum);//satır ve sutunlar
        }
        private void top(int row ,int coloum)//matristeki vezir indisinin yukarı bölgesindeki köşgenlerin engellendigi metot
        {
            int tempRow = row, tempColoum = coloum; ;
            while (true)//vezirin yukarı sol köşegeni
            {
                if (tempRow < 1 || tempColoum < 1)
                    break;
                    tempRow -= 1;
                    tempColoum -= 1;
                if(matrix[tempRow,tempColoum]==0)
                matrix[tempRow, tempColoum] = 2;         
            }
            tempRow = row;   tempColoum = coloum;
            while (true)//vezirin yukarı sag köşegeni
            {
                if (tempRow < 1 || tempColoum > 6)
                    break;
                tempRow -= 1;
                tempColoum += 1;
                if (matrix[tempRow, tempColoum] ==0)
                    matrix[tempRow, tempColoum] = 2;
            }
        }
        private void bot(int row, int coloum)//matristeki vezir indisinin asagı bölgesindeki köşgenlerin engellendigi metot
        {
            int tempRow = row, tempColoum = coloum; ;
            while (true)//vezirin asagı sol köşegeni
            {
                if (tempRow > 6 || tempColoum < 1)
                    break;
                tempRow += 1;
                tempColoum -= 1;
                if (matrix[tempRow, tempColoum] ==0)
                    matrix[tempRow, tempColoum] = 2;
            }
            tempRow = row; tempColoum = coloum;
            while (true)//vezirin asagı sag köşegeni
            {
                if (tempRow > 6 || tempColoum >6)
                    break;
                tempRow += 1;
                tempColoum += 1;
                if (matrix[tempRow, tempColoum] ==0)
                    matrix[tempRow, tempColoum] = 2;
            }
        }
        private void rowsAndColoums(int row,int coloum)//matristeki vezir indisinin satır ve sutunlarının engellendigi metot
        {
            matrix[row, coloum] = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    if (j == coloum && matrix[i,j] ==0)
                        matrix[i, coloum] = 2;
                    else if (i == row && matrix[i, j] ==0)
                        matrix[row, j] = 2;
                    else
                        continue;

                }

            }
        }
        public bool emptySpaceControl()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                        return true;
                }
            }
            return false;
        }//bosta alan varmı diye kontrol eden metot

    }
}
