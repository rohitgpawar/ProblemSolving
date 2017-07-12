/*
 
 HackerLand has cities numbered from 1 to n. The cities are connected by bidirectional roads. A citizen has access to a library if:

    Their city contains a library.
    They can travel by road from their city to a city containing a library


Input Format

The first line contains a single integer, , denoting the number of queries. The subsequent lines describe each query in the following format:

    The first line contains four space-separated integers describing the respective values of (the number of cities), (the number of roads), (the cost to build a library), and (the cost to repair a road).
    Each line of the subsequent lines contains two space-separated integers, and , describing a bidirectional road connecting cities and .


Sample Input
2
3 3 2 1
1 2
3 1
2 3
6 6 2 5
1 3
3 4
2 4
1 2
2 3
5 6

Sample Output
4
12


 
 */


using System;
using System.Collections.Generic;

namespace ProblemSolving
{
    public class CountCityAndRoad
    {
        static void countDisjointCities(int sourceCity, Dictionary<int, HashSet<int>> cityRoads, bool[] visited, ref int roadCount)
        {
            if (cityRoads.ContainsKey(sourceCity))
            {
                foreach (int desCity in cityRoads[sourceCity])
                {
                    if (!visited[desCity])
                    {
                        visited[desCity] = true;
                        roadCount++;
                        countDisjointCities(desCity, cityRoads, visited, ref roadCount);
                    }
                }
            }
        }

        public static void CountCityAndRoadMain()
        {
            int q = Convert.ToInt32(Console.ReadLine());
            long[][] config = new long[q][];
            Dictionary<int, HashSet<int>>[] cityRoads = new Dictionary<int, HashSet<int>>[q];
            for (int a0 = 0; a0 < q; a0++)
            {
                string[] tokens_n = Console.ReadLine().Split(' ');
                config[a0] = new long[4];
                config[a0][0] = Convert.ToInt32(tokens_n[0]);
                config[a0][1] = Convert.ToInt32(tokens_n[1]);
                config[a0][2] = Convert.ToInt64(tokens_n[2]);
                config[a0][3] = Convert.ToInt64(tokens_n[3]);
                cityRoads[a0] = new Dictionary<int, HashSet<int>>();
                for (int a1 = 0; a1 < config[a0][1]; a1++)
                {
                    string[] tokens_city_1 = Console.ReadLine().Split(' ');
                    int city_1 = Convert.ToInt32(tokens_city_1[0]);
                    int city_2 = Convert.ToInt32(tokens_city_1[1]);
                    if (cityRoads[a0].ContainsKey(city_1))
                    {
                        (cityRoads[a0])[city_1].Add(city_2);
                    }
                    else
                    {
                        HashSet<int> roads = new HashSet<int>();
                        roads.Add(city_2);
                        cityRoads[a0].Add(city_1, roads);
                    }
                    if (cityRoads[a0].ContainsKey(city_2))
                    {
                        (cityRoads[a0])[city_2].Add(city_1);
                    }
                    else
                    {
                        HashSet<int> roads = new HashSet<int>();
                        roads.Add(city_1);
                        cityRoads[a0].Add(city_2, roads);
                    }
                }
                if (config[a0][2] < config[a0][3])
                {
                    Console.WriteLine(config[a0][0] * config[a0][2]);
                }
                else
                {
                    int roadCount = 0;
                    int libCount = 0;
                    bool[] visited = new bool[Convert.ToInt32(config[a0][0] + 1)];
                    foreach (KeyValuePair<int, HashSet<int>> kvp in cityRoads[a0])
                    {
                        if (!visited[kvp.Key])
                        {
                            visited[kvp.Key] = true;
                            libCount++;
                            countDisjointCities(kvp.Key, cityRoads[a0], visited, ref roadCount);
                        }
                    }
                    int nonVisitedCities = Convert.ToInt32(config[a0][0]) - (libCount + roadCount);
                    Console.WriteLine(nonVisitedCities*config[a0][2] + libCount * config[a0][2] + roadCount * config[a0][3]);
                }



            }

        }
    }
}
