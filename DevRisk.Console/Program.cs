using DevRisk.Domain;
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        var culture = CultureInfo.GetCultureInfo("en-US");
        string path = Directory.GetCurrentDirectory();
        StreamReader content = new($@"{path}/input.txt");
        StreamWriter output = new($@"{path}/output.txt");
        var referenceDateFromFile = content.ReadLine();
        if (!DateTime.TryParse(referenceDateFromFile, culture, out DateTime referenceDate))
        {
            Console.WriteLine($"Incorrect file format.");
            Environment.Exit(0);
        }
        var tradesQuantity = content.ReadLine();
        Console.WriteLine($"{tradesQuantity} trades found for {referenceDate}");
        var trade = content.ReadLine();
        while (trade != null)
        {
            var currentTrade = trade.Split(' ');
            if(!DateTime.TryParse(currentTrade[2], culture, out DateTime nextPayment)) 
            {
                Console.WriteLine($"Error on processing line {trade}. Date format invalid");
                trade = content.ReadLine();
                continue;
            }
            var tradeDto = new TradeDto(nextPayment, currentTrade[1], double.Parse(currentTrade[0]));
            try
            {
                var instance = TradeFactory.Create(tradeDto, referenceDate);
                output.WriteLine(instance.Category);    
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error on generating Trade -> {ex.Message}");
                continue;
            }
            finally 
            {
                trade = content.ReadLine();
            }
        }
        content.Close();
        output.Close();
    }
}