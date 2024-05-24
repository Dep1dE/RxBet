using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxBetDataBase.Models
{
    public class BetEntity
    {
        public Guid GameId { get; set; }
        public decimal Win { get; set; }
        public DateTime Date { get; set; }
        public decimal Payout { get; set; }
    }
}
