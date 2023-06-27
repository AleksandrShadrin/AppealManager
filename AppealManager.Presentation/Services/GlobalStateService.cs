namespace AppealManager.Presentation.Services
{
    public class GlobalStateService
    {
        public DateTime ProgramLaunchedAt { get; set; }

        public GlobalStateService(DateTime time)
        {
            ProgramLaunchedAt = time;
        }
    }
}
