using System;
using UnityEngine;

public class Day2P1 : Executable
{
    [SerializeField] private TextAsset input;

    [ContextMenu("Execute")]
    protected override void Execute()
    {
        int safeReports = 0;

        string[] content = input.text.Split(new char[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
        bool isSafe;
        int dif;
        foreach (string line in content)
        {
            string[] results = line.Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries);

            isSafe = true;
            for (int i = 0; i < results.Length - 2; i++)
            {
                dif = Int32.Parse(results[i + 1]) - Int32.Parse(results[i]);

                if (Int32.Parse(results[i + 2]) - Int32.Parse(results[i + 1]) > 0
                    != Int32.Parse(results[i + 1]) - Int32.Parse(results[i]) > 0)
                {
                    isSafe = false;
                    break;
                }

                if (Mathf.Abs(dif) > 3 || Mathf.Abs(dif) < 1)
                {
                    isSafe = false;
                    break;
                }
            }

            if (Int32.Parse(results[results.Length - 3]) - Int32.Parse(results[results.Length - 2]) > 0
                != Int32.Parse(results[results.Length - 2]) - Int32.Parse(results[results.Length - 1]) > 0)
            {
                isSafe = false;
            }

            dif = Int32.Parse(results[results.Length - 2]) - Int32.Parse(results[results.Length - 1]);
            if (Mathf.Abs(dif) > 3 || Mathf.Abs(dif) < 1)
            {
                isSafe = false;
            }

            if (isSafe)
                safeReports++;
        }
        
        Debug.Log("The Number of Safe Reports is: " + safeReports);
    }
}
