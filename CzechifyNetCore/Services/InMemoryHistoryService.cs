using CzechifyNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CzechifyNetCore.Services
{
    public class InMemoryHistoryService : IHistoryService
    {
        public const uint MAX_HISTORY_SIZE = 5;
        private static readonly IList<RecentSearch> _history = new List<RecentSearch>();

        public void AddRequest(RecentSearch search)
        {
            _history.Add(search);
            if (_history.Count > MAX_HISTORY_SIZE)
            {
                _history.RemoveAt(0);
            }
        }

        public IEnumerable<RecentSearch> ListRecentRequests()
        {
            return _history.Reverse();
        }
    }
}
