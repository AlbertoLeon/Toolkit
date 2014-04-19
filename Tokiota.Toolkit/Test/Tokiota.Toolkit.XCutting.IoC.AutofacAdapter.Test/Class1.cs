using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Xunit.Should;

namespace Tokiota.Toolkit.XCutting.IoC.AutofacAdapter.Test
{
    
    public class Resolved
    {
        [Fact]
        public void FactMethodName()
        {
            bool x = true;

            x.ShouldBeTrue();
        }
    }
}
