using ShoppingCart.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class SearchController : Controller
    {
        private IProductRepository ProductRepository;
        ShoppingCartDb shoppingCartDb = new ShoppingCartDb();
        public SearchController()
        {
            this.ProductRepository = new ProductRepository(shoppingCartDb);
        }
        // GET: Search
        public ActionResult Index(string key)
        {
            key = Request.Form["searchName"];
            if (key == null)
            {
                return Redirect(Request.UrlReferrer.ToString());
            }else
            {
                var products = ProductRepository.GetProducts().Where(x => x.NAME.ToLower().Contains(key.ToLower()) || x.brand.name.ToLower().Contains(key.ToLower())).ToList();
                return View(products);
            }
        }
    }
}
