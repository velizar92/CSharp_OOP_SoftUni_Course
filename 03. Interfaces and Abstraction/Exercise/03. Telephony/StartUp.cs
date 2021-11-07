using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ICalling caller;
            IBrowsing browser;

            string[] phoneNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] webSites = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var phoneNumber in phoneNumbers)
            {
                if (phoneNumber.Length == 7)
                    caller = new StationaryPhone();
                else
                    caller = new Smartphone();


                caller.Calling(phoneNumber);
            }



            foreach (var webSite in webSites)
            {
                browser = new Smartphone();
                browser.Browsing(webSite);
            }

        }
    }
}
