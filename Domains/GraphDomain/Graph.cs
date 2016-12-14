using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDomain
{
    public class Graph
    {
        public Dictionary<City,List<Road>> graph { get; set; }

        public City currentCity { get; set; }

        public Road currentEdge { get; set; }

        public Dictionary<City,Road> getPosiblesCities { get; set; }
        
        public Graph()
        {
            this.graph = new Dictionary<City, List<Road>>();
        }

        public void addVertex(City city,List<Road> edges)
        {
            if (this.graph.ContainsKey(city))
            {
                this.graph[city].AddRange(edges);
            }
            else
            {
                this.graph.Add(city, edges);
            }
        }

        public List<Tuple<City, int>> shortest_path_Dijkstra(City start, City finish)
        {
            var previous = new Dictionary<City, City>();
            var distances = new Dictionary<City, int>();
            var nodes = new List<City>();

            List<Tuple<City,int>> path = null;

            //iterate for every vertex in the graph looking for the choosen to start, put the other infinite
            foreach (var vertex in this.graph)
            {
                if (vertex.Key == start)
                {
                    distances[vertex.Key] = 0;
                }
                else
                {
                    distances[vertex.Key] = int.MaxValue;
                }

                nodes.Add(vertex.Key);
            }

            while (nodes.Count != 0)
            {
                nodes.Sort((x, y) => distances[x] - distances[y]);

                var smallest = nodes[0];
                nodes.Remove(smallest);

                if (smallest == finish)
                {
                    path = new List<Tuple<City,int>>();
                    while (previous.ContainsKey(smallest))
                    {
                        path.Add(new Tuple<City, int>(smallest, distances[smallest]));
                        smallest = previous[smallest];
                    }

                    break;
                }

                if (distances[smallest] == int.MaxValue)
                {
                    //there is no solution for the path so return null
                    path = null;
                    break;
                }

                foreach (var neighbor in this.graph[smallest])
                {
                    var alt = distances[smallest] + neighbor.weight;
                    if (alt < distances[neighbor.to])
                    {
                        distances[neighbor.to] = alt;
                        previous[neighbor.to] = smallest;
                    }
                }
            }

            return path;
        }

        public List<Tuple<Tuple<City,City>,int>> shortest_path_own(City start,City finish)
        {
            List<Tuple<City, Road>> choosenPaths = new List<Tuple<City,Road>>();

            List<City> nodesToIterate = this.graph.Keys.ToList();

            List<City> nodesToFilter = this.graph.Keys.ToList();

            //Take the first element of the table
            List<Road> taken = this.graph[start];
            foreach(var node in nodesToIterate)
            {
                //ask in the first noder for the other and looking for if exist a posible path
                Road posiblecity = taken.FirstOrDefault(x => x.to == node);
                if (posiblecity != null)
                {
                    if(posiblecity.to == node)
                        choosenPaths.Add(new Tuple<City, Road>(start, new Road() { to = node, weight = 0 }));
                    else
                        choosenPaths.Add(new Tuple<City, Road>(start, new Road() { to = node, weight = posiblecity.weight }));
                }
                else
                {
                    choosenPaths.Add(new Tuple<City, Road>(start, new Road() { to = node, weight = int.MaxValue }));
                }
            }

            //while (nodesToIterate.Count!=0)
            //{
            //    foreach(var nti in nodesToIterate)
            //    {

            //        foreach (var c in this.graph[start])
            //        {
                        
            //            if(nti == c.to )
            //            {
            //                Road accumulateRoad = new Road() {from = nti,to = c.to,weight =  };
            //                choosenPaths.Add(new Tuple<City, Road>(nti, c));
            //            }
            //            else
            //            {

            //            }
            //        }
            //    }
                
            //}
            

            //City first = this.graph.ContainsKey(start)?start:null;

            //if (first != null)
            //{
            //    foreach(var r)

            //    Road minimun = null;
            //    int acwe = 0;
            //    List<Road> posibilitesCalculated = new List<Road>();

            //    while (n.Count != this.graph.Count - 1)
            //    {
            //        Road f = new Road { to = first, weight = acwe };

            //        //Ask for every vertex and put first to max value
            //        //compare every vertex with the choosen before
            //        //then update if the weigth is less than before
            //        //remove from the node asked and update the vertex you asked

                    

            //        //When you take the choosen you have to see al vertex
            //        //then you choose the minimun weight
            //        //now looking for the posibilities and calculate their new weigth
            //        //
            //        foreach (var calculate in this.graph[f.to])
            //        {

            //            var weighcalculate = calculate.weight + f.weight;
            //            var posibleGood = posibilitesCalculated.FirstOrDefault(x => x == calculate);
            //            if (posibleGood!=null && (posibleGood.weight>weighcalculate))
            //            {
                            
            //            }else
            //            {
            //                calculate.weight = weighcalculate;
            //                posibilitesCalculated.Add(calculate);
            //            }
                        
            //        }

            //        minimun = posibilitesCalculated.OrderBy(x => x.weight).FirstOrDefault();
            //        n.Add(new Tuple<Tuple<City, City>, int>(new Tuple<City, City>(f.to, minimun.to), minimun.weight - f.weight));
            //        posibilitesCalculated.Remove(minimun);
            //        acwe = minimun.weight;
            //        first = minimun.to;

            //    }
                    

                

            //}
            

            return null;
        }

    }
}
