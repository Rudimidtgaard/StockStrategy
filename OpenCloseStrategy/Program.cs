// See https://aka.ms/new-console-template for more information
using OpenCloseStrategy.Data;
using OpenCloseStrategy.Models;

Console.WriteLine("Hello, World!");

var myVar = new List<Candle>();

myVar = DataHelper.GetCandles();

foreach(var candle in myVar)
{
    Console.WriteLine(candle.ValidTime);
    Console.WriteLine(candle.OpenPrice);
    Console.WriteLine(candle.ClosePrice);
    Console.WriteLine(candle.HighTrend.ToString());
    Console.WriteLine(candle.LowTrend.ToString());
}

