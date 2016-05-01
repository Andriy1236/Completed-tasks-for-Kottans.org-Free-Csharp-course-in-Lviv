using System;
using System.Collections.Generic;
using System.Linq;

namespace kottansTasks
{
    class BankCard
    {
        public static string GetCreditCardVendor(string cardNumber)
        {
            cardNumber = ConvertToStringWithoutSpace(cardNumber);
            string cardVendor = "Unknown";
            if (IsCreditCardNumberValid(cardNumber))
            {
                int cardNumberLength = cardNumber.Length;
                int firstTwoNumbers = Convert.ToInt32(cardNumber.Substring(0, 2));
                int firstFourNumbers = Convert.ToInt32(cardNumber.Substring(0, 4));
                int firstNumber = Convert.ToInt32(cardNumber.Substring(0, 1));

                if (cardNumberLength == 15 && ((firstTwoNumbers == 34) || (firstTwoNumbers == 37)))
                {
                    return "American Express";
                }

                if ((12 <= cardNumberLength && cardNumberLength <= 19) &&
                    (50 == firstTwoNumbers || ((56 <= firstTwoNumbers) && (firstTwoNumbers >= 59))))
                {
                    cardVendor = "Maestro";
                }

                if (cardNumberLength == 16 && (51 <= firstTwoNumbers && firstTwoNumbers <= 55))
                {
                    cardVendor = "MasterCard";
                }

                if ((cardNumberLength == 13 || cardNumberLength == 16 || cardNumberLength == 19) && firstNumber == 4)
                {
                    cardVendor = "Visa";
                }

                if (cardNumberLength == 16 && (3528 <= firstFourNumbers && firstFourNumbers <= 3589))
                {
                    cardVendor = "JCB";
                }
            }
            return cardVendor;
            
        }

        public static bool IsCreditCardNumberValid(string cardNumber)
        {
            cardNumber = ConvertToStringWithoutSpace(cardNumber);
            if (cardNumber.Any(x => x < '0' || x > '9'))
            {
                throw new Exception("card number has letters");
            }
            if (cardNumber.Length < 12)
            {
                throw new Exception("card number has not enough numbers");
            }
            List<int> numericalСardNumbers = new List<int>();
                numericalСardNumbers.AddRange(cardNumber.Reverse().Select(x => int.Parse(x.ToString()))); 
                for (int i = 0; i < numericalСardNumbers.Count; i++)
                {
                    if (i%2 != 0) 
                    {
                        numericalСardNumbers[i] = numericalСardNumbers[i]*2;
                        if (numericalСardNumbers[i] > 9)
                        {
                            numericalСardNumbers[i] = numericalСardNumbers[i]/10 + numericalСardNumbers[i]%10;
                        }
                    }
                }
            return numericalСardNumbers.Sum(x => x) % 2 == 0;
        }

        public static string GenerateNextCreditCardNumber(string cardNumber)
        {
          
            if (IsCreditCardNumberValid(cardNumber))
            {
                cardNumber = ConvertToStringWithoutSpace(cardNumber);
                ulong integerСardnumber = Convert.ToUInt64(cardNumber);
                while (true)
                {
                    integerСardnumber += 1;
                    if (IsCreditCardNumberValid((integerСardnumber).ToString()))
                    {
                        return integerСardnumber.ToString();
                    }
                }
            }
            return cardNumber;
        }

        private static string ConvertToStringWithoutSpace(string cardNumber)
        {
           return cardNumber.Replace(" ", "");
        }


    }
}



    

