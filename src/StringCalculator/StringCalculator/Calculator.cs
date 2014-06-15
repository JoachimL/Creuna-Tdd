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
            return GetNumberValuesFromString(numbers)
                .Sum(n => GetNumberFromString(n));
        }

        private static IEnumerable<string> GetNumberValuesFromString(string numbers)
        {
            return numbers
                .Split(GetDelimiters(numbers), StringSplitOptions.None);
        }

        private static string[] GetDelimiters(string numbers)
        {
            if (numbers.StartsWith("//"))
                return new[] {numbers.Split(new[] {Environment.NewLine}, StringSplitOptions.None).First().Substring(2)};
            return new[] {",", Environment.NewLine};
        }

        private static int GetNumberFromString(string n)
        {
            var number = 0;
            int.TryParse(n, out number);
            return number;
        }
    }
}
