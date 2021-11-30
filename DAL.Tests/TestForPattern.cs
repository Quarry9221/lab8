using DAL.Entities;
using Xunit;

namespace DAL.Tests
{
    public class TestForPattern
    {
        [Fact]
        public void get_singleton()
        {
            OSN osns = OSN.GetInstance();
            Assert.NotNull(osns);
        }
    }
}