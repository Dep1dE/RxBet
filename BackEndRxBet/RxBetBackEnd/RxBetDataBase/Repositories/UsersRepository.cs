using Microsoft.EntityFrameworkCore;
using RxBetDataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxBetDataBase.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly RxBetDbContext _dbContext;

        public UsersRepository(RxBetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Guid id, string _Username, string _Email, string _PasswordHash,
            DateTime _RegistrationDate, bool _DailyBonusCollected)
        {
            var userEntity = new UserEntity
            {
                Id = id,
                Username = _Username,
                Email = _Email,
                PasswordHash = _PasswordHash,
                RegistrationDate = _RegistrationDate,
                DailyBonusCollected = _DailyBonusCollected
            };

            await _dbContext.Users.AddAsync(userEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Guid id, string _Username, string _Email, string _PasswordHash,
            DateTime _RegistrationDate, bool _DailyBonusCollected, decimal _Balance, string _Role,
            DateTime _LastVisit, decimal _TotalWinnings, decimal _TotalLoss, string _LoyaltyLevel, List<BetEntity> _BettingHistory)
        {
            var userEntity = await _dbContext.Users.Where(x => x.Id == id).ExecuteUpdateAsync(y =>
            y.SetProperty(z => z.Id, id)
            .SetProperty(z => z.Username, _Username)
            .SetProperty(z => z.Email, _Email)
            .SetProperty(z => z.PasswordHash, _PasswordHash)
            .SetProperty(z => z.RegistrationDate, _RegistrationDate)
            .SetProperty(z => z.DailyBonusCollected, _DailyBonusCollected)
            .SetProperty(z => z.Balance, _Balance)
            .SetProperty(z => z.Role, _Role)
            .SetProperty(z => z.LastVisit, _LastVisit)
            .SetProperty(z => z.TotalWinnings, _TotalWinnings)
            .SetProperty(z => z.TotalLoss, _TotalLoss)
            .SetProperty(z => z.LoyaltyLevel, _LoyaltyLevel)
            .SetProperty(z => z.BettingHistory, _BettingHistory)
            );
        }

        public async Task<List<UserEntity>> Get()
        {
            return await _dbContext.Users.AsNoTracking().ToListAsync();
        }

        public async Task<List<UserEntity>> GetWithBettingHistory()
        {
            return await _dbContext.Users.AsNoTracking().Include(x => x.BettingHistory).ToListAsync();
        }

        public async Task<UserEntity?> GetById(Guid id)
        {
            return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UserEntity>> GetByMaxWinning()
        {
            return await _dbContext.Users.AsNoTracking().OrderByDescending(x => x.TotalWinnings).Include(x => x.BettingHistory).ToListAsync();
        }

        public async Task<List<UserEntity>> GetByMaxLosing()
        {
            return await _dbContext.Users.AsNoTracking().OrderByDescending(x => x.TotalLoss).Include(x => x.BettingHistory).ToListAsync();
        }

        public async Task<List<UserEntity>> GetByMaxBalance()
        {
            return await _dbContext.Users.AsNoTracking().OrderByDescending(x => x.Balance).Include(x => x.BettingHistory).ToListAsync();
        }

        public async Task<UserEntity> GetByEmail(string email)
        {
            return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
        }



        /* public async Task<List<BetEntity>> GetBetHistory(Guid id)
         {
             return await _dbContext.Users.AsNoTracking().Where(x => x.Id == id).;
         }*/

        public async Task<bool> CheckAvailability(string email)
        {
            return await _dbContext.Users.Where(x => x.Email == email).AnyAsync();
        }

        public async Task Delete(Guid id)
        {
            await _dbContext.Users.Where(x => x.Id == id).ExecuteDeleteAsync();
        }
    }
}
