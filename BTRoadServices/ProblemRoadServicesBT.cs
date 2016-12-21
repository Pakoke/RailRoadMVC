using BTAlgorithms;
using GraphDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTRoadServices
{
    public class ProblemRoadServicesBT : ProblemBT<List<List<City>>, City>
    {
        private ProblemRoadServicesBT() { }

        public static ProblemBT<List<List<City>>, City> create()
        {
            return new ProblemRoadServicesBT();
        }

        public StateBT<List<List<City>>, City> getInitialState()
        {
            return new StateRoadServices();
        }
    }
}
