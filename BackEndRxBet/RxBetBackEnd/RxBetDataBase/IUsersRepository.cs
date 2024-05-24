using Microsoft.EntityFrameworkCore;
using RxBetDataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxBetDataBase
{
    public interface IUsersRepository
    {
        Task Add(Guid id, string _Username, string _Email, string _PasswordHash,
            DateTime _RegistrationDate, bool _DailyBonusCollected);
        Task Update(Guid id, string _Username, string _Email, string _PasswordHash,
            DateTime _RegistrationDate, bool _DailyBonusCollected, decimal _Balance, string _Role,
            DateTime _LastVisit, decimal _TotalWinnings, decimal _TotalLoss, string _LoyaltyLevel, List<BetEntity> _BettingHistory);
        Task<List<UserEntity>> Get();
        Task<List<UserEntity>> GetWithBettingHistory();
        Task<UserEntity?> GetById(Guid id);
        Task<List<UserEntity>> GetByMaxWinning();
        Task<List<UserEntity>> GetByMaxLosing();
        Task<List<UserEntity>> GetByMaxBalance();
        Task<UserEntity?> GetByEmail(string email);
        Task<bool> CheckAvailability(string email);
        Task Delete(Guid id);
        /* public async Task<List<BetEntity>> GetBetHistory(Guid id)
             {
                 return await _dbContext.Users.AsNoTracking().Where(x => x.Id == id).;
             }*/
    }
}
