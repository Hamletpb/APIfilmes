using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using APIfilmes.Data;
using APIfilmes.Pages.Models;

namespace APIfilmes.Pages.filmes
{
    public class CreateModel : PageModel
    {
        private readonly APIfilmes.Data.APIfilmesContext _context;

        public CreateModel(APIfilmes.Data.APIfilmesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Produtos Produtos { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Produtos.Add(Produtos);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
