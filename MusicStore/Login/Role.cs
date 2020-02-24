using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.Login
{
    public class Role
    {
        public int Id { get; set; }
        [StringLength (40) ]
        public string Name { get; set; }
    }
}