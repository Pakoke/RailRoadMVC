using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using GraphDomain;
using QuickGraph;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphTests
{
    [Binding]
    public sealed class GraphSteps
    {
        List<City> allCities = new List<City>();

        [Given(@"the graph ""(.*)"" and the distances")]
        public void GivenTheGraphAndTheDistances(string graphId, Table table)
        {
            Graph graph = new Graph();

            allCities = new List<City>();

            foreach (var row in table.Rows)
            {
                string id1 = row.Values.ElementAt(0);
                string id2 = row.Values.ElementAt(1);
                City c1 = new City() { id = id1 };
                City c2 = new City() { id = id2 };
                int distance = int.Parse(row.Values.ElementAt(2));

                if (!allCities.Exists(x => x.id == c1.id))
                {
                    allCities.Add(c1);
                    graph.AddVertex(c1);
                }

                if (!allCities.Exists(x => x.id == c2.id))
                {
                    allCities.Add(c2);
                    graph.AddVertex(c2);
                }

                graph.AddEdge(new TaggedEdge<City, int>(allCities.First(x => x.id == c1.id), allCities.First(x => x.id == c2.id), distance));

            }

            ScenarioContext.Current.Add(graphId, graph);
        }

        [When(@"find the distance from the graph ""(.*)""")]
        public void WhenFindTheDistanceFromTheGraph(string graphId, Table table)
        {
            Graph graph = ScenarioContext.Current.Get<Graph>(graphId);
            List<City> citiesPath = new List<City>();
            table.Rows.ToList().ForEach(x => citiesPath.Add(allCities.FirstOrDefault(y => y.id == x.Values.ElementAt(0))));
            int? d = graph.calculateRoute(citiesPath);
            ScenarioContext.Current.Add("distance", d);

        }

        [Then(@"the distance calculate is ""(.*)""")]
        public void ThenTheDistanceCalculateIs(string distance)
        {
            int? distanceTotal = ScenarioContext.Current.Get<int?>("distance");


            int? distanceToCompare;
            if (distance.ToLower() == "null")
            {

                distanceToCompare = null;
            }
            else
            {
                distanceToCompare = (int?)int.Parse(distance);

            }



            Assert.AreEqual(distanceTotal, distanceToCompare);

        }

        [When(@"find the maximum number of strips between city ""(.*)"" and city ""(.*)"" in the graph ""(.*)""")]
        public void WhenFindTheMaximumNumberOfStripsBetweenCityAndCityInTheGraph(string cityId1, string cityId2, string graphId)
        {


        }

        [When(@"find between city ""(.*)"" and city ""(.*)"" in the graph ""(.*)"" a maximum ""(.*)"" stops")]
        public void WhenFindBetweenCityAndCityInTheGraphAMaximumStops(string cityId1, string cityId2, string graphId, int stops)
        {
            Graph graph = ScenarioContext.Current.Get<Graph>(graphId);
            int stps = graph.number_strips(allCities.First(x => x.id == cityId1), allCities.First(x => x.id == cityId2), 0, stops);
            ScenarioContext.Current.Add("stops", stps);
        }

        [Then(@"the stops calculate is ""(.*)""")]
        public void ThenTheStopsCalculateIs(int StopsToCompare)
        {
            int TotalStops = ScenarioContext.Current.Get<int>("stops");
            Assert.AreEqual(TotalStops, StopsToCompare);
        }

        [When(@"find between city ""(.*)"" and city ""(.*)"" in the graph ""(.*)"" a exactly ""(.*)"" stops")]
        public void WhenFindBetweenCityAndCityInTheGraphAExactlyStops(string cityId1, string cityId2, string graphId, int stops)
        {
            Graph graph = ScenarioContext.Current.Get<Graph>(graphId);
            int stps = graph.number_strips_exactly(allCities.First(x => x.id == cityId1), allCities.First(x => x.id == cityId2), stops);
            ScenarioContext.Current.Add("stops", stps);
        }

        [When(@"find the length of the shortest path between city ""(.*)"" and ""(.*)"" in the graph ""(.*)""")]
        public void WhenFindTheLengthOfTheShortestPathBetweenCityAndInTheGraph(string cityId1, string cityId2, string graphId)
        {
            Graph graph = ScenarioContext.Current.Get<Graph>(graphId);
            int path = (int)graph.own_shortest_path(allCities.First(x => x.id == cityId1), allCities.First(x => x.id == cityId2));
            ScenarioContext.Current.Add("path", path);
        }

        [Then(@"the path calculated is ""(.*)""")]
        public void ThenThePathCalculatedIs(int PathToCompare)
        {
            int shortestPath = ScenarioContext.Current.Get<int>("path");
            Assert.AreEqual(shortestPath, PathToCompare);
        }

        [When(@"find the number of routes between ""(.*)"" and ""(.*)"" less than (.*) in the graph ""(.*)""")]
        public void WhenFindTheNumberOfRoutesBetweenAndLessThanInTheGraph(string cityId1, string cityId2, int numberofcombinations, string graphId)
        {
            Graph graph = ScenarioContext.Current.Get<Graph>(graphId);
            int combination = graph.numberofcombinations(allCities.First(x => x.id == cityId1), allCities.First(x => x.id == cityId2), numberofcombinations - 1);
            ScenarioContext.Current.Add("combinations", combination);
        }

        [Then(@"the number of routes found is ""(.*)""")]
        public void ThenTheNumberOfRoutesFoundIs(int combinationToCompare)
        {
            int combination = ScenarioContext.Current.Get<int>("combinations");
            Assert.AreEqual(combination, combinationToCompare);
        }




    }
}
