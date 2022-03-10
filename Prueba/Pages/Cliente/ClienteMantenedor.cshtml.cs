using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Prueba.Modelos;

namespace Prueba.Pages.Cliente
{


        [AllowAnonymous]
        public class ClienteMantenedorModel : PageModel
        {
            private readonly ILogger<ClienteMantenedorModel> _logger;
            private readonly SqlDbContext _context;

            public ClienteMantenedorModel(ILogger<ClienteMantenedorModel> logger, SqlDbContext context)
            {
                _logger = logger;
                _context = context;
            }

            public Modelos.Cliente objCliente { get; set; }
            public List<Modelos.Cliente> Lista { get; set; }

            public List<SelectListItem> ListaPaises { get; set; }

        public async Task<IActionResult> OnGet()
            {
            ListaPaises = new List<SelectListItem>();
            ListaPaises.Add(new SelectListItem { Text = "Estados Unidos", Value = "Estados Unidos" });
            ListaPaises.Add(new SelectListItem { Text = "Puerto Rico", Value = "Puerto Rico" });
            ListaPaises.Add(new SelectListItem { Text = "Otros", Value = "Otros" });


            Lista = await _context.Cliente.ToListAsync();
                return Page();
            }

            public async Task<IActionResult> OnGetEliminarAsync(int idcliente)
            {
                var objEliminar = await _context.Cliente.FirstOrDefaultAsync(p => p.IdCliente == idcliente);

                if (objEliminar != null)
                {
                    _context.Cliente.Remove(objEliminar);
                    _context.SaveChanges();
                }

                return Page();
            }


            public async Task<IActionResult> OnPostAgregarAsync(Modelos.Cliente objcliente)
            {
                var objEliminar = await _context.Cliente.AddAsync(objcliente);
                _context.SaveChanges();


            return RedirectToPage("/Cliente/ClienteMantenedor");
            }
    }
}
