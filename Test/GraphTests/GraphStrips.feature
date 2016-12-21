Feature: GraphStripsFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@CalculateNumberOfStrips
Scenario: Find number of strips with maximum 3 stops
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
	When find between city "C" and city "C" in the graph "GraphToCalculate" a maximum "3" stops
	Then the stops calculate is "2"

@CalculateNumberOfStrips
Scenario: Find number of strips exactly 4 stops
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
	When find between city "A" and city "C" in the graph "GraphToCalculate" a exactly "4" stops
	Then the stops calculate is "3"