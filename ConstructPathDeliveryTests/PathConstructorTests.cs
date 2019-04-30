using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConstructPathDelivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructPathDelivery.Tests
{
    [TestClass()]
    public class PathConstructorTests
    {
        /*
        [TestMethod()]
        public void ConstructPathTest()
        {
            Assert.Fail();
        }
        */

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IputNULLTest()
        {
            PathConstructor pathConstructor = new PathConstructor();
            pathConstructor.ConstructPath(null);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Circle()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            list.Add(new Tuple<string, string>("two", "three"));
            list.Add(new Tuple<string, string>("three", "four"));
            list.Add(new Tuple<string, string>("four", "two"));
            PathConstructor pathConstructor = new PathConstructor();
            var result = pathConstructor.ConstructPath(list);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NullInList()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            list.Add(new Tuple<string, string>("two", "three"));
            list.Add(new Tuple<string, string>("three", "four")); 
            list.Add(new Tuple<string, string>("four", null));
            PathConstructor pathConstructor = new PathConstructor();
            var result = pathConstructor.ConstructPath(list);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyElementInList()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            list.Add(new Tuple<string, string>("two", "three"));
            list.Add(new Tuple<string, string>("three", "four"));
            list.Add(new Tuple<string, string>("four", ""));
            PathConstructor pathConstructor = new PathConstructor();
            var result = pathConstructor.ConstructPath(list);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CircleTwo()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            list.Add(new Tuple<string, string>("one", "two"));
            list.Add(new Tuple<string, string>("two", "three"));            
            list.Add(new Tuple<string, string>("three", "four"));
            list.Add(new Tuple<string, string>("two", "five"));
            list.Add(new Tuple<string, string>("four", "five"));
            PathConstructor pathConstructor = new PathConstructor();
            var result = pathConstructor.ConstructPath(list);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Branch()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            list.Add(new Tuple<string, string>("one", "two"));
            list.Add(new Tuple<string, string>("two", "three"));
            list.Add(new Tuple<string, string>("three", "four"));
            list.Add(new Tuple<string, string>("two", "six"));
            list.Add(new Tuple<string, string>("four", "five"));
            PathConstructor pathConstructor = new PathConstructor();
            var result = pathConstructor.ConstructPath(list);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BranchTwo()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            list.Add(new Tuple<string, string>("one", "two"));
            list.Add(new Tuple<string, string>("two", "three"));
            list.Add(new Tuple<string, string>("three", "four"));
            list.Add(new Tuple<string, string>("seven", "two"));
            list.Add(new Tuple<string, string>("four", "five"));
            PathConstructor pathConstructor = new PathConstructor();
            var result = pathConstructor.ConstructPath(list);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TwoPaths()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            list.Add(new Tuple<string, string>("one", "two"));
            list.Add(new Tuple<string, string>("two", "three"));
            list.Add(new Tuple<string, string>("three", "four"));
            list.Add(new Tuple<string, string>("one1", "two1"));
            list.Add(new Tuple<string, string>("two1", "three1"));
            PathConstructor pathConstructor = new PathConstructor();
            var result = pathConstructor.ConstructPath(list);
        }

        [TestMethod]
        public void OneChain()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            list.Add(new Tuple<string, string>("two", "three"));
            PathConstructor pathConstructor = new PathConstructor();
            var  result = pathConstructor.ConstructPath(list);

            var firstNotSecond = result.Except(list).ToList();
            Assert.AreEqual(firstNotSecond.Count(), 0, "using ListExcept");

        }

        [TestMethod]
        public void MultiChain()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            list.Add(new Tuple<string, string>("two", "three"));
            list.Add(new Tuple<string, string>("four", "five"));
            list.Add(new Tuple<string, string>("one", "two"));
            list.Add(new Tuple<string, string>("three", "four")); 
            PathConstructor pathConstructor = new PathConstructor();
            var result = pathConstructor.ConstructPath(list);

            List<Tuple<string, string>> correctList = new List<Tuple<string, string>>();
            correctList.Add(new Tuple<string, string>("one", "two"));
            correctList.Add(new Tuple<string, string>("two", "three"));
            correctList.Add(new Tuple<string, string>("three", "four"));
            correctList.Add(new Tuple<string, string>("four", "five"));
            var firstNotSecond = result.Except(correctList).ToList();
            Assert.AreEqual(firstNotSecond.Count(), 0, "using ListExcept");

        }

        [TestMethod]
        public void OneChainMyOwnComparator()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            list.Add(new Tuple<string, string>("two", "three"));
            PathConstructor pathConstructor = new PathConstructor();
            var result = pathConstructor.ConstructPath(list);

            Assert.AreEqual(true, Comparator(result, list), "My own Comparator");
        }

        [TestMethod]
        public void MultiChainMyOwnComparator()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            list.Add(new Tuple<string, string>("two", "three"));
            list.Add(new Tuple<string, string>("four", "five"));
            list.Add(new Tuple<string, string>("one", "two"));
            list.Add(new Tuple<string, string>("three", "four"));
            PathConstructor pathConstructor = new PathConstructor();
            var result = pathConstructor.ConstructPath(list);

            List<Tuple<string, string>> correctList = new List<Tuple<string, string>>();
            correctList.Add(new Tuple<string, string>("one", "two"));
            correctList.Add(new Tuple<string, string>("two", "three"));
            correctList.Add(new Tuple<string, string>("three", "four"));
            correctList.Add(new Tuple<string, string>("four", "five"));
            var firstNotSecond = result.Except(correctList).ToList();
            Assert.AreEqual(true, Comparator(result, correctList), "My own Comparator");

        }

        public bool Comparator(List<Tuple<string, string>> first, List<Tuple<string, string>> second )
        {
            if(first == null && second == null)
            {
                return true;
            }
            else if(first != null && second != null)
            {
               if(first.Count != second.Count)
                {
                    return false;
                }
                else
                {
                    for (var i = 0; i < first.Count; i++)
                    {
                        if (first[i].Item1 != second[i].Item1 || first[i].Item2 != second[i].Item2)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }


    }
}