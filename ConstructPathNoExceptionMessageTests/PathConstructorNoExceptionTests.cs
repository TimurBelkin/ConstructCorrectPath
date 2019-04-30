using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConstructPathNoExceptionMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructPathNoExceptionMessage.Tests
{
    [TestClass()]
    public class PathConstructorNoExceptionNoExceptionTests
    {
        [TestMethod()]
        public void IputNULLTestNotException()
        {
            PathConstructorNoException PathConstructorNoException = new PathConstructorNoException();
            var result = PathConstructorNoException.ConstructPath(null);
            Assert.AreEqual(null , result);
        }
        [TestMethod]
        public void CirclePaNoException()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            list.Add(new Tuple<string, string>("two", "three"));
            list.Add(new Tuple<string, string>("three", "four"));
            list.Add(new Tuple<string, string>("four", "two"));
            PathConstructorNoException PathConstructorNoException = new PathConstructorNoException();
            var result = PathConstructorNoException.ConstructPath(list);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void NullInListNoException()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            list.Add(new Tuple<string, string>("two", "three"));
            list.Add(new Tuple<string, string>("three", "four"));
            list.Add(new Tuple<string, string>("four", null));
            PathConstructorNoException PathConstructorNoException = new PathConstructorNoException();
            var result = PathConstructorNoException.ConstructPath(list);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void EmptyElementInListNoException()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            list.Add(new Tuple<string, string>("two", "three"));
            list.Add(new Tuple<string, string>("three", "four"));
            list.Add(new Tuple<string, string>("four", ""));
            PathConstructorNoException PathConstructorNoException = new PathConstructorNoException();
            var result = PathConstructorNoException.ConstructPath(list);
            Assert.AreEqual(null, result);
        }


        [TestMethod]
        public void CircleTwoNoException()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            list.Add(new Tuple<string, string>("one", "two"));
            list.Add(new Tuple<string, string>("two", "three"));
            list.Add(new Tuple<string, string>("three", "four"));
            list.Add(new Tuple<string, string>("two", "five"));
            list.Add(new Tuple<string, string>("four", "five"));
            PathConstructorNoException PathConstructorNoException = new PathConstructorNoException();
            var result = PathConstructorNoException.ConstructPath(list);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void BranchNoException()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            list.Add(new Tuple<string, string>("one", "two"));
            list.Add(new Tuple<string, string>("two", "three"));
            list.Add(new Tuple<string, string>("three", "four"));
            list.Add(new Tuple<string, string>("two", "six"));
            list.Add(new Tuple<string, string>("four", "five"));
            PathConstructorNoException PathConstructorNoException = new PathConstructorNoException();
            var result = PathConstructorNoException.ConstructPath(list);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void BranchTwoNoException()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            list.Add(new Tuple<string, string>("one", "two"));
            list.Add(new Tuple<string, string>("two", "three"));
            list.Add(new Tuple<string, string>("three", "four"));
            list.Add(new Tuple<string, string>("seven", "two"));
            list.Add(new Tuple<string, string>("four", "five"));
            PathConstructorNoException PathConstructorNoException = new PathConstructorNoException();
            var result = PathConstructorNoException.ConstructPath(list);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void TwoPathsNoException()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            list.Add(new Tuple<string, string>("one", "two"));
            list.Add(new Tuple<string, string>("two", "three"));
            list.Add(new Tuple<string, string>("three", "four"));
            list.Add(new Tuple<string, string>("one1", "two1"));
            list.Add(new Tuple<string, string>("two1", "three1"));
            PathConstructorNoException PathConstructorNoException = new PathConstructorNoException();
            var result = PathConstructorNoException.ConstructPath(list);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void OneElementListNoException()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            list.Add(new Tuple<string, string>("two", "three"));
            PathConstructorNoException PathConstructorNoException = new PathConstructorNoException();
            var result = PathConstructorNoException.ConstructPath(list);

            var firstNotSecond = result.Except(list).ToList();
            Assert.AreEqual(firstNotSecond.Count(), 0, "using ListExcept");

        }

        [TestMethod]
        public void MultiElementListNoException()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            list.Add(new Tuple<string, string>("two", "three"));
            list.Add(new Tuple<string, string>("four", "five"));
            list.Add(new Tuple<string, string>("one", "two"));
            list.Add(new Tuple<string, string>("three", "four"));
            PathConstructorNoException PathConstructorNoException = new PathConstructorNoException();
            var result = PathConstructorNoException.ConstructPath(list);

            List<Tuple<string, string>> correctList = new List<Tuple<string, string>>();
            correctList.Add(new Tuple<string, string>("one", "two"));
            correctList.Add(new Tuple<string, string>("two", "three"));
            correctList.Add(new Tuple<string, string>("three", "four"));
            correctList.Add(new Tuple<string, string>("four", "five"));
            var firstNotSecond = result.Except(correctList).ToList();
            Assert.AreEqual(firstNotSecond.Count(), 0, "using ListExcept");

        }

        [TestMethod]
        public void OneElementListMyOwnComparatorNoException()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            list.Add(new Tuple<string, string>("two", "three"));
            PathConstructorNoException PathConstructorNoException = new PathConstructorNoException();
            var result = PathConstructorNoException.ConstructPath(list);

            Assert.AreEqual(true, Comparator(result, list), "My own Comparator");
        }

        [TestMethod]
        public void MultiElementListMyOwnComparatorNoException()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            list.Add(new Tuple<string, string>("two", "three"));
            list.Add(new Tuple<string, string>("four", "five"));
            list.Add(new Tuple<string, string>("one", "two"));
            list.Add(new Tuple<string, string>("three", "four"));
            PathConstructorNoException PathConstructorNoException = new PathConstructorNoException();
            var result = PathConstructorNoException.ConstructPath(list);

            List<Tuple<string, string>> correctList = new List<Tuple<string, string>>();
            correctList.Add(new Tuple<string, string>("one", "two"));
            correctList.Add(new Tuple<string, string>("two", "three"));
            correctList.Add(new Tuple<string, string>("three", "four"));
            correctList.Add(new Tuple<string, string>("four", "five"));
            var firstNotSecond = result.Except(correctList).ToList();
            Assert.AreEqual(true, Comparator(result, correctList), "My own Comparator");

        }

        public bool Comparator(List<Tuple<string, string>> first, List<Tuple<string, string>> second)
        {
            if (first == null && second == null)
            {
                return true;
            }
            else if (first != null && second != null)
            {
                if (first.Count != second.Count)
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