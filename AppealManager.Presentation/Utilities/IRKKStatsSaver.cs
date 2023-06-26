using AppealManager.Application.Models;

namespace AppealManager.Presentation.Utilities
{
    public interface IRKKStatsSaver
    {
        /// <summary>
        /// Возвращает представление статистики РКК в виде текста
        /// </summary>
        /// <param name="stats">Коллекция РКК статистик</param>
        /// <returns>возвращает строку</returns>
        string SaveStats(IEnumerable<RKKStats> stats);
    }
}