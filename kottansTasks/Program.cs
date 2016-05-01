using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace kottansTasks
{
    class Program
    {
        static void Main()
        {
                Console.WriteLine("Hello!");
                while (true)
                {
                try
                {
                    Console.WriteLine("\nPlease Enter the card number ");
                    string cardNumber = Console.ReadLine();
                    Console.WriteLine("The vendor is {0}", BankCard.GetCreditCardVendor(cardNumber));
                    Console.WriteLine("next card numer is {0}", BankCard.GenerateNextCreditCardNumber(cardNumber));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }
    }
}
