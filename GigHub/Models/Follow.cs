using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Models
{
    public class Follow
    {
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Key]
        [Column(Order = 2)]
        public string ArtistId { get; set; }
        public ApplicationUser Artist { get; set; }
    }
}