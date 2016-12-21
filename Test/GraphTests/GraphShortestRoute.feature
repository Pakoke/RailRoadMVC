Feature: GraphShortestRouteFeature
	
Scenario: Find the shortest path between A and C
	Given the graph "GraphToCalculate" and the distances
	| Vertex Source | Vertex Target | Distance |
	| A             | B             | 5        |
	| B             | C             | 4        |
	| C             | D             | 8        |
	| D             | C             | 8        |
	| D             | E             | 6        |
	| A             | D             | 5        |
	| C             | E             | 2        |
	| E             | B             | 3        |
	| A             | E             | 7        |
	When find the length of the shortest path between city "A" and "C" in the graph "GraphToCalculate"
	Then the path calculated is "9"

Scenario: Find the shortest path between B and B
	Given the graph "GraphToCalculate" and the distances
	| Vertex Source | Vertex Target | Distance |
	| A             | B             | 5        |
	| B             | C             | 4        |
	| C             | D             | 8        |
	| D             | C             | 8        |
	| D             | E             | 6        |
	| A             | D             | 5        |
	| C             | E             | 2        |
	| E             | B             | 3        |
	| A             | E             | 7        |
	When find the length of the shortest path between city "B" and "B" in the graph "GraphToCalculate"
	Then the path calculated is "9"

