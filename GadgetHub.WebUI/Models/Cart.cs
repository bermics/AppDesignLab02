using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GadgetHub.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public decimal TotalPrice => Price * Quantity;
    }

    public class Cart
    {
        private List<CartItem> items = new List<CartItem>();

        public IEnumerable<CartItem> Items => items;

        public void AddItem(int productId, string name, decimal price, int quantity = 1)
        {
            var existingItem = items.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem == null)
            {
                items.Add(new CartItem { ProductId = productId, Name = name, Price = price, Quantity = quantity });
            }
            else
            {
                existingItem.Quantity += quantity;
            }
        }

        public void RemoveItem(int productId)
        {
            var item = items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                items.Remove(item);
            }
        }

        public void Clear() => items.Clear();

        public decimal TotalCost => items.Sum(i => i.TotalPrice);

        public int TotalQuantity => items.Sum(i => i.Quantity);
    }

}
