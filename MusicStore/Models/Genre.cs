using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    //investigar partial class
    public partial class Genre
    {
        public int GenreId { get; set; }
        [Required(ErrorMessage = "Information necesary")]
        [StringLength(160, ErrorMessage = "Only use 160 characters")]
        public string Name { get; set; }
        [StringLength(160, ErrorMessage = "Only use 160 characters")]
        public string Description { get; set; }
        public List<Album> Albums { get; set; }
    }
}