using System;

namespace BTAlgorithms
{
    public interface StateBTF<S, A, T> : StateBT<S, A> //where T :IComparable 
    {
        T getObjetive();

        T getEstimateObjective(A a);
    }
}