using MongoDB.Bson;

namespace personalis_notitia_api.Models.Base;

public class BaseModel
{
    public ObjectId Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

}