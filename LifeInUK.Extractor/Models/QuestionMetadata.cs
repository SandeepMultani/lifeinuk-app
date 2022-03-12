using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LifeInUK.Extractor.Models
{
    public class QuestionMetadata
    {
        public string Type { get; set; }
        public int Id { get; set; }
        public int CatId { get; set; }
        public int Points { get; set; }
        public List<int> Correct { get; set; }
    }
}