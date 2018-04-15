﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutosABC.Models;

namespace AutosABC.Controllers
{
    public class AutosController : Controller
    {
        private readonly AutosABCContext _context;

        public AutosController(AutosABCContext context)
        {
            _context = context;
        }

        // GET: Autos
        public async Task<IActionResult> Index()
        {
            var autosABCContext = _context.Auto.Include(a => a.Solicitud);
            return View(await autosABCContext.ToListAsync());
        }

        // GET: Autos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auto = await _context.Auto
                .Include(a => a.Solicitud)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (auto == null)
            {
                return NotFound();
            }

            return View(auto);
        }

        // GET: Autos/Crear/5
        // Method controller to create a new Auto within a specific SolicitudID
        public IActionResult Crear(int id)
        {
            ViewData["SolicitudID"] = id;
            return View();
        }

        // GET: Autos/Create
        public IActionResult Create()
        {
            ViewData["SolicitudID"] = new SelectList(_context.Solicitud, "SolicitudID", "SolicitudID");
            return View();
        }

        // POST: Autos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Marca,Modelo,Folio,Color,TipoTransmision,DescripcionEstetica,SolicitudID")] Auto auto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SolicitudID"] = new SelectList(_context.Solicitud, "SolicitudID", "SolicitudID", auto.SolicitudID);
            return View(auto);
        }

        // GET: Autos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auto = await _context.Auto.SingleOrDefaultAsync(m => m.ID == id);
            if (auto == null)
            {
                return NotFound();
            }
            ViewData["SolicitudID"] = new SelectList(_context.Solicitud, "SolicitudID", "SolicitudID", auto.SolicitudID);
            return View(auto);
        }

        // POST: Autos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Marca,Modelo,Folio,Color,TipoTransmision,DescripcionEstetica,SolicitudID")] Auto auto)
        {
            if (id != auto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoExists(auto.ID))
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
            ViewData["SolicitudID"] = new SelectList(_context.Solicitud, "SolicitudID", "SolicitudID", auto.SolicitudID);
            return View(auto);
        }

        // GET: Autos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auto = await _context.Auto
                .Include(a => a.Solicitud)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (auto == null)
            {
                return NotFound();
            }

            return View(auto);
        }

        // POST: Autos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auto = await _context.Auto.SingleOrDefaultAsync(m => m.ID == id);
            _context.Auto.Remove(auto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoExists(int id)
        {
            return _context.Auto.Any(e => e.ID == id);
        }
    }
}
