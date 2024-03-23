using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Domain.Tests
{
    public class OpinionTests
    {
        [Fact]
        public void Constructor_WithValidArguments_CreatesInstance()
        {
            // Arrange
            var date = DateTime.Now;
            var decision = Opinion.DecisionType.Accepted;
            var description = "Test description";
            var colaborator = new Colaborator("Test Name", "test@example.com");

            // Act
            var opinion = new Opinion(date, decision, description, colaborator);

            // Assert
            Assert.NotNull(opinion);
            Assert.Equal(date, opinion.Date);
            Assert.Equal(decision, opinion.Decision);
            Assert.Equal(description, opinion.Description);
            Assert.Equal(colaborator, opinion.colaborator);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_WithInvalidDescription_ThrowsArgumentNullException(string invalidDescription)
        {
            // Arrange
            var date = DateTime.Now;
            var decision = Opinion.DecisionType.Denyed;
            var colaborator = new Colaborator("Test Name", "test@example.com"); 

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Opinion(date, decision, invalidDescription, colaborator));
        }

        [Fact]
        public void Constructor_WithNullColaborator_ThrowsArgumentNullException()
        {
            // Arrange
            var date = DateTime.Now;
            var decision = Opinion.DecisionType.Accepted;
            var description = "Valid description";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Opinion(date, decision, description, null));
        }
    }
}