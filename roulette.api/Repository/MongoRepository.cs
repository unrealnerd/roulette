using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using roulette.api.Repository;
using MongoDB.Bson;

namespace roulette.api.Repository
{

    public interface IIdentifable
    {
        string Id { get; }
    }

    public class MongoRepository<T> : IRepository<T> where T : class, IIdentifable
    {
        private readonly IDataContext<T> _context = null;

        public MongoRepository(IDataContext<T> context)
        {
            _context = context;
        }

        public async Task<List<T>> Get()
        {
            return await _context.Collection.Find<T>(input => true).ToListAsync<T>();
        }

        public async Task<T> Get(string id)
        {
            return await _context.Collection.Find<T>(input => input.Id == id).FirstOrDefaultAsync();
        }

        public async Task<T> Create(T input)
        {
            try
            {
                await _context.Collection.InsertOneAsync(input);
            }
            catch (System.Exception)
            {
                throw;
            }
            return input;
        }

        public async Task Update(string id, T input)
        {
            await _context.Collection.ReplaceOneAsync<T>(i => i.Id == id, input);
        }

        public async Task Remove(T input)
        {
            await _context.Collection.DeleteOneAsync(i => i.Id == input.Id);
        }

        public async Task Remove(string id)
        {
            await _context.Collection.DeleteOneAsync(i => i.Id == id);
        }

        public async Task<List<T>> Query(FilterDefinition<T> filter)
        {
            var findOptions = new FindOptions
            {
                Collation = new Collation("en", strength: CollationStrength.Primary)
            };

            return await _context.Collection.Find(filter, findOptions).ToListAsync();
        }

        public async Task<List<T>> Random(int N)
        {
            return await _context.Collection.Aggregate<T>(new BsonDocument[]
                {
                    new BsonDocument { { "$sample", new BsonDocument("size", N) } }
                }).ToListAsync();
        }
    }
}