using AppealManager.Core.Entities;

namespace AppealManager.Application.Utilities.RKKUtilities
{
    public class RKKParser : IRKKParser
    {
        private readonly char _splitter = '\t';

        public RKK Parse(string line)
        {
            var columns = line.Split(_splitter);
            var manager = NameUtilites.GetNameAbbreviature(columns[0]);

            var contractors = columns[1]
                .Split(';')
                .Select(x => x.Replace("(Отв.)", ""))
                .Select(x => x.Trim())
                .Select(NameUtilites.GetNameAbbreviature)
                .ToList();

            return RKK.Build(manager, contractors);
        }
    }
}
