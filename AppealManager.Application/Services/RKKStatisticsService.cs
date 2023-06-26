using AppealManager.Application.Models;
using AppealManager.Core.Entities;

namespace AppealManager.Application.Services
{
    public class RKKStatisticsService
    {
        /// <summary>
        /// Возвращает статистику по РКК и обращениям
        /// </summary>
        /// <param name="RKKs">РКК</param>
        /// <param name="appeals">Обращения</param>
        /// <returns>Возвращает список с статистикой по каждому главному исполнителю</returns>
        public List<RKKStats> GetStats(List<RKK> RKKs, List<Appeal> appeals)
        {
            Dictionary<string, int> RKKStats = GetRKKCountWithNames(RKKs);
            Dictionary<string, int> appealStats = GetAppealsCountWithNames(appeals);

            return appealStats
                .Keys.Union(RKKStats.Keys, StringComparer.InvariantCulture)
                .Select
                    (
                        name =>
                        {
                            var appealsCount = 0;
                            var RKKCount = 0;
                            
                            if (RKKStats.ContainsKey(name))
                                RKKCount = RKKStats[name];
                            if (appealStats.ContainsKey(name))
                                appealsCount = appealStats[name];

                            return new RKKStats(name, RKKCount, appealsCount);
                        }
                    ).ToList();
        }
        /// <summary>
        /// Группирует имена главных исполнителей с количеством обращений
        /// </summary>
        /// <param name="appeals">обращения</param>
        /// <returns>Возвращает словарь key - string: имя главного исполнителя, int - value: количество обращений</returns>
        private static Dictionary<string, int> GetAppealsCountWithNames(List<Appeal> appeals)
            => appeals
                .Select(appeal => appeal.MainContractor)
                .GroupBy(contractor => contractor.Name, StringComparer.InvariantCulture)
                .ToDictionary
                    (
                        g => g.Key,
                        g => g.Count(),
                        StringComparer.InvariantCulture
                    );
        /// <summary>
        /// Группирует имена главных исполнителей с количеством РКК
        /// </summary>
        /// <param name="RKKs">РКК</param>
        /// <returns>Возвращает словарь key - string: имя главного исполнителя, int - value: количество РКК</returns>
        private static Dictionary<string, int> GetRKKCountWithNames(List<RKK> RKKs)
            => RKKs
                .Select(rkk => rkk.MainContractor)
                .GroupBy(contractor => contractor.Name, StringComparer.InvariantCulture)
                .ToDictionary
                    (
                        g => g.Key,
                        g => g.Count(),
                        StringComparer.InvariantCulture
                    );
    }
}
