using Sport.Data.Models.Default;
using Sport.Data.Repositories.BetRepository.Base;

namespace Sport.Data.Repositories.BetRepository.Default
{
    public interface IBetRepository : IBaseBetRepository<BetMainInfo>
    {
    }
}