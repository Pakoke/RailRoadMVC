using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDomain
{
    public class Road
    {
        public City from { get; set; }

        public City to { get; set; }

        public int weight { get; set; }

    }
}
