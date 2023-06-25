namespace AppealManager.Application.RKKUtilities
{
    public interface IRKKReader
    {
        /// <summary>
        /// Считывает все RKK из строк
        /// </summary>
        /// <param name="text">строки</param>
        /// <returns>Возвращает коллекцию RKK</returns>
        IEnumerable<AppealManager.Core.Entities.RKK> ReadRKKs(IEnumerable<string> text);
    }
}