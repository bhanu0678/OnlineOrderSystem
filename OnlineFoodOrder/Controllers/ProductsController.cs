//using AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrder.DataAccess;
using OnlineFoodOrder.Models;
using System;

namespace OnlineFoodOrder.Controllers
{
    public class ProductsController : Controller
    {
        private readonly FoodOrderingDbcontext _FoodOrderingDbcontext;
        private IWebHostEnvironment _webHostEnvironment;
        public ProductsController(FoodOrderingDbcontext FoodOrderingDbcontext, IWebHostEnvironment webHostEnvironment)
        {
            _FoodOrderingDbcontext = FoodOrderingDbcontext;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult GetAllMenu()
        {
            var products = new List<Productmenu>();

            var product = _FoodOrderingDbcontext.Productmenu.ToList();
            if (product?.Any() == true)
            {
                foreach (var item in product)
                {
                    products.Add(new Productmenu()
                    {
                        Image_url = item.Image_url,
                        Title = item.Title,
                        Description = item.Description,
                        Price = item.Price,
                    }
                    );
                }
            }

            return View(products);
        }

        public IActionResult Details(int? id)
        {
            Cart cart = new Cart();
            {
                var Product = _FoodOrderingDbcontext.Productmenu.Where(model => model.Id == id).FirstOrDefault();
                
                cart.Count = 1;
            }
           
            return View(cart);
        }

    }
    }

