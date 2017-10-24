using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication2.Entities.Bet.Base;
using ConsoleApplication2.Entities.Bet.Base.Subentities;
using ConsoleApplication2.Entities.Bet.Default.Subentities;

namespace ConsoleApplication2.Services.TaxService
{
    /// <summary>
    /// Tax Service is common for all brands (but we provide ability to customize the work in future)
    /// </summary>
    public class TaxService : ITaxService
    {
        public IEnumerable<BaseTaxInfo> GetBetsTaxes(int userId, IEnumerable<BaseUnifiedBet> bets)
        {
            //FAKE
            var betsTaxes = bets.Select(b => new TaxInfo
            {
                IsActive = b.Id % 2 == 1,
                BetId = b.Id,
                IsTaxFree = true,
                MinimumOdds = 1.5,
                MinimumSelections = 3,
                OnlineDate = new DateTime(2033, 1, 1),
                TaxInfos = new Dictionary<double, double> {{2, 2}, {3, 3}}
            }).ToList();

            return betsTaxes;
        }
    }
}
