using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CollectIt.Tests
{
    [TestClass]
    public class SortedTests
    {
        [TestMethod]
        public void Can_Use_Sorted_List()
        {
            var list = new SortedList<int, string>();
            list.Add(3, "three");
            list.Add(1, "one");
            list.Add(2, "two");

            Assert.AreEqual(0, list.IndexOfKey(1));
            Assert.AreEqual(1, list.IndexOfValue("two"));
        }

        [TestMethod]
        public void Can_Use_Sorted_Set()
        {
            var set = new SortedSet<int>();     //Same as a Hash Set only difference is that it is Sorted. No Duplicates Possible.

            set.Add(3);
            set.Add(1);
            set.Add(2);
            set.Add(3);     //Not Needed as it dooes not Add it to the Set

            var enumerator = set.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(enumerator.Current, 1);
        }
    }
}
