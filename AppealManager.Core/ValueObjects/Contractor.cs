namespace AppealManager.Core.ValueObjects
{
    /// <summary>
    /// Исполнитель
    /// </summary>
    public record Contractor : Person
    {
        public Contractor(string name)
            : base(name) { }
    }
}
