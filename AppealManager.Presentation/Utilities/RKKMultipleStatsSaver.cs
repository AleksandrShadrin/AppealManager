﻿using AppealManager.Application.Models;
using AppealManager.Presentation.Services;

namespace AppealManager.Presentation.Utilities
{
    /// <summary>
    /// Предоставляет различные способы сохранения RKKStats
    /// </summary>
    public class RKKMultipleStatsSaver
    {
        Func<DateTime> _clock;
        public GlobalStateService _globalService { get; set; }

        public RKKMultipleStatsSaver(Func<DateTime> clock, GlobalStateService globalService)
        {
            _clock = clock;
            _globalService = globalService;
        }
        /// <summary>
        /// Сохраняет коллекцию RKKStats в выбранном формате
        /// </summary>
        /// <param name="stats">коллекция RKKStats</param>
        /// <param name="saveOptions">Опция сохранения</param>
        /// <returns>Возвращает строку выбранного формата</returns>
        public string SaveStatsAs(IEnumerable<RKKStats> stats, SaveOptions saveOptions)
        {
            var saver = GetRKKSaver(saveOptions);
            return saver.SaveStats(stats);
        }

        private IRKKStatsSaver GetRKKSaver(SaveOptions saveOptions)
            => saveOptions switch
            {
                SaveOptions.HTML_TABLE => new RKKStatsSaverAsHtml(_clock, _globalService.ProgramLaunchedAt),
                SaveOptions.PLAIN_TEXT => new RKKStatsSaverAsPlainText(_clock, _globalService.ProgramLaunchedAt),
            };

        public enum SaveOptions
        {
            HTML_TABLE,
            PLAIN_TEXT
        }
    }
}
