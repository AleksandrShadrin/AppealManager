namespace AppealManager.Application.Utilities.RKKUtilities
{
    public interface IRKKReader
    {
        /// <summary>
        /// Считывает все RKK из строк
        /// </summary>
        /// <param name="text">строки</param>
        /// <returns>Возвращает коллекцию RKK</returns>
        IEnumerable<Core.Entities.RKK> ReadRKKs(IEnumerable<string> text);
    }
}