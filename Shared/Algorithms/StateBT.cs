using System;
using System.Collections.Generic;

namespace BTAlgorithms
{
    public interface StateBT<S, A> : ICloneable
    {
        void forward(A a);

        void backforward(A a);

        int size();

        bool isFinal();

        bool isNotFinal();

        IEnumerable<A> getAlternatives();

        S getSolution();

        StateBT<S, A> DeepClone();
    }
}