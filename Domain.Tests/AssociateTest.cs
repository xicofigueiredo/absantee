using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Domain.Tests
{
    public class AssociateTest
    {
        [Fact]
        public void WhenPassingAllParameters_ShouldInitializeProperties()
        {
            Mock<IProject> projectDouble = new Mock<IProject>();

            Assert.NotNull(projectDouble.Object);
        }

    }
}