using BTAlgorithms;
using GraphDomain;
using System;
using System.Collections.Generic;
using QuickGraph;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace BTRoadServices
{
    [Serializable]
    public class StateRoadServices : StateBT<List<List<City>>, City> 
    {

        private List<City> actualRoute = null;
        private List<List<City>> everyRoute = null;
        private int actualdistance = int.MinValue;

        private City actualCity = null;
        
        public StateRoadServices()
        {
            StateRoadServicesConstructor(ProblemRoadServices.getOriginCity());
        }

        private void StateRoadServicesConstructor(City city)
        {
            actualRoute = new List<City>();
            everyRoute = new List<List<City>>();
            actualdistance = 0;

            actualCity = city;
            actualRoute.Add(actualCity);
        }

        public void backforward(City a)
        {
            //everyRoute.Remove(actualRoute);
            actualRoute.RemoveAt(actualRoute.Count-1);
            //everyRoute.Add(actualRoute);
            var edges = ProblemRoadServices.getGraph().Edges.ToList();
            actualdistance = actualdistance - edges.First(x => x.Source == actualRoute.ElementAt(actualRoute.Count-1) && x.Target == a).Tag;

            actualCity = actualRoute.ElementAt(actualRoute.Count-1);
        }

        public void forward(City a)
        {
            //everyRoute.Remove(actualRoute);
            actualRoute.Add(a);
            //everyRoute.Add(actualRoute);
            var edges = ProblemRoadServices.getGraph().Edges.ToList();
            actualdistance = actualdistance + edges.First(x=>x.Source == actualCity && x.Target == a).Tag;

            actualCity = a;

        }

        public IEnumerable<City> getAlternatives()
        {
            
            var edges = ProblemRoadServices.getGraph().Edges.ToList();
            edges.RemoveAll(x => (x.Source != actualCity || x.Target == actualCity ) && (x.Tag+this.actualdistance>ProblemRoadServices.getSize()));
            return edges.Select(x => x.Target); 
        }

        public List<List<City>> getSolution()
        {
            everyRoute.Add(actualRoute);
            return everyRoute;
        }

        public bool isFinal()
        {
            bool final = (actualRoute.Count - 1  !=0) && (ProblemRoadServices.getFinalCity() == this.actualCity) ;
            return (final);
        } 

        public bool isNotFinal()
        {
            return (actualRoute.Count - 1 != 0) && ProblemRoadServices.getFinalCity() == this.actualCity ;
        }

        public int size()
        {
            return ProblemRoadServices.getSize() - this.actualdistance;
        }

        public int getDistance()
        {
            return this.actualdistance;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public StateBT<List<List<City>>, City> DeepClone()
        {
            using (MemoryStream memoryStream = new MemoryStream(10))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(memoryStream) as StateBT<List<List<City>>, City>;
            }
        }
    }
}
