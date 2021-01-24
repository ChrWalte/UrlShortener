using System;
using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Models
{
    public class UrlModel
    {
        public Guid Identifier { get; set; }

        [Required(ErrorMessage = "OriginalUrl can not be null")]
        public string OriginalUrl { get; set; }

        public string ShortUrlPath { get; set; }
    }
}