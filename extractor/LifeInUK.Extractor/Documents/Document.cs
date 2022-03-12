using System;
using MongoDB.Bson;

namespace LifeInUK.Extractor.Documents
{
    public class Document : IDocument
    {
        public ObjectId Id { get; set; }
        public DateTime CreatedAt => Id.CreationTime;
    }
}