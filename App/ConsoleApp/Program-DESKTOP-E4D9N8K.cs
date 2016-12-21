using BTAlgorithms;
using BTRoadServices;
using BTSudoku;
using GraphDomain;
using QuickGraph;
using QuickGraph.Algorithms.ShortestPath;
using QuickGraph.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
   
    class Program
    {
        static void Main(string[] args)
        {

           

            //var g = new AdjacencyGraph<City, TaggedEdge<City, int>>();

            var g = new Graph();


            City cA = new City() { id = "A" };
            City cB = new City() { id = "B" };
            City cC = new City() { id = "C" };
            City cD = new City() { id = "D" };
            City cE = new City() { id = "E" };

            g.AddVertex(cA);
            g.AddVertex(cB);
            g.AddVertex(cC);
            g.AddVertex(cD);
            g.AddVertex(cE);

            g.AddEdge(new TaggedEdge<City, int>(cA, cB, 5));
            g.AddEdge(new TaggedEdge<City, int>(cA, cD, 5));
            g.AddEdge(new TaggedEdge<City, int>(cA, cE, 7));

            g.AddEdge(new TaggedEdge<City, int>(cB, cC, 4));

            g.AddEdge(new TaggedEdge<City, int>(cC, cD, 8));
            g.AddEdge(new TaggedEdge<City, int>(cC, cE, 2));

            g.AddEdge(new TaggedEdge<City, int>(cD, cC, 8));
            g.AddEdge(new TaggedEdge<City, int>(cD, cE, 6));

            g.AddEdge(new TaggedEdge<City, int>(cE, cB, 3));


            foreach (var vertex in g.Vertices)
                foreach (var edge in g.OutEdges(vertex))
                    Console.WriteLine(edge + " " +edge.Tag);



            

            //Find the distances....
            int? exe1 = g.calculateRoute(new List<City>() { cA, cB, cC });

            int? exe2 = g.calculateRoute(new List<City>() { cA, cD });

            int? exe3 = g.calculateRoute(new List<City>() { cA, cD, cC });

            int? exe4 = g.calculateRoute(new List<City>() { cA, cE,cB,cC,cD });

            int? exe5 = g.calculateRoute(new List<City>() { cA, cE, cD });

            //Find the number of strips
            var exe6 = g.number_strips(cC, cC,0, 3);

            var exe7 = g.number_strips_exactly(cA, cC, 4);

            //Find the length of the shortest route....
            double exe8 = g.own_shortest_path(cA,cC);

            double exe9 = g.own_shortest_path(cB, cB);

            int exe10 = g.numberofcombinations(cC,cC,29);

            //foreach (var sol in cities)
            //{

            //    Console.WriteLine("------------");
            //    sol.ForEach(x =>Console.Write(" - " + x.ToString() + " - "));
            //    Console.WriteLine(" ");

            //}


            //AlgorithmBT<List<List<City>>, City, int>.conFiltro = false;
            //AlgorithmBT<List<List<City>>, City, int>.isRandomize = false;
            //AlgorithmBT<List<List<City>>, City, int>.soloLaPrimeraSolucion = false;
            //AlgorithmBT<List<List<City>>, City, int>.numeroDeSoluciones = 20;

            //ProblemRoadServices.LoadData(g, cC, cC, 30);

            //ProblemBT<List<List<City>>, City> p = ProblemRoadServicesBT.create();

            //AlgorithmBT<List<List<City>>, City, int> a = FactoryAlgorithms.createBT<List<List<City>>, City, int>(p);
            //a.ejecuta();
            //var sols = a.solutions;
            //foreach(var sol in sols)
            //{

            //    Console.WriteLine("------------");
            //    sol.ForEach(x => 
            //        x.ForEach(y=>Console.Write(" - "+y.ToString()+" - ")));
            //    Console.WriteLine(" ");

            //}

            Console.ReadKey();
        }

    }
}
