using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineFoodOrder.DataAccess;
using OnlineFoodOrder.Models;

namespace OnlineFoodOrder.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly FoodOrderingDbcontext _FoodOrderingDbcontext;
        private IWebHostEnvironment _webHostEnvironment;    
        public AdminController(FoodOrderingDbcontext foodOrderingDbcontext, IWebHostEnvironment webHostEnvironment)
        {
            _FoodOrderingDbcontext = foodOrderingDbcontext;
            _webHostEnvironment = webHostEnvironment;   
             
            
        }

        public IActionResult Index()
        {
            List<Productmenu> data = _FoodOrderingDbcontext.Productmenu.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Productmenu productmenu)
        {
            if(ModelState.IsValid)
            {
                if (productmenu.ImagePath != null)
                {
                    string folder = "Productimages/images";
                    folder += Guid.NewGuid().ToString() + productmenu.ImagePath.FileName;
                    productmenu.Image_url = "~/"+ folder;
                    string serverfolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    productmenu.ImagePath.CopyTo(new FileStream (serverfolder, FileMode.Create)); 
                }                       

                var menu = new Productmenu();
                {
                    menu.Image_url = productmenu.Image_url;
                    menu.Title = productmenu.Title;
                    menu.Description = productmenu.Description;
                    menu.Price= productmenu.Price;
                };
                _FoodOrderingDbcontext.Productmenu.Add(menu);
               int a= _FoodOrderingDbcontext.SaveChanges();
                if (a > 0)
                {
                    
                        ModelState.Clear();
                    return RedirectToAction("Index", "Admin");
                }
                
            }
            return View(productmenu);
        }

        public IActionResult Edit(int id)
        {
            var editmenu = _FoodOrderingDbcontext.Productmenu.Where(model=>model.Id==id).FirstOrDefault();

            TempData["message"] = "editmenu.Image_url";    
            return View(editmenu);
        }
        [HttpPost]
        public IActionResult Edit(Productmenu productmenu)
        {
            if (ModelState.IsValid == true)
            {

                if (productmenu.ImagePath != null)
                {

                    string folder = "Productimages/images";
                    folder += Guid.NewGuid().ToString() + productmenu.ImagePath.FileName;
                    productmenu.Image_url = "~/" + folder;
                    string serverfolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    productmenu.ImagePath.CopyTo(new FileStream(serverfolder, FileMode.Create));
                }

                //var menu = new Productmenu();
                //{
                //    menu.Image_url = productmenu.Image_url;

                //};
                _FoodOrderingDbcontext.Entry(productmenu).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
               _FoodOrderingDbcontext.SaveChanges();

                return RedirectToAction("Index", "Admin");

            }

            return View();


            }

        public IActionResult delete(int id)
        {
            if(id>0)
            {
               var productrecord = _FoodOrderingDbcontext.Productmenu.Where(model=>model.Id==id).FirstOrDefault(); 
                
              if(productrecord != null)
                {

                    _FoodOrderingDbcontext.Entry(productrecord).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    _FoodOrderingDbcontext.SaveChanges();
                }

                return RedirectToAction("Index", "Admin");
            }

            
            return View();
        }


        public IActionResult Details(int id)
        {
            var productrecord = _FoodOrderingDbcontext.Productmenu.Where(model => model.Id == id).FirstOrDefault();
            return View(productrecord);
        }
    }
    }

