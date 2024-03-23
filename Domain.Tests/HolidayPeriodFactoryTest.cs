using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Domain.Tests
{
    public class HolidayPeriodFactoryTest
    {

    [Fact]
    public void NewHolidayPeriod_CreatesHolidayPeriodWithCorrectDates()
    {
        // Arrange
        var factory = new HolidayPeriodFactory();
        var startDate = new DateOnly(2024, 1, 1);
        var endDate = new DateOnly(2024, 1, 10);

        // Act
        var holidayPeriod = factory.NewHolidayPeriod(startDate, endDate);

        // Assert
        Assert.NotNull(holidayPeriod); 
        Assert.Equal(startDate, holidayPeriod.getStartDate()); 
        Assert.Equal(endDate, holidayPeriod.getEndDate()); 
    }

    [Fact]
    public void NewHolidayPeriod_WithEndDateBeforeStartDate_ThrowsArgumentException()
    {
        // Arrange
        var factory = new HolidayPeriodFactory();
        var startDate = new DateOnly(2024, 1, 10);
        var endDate = new DateOnly(2024, 1, 1);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => factory.NewHolidayPeriod(startDate, endDate));
    }
    }
}