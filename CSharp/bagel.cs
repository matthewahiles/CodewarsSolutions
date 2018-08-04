// https://www.codewars.com/kata/54bd6b4c956834c9870001a1/train/csharp
using System.Reflection;
namespace Solution {
    class BagelSolver {
        public static Bagel Bagel {
            get {
                var test = new Bagel();
                test.GetType().GetProperty("Value").SetValue(test, 4,null);
                return test;
            }
        }
    }
}
