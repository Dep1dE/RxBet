namespace RxBetDataBase.Models
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public decimal Balance { get; set; } = 0;
        public string Role { get; set; } = "Player";
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
        public DateTime LastVisit { get; set; }
        public bool DailyBonusCollected { get; set; }
        public decimal TotalWinnings { get; set; } = 0;
        public decimal TotalLoss { get; set; } = 0;
        public string LoyaltyLevel { get; set; } = "Bronze";
        public List<BetEntity> BettingHistory { get; set; } = new List<BetEntity>();

    }
}
