using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
public class PalindromeTransform
{

    public static void PalindromeTransformMain()
    {
        string[] tokens_n = "10 7 6".Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int k = Convert.ToInt32(tokens_n[1]);
        int m = Convert.ToInt32(tokens_n[2]);

        Hashtable transformations = new Hashtable();
        HashSet<int> transformY1 = new HashSet<int>();
        transformY1.Add(3);
        transformations.Add(1, transformY1);
        transformY1 = new HashSet<int>();
        //transformY1.Add(1);
        transformY1.Add(5);
        transformations.Add(3, transformY1);
        transformY1 = new HashSet<int>();
        transformY1.Add(7);
        //transformY1.Add(3);
        transformations.Add(5, transformY1);
        //transformY1 = new HashSet<int>();
        //transformY1.Add(5);
        //transformations.Add(7, transformY1);
        //transformY1 = new HashSet<int>();
        //transformY1.Add(2);
        //transformations.Add(6, transformY1);
        transformY1 = new HashSet<int>();
        transformY1.Add(6);
        transformY1.Add(4);
        transformations.Add(2, transformY1);
        //transformY1 = new HashSet<int>();
        //transformY1.Add(2);
        //transformY1.Add(8);
        //transformations.Add(4, transformY1);
        transformY1 = new HashSet<int>();
        transformY1.Add(4);
        transformations.Add(8, transformY1);
        transformY1 = new HashSet<int>();
        transformY1.Add(9);
        transformations.Add(10, transformY1);
        //transformY1 = new HashSet<int>();
        //transformY1.Add(10);
        //transformations.Add(9, transformY1);
        Hashtable transformationsWithTranspose = new Hashtable();
        foreach (DictionaryEntry kvp in transformations)
        {

            HashSet<int> transformY = (new HashSet<int>((HashSet<int>)kvp.Value));
            foreach (int val in (HashSet<int>)kvp.Value)
            {

                if (transformations.ContainsKey(val))
                {
                    transformY.UnionWith((HashSet<int>)transformations[val]);
                    //transformY.Remove((int)kvp.Key);
                }
            }
            transformationsWithTranspose.Add(kvp.Key, transformY);
        }
        foreach (DictionaryEntry kvp in transformations)
        {
            foreach (int val in (HashSet<int>)kvp.Value)
            {

                if (transformationsWithTranspose.ContainsKey(val))
                {
                    ((HashSet<int>)transformationsWithTranspose[val]).Add((int)kvp.Key);
                    //transformY.Remove((int)kvp.Key);
                }
                else
                {
                    HashSet<int> value2 = new HashSet<int>();
                    value2.Add((int)kvp.Key);
                    transformationsWithTranspose[val] = value2;
                }
            }
            //transformationsWithTranspose.Add(kvp.Key, transformY);
        }

        foreach (DictionaryEntry kvp in transformationsWithTranspose)
        {
            Console.Write("Key = {0}, VAlue :", kvp.Key);
            foreach (int val in (HashSet<int>)kvp.Value)
            {
                Console.Write("{0},", val);
            }
            Console.WriteLine("");
        }

        string[] a_temp = "1 9 2 3 10 3".Split(' ');
        int[] a = Array.ConvertAll(a_temp, Int32.Parse);

        int left = 0;
        int right = a.Length - 1;
        int palindromeCount = 0;
        int j = 0;
        int[][] output = new int[m][];
        for (int i = 0; i < m; i++)
            for(int z=0;z<m;z++)
                output[i]= new int[m];
        for (int i = 0; i < m; i++)
            output[i][i] = 1;


        for (int cl = 2; cl <= m; cl++)
        {
            for (int i = 0; i < m - cl + 1; i++)
            {
                j = i + cl - 1;
                if (isMatching(a[i], a[j], transformationsWithTranspose) && cl == 2)
                    output[i][j] = 2;
                else if (isMatching(a[i], a[j], transformationsWithTranspose))
                    output[i][j] = output[i + 1][j - 1] + 2;
                else
                {
                    output[i][j] = output[i][j - 1] > output[i + 1][j] ? output[i][j - 1] : output[i + 1][j]; //max(L[i][j - 1], L[i + 1][j]);
                }
            }
        }

        

        Console.WriteLine(output[0][m - 1]);

    }

    static bool isMatching(int left, int right, Hashtable transformationsWithTranspose)
    {
        HashSet<int> leftTransformations = new HashSet<int>();
        HashSet<int> rightTransformations = new HashSet<int>();
        if (transformationsWithTranspose.ContainsKey(left))
        {
            leftTransformations = (HashSet<int>)transformationsWithTranspose[left];
        }
        if (transformationsWithTranspose.ContainsKey(right))
        {
            rightTransformations = (HashSet<int>)transformationsWithTranspose[right];
        }
        if (leftTransformations.Count > 0 && rightTransformations.Count > 0 && leftTransformations.Intersect(rightTransformations).Count() > 0)
        {
            return true;
        }
        return false;
    }
}