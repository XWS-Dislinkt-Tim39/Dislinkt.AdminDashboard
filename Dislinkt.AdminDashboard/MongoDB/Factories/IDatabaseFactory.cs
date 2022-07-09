using MongoDB.Driver;

namespace Dislinkt.AdminDashboard.MongoDB.Factories
{
    public interface IDatabaseFactory
    {
        IMongoDatabase Create();
    }
}
