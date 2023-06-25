namespace AppealManager.Application.AppealUtilities
{
    public interface IAppealParser
    {
        /// <summary>
        /// Парсит строку в сущность Appeal
        /// </summary>
        /// <param name="text">строка</param>
        /// <returns>Возвращает обращение</returns>
        AppealManager.Core.Entities.Appeal Parse(string line);
    }
}
