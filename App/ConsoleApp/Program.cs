using GraphDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Graph
    {
        Dictionary<char, Dictionary<char, int>> vertices = new Dictionary<char, Dictionary<char, int>>();

        public void add_vertex(char name, Dictionary<char, int> edges)
        {
            vertices[name] = edges;
        }

        public List<char> shortest_path(char start, char finish)
        {
            var previous = new Dictionary<char, char>();
            var distances = new Dictionary<char, int>();
            var nodes = new List<char>();

            List<char> path = null;

            foreach (var vertex in vertices)
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
                    path = new List<char>();
                    while (previous.ContainsKey(smallest))
                    {
                        path.Add(smallest);
                        smallest = previous[smallest];
                    }

                    break;
                }

                if (distances[smallest] == int.MaxValue)
                {
                    break;
                }

                foreach (var neighbor in vertices[smallest])
                {
                    var alt = distances[smallest] + neighbor.Value;
                    if (alt < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = alt;
                        previous[neighbor.Key] = smallest;
                    }
                }
            }

            return path;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GraphDomain.Graph gr = new GraphDomain.Graph();


            City cA = new City() { id = "A" };
            City cB = new City() { id = "B" };
            City cC = new City() { id = "C" };
            City cD = new City() { id = "D" };
            City cE = new City() { id = "E" };

            gr.addVertex(cA,new List<Road>() {
                new Road() {from=cA,to=cB,weight=5},
                new Road() {from=cA,to=cD,weight=5},
                new Road() {from=cA,to=cE,weight=7}
            });

            gr.addVertex(cB, new List<Road>()
            {
                new Road() {from = cB,to=cC,weight= 4}
            });

            gr.addVertex(cC, new List<Road>()
            {
                new Road() {from = cC,to=cD,weight=8 },
                new Road() {from = cC,to = cE,weight = 2 }
            });

            gr.addVertex(cD, new List<Road>()
            {
                new Road() {from = cD,to=cC,weight=8 },
                new Road() {from = cD,to=cE,weight = 2 }
            });

            gr.addVertex(cE, new List<Road>()
            {
                new Road() {from=cE,to=cB,weight=3 }
            });

            List<Tuple<City, int>> ShortPath = new List<Tuple<City, int>>();

            gr.shortest_path_own(cA, cC);

            ShortPath = gr.shortest_path_Dijkstra(cA,cC);

            ShortPath = gr.shortest_path_Dijkstra(cB, cB);

            //Graph g = new Graph();

            //g.add_vertex('A', new Dictionary<char, int>() { { 'B', 7 }, { 'C', 8 } });
            //g.add_vertex('B', new Dictionary<char, int>() { { 'A', 7 }, { 'F', 2 } });
            //g.add_vertex('C', new Dictionary<char, int>() { { 'A', 8 }, { 'F', 6 }, { 'G', 4 } });
            //g.add_vertex('D', new Dictionary<char, int>() { { 'F', 8 } });
            //g.add_vertex('E', new Dictionary<char, int>() { { 'H', 1 } });
            //g.add_vertex('F', new Dictionary<char, int>() { { 'B', 2 }, { 'C', 6 }, { 'D', 8 }, { 'G', 9 }, { 'H', 3 } });
            //g.add_vertex('G', new Dictionary<char, int>() { { 'C', 4 }, { 'F', 9 } });
            //g.add_vertex('H', new Dictionary<char, int>() { { 'E', 1 }, { 'F', 3 } });

            //g.shortest_path('A', 'H').ForEach(x => Console.WriteLine(x));

            Console.ReadKey();
        }
    }
}
