// https://www.codewars.com/kata/52774a314c2333f0a7000688/solutions/csharp/
using System.Linq;
public class Parentheses
{
    public static bool ValidParentheses(string input)
        {
            input = new System.String(input.ToCharArray().Where(x => x == '(' || x == ')').ToArray());
            int len = input.Length;
            while(len > 0)
            {
                input = input.Replace("()", "");
                if (input.Length == len)
                {
                    return false;
                }
                len = input.Length;
              }
            return true;
        }
}
