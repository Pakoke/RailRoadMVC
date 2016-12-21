
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTAlgorithms
{
    public static class FactoryAlgorithms
    {
        public static AlgorithmBT<S,A,T> createBT<S,A,T>(ProblemBT<S,A> p)
        {
            return new AlgorithmBT<S,A,T>(p);
        }
    }
}
