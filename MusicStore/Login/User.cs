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
        //[RegularExpression("(([^<>()\\[\\]\\.,;:\\s@\"]+(\\.[^<>()\\[\\]\\.,;:\\s@\"]+)*)|(\".+\"))@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))$")]
        [Required]
        [Display(Name = "Email")]
        public string UserId { get; set; }
        [StringLength(100)]
        //[RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,10}$",
          //  ErrorMessage = "La contraseña debe tener 8-10 carac, al menos una letra mayúscula, una letra minúscula, un número y un carácter especial")]
        [Required(ErrorMessage="Dato necesario")]
        public string Password { get; set; }

        public int RoleId { get; set; }
    }
}