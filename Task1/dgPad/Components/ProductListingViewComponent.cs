﻿using dgPad.Infrastructure;
using dgPad.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dgPad.Components
{
        public class ProductListingViewComponent : ViewComponent
        {
                private DataContext _context;

                public IEnumerable<Product> Products;

                public ProductListingViewComponent(DataContext context)
                {
                        _context = context;
                }

                public IViewComponentResult Invoke(string className = "primary")
                {
                        ViewBag.Class = className;
                        return View(_context.Products.Include(p => p.Category).ToList());
                }
        }
}
