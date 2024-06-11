using ApiRest.Data;
using AutoMapper;
using Entidades.DTOs;
using Entidades.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ApiRest.Controller.v1
{
	[Route("api/v1/[controller]")]
	[ApiController]
	[Authorize]
	public class PersonasController : ControllerBase
	{
		private readonly AplicationDbContext _context;
		private readonly IMapper _mapper;

		public PersonasController(AplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		[Authorize(Roles = "admin, user")]
		public async Task<ActionResult<List<PersonaDTO>>> ObtenerListadoPersona()
		{
			var personas = await _context.Personas.ToListAsync();
			if (personas.Count() <= 0)
				return NotFound("No hay personas");

			var personaDTOs = _mapper.Map<List<PersonaDTO>>(personas);
			return personaDTOs;
		}


		[HttpGet("{id}")]
		public async Task<ActionResult<Persona>> ObtenerPersona(int id)
		{
			var persona = await _context.Personas.Where(x => x.DNI == id).FirstOrDefaultAsync();
			if (persona == null)
				return NotFound("No se encontró persona con el id solicitado");

			return persona;
		}

		[HttpPost]
		public async Task<ActionResult> Crear(Persona persona)
		{
			try
			{
				await _context.Personas.AddAsync(persona);
				_context.SaveChanges();

				//return Ok("Persona se creo correctamente");
				return CreatedAtAction("ObtenerPersona", new { id = persona.DNI }, persona);
			}
			catch (Exception ex)
			{
				return BadRequest($"Ocurrio un error: {ex.Message}");
			}
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Modificar(int id, Persona persona)
		{
			try
			{
				var personaDb = await _context.Personas
				.Where(x => x.DNI == id).FirstOrDefaultAsync();

				if (personaDb == null)
					return NotFound("persona no existe");

				personaDb.Paterno = persona.Paterno;
				personaDb.Materno = persona.Materno;
				personaDb.Nombres = persona.Nombres;
				_context.SaveChanges();

				return Ok("Persona se modifico correctamente");
			}
			catch (Exception ex)
			{
				return BadRequest($"Ocurrio un error: {ex.Message}");
			}
		}


		[HttpDelete("{id}")]
		public async Task<ActionResult> Eliminar(int id)
		{
			var personaDb = await _context.Personas
				.Where(x => x.DNI == id).FirstOrDefaultAsync();

			if (personaDb == null)
				return NotFound("persona no existe");

			_context.Remove(personaDb);
			_context.SaveChanges();

			return Ok("Persona se elimino correctamente");
		}

	}
}
