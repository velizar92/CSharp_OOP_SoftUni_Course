﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Operations
{
    public class MathOperations
    {

        public int Add(int numberOne, int numberTwo)
        {
            return numberOne + numberTwo;
        }
        public double Add(double numberOne, double numberTwo, double numberThree)
        {
            return numberOne + numberTwo + numberThree;
        }
        public decimal Add(decimal numberOne, decimal numberTwo, decimal numberThree)
        {
            return numberOne + numberTwo + numberThree;
        }

    }
}
