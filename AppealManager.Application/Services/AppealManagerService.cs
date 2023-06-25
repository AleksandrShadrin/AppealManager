using AppealManager.Application.AppealUtilities;
using AppealManager.Application.RKKUtilities;
using AppealManager.Core.Entities;

namespace AppealManager.Application.Services
{
    public class AppealManagerService : IAppealManagerService
    {
        private readonly IAppealReader _appealReader;
        private readonly IRKKReader _RKKReader;

        public AppealManagerService(IAppealReader appealReader, IRKKReader rKKReader)
        {
            _appealReader = appealReader;
            _RKKReader = rKKReader;
        }

        public IEnumerable<Appeal> GetAppeals(string text)
            => _appealReader
                .ReadAppeals(GetLines(text));

        public IEnumerable<RKK> GetRKKs(string text)
            => _RKKReader
                .ReadRKKs(GetLines(text));

        private string[] GetLines(string text)
            => text.Split(new char[] { '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries);
    }
}
