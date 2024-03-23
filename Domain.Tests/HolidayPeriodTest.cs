using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Domain.Tests
{
    public class HolidayPeriodTest
    {

        [Theory]
        [InlineData(2023, 12, 1, 2023, 12, 1)]
        public void Constructor_WithStartDateEqualToEndDate_CreatesInstance(int startYear, int startMonth, int startDay, int endYear, int endMonth, int endDay)
        {
            // Arrange
            var startDate = new DateOnly(startYear, startMonth, startDay);
            var endDate = new DateOnly(endYear, endMonth, endDay);

            // Act
            var holidayPeriod = new HolidayPeriod(startDate, endDate);

            // Assert
            Assert.Equal(startDate, holidayPeriod.getStartDate());
            Assert.Equal(endDate, holidayPeriod.getEndDate());
        }

        [Theory]
        [InlineData(2023, 12, 31, 2023, 12, 21)]
        public void Constructor_WithInvalidStartOrEndDate_ThrowsArgumentException(int startYear, int startMonth, int startDay, int endYear, int endMonth, int endDay)
        {
            // Arrange
            var startDate = new DateOnly(startYear, startMonth, startDay);
            var endDate = new DateOnly(endYear, endMonth, endDay);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new HolidayPeriod(startDate, endDate));
            Assert.NotEmpty(exception.Message); // Ensures that the exception message is not empty
        }


        [Theory]
        [InlineData(31,2024, 12, 1, 2024, 12, 31)]
        [InlineData( 11, 2024, 12, 1, 2024, 12, 11)]

        public void GetNumberOfDays_WithValidStartAndEndDate_ReturnsNumberOfDays(int expectedDays, int startYear, int startMonth, int startDay, int endYear, int endMonth, int endDay)
        {
            // Arrange
            var startDate = new DateOnly(startYear, startMonth, startDay);
            var endDate = new DateOnly(endYear, endMonth, endDay);
            var holidayPeriod = new HolidayPeriod(startDate, endDate);


            // Act
            var result = holidayPeriod.getNumberOfDays();

            // Assert
            Assert.Equal(expectedDays, result);
        }
    }
}