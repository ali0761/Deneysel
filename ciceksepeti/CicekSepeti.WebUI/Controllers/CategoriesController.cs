﻿using CicekSepeti.Core.Entities;
using CicekSepeti.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CicekSepeti.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IService<Category> _service;

        public CategoriesController(IService<Category> service)
        {
            _service = service;
        }
        public async Task<IActionResult> IndexAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _service.GetQueryable().Include(p => p.Products)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
    }
}
