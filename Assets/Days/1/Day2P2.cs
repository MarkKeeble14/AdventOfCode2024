using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Day2P2 : Executable
{
    [SerializeField] private TextAsset input;

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

                // try removing each level to see if doing so would remove the problem
                for (int i = 0; i < levels.Count; i++)
                {
                    List<int> newLevels = new List<int>();
                    newLevels.AddRange(levels);
                    newLevels.Remove(levels[i]);

                    if (print)
                    {
                        Debug.Log("Desparate Level");
                        newLevels.ForEach(x => Debug.Log(x));
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

        // Accounts for levels i through count - 1
        for (int i = 0; i < levels.Count - 2; i++)
        {
            dif = levels[i + 1] - levels[i];

            if (levels[i + 2] - levels[i + 1] > 0
                != levels[i + 1] - levels[i] > 0)
            {
                return i;
            }

            if (Mathf.Abs(dif) > 3 || Mathf.Abs(dif) < 1)
            {
                return i;
            }
        }

        // Accounts for final level
        int index = levels.Count - 1;
        if (levels[index - 2] - levels[index - 1] > 0
            != levels[index - 1] - levels[index] > 0)
        {
            return index;
        }

        dif = levels[index - 1] - levels[index];
        if (Mathf.Abs(dif) > 3 || Mathf.Abs(dif) < 1)
        {
            return index;
        }

        return -1;
    }
}