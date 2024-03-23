namespace Domain.Tests;

public class ColaboradorTest
{
    [Theory]
    [InlineData("Catarina Moreira", "catarinamoreira@email.pt")]
    [InlineData("a", "catarinamoreira@email.pt")]
    public void WhenPassingCorrectData_ThenColaboradorIsInstantiated(string strName, string strEmail)
    {
       Colaborator colab = new Colaborator( strName, strEmail);

        Assert.Equal(strName, colab.GetName());
    }

    // [Theory]
    // [InlineData("2023-01-10", "2023-01-01")] // End date before start date, assuming this is the invalid scenario.
    // public void WhenPassingInvalidDate_ThenThrowsException(string start, string end)
    // {
    //     // Arrange
    //     var startDate = DateOnly.Parse(start);
    //     var endDate = DateOnly.Parse(end);
    //     var colaborator = new Colaborator("Quim Barreiros", "quim@barreiros.com");

    //     // Act & Assert
    //     var ex = Assert.Throws<ArgumentException>(() => colaborator.GetTotalHolidayDaysInPeriod(startDate, endDate));
    //     Assert.Equal(" end date depois de start date.", ex.Message);
    // }


    [Theory]
    [InlineData("", "catarinamoreira@email.pt")]
    [InlineData("abasdfsc 12", "catarinamoreira@email.pt")]
    [InlineData("     ", "catarinamoreira@email.pt")]
    [InlineData("kasdjflkadjf lkasdfj laksdjf alkdsfjv alkdsfjv asldkfj asldkfvj asdlkvj asdlkfvj asdlkfvj asdflkfvj asfldkjfv jasdflkvj lasf", "catarinamoreira@email.pt")]
    [InlineData(null, "catarinamoreira@email.pt")]

    public void WhenPassingInvalidName_ThenThrowsException(string strName, string strEmail)
    {
        // arrange

        // assert
        var ex = Assert.Throws<ArgumentException>(() =>
        
            // act
            new Colaborator(strName, strEmail)
        );
        Assert.Equal(ex.Message, "Invalid arguments.");
    }

    [Theory]
    [InlineData("Catarina Moreira", "")]
    [InlineData("Catarina Moreira", null)]
    [InlineData("Catarina Moreira", "catarinamoreira.pt")]
    public void WhenPassingInvalidEmail_ThenThrowsException(string strName, string strEmail)
    {
        // assert
        Assert.Throws<ArgumentException>(() =>
        
            // act
            new Colaborator(strName, strEmail)
        );
    }

    [Theory]
    [InlineData("", "")]
    [InlineData(null, null)]
    [InlineData("", null)]
    [InlineData(null, "")]
    [InlineData("", "catarinamoreira.pt")]
    public void WhenPassingInvalidNameAndInvalidEmail_Thenz(string strName, string strEmail)
    {
        Assert.Throws<ArgumentException>(() => new Colaborator(strName, strEmail));
    }

    [Fact]
    public void WhenPassingNameWith50_ThenIsValid()
    {
        // Arrange
        var expectedName = new string('a', 50);
        var expectedEmail = "valid@email.com";

        // act
        var colaborator = new Colaborator(expectedName, expectedEmail);

        // assert
        Assert.Equal(expectedName, colaborator.GetName());
        Assert.Equal(expectedEmail, colaborator.GetEmail());
    }

}