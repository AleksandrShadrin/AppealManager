namespace AppealManager.Core.ValueObjects
{
    /// <summary>
    /// Руководитель
    /// </summary>
    public record Manager : Person
    {
        public Manager(string name)
            : base(name) { }
    }
}
