using System;
using System.Collections.Generic;
using System.Text;

namespace Orckestra
{
    internal class PermissionInfo 
    {
        public int Value { get; set; }
        public char Symbol { get; set; }
    }
    
    public static class SymbolicUtils
    {
        private const int BlockCount = 3;
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
                }} };

        
        
        public static int SymbolicToOctal(string input)
        {
            if (input.Length != 9)
            {
                throw new ArgumentException("input should be a string 3 blocks of 3 characters each");
            }
            var res = 0;
            for (var i = 0; i < BlockCount; i++)
            {
                res += ConvertBlockToOctal(input, i);
            }
            return res;
        }

        private static int ConvertBlockToOctal(string input, int blockNumber)
        {
            var res = 0;
            foreach (var (index, permission) in Permissions)
            {
                var actualValue = input[blockNumber * BlockCount + index];
                if (actualValue == permission.Symbol)
                {
                    res += permission.Value;
                }
            }
            //I guess name of the method suggests 
            //that I shoud play with base of 8
            //but since requirements don't explictly state that
            //I think base of 10 is good enough :)
            return res * (int)Math.Pow(10, BlockCount - blockNumber - 1);
        }
    }
}
