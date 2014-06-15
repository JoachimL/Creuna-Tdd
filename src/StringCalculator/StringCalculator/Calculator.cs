﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {
        private readonly ICalculationAggregator _calculationAggregator;

        public Calculator(ICalculationAggregator calculationAggregator)
        {
            this._calculationAggregator = calculationAggregator;
        }

        public int Add(string numbers)
        {
            var sum = GetNumberValuesFromString(numbers)
                .Sum(n => GetNumberFromString(n));
            if(!_calculationAggregator.PostResults(1))
                throw new Exception();
            return sum;
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
