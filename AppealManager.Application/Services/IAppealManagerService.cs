using AppealManager.Core.Entities;

namespace AppealManager.Application.Services
{
    public interface IAppealManagerService
    {
        /// <summary>
        /// Возвращает все РКК из текста
        /// </summary>
        /// <param name="text">текст из которого извлекается информация</param>
        /// <returns>возвращает коллекцию РКК</returns>
        IEnumerable<RKK> GetRKKs(string text);
        /// <summary>
        /// Возвращает все обращения из текста
        /// </summary>
        /// <param name="text">текст из которого извлекается информация</param>
        /// <returns>возвращает коллекцию обращений</returns>
        IEnumerable<Appeal> GetAppeals(string text);
    }
}
