using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxBetCore.Models
{
    public class User
    {
        private User(Guid id, string userName, string passwordHash, string email) 
        { 
            Id = id;
            Username = userName;
            PasswordHash = passwordHash;
            Email = email;
        }

        public Guid Id { get; private set; }
        public string Username { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public decimal Balance { get; private set; } = 0;
        public string Role { get; private set; } = "Player";
        public DateTime RegistrationDate { get; private set; } = DateTime.UtcNow;
        public DateTime LastVisit { get; private set; }
        public bool DailyBonusCollected { get; private set; }
        public decimal TotalWinnings { get; private set; } = 0;
        public decimal TotalLoss { get; private set; } = 0;
        public string LoyaltyLevel { get; private set; } = "Bronze";
        public List<Bet> BettingHistory { get; private set; } = new List<Bet>();

        public static User Create(Guid id, string userName, string passwordHash, string email)
        {
            return new User(id, userName, passwordHash, email);
        }
    }
}
