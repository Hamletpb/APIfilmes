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
    public class DetailsModel : PageModel
    {
        private readonly APIfilmes.Data.APIfilmesContext _context;

        public DetailsModel(APIfilmes.Data.APIfilmesContext context)
        {
            _context = context;
        }

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
    }
}
