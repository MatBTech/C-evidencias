using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechNova.Models;

namespace TechNova.Controllers
{
    public class ProductoesController : Controller
    {
        private readonly TechNovaDbContext _context;

        public ProductoesController(TechNovaDbContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: Productoes
        public async Task<IActionResult> Index(string searchString)
        {
            var productos = from p in _context.Productos
                            select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                productos = productos.Where(s => s.Nombre.Contains(searchString) || s.Codigo.Contains(searchString));
            }
                return View(await productos.ToListAsync());
        }

        // GET: Productoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductoId,Nombre,Descripcion,PrecioUnitario,Stock,Codigo")] Producto producto)
        {
            // Normalize name for comparison
            var nombreTrim = producto.Nombre?.Trim();

            if (string.IsNullOrEmpty(nombreTrim))
            {
                ModelState.AddModelError("Nombre", "El nombre del producto es obligatorio.");
            }
            else
            {
                // Check duplicate name (case-insensitive)
                var exists = await _context.Productos.AnyAsync(p => p.Nombre.ToLower() == nombreTrim.ToLower());
                if (exists)
                {
                    ModelState.AddModelError("Nombre", "Ya existe un producto con ese nombre.");
                }
            }

            if (ModelState.IsValid)
            {
                producto.Nombre = nombreTrim;
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductoId,Nombre,Descripcion,PrecioUnitario,Stock,Codigo")] Producto producto)
        {
            if (id != producto.ProductoId)
            {
                return NotFound();
            }

            var nombreTrim = producto.Nombre?.Trim();
            if (string.IsNullOrEmpty(nombreTrim))
            {
                ModelState.AddModelError("Nombre", "El nombre del producto es obligatorio.");
            }
            else
            {
                // Check duplicate name among other products
                var exists = await _context.Productos.AnyAsync(p => p.Nombre.ToLower() == nombreTrim.ToLower() && p.ProductoId != producto.ProductoId);
                if (exists)
                {
                    ModelState.AddModelError("Nombre", "Ya existe otro producto con ese nombre.");
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    producto.Nombre = nombreTrim;
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.ProductoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.ProductoId == id);
        }
    }
}
