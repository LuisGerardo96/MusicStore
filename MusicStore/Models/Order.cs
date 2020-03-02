using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MusicStore.Models
{
    [Bind(Exclude = "OrderId")]
    public partial class Order
    {
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }
        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }
        [ScaffoldColumn(false)]
        [StringLength(500)]
        public string Username { get; set; }
        [RegularExpression("^[a-zA-Z]+(?:[\\s.]+[a-zA-Z]+)*$",
            ErrorMessage= "Estas usando caracteres no permitidos")]
        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        [StringLength(160)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression("^[a-zA-Z]+(?:[\\s.]+[a-zA-Z]+)*$",
            ErrorMessage = "Estas usando caracteres no permitidos")]
        [DisplayName("Last Name")]
        [StringLength(160)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(70)]
        [RegularExpression("^[#.0-9a-zA-Z\\s,-]+$", ErrorMessage ="Caracter no permitido")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is required")]
        [StringLength(40)]
        [RegularExpression("^[a-zA-Z]+(?:[\\s.]+[a-zA-Z]+)*$", ErrorMessage = "Caracter no permitido")]
        public string City { get; set; }
        [RegularExpression("^[a-zA-Z]+(?:[\\s.]+[a-zA-Z]+)*$", ErrorMessage = "Caracter no permitido")]
        [Required(ErrorMessage = "State is required")]
        [StringLength(40)]
        public string State { get; set; }
        [RegularExpression("^\\d{5}-\\d{4}|\\d{5}|[A-Z]\\d[A-Z] \\d[A-Z]\\d$", ErrorMessage = "Caracter no permitido")]
        [Required(ErrorMessage = "Postal Code is required")]
        [DisplayName("Postal Code")]
        [StringLength(10)]
        public string PostalCode { get; set; }
        [RegularExpression("^[a-zA-Z]+(?:[\\s.]+[a-zA-Z]+)*$",
           ErrorMessage = "No usar caracteres especiales")]
        [Required(ErrorMessage = "Country is required")]
        [StringLength(40)]
        public string Country { get; set; }
        [RegularExpression("^(([0-9]{2}|0)[0-9]{8})$",
            ErrorMessage = "Estas usando caracteres no permitidos")]
        [Required(ErrorMessage = "Phone is required")]
        [StringLength(24)]
        public string Phone { get; set; }
        
        [Required(ErrorMessage = "Email Address is required")]
        [DisplayName("Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(255)]
        public string Email { get; set; }
        [ScaffoldColumn(false)]
        public decimal Total { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}