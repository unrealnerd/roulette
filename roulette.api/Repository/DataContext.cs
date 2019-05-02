using Microsoft.Extensions.Options;
using MongoDB.Driver;
using roulette.api.Options;

namespace roulette.api.Repository
{
    public class DataContext<T> : IDataContext<T>
    {
        private readonly IMongoDatabase Database = null;
        private readonly IOptions<PhrasesOptions> Options;
        //TODO: remove dependency with phrases options
        public DataContext(IOptions<PhrasesOptions> options)
        {
            Options = options;
            var client = new MongoClient(options.Value.ConnectionString);
            if (client != null)
                Database = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<T> Collection => Database.GetCollection<T>(Options.Value.Collection);

    }
}