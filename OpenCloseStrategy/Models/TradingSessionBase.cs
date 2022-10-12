namespace OpenCloseStrategy.Models
{
    public abstract class TradingSessionBase
    {
        public abstract int Id { get; set; }
        public abstract DateOnly SessionDate { get; set; }
        public abstract Enums.Enums.SessionTimeOfDay TimeOfDay { get; set; }
        public abstract List<Candle> Candles { get; set; }
    }
}