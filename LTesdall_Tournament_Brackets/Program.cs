/*****************************************************************************/
/* Programmer: Lacy Tesdall                                                  */
/* Program Name: Tournament Brackets                                         */
/* Date Written: April 9, 2017                                               */
/* Purpose: Code challenge for American Express                              */
/* --------------------------------------------------------------------------*/
/* Description:
/*****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

namespace LTesdall_Tournament_Brackets
{
    class Program
    {
        private static int? totalTeams; // Number of teams in the tournament
        private static int? favoredTeam; // User's favorite team
        private static SortedList<int, int> pairedTeams = new SortedList<int, int>(); // List of the paired teams

        static void Main(string[] args)
        {
            // Display the instructions to the user
            displayInstructions();

            // Get the number of teams in the tournament from the user
            do
            {
                totalTeams = getTeamCount();
            } while (totalTeams == null);
            totalTeams = totalTeams * totalTeams;

            // Get the favored team from the user
            do
            {
                favoredTeam = getFavoredTeam();
               
            } while (favoredTeam == null);

            // Display the tournamet brackets to the user
            calculatePairings();
        }

        /// <summary>
        /// Displays the purpose of the program and the instructions to the user
        /// </summary>
        public static void displayInstructions()
        {
            Console.WriteLine("\n\n\n\n\n\n");
            Console.WriteLine("This program...");
        }

        /// <summary>
        /// Get the number of teams in the tournament from the user
        /// </summary>
        /// <returns>Int of the total teams</returns>
        public static int? getTeamCount()
        {
            int? x = null;

            Console.WriteLine("\nPlease enter the number of teams: ");

            try
            {
                x = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter an integer value.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number entered is too large, please enter a smaller value.");
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a positive integer value.");
            }

            return x;
        }

        /// <summary>
        /// Get the user's favorite team
        /// </summary>
        /// <returns>Int in the favored team</returns>
        public static int? getFavoredTeam()
        {
            int? x = null;

            try
            {
                Console.WriteLine("Select your favorite team: ");
                x = int.Parse(Console.ReadLine());
                if (x.HasValue)
                    if (x > totalTeams)
                        throw new ArgumentOutOfRangeException("Team does not exist");
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter an integer value.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("An error occurred. Please try again.");
                x = null;
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number entered is too large, please enter a smaller value.");
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a positive integer value.");
            }

            return x;
        }

        /// <summary>
        /// Randomize which teams play against each other and display the results to the user
        /// </summary>
        public static void calculatePairings()
        {
            Random random = new Random(); // Randomizer for assigning brackets
            int teamRandomizerOne = 0;    // Placeholder for the first team
            int teamRandomizerTwo = 0;    // Placeholder for the second team
            bool isEveryOther = true;     // Toggle for adding the pairs every other loop
            String[] initialParings = new String[totalTeams.Value / 2]; // Contains all of the initial pairings in display format

            int ipCount = 0; // Loops through the initial pairings

            // List of all of the teams
            List<int> teams = new List<int>();
            for (int i = 1; i <= totalTeams; i++)
            {
                teams.Add(i);
            }

            // Randomly assign teams for each bracket
            foreach (int i in teams.GetRange(0, totalTeams.Value).OrderBy(x => random.Next()))
            {
                if (isEveryOther)
                {
                    teamRandomizerOne = i;
                    isEveryOther = false;
                }
                else
                {
                    teamRandomizerTwo = i;
                    pairedTeams.Add(teamRandomizerOne, teamRandomizerTwo);
                    isEveryOther = true;
                }
            }

             

            // Display the inital pairings to the user
            Console.WriteLine($"\nTotal Teams: {totalTeams}     Favored Team: {favoredTeam}");
            Console.WriteLine("\nInitial pairing:");
            foreach (KeyValuePair<int, int> pair in pairedTeams)
            {
                initialParings[ipCount] = $"{pair.Key}-{pair.Value}";
                ipCount++;
            }

            Console.WriteLine(string.Join(", ", initialParings));




            List<int> winningTeams = new List<int>(); // All the teams that move on to the next round

            foreach (KeyValuePair<int, int> pair in pairedTeams)
            {
                if (pair.Key > pair.Value)
                    winningTeams.Add(pair.Key);
                else
                    winningTeams.Add(pair.Value);
            }


            ipCount = 0;
            foreach (int team in winningTeams)
            {
                initialParings[ipCount] = $"{team}";
                ipCount++;
            }
            Console.WriteLine("The winning teams: ");
            Console.WriteLine(string.Join(", ", initialParings));

        }
    }
}
