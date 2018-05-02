using System;
using System.Collections.Generic;
using System.Linq;

namespace TestLib
{
    public class LINQTests
    {
        public void DoSome()
        {
            const string searchName = "FunkoPop";

            var shelve = new Shelve();

            // filter
            Func<Box, bool> filterFunction = box => !box.Items.Any();

            IEnumerable<Box> emptyBoxes = shelve.Boxes.Where(filterFunction);

            // map

            Func<Box, string> mapFunction = box => box.Name;

            IEnumerable<String> boxNames = shelve.Boxes.Select(mapFunction);

            // find

            Func<Box, bool> boxFindFunction = box => String.IsNullOrEmpty(box.Name);

            Box firstUnnamedBox = shelve.Boxes.FirstOrDefault(boxFindFunction);

            // find nested list

            Func<Item, bool> itemFindFunction = item => item.Name.Equals(searchName);

            Box someBox = shelve.Boxes.FirstOrDefault(box => box.Items.Any(itemFindFunction));
            Item someItem = someBox.Items.FirstOrDefault(itemFindFunction);

            Item funcoPopItem = shelve.Boxes
                .SelectMany(box => box.Items) // flattens list
                .FirstOrDefault(itemFindFunction);

            // transform a nested item list into another list type

            IEnumerable<String> someItemNames = shelve.Boxes
                .SelectMany(box => box.Items) // flattens list (flatMap)
                .Select(item => item.Name); // map (transformation)

            // net 2.0 (cuando implementarion Generics) ... EVITAR USAR !!!
            // shelve.Boxes.FindAll(<predicate>)

            // pass function as a parameter to another function
            TestFunc2(mySumFunction2);
        }

        public void TestFunc1 (Func<int, int, int> mySumFunction)
        {
            int sum = mySumFunction.Invoke(1, 2);
        }

        public void TestFunc2(Func<int, int, int> mySumFunction2)
        {
            int sum = mySumFunction2(1, 2);
        }
        public void TestAction1(Func<int, int, int> mySumFunction)
        {
            int sum = mySumFunction.Invoke(1, 2);
        }

        public int mySumFunction2(int a, int b) {
            return a + b;
        }
    }

    public class Shelve
    {
        public List<Box> Boxes { get; set; }
    }

    public class Box
    {
        public String Name { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        public String Name { get; set; }
    }
}
