using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraderLibrary
{
    public class TradeModel
    {
        public decimal R { get; set; }  // Price
        public decimal A { get; set; }  // Amount
        public string Ty { get; set; }  // Type
        public long T { get; set; }  // unix Time było decimal
        public Guid Id { get; set; } //dodać trade id

        public override string ToString()
        {
            return $"TradeID: , Amount: {A}, Date: {T}, Price: {R}, Type: {Ty}, Id: {Id}"; //dodaj trade id
        }
        public bool IsPeak(decimal percent, double timeHours, long lastPeakDate)
        {
            var Set = new TradeSet(
                DateTimeOffset.FromUnixTimeSeconds(T - (long)(3600 * timeHours)).DateTime,
                DateTimeOffset.FromUnixTimeSeconds(T).DateTime);
            return Set.Trades.Any(t =>
                T > lastPeakDate + timeHours * 3600
                && T - t.T >= 0
                && T - t.T <= timeHours * 3600
                && R - t.R >= percent / 100 * t.R);
        }
        public bool IsValley(decimal percent, double timeHours, long lastValleyDate)
        {
            var Set = new TradeSet(
                DateTimeOffset.FromUnixTimeSeconds(T - (long)(3600 * timeHours)).DateTime,
                DateTimeOffset.FromUnixTimeSeconds(T).DateTime);
            return Set.Trades.Any(t =>
                T > lastValleyDate + timeHours * 3600
                && T - t.T >= 0
                && T - t.T <= timeHours * 3600
                && R - t.R <= -percent / 100 * t.R);
        }
    }
}
