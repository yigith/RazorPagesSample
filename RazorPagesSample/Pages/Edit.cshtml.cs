using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesSample.Data;

namespace RazorPagesSample
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext db;

        public EditModel (AppDbContext context)
        {
            db = context;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public void OnGet(int id)
        {
            Customer = db.Customers.Find(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.Attach(Customer).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToPage("/Index");
        }
    }
}