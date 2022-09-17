using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIfilmes.Pages.Models;

namespace APIfilmes.Data
{
    public class APIfilmesContext : DbContext
    {
        public APIfilmesContext (DbContextOptions<APIfilmesContext> options)
            : base(options)
        {
        }

        public DbSet<APIfilmes.Pages.Models.Produtos> Produtos { get; set; } = default!;
    }
}
