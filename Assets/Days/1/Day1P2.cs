using System;
using System.Collections.Generic;
using UnityEngine;

public class Day1P2 : Executable
{
    [ContextMenu("Execute")]
    protected override void Execute()
    {
        List<int> left = new List<int>();
        List<int> right = new List<int>();

        var splitfile = input.text.Split(new[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < splitfile.Length; i++)
        {
            if (i % 2 == 0)
                left.Add(Int32.Parse(splitfile[i]));
            else
                right.Add(Int32.Parse(splitfile[i]));
        }

        Dictionary<int, int> occuranceMap = new Dictionary<int, int>();
        foreach (int i in right)
        {
            if (occuranceMap.ContainsKey(i))
                occuranceMap[i]++;
            else
                occuranceMap.Add(i, 1);
        }

        int similarityScore = 0;
        foreach (int i in left)
        {
            if (occuranceMap.ContainsKey(i))
                similarityScore += i * occuranceMap[i];
        }

        Debug.Log("The Similarity Score between the Lists is: " + similarityScore);
    }
}
