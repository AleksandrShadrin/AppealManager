using AppealManager.Core.Entities;

namespace AppealManager.Application.Utilities.AppealUtilities
{
    public class AppealParser : IAppealParser
    {
        private readonly char _splitter = '\t';

        public Appeal Parse(string line)
        {
            var columns = line.Split(_splitter);
            var manager = NameUtilites.GetNameAbbreviature(columns[0]);

            var contractors = columns[1]
                .Split(';')
                .Select(x => x.Replace("(Отв.)", ""))
                .Select(x => x.Trim())
                .Select(NameUtilites.GetNameAbbreviature)
                .ToList();

            return Appeal.Build(manager, contractors);
        }
    }
}
