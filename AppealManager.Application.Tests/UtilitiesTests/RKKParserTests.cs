using AppealManager.Application.Exceptions;
using AppealManager.Application.Utilities.RKKUtilities;
using FluentAssertions;

namespace AppealManager.Application.Tests.UtilitiesTests
{
    public class RKKParserTests
    {
        [Fact]
        public void When_Line_Is_Empty_Should_Throw_ParseException()
        {
            // ARRANGE
            var parser = new RKKParser();
            var emptyLine = string.Empty;

            // ACT
            var action = () => parser.Parse(emptyLine);

            // ASSERT
            action
                .Should()
                .Throw<ParseException>();
        }

        [Fact]
        public void When_Line_Have_Single_Tab_Should_Throw_ParseException()
        {
            // ARRANGE
            var parser = new RKKParser();
            var singleTab = "\t";

            // ACT
            var action = () => parser.Parse(singleTab);

            // ASSERT
            action
                .Should()
                .Throw<ParseException>();
        }

        [Fact]
        public void When_Line_Have_Empty_Right_Part_Should_Throw_EmptyContractorsException()
        {
            // ARRANGE
            var parser = new RKKParser();
            var singleTab = "Васильевич Олег Иванович\t;";

            // ACT
            var action = () => parser.Parse(singleTab);

            // ASSERT
            action
                .Should()
                .Throw<EmptyContractorsException>();
        }

        [Fact]
        public void Parser_Should_Return_Correct_RKK_For_Klimov()
        {
            // ARRANGE
            var parser = new RKKParser();
            var singleTab = "Климов Сергей Александрович\tВасильев Олег Андреевич";

            // ACT
            var RKK = parser.Parse(singleTab);

            // ASSERT
            RKK.MainContractor
                .Name
                .Should()
                .Be("Васильев О.А.");

            RKK.Manager
                .Name
                .Should()
                .Be("Климов С.А.");
        }

        [Fact]
        public void Parser_Should_Return_Correct_RKK_For_Not_Klimov()
        {
            // ARRANGE
            var parser = new RKKParser();
            var singleTab = "Неклимов Сергей Александрович\tВасильев Олег Андреевич";

            // ACT
            var RKK = parser.Parse(singleTab);

            // ASSERT
            RKK.MainContractor
                .Name
                .Should()
                .Be("Неклимов С.А.");

            RKK.Manager
                .Name
                .Should()
                .Be("Неклимов С.А.");
        }
    }
}