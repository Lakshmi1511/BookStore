using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Cart
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal TotalAmount { get; set; }
        public int Count { set; get; }
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal GrandTotal { get; set; }
    }
}