using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStore.Controllers
{
    public class BookstoreApiController : ApiController
    {
        static List<Book> booklist = new List<Book>
            {
                new Book { Id=1, Title = "Mastering åäö", Author = "Average Swede", Price = 762, InStock = 15 },
                new Book { Id=2,Title = "How To Spend Money", Author = "Rich Block", Price = 1000000, InStock = 1 },
                new Book {Id=3, Title = "Generic Title", Author = "First Author", Price = 185.5M, InStock = 5 },
                new Book { Id=4,Title = "Generic Title", Author = "Second Author", Price = 1748M, InStock = 3 },
                new Book { Id=5,Title = "Random Sales", Author = "Cunning Bastard", Price = 999, InStock = 20 },
                new Book { Id=6,Title = "Random Sales", Author = "Cunning Bastard", Price = 499.5M, InStock = 3 },
                new Book { Id=7,Title = "Desired", Author = "Rich Bloke", Price = 564.5M, InStock = 0 }
            };
        static List<Cart> pNewCart = new List<Cart>();
        
    
        [HttpGet]
        public IEnumerable<Book> Get()     //Displays the Book details
        {
            return booklist;
        }



        [HttpGet]
        public List<Book> AddCart(int id)       //Adding Books to the Cart
        {

            Book result = booklist.First(s => s.Id == id);

            if (result.InStock > 0)
            {


                if (pNewCart != null && pNewCart.Count > 0)
                {
                    Cart cartData = pNewCart.FirstOrDefault(s => s.Id == id);
                    if (cartData != null)
                    {
                        
                        cartData.Count = cartData.Count + 1;
                        cartData.TotalAmount = cartData.Count * result.Price;
                       


                    }
                    else
                    {
                        Cart cc = new Cart();
                        
                        cc.TotalAmount = result.Price;
                        cc.Author = result.Author;
                        cc.Title = result.Title;
                        cc.Price = result.Price;
                        cc.Id = result.Id;
                        cc.Count = 1;
                        pNewCart.Add(cc);
                    }

                }

                else
                {
                    Cart cc = new Cart();

                   
                    cc.TotalAmount = result.Price;
                    cc.Author = result.Author;
                    cc.Title = result.Title;
                    cc.Price = result.Price;
                    cc.Id = result.Id;
                    cc.Count = 1;
                    pNewCart.Add(cc);
                }
                result.InStock = result.InStock - 1;
            }

            return booklist;

        }




        [HttpGet]
        public List<Cart> RemoveFromCart(int id)         //Delete books using Id
        {
            Book result = booklist.First(s => s.Id == id);
            Cart cartData = pNewCart.First(s => s.Id == id);
            cartData.Count = cartData.Count - 1;
            cartData.TotalAmount = cartData.TotalAmount - result.Price;
            
            
            
            if (cartData.Count == 0)
            {
                pNewCart.RemoveAll(x => x.Id == id);

            }
            result.InStock = result.InStock + 1;
            return pNewCart;
        }


        [HttpGet]
        public IEnumerable<Cart> GetCart()   //Display the Cart details 
        {
            return pNewCart;
        }

        [HttpGet]
        public IEnumerable<Cart> GetCheckout()   //Display the Checkout details
        {
            return pNewCart;
        }

    }

}


    

