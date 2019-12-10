using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesSample.Data;

namespace RazorPagesSample
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext db;

        public CreateModel(AppDbContext context)
        {
            db = context;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.Customers.Add(Customer);
            db.SaveChanges();
            
            return RedirectToPage("/Index");
        }
    }
}