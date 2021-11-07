using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface IInformable
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
