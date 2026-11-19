using GuardedGoods_Milestone4.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GuardedGoods_Milestone4.Services;

public sealed class MongoDBServices
{
    private readonly IMongoCollection<Ratings> _ratings;

    public MongoDBServices(IOptions<MongoDBSettings> options)
    {
        var settings = options.Value;

        if (string.IsNullOrWhiteSpace(settings.ConnectionString))
        {
            throw new InvalidOperationException("MongoDB:ConnectionString is not configured.");
        }

        if (string.IsNullOrWhiteSpace(settings.DatabaseName))
        {
            throw new InvalidOperationException("MongoDB:DatabaseName is not configured.");
        }

        if (string.IsNullOrWhiteSpace(settings.CollectionName))
        {
            throw new InvalidOperationException("MongoDB:CollectionName is not configured.");
        }

        var client = new MongoClient(settings.ConnectionString);
        _ratings = client
            .GetDatabase(settings.DatabaseName)
            .GetCollection<Ratings>(settings.CollectionName);
    }

    public Task<List<Ratings>> GetRatingsAsync(CancellationToken cancellationToken = default)
    {
        return _ratings
            .Find(Builders<Ratings>.Filter.Empty)
            .ToListAsync(cancellationToken);
    }

    public Task<Ratings?> GetRatingByIdAsync(string ratingsId, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(ratingsId);

        return _ratings
            .Find(rating => rating.RatingsId == ratingsId)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
