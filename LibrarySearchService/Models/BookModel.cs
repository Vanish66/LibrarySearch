using System.Text.Json.Serialization;

namespace LibrarySearchService.Models
{
    public class BookModel
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("relevance")]
        public double Relevance { get; set; }

        [JsonPropertyName("points")]
        public double Points { get; set; }

        [JsonPropertyName("authors")]
        public string[] Authors { get; set; }

        [JsonPropertyName("isbn")]
        public string Isbn { get; set; }

        [JsonPropertyName("pageCount")]
        public int PageCount { get; set; }
    }
}
