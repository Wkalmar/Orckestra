using System;
using System.Collections.Generic;
using System.Globalization;

namespace Orckestra
{
    // I know that going forth with static classes challenges
    // how one sees programming with C#
    // but I see nothing wrong with this approach 
    // since this class contains no internal state
    public static class DateFormatUtils
    {
        private static readonly string[] ValidDateFormats = new[]
        {
            "yyyy/mm/dd",
            "dd/mm/yyyy",
            "mm-dd-yyyy"
        };

        private const string OutputDateFromat = "yyyymmdd";

        // Although spec. file specifies list as input
        // I've decided to accept IReadOnlyCollection
        // since it allows me to accept any enumerated collection
        // i.e. array of strings like I do in tests
        public static IEnumerable<string> ChangeDateFormat(IReadOnlyCollection<string> input)
        {
            foreach (var item in input)
            {
                for (var i = 0; i < ValidDateFormats.Length; i++)
                {
                    var parsed = DateTime.TryParseExact(item,
                        ValidDateFormats[i],
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out var d);
                    if (parsed)
                    {
                        yield return d.ToString(OutputDateFromat); //let the caller enumerate it once needed
                    }
                }
            }
        }
    }
}
