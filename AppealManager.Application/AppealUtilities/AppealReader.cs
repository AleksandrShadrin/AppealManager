using AppealManager.Core.Entities;

namespace AppealManager.Application.AppealUtilities
{
    internal class AppealReader : IAppealReader
    {
        private readonly IAppealParser _parser;

        public AppealReader(IAppealParser parser)
        {
            _parser = parser;
        }

        public IEnumerable<Appeal> ReadAppeals(IEnumerable<string> text)
            => text.Select(_parser.Parse);
    }
}
