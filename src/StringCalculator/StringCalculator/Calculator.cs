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
            foreach (var stringPart in numbers.Split(new[] { ',' }))
            {
                var number = 0;
                if (int.TryParse(stringPart, out number))
                    sum += number;
            }
            return sum;
        }
    }
}
