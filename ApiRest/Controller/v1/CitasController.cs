using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiRest.Data;
using Entidades.Models;
using Entidades.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace ApiRest.Controller.v1
{
	[Route("api/v1/[controller]")]
	[ApiController]
	//[Authorize]
	public class CitasController : ControllerBase
	{
		private readonly AplicationDbContext _context;
		private readonly IMapper _mapper;

		public CitasController(AplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		// GET: api/Citas
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Cita>>> GetCitas()
		{
			return await _context.Citas
				.Include(c => c.Medico).ThenInclude(m => m.Especialidad)
				.Include(c => c.Persona)
				.ToListAsync();
		}

		// GET: api/Citas/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Cita>> GetCita(int id)
		{
			var cita = await _context.Citas.FindAsync(id);

			if (cita == null)
			{
				return NotFound();
			}

			return cita;
		}

		// PUT: api/Citas/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutCita(int id, Cita cita)
		{
			if (id != cita.Id)
			{
				return BadRequest();
			}

			_context.Entry(cita).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!CitaExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Citas
		[HttpPost]
		public async Task<ActionResult<Cita>> PostCita(CitaDTO dTO)
		{
			#region Mapeo manual ...
			//var cita = new Cita()
			//{
			//	Fecha = dTO.Fecha,
			//	Estado = dTO.Estado,
			//	Observacion = dTO.Observacion,
			//	MedicoId = dTO.MedicoId,
			//	PersonaId = dTO.PersonaId
			//};
			#endregion

			//MAPEO AUTOMATICO CON AUTOMAPPER
			var cita = _mapper.Map<Cita>(dTO);
			_context.Citas.Add(cita);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetCita", new { id = cita.Id }, cita);
		}

		// DELETE: api/Citas/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCita(int id)
		{
			var cita = await _context.Citas.FindAsync(id);
			if (cita == null)
			{
				return NotFound();
			}

			_context.Citas.Remove(cita);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool CitaExists(int id)
		{
			return _context.Citas.Any(e => e.Id == id);
		}
	}
}
