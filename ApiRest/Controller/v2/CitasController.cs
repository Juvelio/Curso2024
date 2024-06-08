using ApiRest.Data;
using ApiRest.Repositorios;
using AutoMapper;
using Entidades.DTOs;
using Entidades.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Controller.v2
{
	[Route("api/v2/[controller]")]
	[ApiController]
	//[Authorize]
	public class CitasController : ControllerBase
	{
		private readonly AplicationDbContext _context;
		private readonly IMapper _mapper;
		private readonly CitaRepositorio _repositorio;

		public CitasController(AplicationDbContext context, IMapper mapper, CitaRepositorio repositorio)
		{
			_context = context;
			_mapper = mapper;
			_repositorio = repositorio;
		}

		// GET: api/Citas
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Cita>>> GetCitas()
		{
			//return await _context.Citas
			//	.Include(c => c.Medico).ThenInclude(m => m.Especialidad)
			//	.Include(c => c.Persona)
			//	.ToListAsync();

			var data = await _repositorio.ListarCita();
			return data;
		}		
	}
}
