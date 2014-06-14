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
            return numbers.Split(new[] {','}).Sum(n =>
            {
                var number = 0;
                int.TryParse(n, out number);
                return number;
            });
        }
    }
}
