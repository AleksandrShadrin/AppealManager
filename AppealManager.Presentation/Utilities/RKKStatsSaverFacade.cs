using AppealManager.Application.Models;

namespace AppealManager.Presentation.Utilities
{
    public class RKKStatsSaverFacade
    {
        public string SaveStatsAs(IEnumerable<RKKStats> stats, SaveOptions saveOptions)
        {
            var saver = GetRKKSaver(saveOptions);
            return saver.SaveStats(stats);
        }

        public IRKKStatsSaver GetRKKSaver(SaveOptions saveOptions)
            => saveOptions switch
            {
                SaveOptions.HTML_TABLE => new RKKStatsSaverAsHtml(),
                SaveOptions.PLAIN_TEXT => new RKKStatsSaverAsPlainText(),
            };

        public enum SaveOptions
        {
            HTML_TABLE,
            PLAIN_TEXT
        }
    }
}
