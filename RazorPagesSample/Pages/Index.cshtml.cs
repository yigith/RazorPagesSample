using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesSample.Data;

namespace RazorPagesSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext db;

        public IndexModel(AppDbContext context)
        {
            db = context;
        }

        public string Mesaj { get; set; }

        public List<Customer> Customers { get; set; }

        public void OnGet()
        {
            Customers = db.Customers.ToList();
        }

        public IActionResult OnPostDelete(int id)
        {
            var customer = db.Customers.Find(id);

            if (customer != null)
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
            }

            return RedirectToPage();
        }
    }
}
