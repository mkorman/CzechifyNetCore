using CzechifyNetCore.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace CzechifyNetCore.Services
{
    public class MongoDbHistoryService : IHistoryService
    {
        private DbConfiguration _config;
        private static MongoClient _client;

        public MongoDbHistoryService(DbConfiguration config)
        {
            _config = config;
            _client = new MongoClient(config.ConnectionString);
        }

        public void AddRequest(RecentSearch search)
        {
            var database = _client.GetDatabase("db");
            var collection = database.GetCollection<RecentSearch>("history");
            collection.InsertOne(search);
        }

        public IEnumerable<RecentSearch> ListRecentRequests()
        {
            var database = _client.GetDatabase("db");
            var collection = database.GetCollection<RecentSearch>("history");
            return collection
                .Find(FilterDefinition<RecentSearch>.Empty)
                .Sort("{Timestamp: -1}")
                .Limit(5)
                .ToEnumerable();
        }
    }
}
