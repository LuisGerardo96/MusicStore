using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Login
{
    public class User
    {
        public int Id { get; set; }
        [StringLength (30)]
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }
        [StringLength(50)]
        [Required]
        [Display(Name = "Email")]
        public string UserId { get; set; }
        [StringLength(30)]
        [Required]
        public string Password { get; set; }

        public int RoleId { get; set; }
    }
}