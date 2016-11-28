using ShoppingCart.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace ShoppingCart.Controllers
{
    public class MyCartController : Controller
    {
        IProductRepository ProductRepository;
        ShoppingCartDb shoppingCartDb = new ShoppingCartDb();
        public MyCartController()
        {
            this.ProductRepository = new ProductRepository(shoppingCartDb);
        }

        // GET: MyCart
        public ActionResult Index()
        {
            var cart = new List<ItemProduct>();
            if (Session["cart"] != null)
            {
                cart = (List<ItemProduct>)Session["cart"];

            }
            return View(cart);
        }
        public ActionResult addToCart(int id)
        {
            if (Session["cart"] == null)
            {
                List<ItemProduct> cart = new List<ItemProduct>();
                cart.Add(new ItemProduct(ProductRepository.GetProductById(id), 1));
                Session["cart"] = cart;
            }
            else
            {
                List<ItemProduct> cart = (List<ItemProduct>)Session["cart"];
                int index = isExisting(id);
                if (index == -1)
                {
                    cart.Add(new ItemProduct(ProductRepository.GetProductById(id), 1));
                }
                else
                {
                    cart[index].Quantity++;
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Index");
        }

        private int isExisting(int id)
        {
            List<ItemProduct> cart = (List<ItemProduct>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Pr.id == id)
                    return i;
            }
            return -1;

        }
        public ActionResult Delete(int id)
        {
            int index = isExisting(id);
            List<ItemProduct> cart = (List<ItemProduct>)Session["cart"];
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

    }
}