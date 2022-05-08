using System;
using System.Text;
using System.Text.Json.Serialization;

namespace photo_project_api.Models
{
    public class Photo
    {
        [JsonPropertyName("albumId")]
        public int AlbumId { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }


        // Leaving off the Album ID for to avoid displaying a redundant ID
        public string ToAlbumPhotoString()
        {
            var stringBuilder = new StringBuilder($"Photo Id: {Id}");
            stringBuilder.Append(Constants.Newline);
            stringBuilder.Append(Constants.Tab);
            stringBuilder.Append($"Title: {Title}");
            stringBuilder.Append(Constants.Newline);
            stringBuilder.Append(Constants.Tab);
            stringBuilder.Append($"Url: {Url}");
            stringBuilder.Append(Constants.Newline);
            stringBuilder.Append(Constants.Tab);
            stringBuilder.Append($"ThumbnailUrl: {ThumbnailUrl}");
            stringBuilder.Append(Constants.Newline);

            return stringBuilder.ToString();
        }

        // Normal ToString with everything
        public override string ToString()
        {
            var stringBuilder = new StringBuilder($"Album Id: {AlbumId}");
            stringBuilder.Append(Constants.Newline);
            stringBuilder.Append(ToAlbumPhotoString());

            return stringBuilder.ToString();
        }

    }
}
