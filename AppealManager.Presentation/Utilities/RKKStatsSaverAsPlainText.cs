using AppealManager.Application.Models;
using System.Text;

namespace AppealManager.Presentation.Utilities
{
    public class RKKStatsSaverAsPlainText : IRKKStatsSaver
    {
        public string SaveStats(IEnumerable<RKKStats> stats)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Главный исполнитель\tКоличество РКК\tКоличество обращений\tСуммарное количество документов");

            foreach (RKKStats stat in stats)
                sb.AppendLine($"{stat.MainContractor}\t{stat.NumberOfRKK}\t{stat.NumOfAppeals}\t{stat.SummaryDocuments}");

            return sb.ToString();
        }
    }
}
