using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Day2P2 : Executable
{
    [ContextMenu("Execute")]
    protected override void Execute()
    {
        int safeReports = 0;
        bool savedByDampening;

        string[] content = input.text.Split(new char[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
        foreach (string line in content)
        {
            // Make our list of levels
            string[] results = line.Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries);
            List<int> levels = new();
            foreach (string s in results)
                levels.Add(Int32.Parse(s));

            // Check the level
            int problemIndex = CheckLevel(levels);

            // if there are no problems, the report is safe
            if (problemIndex == -1)
            {
                safeReports++;
            } else // if there is a problem
            {
                savedByDampening = false;

                if (print)
                {
                    Debug.Log("Bad Levels: " + line);
                }

                // try removing each level to see if doing so would remove the problem
                for (int i = 0; i < levels.Count; i++)
                {
                    List<int> newLevels = new List<int>();
                    newLevels.AddRange(levels);
                    newLevels.RemoveAt(i);

                    if (print)
                    {
                        string levelString = "Testing Level: ";
                        foreach (var item in newLevels)
                        {
                            levelString += item + ", ";
                        }
                        Debug.Log(levelString);
                    }

                    problemIndex = CheckLevel(newLevels);
                    if (problemIndex == -1)
                    {
                        safeReports++;
                        savedByDampening = true;
                        break;
                    }
                }

                if (!savedByDampening)
                    Debug.Log("Unsavable Level: " + line);
            }
        }

        Debug.Log("The Number of Safe Reports is: " + safeReports);
    }

    private int CheckLevel(List<int> levels)
    {
        int dif;
        bool curAscending;
        bool prevAscending = false;

        // Accounts for levels i through count - 1
        for (int i = 0; i < levels.Count - 1; i++)
        {
            dif = levels[i + 1] - levels[i];
            curAscending = dif > 0;
            
            if (i > 0)
            {
                if (prevAscending != curAscending)
                {
                    return i;
                }
            }

            if (Mathf.Abs(dif) > 3 || Mathf.Abs(dif) < 1)
            {
                return i;
            }

            prevAscending = curAscending;
        }

        return -1;
    }
}