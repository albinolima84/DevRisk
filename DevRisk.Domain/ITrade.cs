namespace DevRisk.Domain;

public interface ITrade
{
    double Value { get; }
    ClientSectorTypes ClientSector { get; }
    DateTime NextPaymentDte { get; }
    string Category { get; }
}
