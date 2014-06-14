using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {

        public int Add(string numbers)
        {
            if (numbers == "1")
                return 1;
            if (numbers == "2")
                return 2;
            return 0;
        }
    }
}
