using System.Collections.Generic;
using ConsoleApplication2.Entities;

namespace ConsoleApplication2.Services.MultiTenantCashOutService
{
    public interface IMultiTenantCashOutService
    {
        IEnumerable<CashoutableBetLightInfo> GetCashoutableStakesLightInfoAsync(int userId);
    }

    public class MultiTenantCashOutService : IMultiTenantCashOutService
    {
        public IEnumerable<CashoutableBetLightInfo> GetCashoutableStakesLightInfoAsync(int userId)
        {
            return new List<CashoutableBetLightInfo>
            {
                 new CashoutableBetLightInfo
                 {
                     Id = 1,
                     MaxCashOutAmount = 100,
                     MinCashOutAmount = 10
                 }
            };
        }
    }
}
