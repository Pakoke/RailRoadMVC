using System;

namespace BTAlgorithms
{
    public interface ProblemBT<S, A>
    {
        StateBT<S, A> getInitialState();
    }
}