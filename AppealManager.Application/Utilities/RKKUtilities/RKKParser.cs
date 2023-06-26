using AppealManager.Application.Exceptions;
using AppealManager.Core.Entities;

namespace AppealManager.Application.Utilities.RKKUtilities
{
    public class RKKParser : IRKKParser
    {
        private readonly char _splitter = '\t';

        public RKK Parse(string line)
        {
            var columns = line.Split(new char[] { _splitter }, StringSplitOptions.RemoveEmptyEntries);

            if (columns.Length != 2)
                throw new ParseException(line);

            var manager = NameUtilites.GetNameAbbreviature(columns[0]);

            var contractors = columns[1]
                .Split(';')
                .Select(x => x.Replace("(Отв.)", ""))
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(NameUtilites.GetNameAbbreviature)
                .ToList();

            if (contractors.Count == 0)
                throw new EmptyContractorsException();

            return RKK.Build(manager, contractors);
        }
    }
}