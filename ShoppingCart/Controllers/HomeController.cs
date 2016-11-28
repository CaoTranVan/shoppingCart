using ShoppingCart;
using ShoppingCart.Interfaces;
using ShoppingCart.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository ProductRepository;
        ShoppingCartDb shoppingCartDb = new ShoppingCartDb();
        private IBrandRepository BrandRepository;
        public HomeController()
        {
            this.ProductRepository = new ProductRepository(shoppingCartDb);
        }

        public ActionResult Index()
        {
            //List<object> model = new List<object>();
            //model.Add(ProductRepository.GetProducts().ToList());
            //model.Add(BrandRepository.GetBrands().ToList());
            var products = ProductRepository.GetProducts().ToList();
            return View(products);
        }

        //private ActionResult View(List<product> products, List<brand> brands)
        //{
        //    throw new NotImplementedException();
        //}
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
        public ActionResult listBrand()
        {
            //List<object> model = new List<object>();
            //model.Add(ProductRepository.GetProducts().ToList());
            //model.Add(BrandRepository.GetBrands().ToList());
            var brands = BrandRepository.GetBrands().ToList();
            return View(brands);
        }


    }
}