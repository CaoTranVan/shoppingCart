using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Controllers
{
    public class ItemProduct
    {
        private product pr = new product();
        private int quantity;

        public ItemProduct()
        {

        }

        public ItemProduct(product pr)
        {
            this.pr = pr;
        }

        public ItemProduct(product pr, int quantity)
        {
            this.pr = pr;
            this.Quantity = quantity;
        }

        public product Pr
        {
            get
            {
                return pr;
            }

            set
            {
                pr = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }
    }
}