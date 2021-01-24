using System;

namespace UrlShortener.Entities
{
    public class Url
    {
        public Guid Identifier { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortUrlPath { get; set; }
        public int NumberOfUses { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastUsed { get; set; }
    }
}