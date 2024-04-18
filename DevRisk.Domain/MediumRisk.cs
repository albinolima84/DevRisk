
namespace DevRisk.Domain;

public class MediumRisk : ITrade
{
    public MediumRisk(double value, ClientSectorTypes clientSector, DateTime nextPaymentDate)
    {
        Value = value;
        ClientSector = clientSector;
        NextPaymentDte = nextPaymentDate;
    }
    public double Value { get; }

    public ClientSectorTypes ClientSector { get; }

    public DateTime NextPaymentDte { get; }

    public string Category => "MEDIUMRISK";
}
