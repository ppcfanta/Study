using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    public class BenchTester
    {
        string[] Array;
        HashSet<string> hashset;

        public BenchTester()
        {
            Array = new string[10000];
            Program.FillArray(Array, 10000);
            hashset = new HashSet<string>();
            Program.FillHashSet(hashset, 10000);
        }

        [Benchmark]
        public void TestArraySearch()
        {
            Program.SearchInArray(Array, "9876");
        }

        [Benchmark]
        public void TestHashSetSearch()
        {
            Program.SearchInHashSet(hashset, "9876");
        }
    }
}
