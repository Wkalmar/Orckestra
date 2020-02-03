using FluentAssertions;
using Xunit;

namespace Orckestra.Test
{
    public class SymbolicUtilsTests
    {
        [Fact]
        public void HandlesCorrectInput()
        {
            SymbolicUtils.SymbolicToOctal("rwxr-x-w-").Should().Be(752);
        }
    }
}
