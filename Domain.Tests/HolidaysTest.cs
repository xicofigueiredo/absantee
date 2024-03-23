using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Domain.Tests
{
    public class HolidaysTest
    {
        private readonly Mock<IHoliday> mockHoliday;
        private readonly Mock<IColaborator> mockColaborator;
        private readonly Holidays holidays;

        public HolidaysTest()
        {
            mockHoliday = new Mock<IHoliday>();
            mockColaborator = new Mock<IColaborator>();

            mockHoliday.Setup(h => h.GetColaborator()).Returns(mockColaborator.Object);

            holidays = new Holidays(new List<IHoliday> { mockHoliday.Object });
        }

        [Fact]
        public void AddHoliday_IncreasesCount()
        {
            // Arrange
            var initialCount = holidays.GetHolidays().Count;
            var newHoliday = new Mock<IHoliday>();

            // Act
            holidays.addHoliday(newHoliday.Object);

            // Assert
            Assert.Equal(initialCount + 1, holidays.GetHolidays().Count);
        }

        [Fact]
        public void GetTotalDiasFeriasOfColaboratorinRange_WithHolidaysWithinRange_ReturnsCorrectTotalDays()
        {
            // Arrange
            var mockHoliday = new Mock<IHoliday>();
            var mockColaborator = new Mock<IColaborator>();
            var holidaysList = new List<IHoliday> { mockHoliday.Object };
            var holidays = new Holidays(holidaysList);
            var startDate = new DateOnly(2023, 1, 1);
            var endDate = new DateOnly(2023, 1, 31);
            var holidayPeriods = new List<HolidayPeriod>
            {
                new HolidayPeriod(new DateOnly(2023, 1, 10), new DateOnly(2023, 1, 15))
            };

            mockHoliday.Setup(h => h.GetColaborator()).Returns(mockColaborator.Object);
            mockHoliday.Setup(h => h.getHolidayPeriodsInRange(It.IsAny<DateOnly>(), It.IsAny<DateOnly>())).Returns(holidayPeriods);
            mockHoliday.Setup(h => h.getTotalHolidayDays(It.IsAny<List<HolidayPeriod>>())).Returns(6); // Assuming 6 days including start and end

            // Act
            int totalDays = holidays.GetTotalDiasFeriasOfColaboratorinRange(startDate, endDate, mockColaborator.Object);

            // Assert
            Assert.Equal(6, totalDays);
        }

        [Fact]
        public void GetHolidaysByColaborator_ReturnsCorrectHolidays_ForThatColaborator()
        {
            // Arrange
            var mockColaborator1 = new Mock<IColaborator>();
            var mockColaborator2 = new Mock<IColaborator>();
            var holidayForColaborator1 = new Mock<IHoliday>();
            var holidayForColaborator2 = new Mock<IHoliday>();

            holidayForColaborator1.Setup(h => h.GetColaborator()).Returns(mockColaborator1.Object);
            holidayForColaborator2.Setup(h => h.GetColaborator()).Returns(mockColaborator2.Object);

            var holidays = new List<IHoliday> { holidayForColaborator1.Object, holidayForColaborator2.Object };
            var holidayManager = new Holidays(holidays);

            // Act
            var results = holidayManager.GetHolidaysByColaborator(mockColaborator1.Object);

            // Assert
            Assert.Contains(holidayForColaborator1.Object, results);
            Assert.DoesNotContain(holidayForColaborator2.Object, results);
        }



    //     [Fact]
    //     public void GetHolidaysOfColaborator_ReturnsCorrectHolidays()
    //     {
    //         // Arrange
    //         var mockColaborator = new Mock<IColaborator>();
    //         var mockHoliday1 = new Mock<IHoliday>();
    //         var mockHoliday2 = new Mock<IHoliday>();
    //         mockHoliday1.Setup(h => h.GetColaborator()).Returns(mockColaborator.Object);
    //         mockHoliday2.Setup(h => h.GetColaborator()).Returns(mockColaborator.Object);
            
    //         var holidays = new Holidays(new List<IHoliday> { mockHoliday1.Object, mockHoliday2.Object });

    //         // Act
    //         var result = holidays.GetHolidaysOfColaborator(mockColaborator.Object);

    //         // Assert
    //         Assert.Equal(2, result.Count);
    //         Assert.True(result.All(h => h.GetColaborator() == mockColaborator.Object));
    //     }

    //     [Fact]
    //     public void GetHolidaysByColaborator_ReturnsCorrectHolidays()
    //     {
    //         // Arrange
    //         var mockColaborator = new Mock<IColaborator>();
    //         var mockHoliday1 = new Mock<IHoliday>();
    //         var mockHoliday2 = new Mock<IHoliday>();
    //         mockHoliday1.Setup(h => h.GetColaborator()).Returns(mockColaborator.Object);
    //         mockHoliday2.Setup(h => h.GetColaborator()).Returns(mockColaborator.Object);
            
    //         var holidays = new Holidays(new List<IHoliday> { mockHoliday1.Object, mockHoliday2.Object });

    //         // Act
    //         var result = holidays.GetHolidaysByColaborator(mockColaborator.Object);

    //         // Assert
    //         Assert.Equal(2, result.Count);
    //         Assert.True(result.All(h => h.GetColaborator() == mockColaborator.Object));
    //     }

    //     [Fact]
    //     public void GetColaboratorWithMoreThen_ReturnsCorrectColaborators()
    //     {
    //         // Arrange
    //         var mockColaborator = new Mock<IColaborator>();
    //         var mockHoliday = new Mock<IHoliday>();
    //         var holidaysList = new List<IHoliday> { mockHoliday.Object };

    //         var holidayPeriods = new List<HolidayPeriod>
    //         {
    //             new HolidayPeriod(DateOnly.FromDateTime(DateTime.Today.AddDays(-10)), DateOnly.FromDateTime(DateTime.Today)),
    //             new HolidayPeriod(DateOnly.FromDateTime(DateTime.Today.AddDays(-5)), DateOnly.FromDateTime(DateTime.Today))
    //         };

    //         mockHoliday.Setup(h => h.GetColaborator()).Returns(mockColaborator.Object);
    //         mockHoliday.Setup(h => h.GetHolidayPeriods()).Returns(holidayPeriods);

    //         var holidays = new Holidays(holidaysList);
    //         int XDays = 7; 

    //         // Act
    //         var result = holidays.GetColaboratorWithMoreThen(XDays);

    //         // Assert
    //         Assert.Contains(mockColaborator.Object, result);
    //         Assert.Single(result);
    //     }
    }
}