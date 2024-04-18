namespace DevRisk.Domain;

public struct TradeDto
{
    public TradeDto(DateTime nextPayment, string clientSector, double value)
    {
        NextPayment = nextPayment;
        Value = value;
        ClientSector = clientSector;
    }
    public DateTime NextPayment;
    public string ClientSector;
    public double Value;
}
