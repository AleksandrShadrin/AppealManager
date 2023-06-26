using AppealManager.Core.ValueObjects;

namespace AppealManager.Core.Entities
{
    /// <summary>
    /// РКК
    /// </summary>
    public class RKK
    {
        /// <summary>
        /// Руководитель
        /// </summary>
        public Manager Manager { get; private set; }
        /// <summary>
        /// Главный исполнитель
        /// </summary>
        public Contractor MainContractor { get; private set; }

        internal RKK(Manager manager, Contractor contractor)
        {
            Manager = manager;
            MainContractor = contractor;
        }

        public static RKK Build(string managerName, List<string> contractors)
        {
            var manager = new Manager(managerName);
            Contractor mainContractor;

            if (StringComparer.InvariantCulture.Compare(managerName, "Климов С.А.") == 0)
                mainContractor = new Contractor(contractors.First());
            else
                mainContractor = new Contractor(managerName);

            return new(manager, mainContractor);
        }
    }
}