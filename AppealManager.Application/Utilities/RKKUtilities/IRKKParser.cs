namespace AppealManager.Application.Utilities.RKKUtilities
{
    public interface IRKKParser
    {
        /// <summary>
        /// Парсит строку в сущность RKK
        /// </summary>
        /// <param name="line">строка</param>
        /// <returns>Возвращает RKK</returns>
        Core.Entities.RKK Parse(string line);
    }
}
