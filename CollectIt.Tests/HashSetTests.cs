using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectIt.Tests
{
    [TestClass]
    public class HashSetTests
    {
        [TestMethod]
        public void Intersect_Sets()
        {
            var set1 = new HashSet<int> { 1, 2, 3 };
            var set2 = new HashSet<int> { 2, 3, 4 };

            set1.IntersectWith(set2);           //Note that IntersectWith modifies the current Set whereas Intersect returns a New Set with the result and does not modify the Current Set.

            Assert.IsTrue(set1.SetEquals(new[] { 2, 3 }));
        }

        [TestMethod]
        public void Union_Sets()
        {
            var set1 = new HashSet<int> { 1, 2, 3 };
            var set2 = new HashSet<int> { 2, 3, 4 };

            set1.UnionWith(set2);                       //Note that UnionWith modifies the current Set whereas UnionWith returns a New Set with the result and does not modify the Current Set.

            Assert.IsTrue(set1.SetEquals(new[] { 1, 2, 3, 4 }));
        }

        [TestMethod]
        public void SymmetricExceptWith_Sets()
        {
            var set1 = new HashSet<int>() { 1, 2, 3 };
            var set2 = new HashSet<int>() { 2, 3, 4 };

            set1.SymmetricExceptWith(set2);

            Assert.IsTrue(set1.SetEquals(new[] { 1, 4 }));
        }
    }
}
