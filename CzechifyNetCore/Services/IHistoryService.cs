using CzechifyNetCore.Models;
using System.Collections.Generic;

namespace CzechifyNetCore.Services
{
    public interface IHistoryService
    {
        void AddRequest(RecentSearch search);
        IEnumerable<RecentSearch> ListRecentRequests();
    }
}
