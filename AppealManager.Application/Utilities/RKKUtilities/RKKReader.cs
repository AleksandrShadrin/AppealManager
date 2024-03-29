﻿using AppealManager.Core.Entities;

namespace AppealManager.Application.Utilities.RKKUtilities
{
    public class RKKReader : IRKKReader
    {
        private readonly IRKKParser _parser;

        public RKKReader(IRKKParser parser)
        {
            _parser = parser;
        }

        public IEnumerable<RKK> ReadRKKs(IEnumerable<string> text)
            => text.Select(_parser.Parse);
    }
}
