using MongoDB.Bson.Serialization.Attributes;

namespace GuardedGoods_Milestone4.Model
{
    [BsonIgnoreExtraElements]
    public class Ratings
    {
        [BsonElement("ratings_ID")]
        public string RatingsId { get; set; } = string.Empty;

        [BsonElement("ratingsUID")]
        public string RatingsUserId { get; set; } = string.Empty;

        [BsonElement("ratingsSID")]
        public string RatingsSellerId { get; set; } = string.Empty;

        [BsonElement("comments")]
        public string Comments { get; set; } = string.Empty;

        [BsonElement("timestamps")]
        public DateTime Timestamps { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; }

        [BsonElement("scale")]
        public int Scale { get; set; }
    }
}
