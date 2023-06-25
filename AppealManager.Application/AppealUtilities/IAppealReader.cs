namespace AppealManager.Application.AppealUtilities
{
    public interface IAppealReader
    {
        /// <summary>
        /// Считывает все обращения из строк
        /// </summary>
        /// <param name="text">строки</param>
        /// <returns>Возвращает коллекцию обращений</returns>
        IEnumerable<AppealManager.Core.Entities.Appeal> ReadAppeals(IEnumerable<string> text);
    }
}