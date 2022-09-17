using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using APIfilmes.Data;
using APIfilmes.Pages.Models;

namespace APIfilmes.Pages.filmes
{
    public class DeleteModel : PageModel
    {
        private readonly APIfilmes.Data.APIfilmesContext _context;

        public DeleteModel(APIfilmes.Data.APIfilmesContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Produtos Produtos { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produtos = await _context.Produtos.FirstOrDefaultAsync(m => m.ID == id);

            if (produtos == null)
            {
                return NotFound();
            }
            else 
            {
                Produtos = produtos;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }
            var produtos = await _context.Produtos.FindAsync(id);

            if (produtos != null)
            {
                Produtos = produtos;
                _context.Produtos.Remove(Produtos);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
