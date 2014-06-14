using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {

        public int Add(string numbers)
        {
            var sum = 0;
            int number = 0;
            if (int.TryParse(numbers, out number))
                return number;
            return 0;
        }
    }
}
