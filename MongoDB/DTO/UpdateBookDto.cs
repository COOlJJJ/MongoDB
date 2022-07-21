using System;
using System.Text.Json.Serialization;

namespace MongoDB.DTO
{

    public class UpdateBookDto : CreateBookDto
    {
        public string Id { get; set; }

        [JsonIgnore]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
