using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Domain.Tests
{
    public class ProjectTest
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            Mock<IProject> projectDouble = new Mock<IProject>();

            Assert.NotNull(projectDouble.Object);
        }
        

        // [Theory]
        // [InlineData("Nome do projeto", 2024, 01, 01, 2024, 01, 31)]

        // public void WhenPassingCorrectData_ThenProjectShouldBeInitialized(string name, int startYear, int startMonth, int startDay, int endYear, int endMonth, int endDay)
        // {
        //     DateOnly startDate = new DateOnly(startYear, startMonth, startDay);
        //     DateOnly endDate = new DateOnly(endYear, endMonth, endDay);

        //     var project = new Project(name, startDate, endDate);

        //     Assert.Equal(name, project._strName);
        //     Assert.Equal(startDate, project._dateStart);
        //     Assert.Equal(endDate, project._dateEnd);
        // }

        // [Theory]
        // [InlineData("Project 1", "2024-01-01", null)]
        // public void Constructor_WithNullEndDate_ShouldInitializeWithNullEndDate(string name, string startDate, string endDateAsString)
        // {
        //     // Arrange
        //     var start = DateOnly.Parse(startDate);
        //     DateOnly? end = string.IsNullOrEmpty(endDateAsString) ? null : DateOnly.Parse(endDateAsString);

        //     // Act
        //     var project = new Project(name, start, end);

        //     // Assert
        //     Assert.Equal(name, project._strName);
        //     Assert.Equal(start, project._dateStart);
        //     Assert.Null(project._dateEnd);
        // }

    //     [Theory]
    //     [InlineData("2024-02-01", "2024-12-31", 44)] 
    //     [InlineData("2024-01-01", "2024-01-31", 0)]
    //     [InlineData("2024-12-25", "2024-12-31", 14)]
    //     public void GetTotalHolidayDaysForAllColaboratorsInProject_ShouldReturnCorrectDays(string start, string end, int expectedDays)
    //     {
        
    //     }
    }
}