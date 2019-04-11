# TournamentBrackets
Code challenge 

Description
Given a list of 2N ranked sports teams (ranked 1 through 2N) entering a tournament, you want to determine a set of initial matchups where a specific team T will advance as far as possible in the tournament before being eliminated (or winning). Assume that a team with a higher ranking (lower number) will always win when paired against any team with a lower ranking (e.g. team 1 beats team 2). 

Code
Write a function that, given valid integer values for N and T, outputs the pairings for the first round of the tournament. There may be numerous equivalent solutions, but your function only needs to output one of them. The function should output the solution as a comma-separated list in a format similar to “3-4, 1-2”, indicating that Team 3 plays Team 4, and Team 1 plays Team 2. Note that the order of the teams in each matchup does not matter as long as the specified team can advance as far as possible (e.g. 1-2 is equivalent to 2-1).
