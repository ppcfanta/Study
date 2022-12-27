using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }

}
