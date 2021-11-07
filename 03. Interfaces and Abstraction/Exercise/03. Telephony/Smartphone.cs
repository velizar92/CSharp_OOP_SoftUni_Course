using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {
        public void Browsing(string webSiteURL)
        {
            bool isValidUrl = true;
            foreach (char symbol in webSiteURL)
            {
                if(Char.IsDigit(symbol) == true)
                {
                    isValidUrl = false;
                    break;
                }
            }

            if (isValidUrl == true)
            {
                Console.WriteLine($"Browsing: {webSiteURL}!");
            }
            else
            {
                Console.WriteLine("Invalid URL!");
            }
        }

        public void Calling(string number)
        {
            bool isValidNumber = number.All(char.IsDigit);
            if (isValidNumber == true)
            {
                Console.WriteLine($"Calling... {number}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }

        }
    }
}
