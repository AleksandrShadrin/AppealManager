using AppealManager.Application.Services;
using AppealManager.Application.Utilities.AppealUtilities;
using AppealManager.Application.Utilities.RKKUtilities;
using AppealManager.Core.Entities;
using FluentAssertions;
using NSubstitute;

namespace AppealManager.Application.Tests.ServicesTests
{
    public class AppealManagerServiceTests
    {
        [Fact]
        public void Service_Should_Send_To_Reader_All_Lines_In_Text()
        {
            // ARRANGE
            var RKKReader = Substitute.For<IRKKReader>();
            var appealReader = Substitute.For<IAppealReader>();

            var service = new AppealManagerService(appealReader, RKKReader);

            RKKReader.ReadRKKs(Arg.Any<IEnumerable<string>>()).Returns(Enumerable.Empty<RKK>());
            appealReader.ReadAppeals(Arg.Any<IEnumerable<string>>()).Returns(Enumerable.Empty<Appeal>());

            var text = "1\r\n2\n3\n\r4";

            // ACT
            service.GetRKKs(text).ToList();
            service.GetAppeals(text).ToList();

            // ASSERT
            RKKReader
                .ReceivedCalls()
                .Should()
                .HaveCount(1);

            RKKReader
                .Received()
                .ReadRKKs
                    (Arg.Do<IEnumerable<string>>(
                        text => text
                        .Should()
                        .BeEquivalentTo(new List<string>() { "1", "2", "3", "4" }))
                    );

            appealReader
                .Received()
                .ReadAppeals
                    (Arg.Do<IEnumerable<string>>(
                        text => text
                        .Should()
                        .BeEquivalentTo(new List<string>() { "1", "2", "3", "4" }))
                    );
        }
    }
}
