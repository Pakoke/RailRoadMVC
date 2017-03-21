using GraphDomain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class GraphController : Controller
    {
        Graph graph;
        List<City> cities;
        // GET: Graph
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CalculatePath(int? id)
        {
            cities = new List<City>();
            try
            {
                graph = new Graph();
                Stream req = Request.InputStream;
                req.Seek(0, System.IO.SeekOrigin.Begin);
                string json = new StreamReader(req).ReadToEnd();
                GenerateGraph(json);
                List<City> route = new List<City>();
                JToken o = JToken.Parse(json);
                JToken pathjson = o["Path"];
                string[] array = pathjson.ToString().Split(',');
                array.ToList().ForEach(x => route.Add(cities.FirstOrDefault(v => v.id == x.ToUpper())));
                int? distance = graph.calculateRoute(route);
                JObject obj = JObject.FromObject(new { error = false, distant = distance });
                return Json(obj.ToString());
            }
            catch(Exception e)
            {
                dynamic obj = JObject.FromObject(new { error = true });
                return Json(obj);
            }
        }

        [HttpPost]
        public JsonResult CalculateStripsExactly(int? id)
        {
            cities = new List<City>();
            try
            {
                graph = new Graph();
                Stream req = Request.InputStream;
                req.Seek(0, System.IO.SeekOrigin.Begin);
                string json = new StreamReader(req).ReadToEnd();
                GenerateGraph(json);
                JToken o = JToken.Parse(json);
                JToken CitySource = o["Source"];
                JToken CityTarget = o["Target"];
                JToken Strips = o["Strips"];
                int distance = graph.number_strips_exactly(cities.FirstOrDefault(x=>x.id == CitySource.Value<string>()), cities.FirstOrDefault(x => x.id == CityTarget.Value<string>()),Strips.Value<int>());
                
                JObject obj = JObject.FromObject(new { error = false, result = distance });
                return Json(obj.ToString());
            }
            catch (Exception e)
            {
                dynamic obj = JObject.FromObject(new { error = true });
                return Json(obj);
            }
        }

        [HttpPost]
        public JsonResult CalculateStripsMinimun(int? id)
        {
            cities = new List<City>();
            try
            {
                graph = new Graph();
                Stream req = Request.InputStream;
                req.Seek(0, System.IO.SeekOrigin.Begin);
                string json = new StreamReader(req).ReadToEnd();
                GenerateGraph(json);
                List<City> route = new List<City>();
                JToken o = JToken.Parse(json);
                JToken CitySource = o["Source"];
                JToken CityTarget = o["Target"];
                JToken Strips = o["Strips"];
                int distance = graph.number_strips(cities.FirstOrDefault(x => x.id == CitySource.Value<string>()), cities.FirstOrDefault(x => x.id == CityTarget.Value<string>()), 0, Strips.Value<int>());
                JObject obj = JObject.FromObject(new { error = false, result = distance });
                return Json(obj.ToString());
            }
            catch (Exception e)
            {
                dynamic obj = JObject.FromObject(new { error = true });
                return Json(obj);
            }
        }

        [HttpPost]
        public JsonResult CalculateShortestRoute(int? id)
        {
            cities = new List<City>();
            try
            {
                graph = new Graph();
                Stream req = Request.InputStream;
                req.Seek(0, System.IO.SeekOrigin.Begin);
                string json = new StreamReader(req).ReadToEnd();
                GenerateGraph(json);
                List<City> route = new List<City>();
                JToken o = JToken.Parse(json);
                JToken pathjson = o["Path"];
                string[] array = pathjson.ToString().Split(',');
                array.ToList().ForEach(x => route.Add(cities.FirstOrDefault(v => v.id == x.ToUpper())));
                int? distance = graph.calculateRoute(route);
                JObject obj = JObject.FromObject(new { error = false, distant = distance });
                return Json(obj.ToString());
            }
            catch (Exception e)
            {
                dynamic obj = JObject.FromObject(new { error = true });
                return Json(obj);
            }
        }

        [HttpPost]
        public JsonResult CalculateRoutes(int? id)
        {
            cities = new List<City>();
            try
            {
                graph = new Graph();
                Stream req = Request.InputStream;
                req.Seek(0, System.IO.SeekOrigin.Begin);
                string json = new StreamReader(req).ReadToEnd();
                GenerateGraph(json);
                List<City> route = new List<City>();
                JToken o = JToken.Parse(json);
                JToken pathjson = o["Path"];
                string[] array = pathjson.ToString().Split(',');
                array.ToList().ForEach(x => route.Add(cities.FirstOrDefault(v => v.id == x.ToUpper())));
                int? distance = graph.calculateRoute(route);
                JObject obj = JObject.FromObject(new { error = false, distant = distance });
                return Json(obj.ToString());
            }
            catch (Exception e)
            {
                dynamic obj = JObject.FromObject(new { error = true });
                return Json(obj);
            }
        }

        private void GenerateGraph(string resultJsonGraph)
        {

            JToken o = JToken.Parse(resultJsonGraph);
            JToken vertices = o["GraphNodes"];
            
            JArray arrays = (JArray)JToken.Parse(vertices.ToString());

            foreach (var vertex in arrays)
            {
                City cityToSave = new City() { id = vertex["id"].ToString().ToUpper() };
                cities.Add(cityToSave);
                graph.AddVertex(cityToSave);
            }

            JToken edges = o["GraphVertices"];
            arrays = (JArray)JToken.Parse(edges.ToString());
            foreach (var edge in arrays)
            {
                graph.AddEdge(new QuickGraph.TaggedEdge<City, int>(
                    cities.First(x => x.id == edge["from"].ToString().ToUpper()),
                    cities.First(x => x.id == edge["to"].ToString().ToUpper()),
                    int.Parse(edge["label"].ToString())
                ));

            }

        }
    }
}