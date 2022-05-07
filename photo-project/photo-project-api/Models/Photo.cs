namespace photo_project_api.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}

/*
    "albumId": 3,
    "id": 102,
    "title": "eaque iste corporis tempora vero distinctio consequuntur nisi nesciunt",
    "url": "https://via.placeholder.com/600/a393af",
    "thumbnailUrl": "https://via.placeholder.com/150/a393af"
*/