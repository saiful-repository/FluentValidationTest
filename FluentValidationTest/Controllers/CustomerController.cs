using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using FluentValidationTest.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System;

namespace FluentValidationTest.Controllers
{
    public class CustomerController : Controller
    {
        private IValidator<CustomerModel> _validator;
        public CustomerController(IValidator<CustomerModel> validator)
        {          
            _validator = validator;           
        }
        public IActionResult Index()
        {

            return View(new List<CustomerModel>());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerModel model)
        {
            ValidationResult result = await _validator.ValidateAsync(model);

            if (!result.IsValid)
            {               
                result.AddToModelState(this.ModelState);                
                return View(model);
            }

            return RedirectToAction("Index");
        }
    }
}
