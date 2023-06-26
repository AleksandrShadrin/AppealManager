using AppealManager.Application.Models;
using AppealManager.Application.Services;
using AppealManager.Core.Entities;
using FluentAssertions;

namespace AppealManager.Application.Tests.ServicesTests
{
    public class RKKStatisticsServiceTests
    {
        [Fact]
        public void Service_Should_Return_Empty_Statistics_For_Empty_Lists()
        {
            // ARRANGE
            var service = new RKKStatisticsService();

            // ACT
            var result = service.GetStats(new(), new());

            // ASSERT
            result.Should()
                .BeEmpty();
        }

        [Fact]
        public void Service_Should_Return_Right_Statistics_For_Single_Data()
        {
            // ARRANGE
            var service = new RKKStatisticsService();
            var data = new List<RKK>() { RKK.Build("name", new() { "name" }) };
            var shouldHave = new RKKStats("name", 1, 0);

            // ACT
            var result = service.GetStats(data, new());

            // ASSERT
            result.Should()
                .HaveCount(1)
                .And
                .Contain(shouldHave);
        }

        [Fact]
        public void Service_Should_Return_Right_Statistics_For_Multiple_Data()
        {
            // ARRANGE
            var service = new RKKStatisticsService();
            var RKKData = new List<RKK>() 
            {
                RKK.Build("name", new() { "name" }),
                RKK.Build("name2", new() { "name" }),
                RKK.Build("name3", new() { "name" }),
                RKK.Build("name", new() { "name" }),
                RKK.Build("name2", new() { "name" }),
                RKK.Build("name", new() { "name" }),
                RKK.Build("name3", new() { "name" }),
                RKK.Build("name", new() { "name" }),
            };
            var appealData = new List<Appeal>()
            {
                Appeal.Build("name", new() { "name" }),
                Appeal.Build("name2", new() { "name" }),
                Appeal.Build("name3", new() { "name" }),
                Appeal.Build("name", new() { "name" }),
                Appeal.Build("name2", new() { "name" }),
                Appeal.Build("name", new() { "name" }),
                Appeal.Build("name3", new() { "name" }),
                Appeal.Build("name", new() { "name" }),
            };

            // ACT
            var result = service.GetStats(RKKData, appealData);

            // ASSERT
            result.Should()
                .HaveCount(3)
                .And
                .Equal(
                    new RKKStats("name", 4, 4),
                    new RKKStats("name2", 2, 2),
                    new RKKStats("name3", 2, 2)
                );
        }
    }
}
