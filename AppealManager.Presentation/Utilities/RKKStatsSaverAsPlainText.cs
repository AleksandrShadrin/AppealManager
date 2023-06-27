using AppealManager.Application.Models;
using System.Text;

namespace AppealManager.Presentation.Utilities
{
    /// <summary>
    /// Сохраняет коллекцию RKKStats в виде обычного текста
    /// </summary>
    public class RKKStatsSaverAsPlainText : IRKKStatsSaver
    {
        /// <summary>
        /// Возвращает текущее время
        /// </summary>
        private Func<DateTime> _clock;
        private DateTime _programLaunchedTime;

        public RKKStatsSaverAsPlainText(Func<DateTime> clock, DateTime programLaunchedTime)
        {
            _clock = clock;
            _programLaunchedTime = programLaunchedTime;
        }

        /// <summary>
        /// Сохраняет РКК статистики, как обычный текст
        /// </summary>
        public string SaveStats(IEnumerable<RKKStats> stats)
        {
            var list = stats.ToList();

            var maxLengths = list
                .Fold
                    (
                        ("Главный исполнитель|".Length, 
                            "Количество РКК|".Length, 
                            "Количество обращений|".Length, 
                            "Суммарное количество документов|".Length),
                        (state, next) => (
                            Math.Max(next.MainContractor.Length, state.Item1),
                            Math.Max(next.NumberOfRKK.ToString().Length, state.Item2),
                            Math.Max(next.NumOfAppeals.ToString().Length, state.Item3),
                            Math.Max(next.SummaryDocuments.ToString().Length, state.Item4)
                            )
                    );

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Отчет сохранён: {_clock()}");
            sb.AppendLine($"Программа была запущена: {_programLaunchedTime}");
            sb.Append("Главный исполнитель|".PadLeft(maxLengths.Item1));
            sb.Append("Количество РКК|".PadLeft(maxLengths.Item2));
            sb.Append("Количество обращений|".PadLeft(maxLengths.Item3));
            sb.Append("Суммарное количество документов|".PadLeft(maxLengths.Item4));
            
            foreach (RKKStats stat in stats)
            {
                sb.AppendLine();
                sb.Append($"{stat.MainContractor}|".PadLeft(maxLengths.Item1));
                sb.Append($"{stat.NumberOfRKK}|".PadLeft(maxLengths.Item2));
                sb.Append($"{stat.NumOfAppeals}|".PadLeft(maxLengths.Item3));
                sb.Append($"{stat.SummaryDocuments}|".PadLeft(maxLengths.Item4));    
            }

            return sb.ToString();
        }
    }
}
