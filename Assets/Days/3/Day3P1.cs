using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day3P1 : Executable
{
    protected override void Execute()
    {
        string num;
        int num1;
        int num2;
        char c;
        string str = "";
        int total = 0;

        for (int i = 0; i < input.text.Length; i++)
        {            c = input.text[i];
            if (c == 'm')
            {
                str += c;
                continue;
            }

            if (str == "m")
            {
                if (c == 'u')
                {
                    str += c;
                    continue;
                } else
                {
                    str = "";
                    continue;
                }
            }

            if (str == "mu")
            {
                if (c == 'l')
                {
                    str += c;
                    continue;
                }
                else
                {
                    str = "";
                    continue;
                }
            }

            if (str == "mul")
            {
                if (c == '(')
                {
                    str += c;

                    // try to scan an int in
                    num = ScanForInt(input.text, i + 1, ',');
                    if (num == "")
                    {
                        str = ""; // failed to scan for some reason, reset and continue
                        continue;
                    }
                    else
                    {
                        // succesfully scanned in num1
                        num1 = int.Parse(num);

                        // increment count by length of number + 1 (the comma)
                        i += num.Length + 1;

                        // try to scan another int in
                        num = ScanForInt(input.text, i + 1, ')');

                        if (num == "")
                        {
                            str = ""; // failed to scan for some reason, reset and continue
                            continue;
                        }
                        else
                        {
                            // succesfully scanned in num2
                            num2 = int.Parse(num);

                            // increment count by length of number + 1 (the close bracket)
                            i += num.Length + 1;

                            // add to total
                            total += num1 * num2;

                            if (print)
                                Debug.Log("Adding to Total: " + num1 + "x" + num2 + "=" + num1 * num2);

                            str = "";
                        }
                    }
                } else
                {
                    str = "";
                    continue;
                }
            }
        }

        Debug.Log("Total: " + total);
    }

    private string ScanForInt(string s, int startIndex, char endScanOn)
    {
        string num = "";
        int c1;
        for (int p = startIndex; ; p++)
        {
            // if it's a number, add it to the string to be converted to a number later
            if (int.TryParse(input.text[p].ToString(), out c1))
            {
                num += c1.ToString();
            }
            else if (input.text[p] == endScanOn) // if it's a comma, we make the number something
            {
                if (num.Length > 0)
                {
                    return num;
                } else
                {
                    return "";
                }
            }
            else // if it's neither a number nor a comma, problem
            {
                return "";
            }
        }
    }
}
