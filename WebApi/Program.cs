using System;
using ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Default;
using ConsoleApplication2.EntityConstruction.UnifiedBet.BetInfoProviders.Italy;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Factories.BetBuilderFactories.Default;
using ConsoleApplication2.EntityConstruction.UnifiedBet.Factories.BetBuilderFactories.Italy;
using ConsoleApplication2.Services.MultitenantUnifiedBetService.Default;
using ConsoleApplication2.Services.MultitenantUnifiedBetService.Italy;
using ConsoleApplication2.Services.MultiTenantCashOutService;
using ConsoleApplication2.Services.TaxService;
using ConsoleApplication2.Utilities.Mappers.Bet.Default;
using ConsoleApplication2.Utilities.Mappers.Bet.Italy;
using Newtonsoft.Json;
using Sport.Data.Repositories.BetRepository.Default;
using Sport.Data.Repositories.BetRepository.Italy;
using WebApi.Controllers;
using WebApi.Dto;
using WebApi.UserBetDtoBuilder.Base;
using WebApi.UserBetDtoBuilder.Base.FeatureSpecific;
using WebApi.UserBetDtoBuilder.Brands;

namespace WebApi
{
    public static class Program
    {
        public static void Main()
        {
            Console.BufferHeight = 5000;
            Console.SetWindowSize(Console.LargestWindowWidth / 2, Console.LargestWindowHeight - 5);

            var userId = 1; //whatever
            var betId = 1; //whatever
            string json;
            BetsController controller;

            Console.WriteLine("********************************************************");
            Console.WriteLine("***** UserBetDto TEST: ONGOING/ENDED/PRELIVE/LIVE*******");
            Console.WriteLine("********************************************************");
            //IoC setup:
            //<IBaseUserBetDtoBuilder, UserBetDtoBuilder>
            //<IMultitenantUnifiedBetService, MultitenantUnifiedBetService>
            //<IBetBuilderFactory, BetBuilderFactory>
            //<IBetRepository, BetRepository>
            //<IMultiTenantCashOutService, MultiTenantCashOutService>
            //<IBetMapper, BetMapper>
            //<IBetSelectionMapper, BetSelectionMapper>
            //<IUniversalTaxInfoProvider, UniversalTaxInfoProvider>
            //<ITaxService, TaxService>

            controller = new BetsController(
                    new Lazy<IBaseUserBetDtoBuilder>(() =>
                        new UserBetDtoBuilder.Brands.UserBetDtoBuilder(
                            new MultitenantUnifiedBetService(
                                new BetBuilderFactory(
                                    new BetRepository(),
                                    new MultiTenantCashOutService(),
                                    new BetMapper(),
                                    new BetSelectionMapper(),
                                    new UniversalTaxInfoProvider(new TaxService())
                                    )
                                )
                        )
                    ),
                    null
                );

            json = OngoingUserBetDtoTest(controller, userId, getLive: true, getPrelive: true);
            Console.WriteLine("\nONGOING bets:");
            Console.WriteLine(json);

            json = EndedUserBetDtoTest(controller, userId);
            Console.WriteLine("\nENDED bets:");
            Console.WriteLine(json);

            json = PreliveUserBetDtoTest(controller, userId, betId, getScoreboards: false);
            Console.WriteLine("\nPRELIVE bet:");
            Console.WriteLine(json);

            json = LiveUserBetDtoTest(controller, userId, betId, getScoreboards: false);
            Console.WriteLine("\nLIVE bet:");
            Console.WriteLine(json);



            Console.Write("\n\n\n");
            Console.WriteLine("**********************************************************************************");
            Console.WriteLine("***** ItUserBetDto TEST: ONGOING/ENDED/PRELIVE/LIVE/PENDING (Italy specific)******");
            Console.WriteLine("**********************************************************************************");
            //IoC setup:
            //<IBaseUserBetDtoBuilder, ItUserBetDtoBuilder>
            //<IItMultitenantUnifiedBetService, ItMultitenantUnifiedBetService>
            //<IItBetBuilderFactory, ItBetBuilderFactory>
            //<IItBetRepository, ItBetRepository>
            //<IMultiTenantCashOutService, MultiTenantCashOutService>
            //<IItBetMapper, ItBetMapper>
            //<IItBetSelectionMapper, ItBetSelectionMapper>
            //<IItUniversalTaxInfoProvider, ItUniversalTaxInfoProvider>
            //<ITaxService, TaxService>
            //<IItUniversalRegulatorInfoProvider, ItUniversalRegulatorInfoProvider>
            var itUserBetDtoBuilder = new ItUserBetDtoBuilder(
                new ItMultitenantUnifiedBetService(
                    new ItBetBuilderFactory(
                        new ItBetRepository(),
                        new MultiTenantCashOutService(),
                        new ItBetMapper(),
                        new ItBetSelectionMapper(),
                        new ItUniversalTaxInfoProvider(new TaxService()),
                        new ItUniversalRegulatorInfoProvider()
                        )
                    )
                );
            controller = new BetsController(
                    new Lazy<IBaseUserBetDtoBuilder>(() => itUserBetDtoBuilder),
                    new Lazy<IBasePendingUserBetDtoBuilder>(() => itUserBetDtoBuilder)
            );

            json = OngoingUserBetDtoTest(controller, userId, getLive: true, getPrelive: true);
            Console.WriteLine("\nONGOING bets:");
            Console.WriteLine(json);

            json = EndedUserBetDtoTest(controller, userId);
            Console.WriteLine("\nENDED bets:");
            Console.WriteLine(json);

            json = PreliveUserBetDtoTest(controller, userId, betId, getScoreboards: false);
            Console.WriteLine("\nPRELIVE bet:");
            Console.WriteLine(json);

            json = LiveUserBetDtoTest(controller, userId, betId, getScoreboards: false);
            Console.WriteLine("\nLIVE bet:");
            Console.WriteLine(json);

            json = UserPendingBetDtoTest(controller, userId);
            Console.WriteLine("\nPENDING bets (Italy specific):");
            Console.WriteLine(json);

            Console.ReadLine();
        }

        private static string OngoingUserBetDtoTest(BetsController betsController, int userId, bool getLive = true, bool getPrelive = true)
        {
            var userBetDtos = betsController.GetOngoingBets(userId, getLive, getPrelive);
            var json = JsonConvert.SerializeObject(userBetDtos, Formatting.Indented);
            return json;
        }

        private static string EndedUserBetDtoTest(BetsController betsController, int userId)
        {
            var userBetDtos = betsController.GetEndedBets(userId,
                    new EndedStakesFiltersDto
                    { StartIndex = 0, LastIndex = 1 });
            var json = JsonConvert.SerializeObject(userBetDtos, Formatting.Indented);
            return json;
        }

        private static string PreliveUserBetDtoTest(BetsController betsController, int userId, int betId, bool getScoreboards)
        {
            var userBetDtos = betsController.GetPreliveBet(userId, betId, getScoreboards);
            var json = JsonConvert.SerializeObject(userBetDtos, Formatting.Indented);
            return json;
        }

        private static string LiveUserBetDtoTest(BetsController betsController, int userId, int betId, bool getScoreboards)
        {
            var userBetDtos = betsController.GetLiveBet(userId, betId, getScoreboards);
            var json = JsonConvert.SerializeObject(userBetDtos, Formatting.Indented);
            return json;
        }

        private static string UserPendingBetDtoTest(BetsController betsController, int userId)
        {
            var userBetDtos = betsController.GetPendingBets(userId);
            var json = JsonConvert.SerializeObject(userBetDtos, Formatting.Indented);
            return json;
        }
    }
}
