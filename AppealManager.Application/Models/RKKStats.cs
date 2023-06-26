namespace AppealManager.Application.Models
{
    public record struct RKKStats(
        string MainContractor, 
        int NumberOfRKK, 
        int NumOfAppeals)
    {
        public int SummaryDocuments { get => NumberOfRKK + NumOfAppeals; }
    }
}
