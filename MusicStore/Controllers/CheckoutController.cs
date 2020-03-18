using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Filtros;
using MusicStore.Models;

namespace MvcMusicStore.Controllers
{
    [HandleError]
    [CustomAuthenticationFilter]
    [CustomAuthorize("Normal", "Admin")]
    public class CheckoutController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        
        // GET: /Checkout/AddressAndPayment
        public ActionResult AddressAndPayment()
        {
            return View();
        }
        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                {
                    order.Username = Convert.ToString(HttpContext.Session["UserName"]);
                    order.OrderDate = DateTime.Now;
                    var total = ShoppingCart.GetCart(this.HttpContext);
                    order.Total = total.GetTotal();

                    //Save Order
                    storeDB.Orders.Add(order);
                    storeDB.SaveChanges();
                    //Process the order
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);

                    return RedirectToAction("Complete", new { id = order.OrderId });
                }
            }
            catch 
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }
        //
        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {

            var username= Convert.ToString(HttpContext.Session["UserName"]);
            // Validate customer owns this order
            bool isValid = storeDB.Orders.Any(o => o.OrderId == id && o.Username == username);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}