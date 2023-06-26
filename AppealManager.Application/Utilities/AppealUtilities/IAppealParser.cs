namespace AppealManager.Application.Utilities.AppealUtilities
{
    public interface IAppealParser
    {
        /// <summary>
        /// Парсит строку в сущность Appeal
        /// </summary>
        /// <param name="text">строка</param>
        /// <returns>Возвращает обращение</returns>
        Core.Entities.Appeal Parse(string line);
    }
}
