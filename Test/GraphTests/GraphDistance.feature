Feature: GraphDistanceFeature
	
@CalculateDistance
Scenario: Calculate distance graph A-B-C
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
	When find the distance from the graph "GraphToCalculate"
	| Distances  |
	|A           |
	|B           |
	|C           |
	Then the distance calculate is "9"

@CalculateDistance
Scenario: Calculate distance graph A-D
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
	When find the distance from the graph "GraphToCalculate"
	| Distances  |
	|A           |
	|D           |
	Then the distance calculate is "5"

@CalculateDistance
Scenario: Calculate distance graph A-D-C
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
	When find the distance from the graph "GraphToCalculate"
	| Distances  |
	|A           |
	|D           |
	|C           |
	Then the distance calculate is "13"

@CalculateDistance
Scenario: Calculate distance graph A-E-B-C-D
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
	When find the distance from the graph "GraphToCalculate"
	| Distances  |
	|A           |
	|E           |
	|B           |
	|C           |
	|D           |
	Then the distance calculate is "22"

@CalculateDistance
Scenario: Calculate distance graph A-E-D
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
	When find the distance from the graph "GraphToCalculate"
	| Distances  |
	|A           |
	|E           |
	|D           |
	Then the distance calculate is "null"