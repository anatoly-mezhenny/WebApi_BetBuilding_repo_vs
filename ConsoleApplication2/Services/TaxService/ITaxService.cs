using System.Collections.Generic;
using ConsoleApplication2.Entities.Bet.Base;
using ConsoleApplication2.Entities.Bet.Base.Subentities;

namespace ConsoleApplication2.Services.TaxService
{
    /// <summary>
    /// Tax Service is common for all brands (but we provide ability to customize the work in future)
    /// </summary>
    public interface ITaxService
    {
        IEnumerable<BaseTaxInfo> GetBetsTaxes(int userId, IEnumerable<BaseUnifiedBet> bets);
    }
}