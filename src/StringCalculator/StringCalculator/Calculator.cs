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
            var delimiters = new[] { ",", Environment.NewLine };
            if (numbers.StartsWith("//"))
                delimiters = new[] { numbers.Split(new[] { Environment.NewLine }, StringSplitOptions.None).First().Substring(2) };

            return numbers
                .Split(delimiters, StringSplitOptions.None)
                .Sum(n => GetNumberFromString(n));
        }

        private static int GetNumberFromString(string n)
        {
            var number = 0;
            int.TryParse(n, out number);
            return number;
        }
    }
}
