using AppealManager.Application.Models;
using System.Text;

namespace AppealManager.Presentation.Utilities
{
    public class RKKStatsSaverAsHtml : IRKKStatsSaver
    {
        /// <summary>
        /// Сохраняет РКК статистики, как html таблицу
        /// </summary>
        public string SaveStats(IEnumerable<RKKStats> stats)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<table>");
            WriteTableHead(sb);
            foreach (RKKStats stat in stats)
            {
                sb.Append(@"<tr>");
                sb.Append(@$"<td>{stat.MainContractor}</td>");
                sb.Append(@$"<td>{stat.NumberOfRKK}</td>");
                sb.Append(@$"<td>{stat.NumOfAppeals}</td>");
                sb.Append(@$"<td>{stat.SummaryDocuments}</td>");
                sb.Append(@"</tr>");
            }
            sb.Append(@"</table>");
            return sb.ToString();
        }

        private static void WriteTableHead(StringBuilder sb)
        {
            sb.Append(@"<thead>");
            sb.Append(@"<tr>");
            sb.Append(@"<td>Главный исполнитель</td>");
            sb.Append(@"<td>Количество РКК</td>");
            sb.Append(@"<td>Количество обращений</td>");
            sb.Append(@"<td>Суммарное количество документов</td>");
            sb.Append(@"</tr>");
            sb.Append(@"</thead>");
        }
    }
}
