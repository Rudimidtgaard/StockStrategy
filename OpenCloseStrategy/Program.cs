// See https://aka.ms/new-console-template for more information
using OpenCloseStrategy.Data;
using OpenCloseStrategy.Models;
using OpenCloseStrategy.Service;
using OpenCloseStrategy.Models.Enums;

var myVar = new List<Candle>();

//DateTimeKind timeSpan = new Date

//DateTime startDate = new DateTime(2022, 08, 05, 07, 00, 00);
//DateTime endDate = new DateTime(2022, 08, 05, 07, 15, 00);

////myVar = DataHelper.GetCandles();
//myVar = Trade.GetCandlesByDate(startDate, endDate);

//foreach (var candle in myVar)
//{
//    Console.WriteLine(candle.ValidTime);
//    Console.WriteLine("Candle open price was: " + candle.OpenPrice.ToString());
//    Console.WriteLine("Candle close price was: " + candle.ClosePrice.ToString());
//    Console.WriteLine("Candle high trend was: " + candle.HighTrend.ToString());
//    Console.WriteLine("Candle low trend was: " + candle.LowTrend.ToString());
//    Console.WriteLine(Environment.NewLine);
//}

DateOnly testDay = new DateOnly(2022, 08, 05);
Enums.SessionTimeOfDay morningSession = Enums.SessionTimeOfDay.Morning;

Trade.GetTradingSession(testDay, morningSession);