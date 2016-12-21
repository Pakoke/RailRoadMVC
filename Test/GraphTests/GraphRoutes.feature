Feature: GraphRoutes
	
Scenario: Find the number of routes less than 30
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
	When find the number of routes between "C" and "C" less than 30 in the graph "GraphToCalculate"
	Then the number of routes found is "7"


