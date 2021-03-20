using System;
using System.Linq;

namespace ConvertSN
{
    public static class ConvertNS
    {
        private static string _str;
        private static string _temps;

        private static int CharToInt(char a)
        {
            if (a >= 'A') return a - 55;
            if (a > 0) return a - 48;
            return a + 74;
        }

        /// <summary>
        ///     Convert integer part of a number
        /// </summary>
        /// <param name="at">from which number system to convert</param>
        /// <param name="bt">in which number system to convert</param>
        /// <returns>whole part</returns>
        private static string Whole_number(int at, int bt)
        {
            string ex = "";
            int tempi = 0;

            for (int i = 0; i < _str.Length && _str[i] != '.'; ++i) _temps += _str[i]; //До точки

            tempi = _temps.Aggregate(tempi, (current, t) => current * at + CharToInt(t));

            if (tempi == 0) Console.WriteLine("0");
            else
                while (tempi != 0)
                {
                    ex = Convert.ToString(tempi % bt) + ex;
                    tempi /= bt;
                }

            return ex;
        }

        /// <summary>
        ///     Convert fractional part of number
        /// </summary>
        /// <param name="at">from which number system to convert</param>
        /// <param name="bt">in which number system to convert</param>
        /// <returns>fractional part</returns>
        private static string D_number(int at, int bt)
        {
            string ex;
            double tempd = 0;
            ex = _temps;
            _temps = "";
            for (int i = ex.Length + 1; i < _str.Length; ++i) _temps += _str[i]; //После
            if (_temps.Length > 0)
            {
                ex = "";
                for (int i = _temps.Length - 1; i >= 0; --i) tempd = (CharToInt(_temps[i]) + tempd) / at;
                //while (Math.Round(tempd, MidpointRounding.AwayFromZero) > 0) tempd *= 0.1;
                while (tempd > 0)
                {
                    tempd *= bt;
                    ex += Convert.ToString(Math.Round(tempd, MidpointRounding.AwayFromZero));
                    tempd -= Math.Round(tempd, MidpointRounding.AwayFromZero);
                }
            }

            return ex;
        }

        /// <summary>
        ///     Convert from any number system to any
        /// </summary>
        /// <param name="fromNs">from which number system to convert</param>
        /// <param name="toNs">in which number system to convert</param>
        /// <param name="numberS">translated number</param>
        /// <returns>Converted number</returns>
        public static string Toany(int fromNs, int toNs, string numberS)
        {
            if (numberS == "") return "EmptyString";
            _str = numberS;
            int a = 0;


            if (fromNs < 2 || fromNs > 36) return "OutOfNumberSystem";
            if (toNs < 2 || toNs > 36) return "OutOfNumberSystem";
            foreach (char t in _str)
                if (t == '.')
                    a = 1;
            if (a == 1)
                return Whole_number(fromNs, toNs) + "." + D_number(fromNs, toNs);
            return Whole_number(fromNs, toNs);
        }
    }
}