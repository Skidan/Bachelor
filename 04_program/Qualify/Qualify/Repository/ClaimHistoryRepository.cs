using Microsoft.EntityFrameworkCore;
using Qualify.Models;
using Qualify.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualify.Repository
{
    public class ClaimHistoryRepository
    {
        private readonly QualifyContext _context = null;
        public ClaimHistoryRepository(QualifyContext context)
        {
            _context = context;
        }

        public async Task<int> AddHistory(ClaimHistory claimHistory, int claimId) 
        {
            var newHistory = new ClaimHistory()
            {
                ClaimID = claimId,
                Description = claimHistory.Description,
                EmployeeID = claimHistory.EmployeeID,
                DateStart = DateTime.UtcNow
            };
            await _context.ClaimHistories.AddAsync(newHistory);
            await _context.SaveChangesAsync();
            return newHistory.ID;
        }

        public async Task<List<ClaimHistory>> GetHistoriesByClaimId(int id)
        {
            var histories = new List<ClaimHistory>();
            var allHistories = await _context.ClaimHistories.ToListAsync();
            if (allHistories?.Any() == true)
            {
                foreach (var history in allHistories)
                {
                    if (history.ClaimID == id) 
                    {
                        histories.Add(new ClaimHistory()
                        {
                            ID = history.ID,
                            ClaimID = history.ClaimID,
                            Description = history.Description,
                            EmployeeID = history.EmployeeID,
                            Performed = history.Performed,
                            Done = history.Done,
                            DateStart = history.DateStart,
                            DateEnd = history.DateEnd
                        });
                    }                    
                }
            }
            return histories;
        }

    }
}
