using BTAlgorithms;
using System.Data;
using System;
using System.Collections.Generic;

namespace BTSudoku
{
    public class ProblemaSudokuBT : ProblemBT<Dictionary<int?, Dictionary<int?, int?>>, int?>
    {
        private ProblemaSudokuBT()
        {
        }

        public static ProblemBT<Dictionary<int?, Dictionary<int?, int?>>, int?> create()
        {
            return new ProblemaSudokuBT();
        }
        public StateBT<Dictionary<int?, Dictionary<int?, int?>>, int?> getInitialState()
        {
            return new EstadoSudoku();
        }
    }
}
