using QuickGraph;
using QuickGraph.Algorithms.ShortestPath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDomain
{
    public class Graph : AdjacencyGraph<City, TaggedEdge<City, int>>
    {
        public Dictionary<City, List<Road>> graph { get; set; }

        public Dictionary<City, DijkstraShortestPathAlgorithm<City, TaggedEdge<City, int>>> getCalculatesCities { get; set; }

        public int position;

        public Graph()
        {
            this.graph = new Dictionary<City, List<Road>>();
        }

        public void addVertex(City city, List<Road> edges)
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

        public int? calculateRoute(List<City> route)
        {
            int? length = 0;

            if (route.Count == 0)
            {
                length = null;
            }
            else if (route.Count == 1)
            {
                length = 0;
            }
            else if (route.Count == 2)
            {
                TaggedEdge<City, int> roadAssociated = this.Edges.FirstOrDefault(x => x.Target == route.Last() && x.Source == route.First());// this.graph[route.First()].FirstOrDefault(x => x.to == route.Last());
                length = (roadAssociated == null) ? null : (int?)roadAssociated.Tag;
            }
            else
            {
                length += calculateRoute(route.Take((route.Count / 2) + 1).ToList());
                length += calculateRoute(route.Skip((route.Count / 2)).Take(route.Count).ToList());
            }

            return length;
        }

        public List<Tuple<City, Road>> shortest_path_Dijkstra(City start, City finish)
        {
            List<Tuple<City, Road>> choosenPaths = new List<Tuple<City, Road>>();
            List<Tuple<City, Road>> optimalPath = new List<Tuple<City, Road>>();
            List<City> nodesToIterate = this.graph.Keys.ToList();
            List<City> nodesToFilter = this.graph.Keys.ToList();
            int minimunWeight = 0;

            while (finish != start)
            {
                //Take the first element of the table
                List<Road> taken = this.graph[start];

                foreach (var node in nodesToIterate)
                {
                    //Don't analize the same node.
                    if (node != start)
                    {
                        //ask in the first node for the other and looking for if exist a posible path before created or not
                        Road posiblecity = taken.FirstOrDefault(x => x.to == node);
                        if (posiblecity != null)
                        {

                            Tuple<City, Road> tryToUpdate = choosenPaths.FirstOrDefault(x => x.Item2.to == node);

                            Tuple<City, Road> Combination = new Tuple<City, Road>(start, new Road() { to = node, weight = posiblecity.weight + minimunWeight });
                            //Check if the path exist and their value is more than the acumulate
                            if (tryToUpdate != null && tryToUpdate.Item2.weight > Combination.Item2.weight)
                            {
                                //Remove from the paths to analize to modify later
                                choosenPaths.RemoveAll(x => x.Item2.to == node);
                                //update the data with the new value
                                choosenPaths.Add(Combination);
                            }
                            else if (tryToUpdate != null && tryToUpdate.Item2.weight <= Combination.Item2.weight)
                            {

                            }
                            else
                            {
                                Combination = new Tuple<City, Road>(start, new Road() { to = node, weight = posiblecity.weight });

                                //add the new value with their weight
                                choosenPaths.Add(Combination);
                            }

                        }
                        else
                        {
                            //if not exist, don't mean that there are some other path before
                            var CombinationBefore = choosenPaths.FirstOrDefault(x => x.Item2.to == node);

                            if (CombinationBefore != null)
                            {
                                //Exist but you have to update the value if it's less

                            }
                            else
                            {

                                //if don't exist put the weight to infinite
                                Tuple<City, Road> Combination = new Tuple<City, Road>(start, new Road() { to = node, weight = int.MaxValue });
                                choosenPaths.Add(Combination);
                            }

                        }
                    }
                }
                //Remove the node because it's already analize
                nodesToIterate.Remove(start);

                //Save the path of the minimun weight
                Tuple<City, Road> minimunCombination = choosenPaths.OrderBy(x => x.Item2.weight).First();
                //Remove from the path to chose because it's already analize
                choosenPaths.Remove(minimunCombination);
                //the new city to start is the chosen
                start = minimunCombination.Item2.to;
                //the new weight is the minimun
                minimunWeight = minimunCombination.Item2.weight;
                //add to the final list solution
                optimalPath.Add(minimunCombination);
            }

            return optimalPath;
        }



        private List<List<City>> routes = new List<List<City>>();
        private Dictionary<int, List<List<City>>> goodroutes = new Dictionary<int, List<List<City>>>();

        public int maxdistance = 0;

        public int numberofcombinations(City cC1, City cC2, int v)
        {
            maxdistance = v;
            routes = new List<List<City>>();
            for (int distanceMaximun = 0; distanceMaximun <= maxdistance; distanceMaximun++)
            {
                goodroutes.Add(distanceMaximun, new List<List<City>>());
                List<City> sd = new List<City>();
                sd.Add(cC1);
                var ed = this.Edges.ToList();
                ed.RemoveAll(x => x.Source != cC1 || x.Target == cC1);
                foreach (var pos in ed)
                    combinations(ref sd, pos.Target, cC2, pos.Tag, distanceMaximun);
            }

            return routes.Count;
        }

        private void combinations(ref List<City> sd, City cC1, City cC2, int actualdistance, int distanceMaximun)
        {
            if (cC2 == cC1 && distanceMaximun == actualdistance)
            {
                sd.Add(cC2);
                List<City> listToSave = new List<City>();
                listToSave.AddRange(sd);
                goodroutes[distanceMaximun].Add(listToSave);
                routes.Add(listToSave);
                sd.RemoveAt(sd.Count - 1);
            }
            else if (cC1 == cC2 && distanceMaximun < actualdistance)
            {
                return;
            }
            else
            {
                sd.Add(cC1);
                var ed = this.Edges.ToList();
                ed.RemoveAll(x => x.Source != cC1 || x.Target == cC1);
                foreach (var pos in ed)
                {
                    //sd.Add(pos.Target);
                    int updatedistance = actualdistance + pos.Tag;
                    combinations(ref sd, pos.Target, cC2, updatedistance, distanceMaximun);
                    //sd.RemoveAt(sd.Count-1);
                }
                sd.RemoveAt(sd.Count - 1);

            }
        }

        public int number_strips_exactly(City c1, City c2, int v)
        {
            int maxdistance = v;
            numberofstrips = new List<List<City>>();
            routes = new List<List<City>>();

            List<City> sd = new List<City>();
            sd.Add(c1);
            var ed = this.Edges.ToList();
            ed.RemoveAll(x => x.Source != c1 || x.Target == c1);
            foreach (var pos in ed)
                number_strips_exactly_generalize(ref sd, pos.Target, c2, maxdistance);


            return numberofstrips.Count;
        }

        private void number_strips_exactly_generalize(ref List<City> strips, City target, City final, int maximunstrips)
        {
            if (target == final && strips.Count == maximunstrips)
            {
                strips.Add(final);
                List<City> listToSave = new List<City>();
                listToSave.AddRange(strips);
                numberofstrips.Add(listToSave);
                strips.RemoveAt(strips.Count - 1);
            }
            else if (strips.Count > maximunstrips)
            {
                return;
            }
            else
            {
                var edges = this.Edges.ToList();
                edges.RemoveAll(x => x.Source != target || x.Target == target);
                foreach (var edge in edges)
                {
                    strips.Add(target);
                    number_strips_exactly_generalize(ref strips, edge.Target, final, maximunstrips);
                    strips.RemoveAt(strips.Count - 1);
                }
            }
        }

        private List<List<City>> numberofstrips = new List<List<City>>();

        public int number_strips(City c1, City c2, int initial, int final)
        {
            numberofstrips = new List<List<City>>();
            List<City> strips = new List<City>();
            strips.Add(c1);

            for (int strip = initial; strip <= final; strip++)
            {
                var edges = this.Edges.ToList();
                edges.RemoveAll(x => x.Source != c1 || x.Target == c1);

                foreach (var e in edges)
                {
                    number_strips_generalize(ref strips, e.Target, c2, final - 1, strip);
                }
            }
            return numberofstrips.Count;
        }

        private void number_strips_generalize(ref List<City> strips, City target, City c2, int v, int maximunstrips)
        {
            if (target == c2 && v == maximunstrips)
            {
                strips.Add(c2);
                List<City> listToSave = new List<City>();
                listToSave.AddRange(strips);
                numberofstrips.Add(listToSave);
                strips.RemoveAt(strips.Count - 1);
            }
            else if (v < 0)
            {
                return;
            }
            else
            {
                var edges = this.Edges.ToList();
                edges.RemoveAll(x => x.Source != target || x.Target == target);
                foreach (var edge in edges)
                {
                    strips.Add(target);
                    number_strips_generalize(ref strips, edge.Target, c2, v - 1, maximunstrips);
                    strips.RemoveAt(strips.Count - 1);
                }
            }
        }

        public double own_shortest_path(City c1, City c2)
        {
            double distance = 0.0;
            if (!getCalculatesCities.ContainsKey(c1))
            {
                Func<TaggedEdge<City, int>, double> edgeCost = e => e.Tag;
                var tryGetPaths = new DijkstraShortestPathAlgorithm<City, TaggedEdge<City, int>>(this, edgeCost);
                tryGetPaths.Compute(c1);
                if (c1 == c2)
                {
                    double minweigth = int.MaxValue;
                    foreach (var c in tryGetPaths.Distances)
                    {

                        var AllEdges = this.Edges.ToList();
                        AllEdges.RemoveAll(x => x.Target != c2 || x.Source != c.Key);
                        foreach (var edge in AllEdges)
                        {
                            double posibleweight = edge.Tag + c.Value;
                            if (posibleweight < minweigth)
                            {
                                minweigth = posibleweight;
                            }
                        }
                    }
                    distance = minweigth;
                }
                else
                {
                    distance = tryGetPaths.Distances[c2];
                }
                getCalculatesCities.Add(c1, tryGetPaths);
            }
            else
            {
                distance = getCalculatesCities[c1].Distances[c2];
            }
            return distance;
        }

        public override bool AddVertex(City v)
        {

            this.getCalculatesCities = new Dictionary<City, DijkstraShortestPathAlgorithm<City, TaggedEdge<City, int>>>();
            return base.AddVertex(v);
        }


        public List<List<City>> permutations(City startCity, City finalCity, int maxstrips)
        {
            int strips = maxstrips;
            List<List<City>> l = new List<List<City>>();

            if (strips == 0)
            {
                l.Add(new List<City>() { finalCity, startCity });
                return l;
            }
            else
            {
                foreach (var routes in this.graph[startCity])
                {
                    City possible = routes.to;
                    if (possible != null)
                    {
                        int stripless = strips - 1;
                        l.AddRange(permutations(possible, finalCity, stripless));
                        stripless = strips + 1;
                    }
                }
            }
            return l;
        }

        public void calculateInternalStrips(City startCity, City finalCity, int maxstrips, ref List<City> solution)
        {
            int stripsAllowed = maxstrips;

            if (startCity == finalCity && stripsAllowed == 0)
            {

                solution = new List<City>() { finalCity };
            }
            else if (startCity != finalCity && stripsAllowed == 0)
            {

            }
            else
            {
                City actually = startCity;
                foreach (var posiblespath in this.graph[actually])
                {
                    var lesstrips = maxstrips - 1;
                    calculateInternalStrips(posiblespath.to, finalCity, lesstrips, ref solution);
                    solution.Add(posiblespath.to);
                    this.position++;

                }
            }
        }




    }


}
