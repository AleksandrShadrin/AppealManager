using AppealManager.Application.Utilities.RKKUtilities;
using AppealManager.Core.Entities;
using FluentAssertions;
using NSubstitute;

namespace AppealManager.Application.Tests.UtilitiesTests
{
    public class RKKReaderTests
    {
        [Fact]
        public void RKKReader_Should_Call_Parser_Same_Times_As_Lines()
        {
            // ARRANGE
            var linesCount = Enumerable.Range(1, 100);
            var data = linesCount
                .Select(n => new string('\n', n));
            var parser = Substitute.For<IRKKParser>();
            var returnValue = RKK.Build("Клим А.А.", new() { "Анатолевич В.В." });
            parser.Parse(Arg.Any<string>()).Returns(returnValue);
            var reader = new RKKReader(parser);

            foreach (var text in data)
            {
                // ACT
                reader.ReadRKKs(text.Split("\n")).ToList();

                // ASSERT
                parser
                    .ReceivedCalls()
                    .Count()
                    .Should()
                    .Be(text.Split("\n").Length);

                parser.ClearReceivedCalls();
            }
        }

        [Fact]
        public void RKKReader_Should_Work_With_RKKParser()
        {
            // ARRANGE
            var text = new List<string>() 
            { 
                "Сергеев А.А.\tАнатольевич В.В.",
                "Климов С.А.\tАнатольевич В.В.",
                "Климов А.А.\tАнатольевич В.В.",
                "Климов А.С.\tСергеев К.В."
            };

            var shouldBe = new List<RKK>()
            {
                RKK.Build("Сергеев А.А.", new() { "Анатольевич В.В." } ),
                RKK.Build("Климов С.А.", new() { "Анатольевич В.В." } ),
                RKK.Build("Климов А.А.", new() { "Анатольевич В.В." } ),
                RKK.Build("Климов А.С.", new() { "Сергеев К.В." } ),
            };

            var parser = new RKKParser();
            var reader = new RKKReader(parser);

            // ACT
            var result = reader.ReadRKKs(text).ToList();

            // ASSERT
            result
                .Should()
                .BeEquivalentTo(shouldBe);
        }
    }
}
