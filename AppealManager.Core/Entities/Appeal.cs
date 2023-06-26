using AppealManager.Core.ValueObjects;

namespace AppealManager.Core.Entities
{
    /// <summary>
    /// Обращение
    /// </summary>
    /// <param name="Appealed">Руководитель</param>
    /// <param name="MainContractor">главный исполнитель</param>
    public record Appeal
    {
        public Manager Appealed { get; private set; }
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