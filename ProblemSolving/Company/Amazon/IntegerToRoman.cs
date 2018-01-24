/*
 Input : 9
Output : IX

Input : 40
Output : XL

Input :  1904
Output : MCMIV

Symbol Table:
I   1   
IV  4   
V   5   
IX  9   
X   10  
XL  40  
L   50  
XC  90  
C   100 
CD  400 
D   500 
CM  900 
M   1000
 */
 //Amazon
using System.Collections;
using System.Text;

namespace ProblemSolving
{
    public class IntegerToRoman
    {
        public static Hashtable converter = new Hashtable();
        public static void IntegerToRomanMain()
        {
            converter.Add(1, "I");
            converter.Add(4, "IV");
            converter.Add(5, "V");
            converter.Add(9, "IX");
            converter.Add(10, "X");
            converter.Add(40, "XL");
            converter.Add(50, "L");
            converter.Add(90, "XC");
            converter.Add(100, "C");
            converter.Add(400, "CD");
            converter.Add(500, "D");
            converter.Add(900, "CM");
            converter.Add(1000, "M");

            string roman = ConvertIntToRoman(9);

        }

        private static string GetRomanByPlace(int place, int reminder)
        {

            StringBuilder output = new StringBuilder();
            if (reminder == 9)
            {
                output.Append(converter[9 * place]);
                reminder = reminder - 9;
            }
            else if (reminder >= 5)
            {
                output.Append(converter[5 * place]);
                reminder = reminder - 5;
            }
            else if (reminder == 4)
            {
                output.Append(converter[4 * place]);
                reminder = reminder - 4;
            }
            while (reminder > 0)
            {
                output.Append(converter[place]);
                reminder = reminder - 1;
            }

            return output.ToString();
        }

        public static string ConvertIntToRoman(int number)
        {
            StringBuilder output = new StringBuilder();
            int place = 1;
            while (number > 0)
            {
                int reminder = number % 10;
                if (reminder > 0)
                {
                    string previous = output.ToString();
                    output.Clear().Append(GetRomanByPlace(place, reminder) + previous);
                }
                place = place * 10;
                number = number / 10;
            }
            
            return output.ToString();
        }
    }
}
