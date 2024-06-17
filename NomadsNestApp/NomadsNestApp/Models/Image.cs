using System;

namespace NomadsNestApp.Models
{
    public class Image
    {
        public int Id { get; set; }
        public int CampingSpotId { get; set; }
        public string Url { get; set; } = "";
        public int UploadedBy { get; set; }
        public DateTime UploadedAt { get; set; }

        // Relationships
        public CampingSpot CampingSpot { get; set; } = new CampingSpot(); // Many-to-one relationship with CampingSpot
        public User? UploadedByUser { get; set; } = new User(); // Many-to-one relationship with User

        public string FilePath { get; set; } = ""; // File path of the image
    }
}
