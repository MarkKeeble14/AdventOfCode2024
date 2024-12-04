using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day3P1 : Executable
{
    protected override void Execute()
    {
        bool capturingNum;
        string num1Str;
        int num1;
        string num2Str;
        int num2;
        char c;
        string str = "";
        for (int i = 0; i < input.text.Length; i++)
        {
            c = input.text[i];
            if (c == 'm')
            {
                str += c;
                continue;
            }

            if (str == "m" && c == 'u')
            {
                str += c;
                continue;
            }

            if (str == "mu" && c == 'l')
            {
                str += c;
                continue;
            }

            if (str == "mul" && c == '(')
            {
                str += c;

                string num = "";
                for (int p = i + 1; ; p++)
                {
                    int c1;
                    // if it's a number, add it to the string to be converted to a number later
                    if (int.TryParse(input.text[p + 1].ToString(), out c1))
                    {
                        num += c1.ToString();
                    } else if (input.text[p + 1] == ',') // if it's a comma, cool we do something
                    {
                        if (num.Length > 0)
                        {
                            num1 = int.Parse(num);
                        }

                    } else // if it's neither a number nor a comma, problem
                    {
                        str = "";
                        break;
                    }
                }


                continue;
            }


        }
    }
}
