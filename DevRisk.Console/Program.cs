using DevRisk.Domain;
using System.IO;
internal class Program
{
    private static void Main(string[] args)
    {
        string path = Directory.GetCurrentDirectory();
        StreamReader content = new($@"{path}/input.txt");
        var referenceDateFromFile = content.ReadLine();
        if (!DateTime.TryParse(referenceDateFromFile, out DateTime referenceDate))
        {
            Console.WriteLine($"Incorrect file format.");
            Environment.Exit(0);
        }
        var tradesQuantity = content.ReadLine();
        Console.WriteLine($"{tradesQuantity} trades found for {referenceDate}");
        var trade = content.ReadLine();
        while (trade != null)
        {
        // var trade = new TradeDto(DateTime.Now.AddDays(11), "Public", 1_000_001);
        // var instance = TradeFactory.Create(trade, DateTime.Now);
        // Console.WriteLine(instance.Category);
        }
    }
}