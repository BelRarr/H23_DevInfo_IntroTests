using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H23_DevInfo_IntroTests
{
    public class Calculatrice
    {
        // 1 + 2 = 3
        // 0 + 0 = 0
        // 1 + 0 = 1
        // -1 + 2 = 1
        public int Addition(int a, int b)  
        {
            return a + b;
        }

        // 1 - 2 = -1
        // 0 - 0 = 0
        // 1 - 0 = 1
        // -1 - 2 = -3
        public int Soustraction(int a, int b)
        {
            return a - b;
        }

        // 1 * 2 = 2
        // 0 * 0 = 0
        // 1 * 0 = 0
        // -1 * 2 = -2
        public int Multiplication(int a, int b)
        {
            return a * b;
        }

        // 1 / 2 = 0
        // 0 / 0 = exception
        // 1 / 0 = exception
        // -1 / 2 = 0
        // 2 / 2 = 1
        // 3 / 2 = 1
        // 6 / 2 = 3
        public int Division(int a, int b)
        {
            return a / b;
        }



        public int PuissanceDeux(int a)
        {
            if(a < 0)
            {
                throw new ArgumentOutOfRangeException("a", "a doit être positif ou nul");
            }
            else
                return a * a;
        }


        private bool EstPair(int a)
        {
            return a % 2 == 0;
        }


        internal bool EstImpair(int a)
        {
            return !EstPair(a);
        }


        public List<int> TrierNombres(List<int> nombres)
        {
            if (nombres == null)
                throw new ArgumentNullException();

            return nombres.Distinct().OrderBy(x => x).ToList();
        }
    }
}
