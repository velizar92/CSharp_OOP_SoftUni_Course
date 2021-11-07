using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {


        public string RandomString()
        {
            Random random = new Random();
            int retIndex = random.Next(0, this.Count);

            string retElement = this[retIndex];
            this.Remove(retElement);

            return retElement;
        }
    }
}
