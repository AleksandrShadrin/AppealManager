namespace AppealManager.Application.RKKUtilities
{
    public interface IRKKParser
    {
        /// <summary>
        /// Парсит строку в сущность RKK
        /// </summary>
        /// <param name="text">строка</param>
        /// <returns>Возвращает RKK</returns>
        AppealManager.Core.Entities.RKK Parse(string text);
    }
}
