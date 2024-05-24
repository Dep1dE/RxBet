using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxBetCore.Models
{
    public class Bet
    {
        private Bet(Guid gameId, decimal win, DateTime date, decimal payout)
        {
            GameId = gameId;
            Win = win;
            Date = date;
            Payout = payout;
        }
        public Guid GameId { get; private set; }
        public decimal Win { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Payout { get; private set; }

        public static Bet Create(Guid gameId, decimal win, DateTime date, decimal payout)
        {
            return new Bet(gameId, win, date, payout);
        }
    }
}
