using ShoppingCart.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class ASUSController : Controller
    {
        // GET: ASUS
        private IProductRepository ProductRepository;
        public ASUSController()
        {
            this.ProductRepository = new ProductRepository(new ShoppingCartDb());
        }

        public ActionResult Index()
        {
            //List<object> model = new List<object>();
            //model.Add( ProductRepository.GetProducts().ToList());
            var products = ProductRepository.GetProducts().ToList();
            return View(products);
        }
    }
}