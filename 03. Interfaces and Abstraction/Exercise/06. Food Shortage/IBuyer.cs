using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface IBuyer : IInformable
    {
        public int Food { get; set; }

        void BuyFood();
    }
}
