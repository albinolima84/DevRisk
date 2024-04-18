using DevRisk.Domain;

namespace DevRisk.Tests;

public class TradeFactoryTest
{
    [Theory, MemberData(nameof(Cases))]
    public void ShouldCreateTheCorrectInstanceType(DateTime referenceDate, double value, string clientSector, DateTime nextPayment, string output)
    {
        var trade = new TradeDto(nextPayment, clientSector, value);
        var instance = TradeFactory.Create(trade, referenceDate);
        Assert.Equal(output, instance.Category);
    }

    [Theory, MemberData(nameof(Exceptions))]
    public void ShouldThrowException(DateTime referenceDate, double value, string clientSector, DateTime nextPayment, string errorMessage)
    {
        var trade = new TradeDto(nextPayment, clientSector, value);
        try {
            var instance = TradeFactory.Create(trade, referenceDate);
        }
        catch(Exception ex)
        {
            Assert.Equal(errorMessage, ex.Message);
        }
    }

    public static TheoryData<DateTime, double, string, DateTime, string> Cases =
    new()
    {
        { DateTime.Parse("12/11/2020"), 2_000_000, "Private", DateTime.Parse("12/29/2025"), "HIGHRISK" },
        { DateTime.Parse("12/11/2020"), 400_000, "Public", DateTime.Parse("07/01/2020"), "EXPIRED" },
        { DateTime.Parse("12/11/2020"), 5_000_000, "Public", DateTime.Parse("01/02/2024"), "MEDIUMRISK" },
        { DateTime.Parse("12/11/2020"), 3_000_000, "Public", DateTime.Parse("10/26/2023"), "MEDIUMRISK" }
    };

    public static TheoryData<DateTime, double, string, DateTime, string> Exceptions =
    new()
    {
        { DateTime.Parse("04/11/2024"), 200_000, "Private", DateTime.Parse("12/29/2025"), "Invalid category type" },
        { DateTime.Parse("04/11/2024"), 1_000_000, "Public", DateTime.Parse("04/20/2024"), "Invalid category type" },
        { DateTime.Parse("04/11/2024"), 5_000_000, "Publico", DateTime.Parse("01/02/2024"), "Invalid Client Sector" }
    };
}