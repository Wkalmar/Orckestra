using FluentAssertions;
using Xunit;

namespace Orckestra.Test
{
    public class ChangeDateFormatTests
    {
        [Fact]
        public void FiltersOutInvalidDateFormats()
        {
            DateFormatUtils.ChangeDateFormat(new[] {
                "2010/03/30", "15/12/2016", "11-15-2012", "20130720"
            }).Should().BeEquivalentTo("20100330", "20161215", "20121115");
        }
    }
}
