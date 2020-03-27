using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Orckestra
{
    [MemoryDiagnoser]
    public class Test
    {
        [Benchmark]
        public void Test1()
        {
            var a = SymbolicUtils.SymbolicToOctal("rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-");
        }

        [Benchmark]
        public void Test2()
        {
            var b = SymbolicUtils2.SymbolicToOctal("rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Test>();
            Console.ReadLine();

        }
    }
}
