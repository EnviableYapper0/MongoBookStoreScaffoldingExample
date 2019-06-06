using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Security.Authentication;

namespace MongoBookStore.Models
{
    public class MongoBookStoreContext
    {
        public MongoBookStoreContext(IConfiguration configuration)
        {
            // Connect to the Mongo database and obtain reference to Book collection
            MongoClientSettings settings = MongoClientSettings.FromUrl(
                new MongoUrl(configuration.GetConnectionString("MongoBookStoreContext"))
            );
            settings.SslSettings =
                new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);
            var database = mongoClient.GetDatabase("BookstoreDb");
            Book = database.GetCollection<Book>("Books");
        }

        // Readonly IMongoCollection, our equivalent to DbSet
        public IMongoCollection<Book> Book { get; }
    }
}
