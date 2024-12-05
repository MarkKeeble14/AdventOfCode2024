using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day3P2 : Executable
{
    protected override void Execute()
    {
        int total = 0;
        bool allowMulScan = true;
        int mulResult;
        for (int i = 0; i < input.text.Length; i++)
        {
            if (ScanForMul(i, out mulResult, out i))
            {
                if (allowMulScan)
                    total += mulResult;
            } else if (ScanForDo(i))
            {
                allowMulScan = true;
                i += 3;
            } else if (ScanForDont(i))
            {
                allowMulScan = false;
                i += 6;
            }
        }

        Debug.Log("Total: " + total);
    }

    private bool ScanForMul(int scanFrom, out int mulResult, out int newIndex)
    {
        string num;
        int num1;
        int num2;
        int scanningAt = scanFrom;

        if (scanningAt > input.text.Length - 4)
        {
            mulResult = 0;
            newIndex = scanFrom;
            return false;
        };

        string str = input.text.Substring(scanningAt, 4);
        scanningAt += 3;

        if (str == "mul(")
        {
            // try to scan an int in
            num = ScanForInt(scanningAt + 1, ',');
            if (num != "")
            {
                // succesfully scanned in num1
                num1 = int.Parse(num);

                // increment count by length of number + 1 (the comma)
                scanningAt += num.Length + 1;

                // try to scan another int in
                num = ScanForInt(scanningAt + 1, ')');

                if (num != "")
                {
                    // succesfully scanned in num2
                    num2 = int.Parse(num);

                    // increment count by length of number + 1 (the close bracket)
                    scanningAt += num.Length + 1;

                    if (print)
                        Debug.Log("Adding to Total: " + num1 + "x" + num2 + "=" + num1 * num2);

                    mulResult = num1 * num2;
                    newIndex = scanningAt;
                    return true;
                }
            }
        }

        mulResult = 0;
        newIndex = scanFrom;
        return false;
    }

    private bool ScanForDo(int scanFrom)
    {
        if (scanFrom > input.text.Length - 4)
        {
            return false;
        }

        return input.text.Substring(scanFrom, 4) == "do()";
    }

    private bool ScanForDont(int scanFrom)
    {
        if (scanFrom > input.text.Length - 7)
        {
            return false;
        }

        return input.text.Substring(scanFrom, 7) == "don't()";
    }

    private string ScanForInt(int startIndex, char endScanOn)
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
                }
                else
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
