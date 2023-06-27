using AppealManager.Application.Models;
using AppealManager.Presentation.Utilities;
using FluentAssertions;

namespace AppealManager.Presentation.Tests.UtilitiesTests
{
    public class HtmlSaverTests
    {
        [Fact]
        public void HtmlSaver_Should_Save_As_Html_Table_Empty_Collection()
        {
            // ARRANGE
            var empty = Enumerable.Empty<RKKStats>();
            var clock = () => new DateTime(2000, 2, 15);
            var saver = new RKKStatsSaverAsHtml(clock, clock());
            // ACT
            var res = saver.SaveStats(empty);
            // ASSERT
            res.Should()
                .Be($"<table>{tableHead}</table><h2>Отчет сохранен: 15.02.2000 0:00:00</h2>" +
                "<h2>Программа была запущена: 15.02.2000 0:00:00</h2>");
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
            var saver = new RKKStatsSaverAsHtml(clock, clock());
            // ACT
            var res = saver.SaveStats(empty);
            // ASSERT
            res.Should()
                .Be
                    (
                        $"<table>{tableHead}" +
                        "<tr><td>name</td><td>4</td><td>4</td><td>8</td></tr>" +
                        "<tr><td>name2</td><td>4</td><td>4</td><td>8</td></tr></table>" +
                        "<h2>Отчет сохранен: 15.02.2000 0:00:00</h2>" +
                        "<h2>Программа была запущена: 15.02.2000 0:00:00</h2>"
                    );
        }

        private const string tableHead = "<thead><tr><td>Главный исполнитель</td>" +
            "<td>Количество РКК</td><td>Количество обращений</td>" +
            "<td>Суммарное количество документов</td></tr></thead>";
    }
}
