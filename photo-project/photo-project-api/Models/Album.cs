using System.Collections.Generic;

namespace photo_project_api.Models
{
    public class Album
    {
        public int Id { get; set; }
        public List<Photo> Photos { get; set; }
    }
}
