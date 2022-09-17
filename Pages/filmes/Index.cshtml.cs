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
    public class IndexModel : PageModel
    {
        private readonly APIfilmes.Data.APIfilmesContext _context;

        public IndexModel(APIfilmes.Data.APIfilmesContext context)
        {
            _context = context;
        }

        public IList<Produtos> Produtos { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Produtos != null)
            {
                Produtos = await _context.Produtos.ToListAsync();
            }
        }
    }
}
