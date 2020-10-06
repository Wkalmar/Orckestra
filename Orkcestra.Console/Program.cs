using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Orckestra
{
    [MemoryDiagnoser]
    public class Test
    {
        [Benchmark]
        public void ReadonlySpan()
        {
            var a = SymbolicUtils.SymbolicToOctal("rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-");
        }

        [Benchmark]
        public void ReadonlySpanWithFsharp()
        {
            var b = SymbolicUtils3.SymbolicToOctal("rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-rwxr-x-w-");
        }

        [Benchmark]
        public void String()
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
