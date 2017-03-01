using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14253024HW1
{
    class race
    {
        public int moveRabbit(int rabbit,int rnd)//tavsanın hareket methodu
        {
            if (rnd >= 1 && rnd <= 2)
                return rabbit;
            else if (rnd > 2 && rnd <= 4)
            {
                if ((rabbit + 9) < 69)
                    return rabbit + 9;
                else
                    return 69;
            }
            else if (rnd == 5)
            {
                if ((rabbit - 12) >= 0)
                    return rabbit - 12;
                else
                    return 0;
            }
            else if (rnd > 5 && rnd <= 8)
            {

                if ((rabbit + 1) < 69)
                    return rabbit + 1;
                else
                    return 69;
            }
            else
            {
                if ((rabbit - 2) >= 0)
                    return rabbit - 2;
                else
                    return 0;
            }
          
        }
        public int moveTurtle(int turtle,int rnd)//kamplumbaganın hareket metodu
        {
            if (rnd >= 1 && rnd <= 5)
            {

                if ((turtle + 3) < 69)
                    return turtle + 3;
                else
                    return 69;
            }
            else if (rnd > 5 && rnd <= 7)
            {
                if ((turtle - 6) >= 0)
                    return turtle - 6;
                else
                    return 0;
            }
            else
            {
                if ((turtle + 1) < 69)
                    return turtle + 1;
                else
                    return 69;
            }
                
        }

        public void createPath(string[] path)//yola kare degerleri verdigim yer
        {
            for (int i = 0; i < path.Length; i++)
            {
                path[i] = "_";
            }
        }
     
    }
}
