using System.Globalization;

namespace DevRisk.Domain;

public static class TradeFactory
{
    const double DAYS_TO_EXPIRE = 30;
    const double WARNING_AMOUNT = 1_000_000;
    public static ITrade Create(TradeDto tradeDto, DateTime referenceDate)
    {
        if (!Enum.TryParse(tradeDto.ClientSector, out ClientSectorTypes clientSector)) throw new Exception("Invalid Client Sector");
        if ((referenceDate - tradeDto.NextPayment).TotalDays > DAYS_TO_EXPIRE)
        {
            return new ExpiredTrade(tradeDto.Value, clientSector, tradeDto.NextPayment);
        }
        else if (tradeDto.Value > WARNING_AMOUNT)
        {
            switch (clientSector)
            {
                case ClientSectorTypes.Private:
                    return new HighRisk(tradeDto.Value, clientSector, tradeDto.NextPayment);
                case ClientSectorTypes.Public:
                    return new MediumRisk(tradeDto.Value, clientSector, tradeDto.NextPayment);
            }
        }
        throw new Exception("Invalid category type");
    }
}
