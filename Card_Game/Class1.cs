using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Card_Game
{

    internal class Class1
    {
        public static void kart_atayici(string a,string b)
        {

        }
        public static short oncul_kontrol(string a, string b)
        {
            int x = Convert.ToInt16(a);
            int y = Convert.ToInt16(b);
            short sonuc = 0;
            if (x > y)
            {
                sonuc = 1;
            }
            if (x < y)
            {
                sonuc = -1;
            }
            if (x == y)
            {
                sonuc = 0;
            }
            return sonuc;
        }
        public static short tier_kontrol(string x, string y)
        {
            int a = Convert.ToInt16(x);
            int b = Convert.ToInt16(y);
            short sonuc = 0;
            if (a > b)
            {
                sonuc = 1;
            }
            if (a < b)
            {
                sonuc = -1;
            }
            if (a == b)
            {
                sonuc = 0;
            }
            return sonuc;
        }
        
    }
    }

   



