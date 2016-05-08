using System;

namespace kottansTasks
{
    class Program
    {
        static void Main()
        {
         Console.WriteLine("Hello!");
         BankCard bankCard = new BankCard();
         bankCard.TestValidation += Show_Message;

            while (true)
            {
                try
                {
                    Console.WriteLine("\nPlease Enter the card number ");
                    string cardNumber = Console.ReadLine();
                    Console.WriteLine("The vendor is {0}", bankCard.GetCreditCardVendor(cardNumber));
                    Console.WriteLine("next card numer is {0}", bankCard.GenerateNextCreditCardNumber(cardNumber));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }

        private static void Show_Message(string message)
        {
            Console.WriteLine(message);
        }
    }
}
