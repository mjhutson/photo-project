using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace photo_project_api.Models
{
    public class Album
    {
        public int Id { get; set; }
        public List<Photo> Photos { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder($"Album Id: {Id}");
            if (Photos.Any())
            { 
                stringBuilder.Append(" {");
                stringBuilder.Append(Constants.Newline);
                foreach (var photo in Photos)
                {
                    stringBuilder.Append(photo.ToAlbumPhotoString());
                }

                stringBuilder.Append("}");
                return stringBuilder.ToString();
            }

            stringBuilder.Append(Constants.Newline);
            stringBuilder.Append(Constants.EmptyAlbum);

            return stringBuilder.ToString();
        }
    }
}
