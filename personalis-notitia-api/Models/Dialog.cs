using MongoDB.Bson;
using personalis_notitia_api.Models.Base;

namespace personalis_notitia_api.Models;

public class Dialog : BaseModel
{
    public string? Message { get; set; }
}