using System;
using MongoDB.Bson;

namespace LifeInUK.Api.Documents
{
    public class Document : IDocument
    {
        public ObjectId Id { get; set; }
        public DateTime CreatedAt => Id.CreationTime;
    }
}