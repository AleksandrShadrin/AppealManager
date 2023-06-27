using AppealManager.Application.Models;
using AppealManager.Presentation.Utilities;
using FluentAssertions;

namespace AppealManager.Presentation.Tests.UtilitiesTests
{
    public class PlainTextSaverTests
    {
        [Fact]
        public void HtmlSaver_Should_Save_As_Plain_Text_Empty_Collection()
        {
            // ARRANGE
            var empty = Enumerable.Empty<RKKStats>();
            var clock = () => new DateTime(2000, 2, 15);
            var saver = new RKKStatsSaverAsPlainText(clock);
            var shouldBe = "Отчет сохранён: 15.02.2000 0:00:00\r\n"
                + "Главный исполнитель|Количество РКК|Количество обращений|Суммарное количество документов|";
            // ACT
            var res = saver.SaveStats(empty);
            // ASSERT
            res.Should()
                .Be(shouldBe);
        }

        [Fact]
        public void HtmlSaver_Should_Save_As_Html_Table_Not_Empty_Collection()
        {
            // ARRANGE
            var empty = new List<RKKStats>()
            {
                new RKKStats("name", 4, 4),
                new RKKStats("name2", 4, 4),
            };

            var clock = () => new DateTime(2000, 2, 15);
            var saver = new RKKStatsSaverAsPlainText(clock);
            var shouldBe = "Отчет сохранён: 15.02.2000 0:00:00\r\n"
                + "Главный исполнитель|Количество РКК|Количество обращений|Суммарное количество документов|\r\n" 
                + "               name|             4|                   4|                              8|\r\n"
                + "              name2|             4|                   4|                              8|";
            // ACT
            var res = saver.SaveStats(empty);
            // ASSERT
            res.Should()
                .Be(shouldBe);
        }
    }
}
