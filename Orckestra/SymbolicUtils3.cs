using System;
using System.Collections.Generic;
using Orckestra.Fsharp;

namespace Orckestra
{
    internal ref struct SymbolicPermission3
    {
        private struct PermissionInfo
        {
            public int Value { get; set; }
            public char Symbol { get; set; }
        }

        private const int BlockCount = 18;
        private const int BlockLength = 12;
        private const int MissingPermissionSymbol = '-';

        //I could smh decuce value from the position
        //Since values are powers of 2
        //But I think that such dictionary
        //Allows better to capture domain knowledge
        private readonly static Dictionary<int, PermissionInfo> Permissions = new Dictionary<int, PermissionInfo>() {
                {0, new PermissionInfo {
                    Symbol = 'r',
                    Value = 4
                } },
                {1, new PermissionInfo {
                    Symbol = 'w',
                    Value = 2
                }},
                {2, new PermissionInfo {
                    Symbol = 'x',
                    Value = 1
                }},
                {3, new PermissionInfo {
                    Symbol = 'r',
                    Value = 4
                } },
                {4, new PermissionInfo {
                    Symbol = 'w',
                    Value = 2
                }},
                {5, new PermissionInfo {
                    Symbol = 'x',
                    Value = 1
                }},
                {6, new PermissionInfo {
                    Symbol = 'r',
                    Value = 4
                } },
                {7, new PermissionInfo {
                    Symbol = 'w',
                    Value = 2
                }},
                {8, new PermissionInfo {
                    Symbol = 'x',
                    Value = 1
                }},
                {9, new PermissionInfo {
                    Symbol = 'r',
                    Value = 4
                } },
                {10, new PermissionInfo {
                    Symbol = 'w',
                    Value = 2
                }},
                {11, new PermissionInfo {
                    Symbol = 'x',
                    Value = 1
                }}};

        private ReadOnlySpan<char> _value;

        private SymbolicPermission3(ReadOnlySpan<char> value)
        {
            _value = value;
        }

        public static SymbolicPermission3 Parse(ReadOnlySpan<char> input)
        {
            if (input.Length != BlockCount * BlockLength)
            {
                throw new ArgumentException("input should be a string 3 blocks of 3 characters each");
            }
            for (var i = 0; i < input.Length; i++)
            {
                TestCharForValidity(input, i);
            }

            return new SymbolicPermission3(input);
        }

        public int GetOctalRepresentation()
        {
            var res = 0;
            for (var i = 0; i < BlockCount; i++)
            {
                var block = GetBlock(i);
                res += new Helpers().ConvertBlockToOctal(block) * (int)Math.Pow(10, BlockCount - i - 1);
            }
            return res;
        }

        private static void TestCharForValidity(ReadOnlySpan<char> input, int position)
        {
            var index = position % BlockLength;
            var expectedPermission = Permissions[index];
            var symbolToTest = input[position];
            if (symbolToTest != expectedPermission.Symbol && symbolToTest != MissingPermissionSymbol)
            {
                throw new ArgumentException($"invalid input in position {position}");
            }
        }

        private ReadOnlySpan<char> GetBlock(int blockNumber)
        {
            return _value.Slice(blockNumber * BlockLength, BlockLength);
        }
    }

    public static class SymbolicUtils3
    {
        public static int SymbolicToOctal(string input)
        {
            var permission = SymbolicPermission3.Parse(input);
            return permission.GetOctalRepresentation();
        }
    }
}
