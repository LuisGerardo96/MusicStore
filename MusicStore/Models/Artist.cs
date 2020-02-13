using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        [Required(ErrorMessage = "Information necesary")]
        [StringLength(160, ErrorMessage = "Only use 160 characters")]
        public string Name { get; set; }
    }
}