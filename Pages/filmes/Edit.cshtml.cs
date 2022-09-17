using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APIfilmes.Data;
using APIfilmes.Pages.Models;

namespace APIfilmes.Pages.filmes
{
    public class EditModel : PageModel
    {
        private readonly APIfilmes.Data.APIfilmesContext _context;

        public EditModel(APIfilmes.Data.APIfilmesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produtos Produtos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produtos =  await _context.Produtos.FirstOrDefaultAsync(m => m.ID == id);
            if (produtos == null)
            {
                return NotFound();
            }
            Produtos = produtos;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Produtos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutosExists(Produtos.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProdutosExists(int id)
        {
          return _context.Produtos.Any(e => e.ID == id);
        }
    }
}
