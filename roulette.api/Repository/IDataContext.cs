using MongoDB.Driver;

namespace roulette.api.Repository
{
    public interface IDataContext<T>
    {
        IMongoCollection<T> Collection { get; } 
    }
}