using AppealManager.Presentation.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Components.Forms;
using NSubstitute;

namespace AppealManager.Presentation.Tests.ServicesTests
{
    public class TextFileReaderTests
    {
        [Theory]
        [InlineData("sample text")]
        [InlineData("Another text с русскими буквами")]
        [InlineData("Another text с русскими буквами и символами!?.,:;")]
        public async Task TextFileReader_Should_Read_Exact_Text(string text)
        {
            // ASSERT
            var file = Substitute.For<IBrowserFile>();
            file.ContentType.Returns("text/plain");

            var bytes = System.Text.Encoding.UTF8.GetBytes(text);
            var stream = new MemoryStream(bytes);

            file.OpenReadStream().Returns(stream);
            var textReader = new TextFileReader();

            // ACT
            var result = await textReader.ReadFileAsync(file);

            // ASSERT
            result.IsSome
                .Should()
                .BeTrue();

            result.First()
                .Should()
                .Be(text);
        }

        [Fact]
        public async Task When_File_Is_Not_Plai_Text_Reader_Should_Return_None()
        {
            // ASSERT
            var file = Substitute.For<IBrowserFile>();
            file.ContentType.Returns("pdf");
            var textReader = new TextFileReader();

            // ACT
            var result = await textReader.ReadFileAsync(file);

            // ASSERT
            result.IsNone
                .Should()
                .BeTrue();
        }
    }
}
