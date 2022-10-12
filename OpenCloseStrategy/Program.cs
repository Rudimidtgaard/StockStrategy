// See https://aka.ms/new-console-template for more information
using OpenCloseStrategy.Data;
using OpenCloseStrategy.Models;
using OpenCloseStrategy.Service;

Console.WriteLine("Hello, World!");

var myVar = new List<Candle>();

//DateTimeKind timeSpan = new Date

DateTime startDate = new DateTime(2022, 08, 05, 07, 00, 00);
DateTime endDate = new DateTime(2022, 08, 05, 07, 15, 00);

//myVar = DataHelper.GetCandles();
myVar = Trade.GetCandlesByDate(startDate, endDate);

foreach (var candle in myVar)
{
    Console.WriteLine(candle.ValidTime);
    Console.WriteLine(candle.OpenPrice);
    Console.WriteLine(candle.ClosePrice);
    Console.WriteLine(candle.HighTrend.ToString());
    Console.WriteLine(candle.LowTrend.ToString());
}

