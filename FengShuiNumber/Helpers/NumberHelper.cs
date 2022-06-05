using System;
using System.Collections.Generic;
using System.Text;

namespace FengShuiNumber.Helpers
{
    public class NumberHelper
    {
        public static int Random(int from, int to)
        {
            Random rd = new Random();
            int rand_num = rd.Next(from, to);

            return rand_num;
        }

        public static string RandomStringNumber(int len)
        {
            var num = "";


            for(int i = 0 ; i < len; i++)
            {
                num += Random(0, 9).ToString();
            }

            return num;
            
        }
    }
}
