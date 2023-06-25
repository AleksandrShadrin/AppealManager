using AppealManager.Core.ValueObjects;

namespace AppealManager.Core.Entities
{
    /// <summary>
    /// Обращение
    /// </summary>
    /// <param name="Appealed">Руководитель</param>
    /// <param name="Contractors">Исполнители</param>
    public record Appeal(Manager Appealed, List<Contractor> Contractors);
}