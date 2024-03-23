using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace Domain.Tests
{
    public class TrainingTest
    {
        [Theory]
        [InlineData(null)]
        public void WhenPassingInvalidColaborator_ThenThrowsException(IColaborator colab)
        {
            // Arrange
            string description = "Valid Description";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Training(description, colab!));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void WhenPassingInvalidDescription_ThenThrowsException(string description)
        {
            // Arrange
            var colabMock = new Mock<IColaborator>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Training(description!, colabMock.Object));
        }

        [Theory]
        [InlineData("A valid description")]
        [InlineData("Another valid description")]
        public void WhenPassingValidDescriptionAndColaborator_ThenCreatesInstanceSuccessfully(string validDescription)
        {
            // Arrange
            var colabMock = new Mock<IColaborator>();

            // Act
            var training = new Training(validDescription, colabMock.Object);

            // Assert
            Assert.NotNull(training);
            Assert.Equal(validDescription, training.Description);
        }

        [Fact]
        public void WhenAddingNewPeriod_ThenPeriodIsAdded()
        {
            // arrange
            DateOnly initialDate = DateOnly.MinValue;
            DateOnly FinalDate = DateOnly.MaxValue;
            Mock<IColaborator> colabDouble = new Mock<IColaborator>();
            var training = new Training(colabDouble.Object);
    
            //act
            TrainingPeriod result = training.addTrainingPeriod(initialDate, FinalDate);
    
            //assert
            Assert.NotNull(result);
            Assert.Equal(initialDate,result._startDate);
            Assert.Equal(FinalDate,result._endDate);
    
        }

    }
}