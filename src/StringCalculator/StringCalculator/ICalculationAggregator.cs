using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public interface ICalculationAggregator
    {
        bool PostResults(int result);
    }
}
