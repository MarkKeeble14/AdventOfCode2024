using System;
using System.Collections.Generic;
using UnityEngine;

public class Day1P1 : Executable
{
    [SerializeField] private TextAsset input;

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
        int[] leftArr = left.ToArray();
        int[] rightArr = right.ToArray();

        Array.Sort(leftArr);
        Array.Sort(rightArr);

        int totalDistance = 0;
        for (int i = 0; i < leftArr.Length; i++)
        {
            totalDistance += Mathf.Abs(leftArr[i] - rightArr[i]);
        }

        Debug.Log("The Total Distance between the Lists is: " + totalDistance);
    }
}
