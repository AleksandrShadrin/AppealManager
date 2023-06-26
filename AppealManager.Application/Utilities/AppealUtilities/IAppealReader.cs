namespace AppealManager.Application.Utilities.AppealUtilities
{
    public interface IAppealReader
    {
        /// <summary>
        /// Считывает все обращения из строк
        /// </summary>
        /// <param name="text">строки</param>
        /// <returns>Возвращает коллекцию обращений</returns>
        IEnumerable<Core.Entities.Appeal> ReadAppeals(IEnumerable<string> text);
    }
}