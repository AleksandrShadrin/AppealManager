using AppealManager.Core.ValueObjects;

namespace AppealManager.Core.Entities
{
    /// <summary>
    /// Обращение
    /// </summary>
    public record Appeal
    {
        /// <summary>
        /// Руководитель
        /// </summary>
        public Manager Appealed { get; private set; }
        /// <summary>
        /// Главный исполнитель
        /// </summary>
        public Contractor MainContractor { get; private set; }

        internal Appeal(Manager appealed, Contractor contractor)
        {
            Appealed = appealed;
            MainContractor = contractor;
        }

        public static Appeal Build(string managerName, List<string> contractorsNames)
        {
            var manager = new Manager(managerName);
            Contractor mainContractor;

            if (StringComparer.InvariantCulture.Compare(managerName, "Климов С.А.") == 0)
                mainContractor = new Contractor(contractorsNames.First());
            else
                mainContractor = new Contractor(managerName);

            return new(manager, mainContractor);
        }
    }
}