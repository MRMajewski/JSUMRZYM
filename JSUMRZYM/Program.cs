using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rzymskie_cs
{
    /// <summary>
    /// Konwersja liczby arabskie <-> rzymskie
    /// </summary>
    class Rzymskie
    {
        private static int[] arabic = { 1000, 500, 100, 50, 10, 5, 1 };
        private static char[] roman = { 'M', 'D', 'C', 'L', 'X', 'V', 'I' };
        private static int ROMAN_N = arabic.Length;


        





        /// <summary>
        /// Converts arabic <number> to roman <result>
        /// </summary>
        /// <param name="number">Arabic number to convert</param>
        /// <returns>Returns <result> or "", if an ERROR occurs.</returns>
        public static String arabic2roman(int number)
        {
            int i = 0; //position in arabic and roman arrays

            String result = "";

            if ((number > 3999) || (number <= 0))
            {
                return result;
            }

            while ((number > 0) && (i < ROMAN_N))
            {
                if (number >= arabic[i])
                {
                    number -= arabic[i];
                    result += roman[i];
                }
                else if ((i % 2 == 0) &&
                (i < ROMAN_N - 2) && // 9xx condition
                (number >= arabic[i] - arabic[i + 2]) &&
                (arabic[i + 2] != arabic[i] - arabic[i + 2]))
                {
                    number -= arabic[i] - arabic[i + 2];
                    result += roman[i + 2];
                    result += roman[i];
                    i++;
                }
                else if ((i % 2 == 1) &&
                (i < ROMAN_N - 1) && //4xx condition
                (number >= arabic[i] - arabic[i + 1]) &&
                (arabic[i + 1] != arabic[i] - arabic[i + 1]))
                {
                    number -= arabic[i] - arabic[i + 1];
                    result += roman[i + 1];
                    result += roman[i];
                    i++;
                }
                else
                {
                    i++;
                }
            }

            return result;
        }

        /// <summary>
        /// Converts roman <number> to arabic
        /// </summary>
        /// <param name="number">Roman number to convert</param>
        /// <returns>Returns <result> or -1, if an ERROR occurs.</returns>
        public static int roman2arabic(String number)
        {
            int i = 0, //position in arabic and roman arrays
            j = 0, //position in number
            result = 0,
            length = 0;

            length = number.Length;

            while ((j < length) && (i < ROMAN_N))
            {
                if (number[j] == roman[i])
                {
                    result += arabic[i];
                    j++;
                }
                else if ((i % 2 == 0) &&
                (i < ROMAN_N - 2) && // 9xx condition
                (j < length - 1) &&
                (number[j] == roman[i + 2]) &&
                (number[j + 1] == roman[i]))
                {
                    result += arabic[i] - arabic[i + 2];
                    j += 2;
                    i++;
                }
                else if ((i % 2 == 1) &&
                (i < ROMAN_N - 1) && //4xx condition
                (j < length - 1) &&
                (number[j] == roman[i + 1]) &&
                (number[j + 1] == roman[i]))
                {
                    result += arabic[i] - arabic[i + 1];
                    j += 2;
                    i++;
                }
                else
                {
                    i++;
                }
            }

            //there was an error during conversion
            if (i == ROMAN_N)
            {
                result = -1;
            }

            return result;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            Dictionary<char, int> RomanToArabic = new Dictionary<char, int>();
           // Dictionary<char, int> RomanToArabic = new Dictionary<char, int>();

            RomanToArabic.Add('M',1000);
            RomanToArabic.Add('D', 500);
            RomanToArabic.Add('C', 100);
            RomanToArabic.Add('L', 50);
            RomanToArabic.Add('X', 10);
            RomanToArabic.Add('V', 5);
            RomanToArabic.Add('I', 1);

            var ArabicToRoman = RomanToArabic.ToDictionary(kp => kp.Value, kp => kp.Key); //zamiana kluczy z wartościami

            Console.WriteLine(RomanToArabic['M']);
            Console.WriteLine(ArabicToRoman[1000]);


        }
    }
}