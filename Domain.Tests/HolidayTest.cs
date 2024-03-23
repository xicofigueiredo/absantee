namespace Domain.Tests;

public class HolidayTest
{

    [Fact]
    public void WhenPassingAColaborator_ThenHolidayIsInstantiated()
    {
        //Mock<Colaborator> colabDouble = new Mock<Colaborator>("a", "b@b.pt");
        Mock<IColaborator> colabDouble = new Mock<IColaborator>();

        new Holiday(colabDouble.Object);

    }

    [Fact]
    public void Constructor_WithValidIColaborator_SetsColaboratorCorrectly()
    {
        // Arrange
        var mockColab = new Mock<IColaborator>();

        // Act
        var holiday = new Holiday(mockColab.Object);

        // Assert
        Assert.Equal(mockColab.Object, holiday.GetColaborator());
    }


    [Fact]
    public void WhenPassingNullAsColaborator_ThenThrowsException()
    {
        var exception = Assert.Throws<ArgumentException>(() => new Holiday(null!));

        Assert.Contains("Invalid argument: colaborator must be non null", exception.Message);
    }


    [Fact]
    public void WhenAddingNewPeriod_ThenPeriodIsAdded()
    {
        // arrange
        DateOnly initialDate = DateOnly.MinValue;
        DateOnly finalDate = DateOnly.MaxValue;

        Mock<HolidayPeriod> holidayPeriod = new Mock<HolidayPeriod>(); // quero usar isto, perguntar professor
        Mock<IColaborator> colabDouble = new Mock<IColaborator>();
        Mock<IHolidayPeriodFactory> holidayPeriodFactoryDouble = new Mock<IHolidayPeriodFactory>();

        var holiday = new Holiday(colabDouble.Object);
        var expectedHolidayPeriod = new HolidayPeriod(initialDate, finalDate);

        holidayPeriodFactoryDouble.Setup(hpf => hpf.NewHolidayPeriod(initialDate, finalDate)).Returns(expectedHolidayPeriod);

        //act
        HolidayPeriod result = holiday.addHolidayPeriod(holidayPeriodFactoryDouble.Object, initialDate, finalDate);

        //assert
        Assert.NotNull(result);
        Assert.Equal(initialDate, result.getStartDate());
        Assert.Equal(finalDate, result.getEndDate());
 
    }

    [Fact]
    public void WhenAddingMultiplePeriods_ThenAllPeriodsAreAdded()
    {
        // Arrange
        var colabMock = new Mock<IColaborator>();
        var holiday = new Holiday(colabMock.Object);
        var holidayPeriodFactoryMock = new Mock<IHolidayPeriodFactory>();
        var firstPeriod = new HolidayPeriod(DateOnly.FromDateTime(DateTime.Today), DateOnly.FromDateTime(DateTime.Today.AddDays(5)));
        var secondPeriod = new HolidayPeriod(DateOnly.FromDateTime(DateTime.Today.AddDays(6)), DateOnly.FromDateTime(DateTime.Today.AddDays(10)));

        holidayPeriodFactoryMock.SetupSequence(hpf => hpf.NewHolidayPeriod(It.IsAny<DateOnly>(), It.IsAny<DateOnly>()))
            .Returns(firstPeriod)
            .Returns(secondPeriod);

        // Act
        holiday.addHolidayPeriod(holidayPeriodFactoryMock.Object, firstPeriod.getStartDate(), firstPeriod.getEndDate());
        holiday.addHolidayPeriod(holidayPeriodFactoryMock.Object, secondPeriod.getStartDate(), secondPeriod.getEndDate());

        // Assert
        Assert.Equal(2, holiday.getHolidayPeriodsInRange(DateOnly.MinValue, DateOnly.MaxValue).Count);
    }

    [Fact]
    public void GivenPeriodsInRange_WhenExactMatch_ThenReturnsMatchingPeriods()
    {
        // Arrange
        var colabMock = new Mock<IColaborator>();
        var holiday = new Holiday(colabMock.Object);
        var holidayPeriodFactoryMock = new Mock<IHolidayPeriodFactory>();
        var period = new HolidayPeriod(DateOnly.FromDateTime(DateTime.Today), DateOnly.FromDateTime(DateTime.Today.AddDays(5)));

        holidayPeriodFactoryMock.Setup(hpf => hpf.NewHolidayPeriod(It.IsAny<DateOnly>(), It.IsAny<DateOnly>()))
            .Returns(period);

        holiday.addHolidayPeriod(holidayPeriodFactoryMock.Object, period.getStartDate(), period.getEndDate());

        // Act
        var result = holiday.getHolidayPeriodsInRange(period.getStartDate(), period.getEndDate());

        // Assert
        Assert.Single(result);
        Assert.Equal(period, result.First());
    }

    [Fact]
    public void GetTotalHolidayDays_SinglePeriod_CalculatesCorrectly()
    {
        // Arrange
        var mockFactory = new Mock<IHolidayPeriodFactory>();
        var mockColab = new Mock<IColaborator>();
        var holiday = new Holiday(mockColab.Object);
        var startDate = new DateOnly(2023, 1, 1);
        var endDate = new DateOnly(2023, 1, 10);
        var expectedDays = 10; 
        var period = new HolidayPeriod(startDate, endDate);

        mockFactory.Setup(f => f.NewHolidayPeriod(startDate, endDate)).Returns(period);

        holiday.addHolidayPeriod(mockFactory.Object, startDate, endDate);

        // Act
        var totalDays = holiday.getTotalHolidayDays(new List<HolidayPeriod> { period });

        // Assert
        Assert.Equal(expectedDays, totalDays);
    }

    [Fact]
    public void GivenPeriodsOutsideRange_WhenRetrieving_ThenIgnoresNonMatchingPeriods()
    {
        // Arrange
        var colabMock = new Mock<IColaborator>();
        var holiday = new Holiday(colabMock.Object);
        var holidayPeriodFactoryMock = new Mock<IHolidayPeriodFactory>();
        var beforePeriod = new HolidayPeriod(DateOnly.FromDateTime(DateTime.Today.AddDays(-10)), DateOnly.FromDateTime(DateTime.Today.AddDays(-5)));
        var afterPeriod = new HolidayPeriod(DateOnly.FromDateTime(DateTime.Today.AddDays(6)), DateOnly.FromDateTime(DateTime.Today.AddDays(10)));

        holidayPeriodFactoryMock.SetupSequence(hpf => hpf.NewHolidayPeriod(It.IsAny<DateOnly>(), It.IsAny<DateOnly>()))
                .Returns(beforePeriod)
                .Returns(afterPeriod);

        holiday.addHolidayPeriod(holidayPeriodFactoryMock.Object, beforePeriod.getStartDate(), beforePeriod.getEndDate());
        holiday.addHolidayPeriod(holidayPeriodFactoryMock.Object, afterPeriod.getStartDate(), afterPeriod.getEndDate());


        var rangeStart = DateOnly.FromDateTime(DateTime.Today);
        var rangeEnd = DateOnly.FromDateTime(DateTime.Today.AddDays(1));

        // Act
        var result = holiday.getHolidayPeriodsInRange(rangeStart, rangeEnd);

        // Assert
        Assert.Empty(result);
    }


}