using GraphDomain;


namespace BTRoadServices
{
    public class ProblemRoadServices
    {
        private static int DistanceLimit;
        private static City cityOrigin;
        private static City cityFinal;
        private static Graph graph;

        private ProblemRoadServices() { }

        public static void LoadData(Graph graphToLoad,City origin, City final,int limitDistance)
        {
            DistanceLimit= limitDistance;

            cityOrigin = origin;

            cityFinal = final;

            graph = graphToLoad;

        }

        public static int getSize()
        {
            return DistanceLimit;
        }

        public static City getOriginCity()
        {
            return cityOrigin;
        }

        public static City getFinalCity()
        {
            return cityFinal;
        }

        public static Graph getGraph()
        {
            return graph;
        }

    }
}
