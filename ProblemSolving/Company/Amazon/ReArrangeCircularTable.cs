/*
 A group of people are seated in a circular table. After a while , each members takes a chit and writes his name along with the next person name (anticlock wise.)   . 
 If such chits are given , re draw the the table. A optimal approach was expected. eg. A – B – C- D – E – A
chits will be written as A-B
B-C
C-D etc

VERSION 2
Same questions as above . if each member takes a chit and writes his neighbors name . re draw the table.
 */

using System.Collections;
using System.Collections.Generic;

namespace ProblemSolving
{
    public class ReArrangeCircularTable
    {
        public static void ReArrangeCircularTableMain()
        {
            List<char[]> chits = new List<char[]>();
            chits.Add(new char[2] {'A','B' });
            chits.Add(new char[2] {'B', 'C' });
            chits.Add(new char[2] {'C', 'D' });
            chits.Add(new char[2] {'D', 'E' });
            chits.Add(new char[2] {'E', 'F' });
            chits.Add(new char[2] {'F', 'G' });
            chits.Add(new char[2] {'G', 'A' });

            GetRearrengedTable(chits);

            List<char[]> chitsWithNeighbours = new List<char[]>();
            chitsWithNeighbours.Add(new char[3] { 'F', 'G', 'E' });
            chitsWithNeighbours.Add(new char[3] { 'A', 'B','D' });
            chitsWithNeighbours.Add(new char[3] { 'G', 'F', 'A' });
            chitsWithNeighbours.Add(new char[3] { 'B', 'C','A' });
            chitsWithNeighbours.Add(new char[3] { 'C', 'B','D' });
            chitsWithNeighbours.Add(new char[3] { 'E', 'F','D' });
            chitsWithNeighbours.Add(new char[3] { 'D', 'C', 'E' });
            GetRearrengedTablewithBothNeighbours(chitsWithNeighbours);

        }

        /// <summary>
        /// Get Table GetRearrengedTable for given List of chits contains person next to current person
        /// </summary>
        /// <param name="chits"></param>
        public static void GetRearrengedTable(List<char[]> chits)
        {
            Hashtable chitTable = new Hashtable();//To store chits as key value pair
            HashSet<char> visitedPersons = new HashSet<char>();//To store visited persons from chits
            foreach(char[] chit in chits)
            {//Store chits in Hasttable
                chitTable.Add(chit[0], chit[1]);
            }
            char person = chits[0][0];
            while(!visitedPersons.Contains(person))
            {//If person not in visited then add it in visited, print it and move to its object in Hashtable
                visitedPersons.Add(person);
                System.Console.Write(person+"-");
                person = (char)chitTable[person];
            }
            System.Console.WriteLine(person);
        }

        /// <summary>
        /// Get Round table from chits with both neighbours
        /// </summary>
        /// <param name="chitsWithNeighbours"></param>
        public static void GetRearrengedTablewithBothNeighbours(List<char[]> chitsWithNeighbours)
        {
            Hashtable chitTable = new Hashtable();//To store chitsWithNeighbours as key value pair
            HashSet<char> visitedPersons = new HashSet<char>();//To store visited persons from chitsWithNeighbours
            foreach (char[] chit in chitsWithNeighbours)
            {//Store chits in Hasttable
                chitTable.Add(chit[0], chit);
            }
            char person = chitsWithNeighbours[0][0];
            char firstPerson = person;

            while (true)
            {//If person not in visited then add it in visited, print it and move to its object in Hashtable
                if (!visitedPersons.Contains(person))
                {//Person not visited 
                    char oldPerson = person;
                    visitedPersons.Add(person);
                    System.Console.Write(person + "-");
                    char[] neighbours = (char[])chitTable[person];
                    foreach(char neighbour in neighbours)
                    {
                        if (!visitedPersons.Contains(neighbour))
                        {
                            person = neighbour;
                            break;
                        }
                    }
                    if(oldPerson == person)
                    {//Couldnt find unvisited Neighbour so break
                        break;
                    }
                }
                else
                {//Person is visited
                    break;
                }
                
            }
            System.Console.WriteLine(firstPerson);
        }

    }
}
