using Xunit;
using Xunit.Should;

namespace Tokiota.Toolkit.XCutting.IoC.AutofacAdapter.Test
{
    public class Resolved
    {
        #region Public Methods and Operators

        [Fact]
        public void FactMethodName()
        {
            bool x = true;

            x.ShouldBeTrue();
        }

        #endregion
    }
}