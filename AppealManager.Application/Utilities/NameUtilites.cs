namespace AppealManager.Application.Utilities
{
    internal static class NameUtilites
    {
        /// <summary>
        /// Возвращает аббревиатуру полного имени
        /// </summary>
        /// <param name="name">имя</param>
        /// <returns>Возвращает аббревиатуру, как строку</returns>
        public static string GetNameAbbreviature(string name)
        {
            var nameParts = name.Trim().Split(" ");

            if (nameParts.Length != 3 )
                return name;

            nameParts[1] = nameParts[1][0] + ".";
            nameParts[2] = nameParts[2][0] + ".";
            
            return nameParts[0] + ' ' + nameParts[1] + nameParts[2];
        }
    }
}
