﻿using ApiRest.Data;
using Entidades.DTOs;
using Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiRest.Controller.v1
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class CuentasController : ControllerBase
	{
		private readonly AplicationDbContext _context;
		private readonly IConfiguration _configuration;

		public CuentasController(AplicationDbContext context, IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;
		}

		[HttpPost]
		public async Task<ActionResult<string>> Login(UserLogin userLogin)
		{
			var usuario = await _context.Personas
				.Where(p => p.Usuario == userLogin.User && p.Password == userLogin.Password)
				.FirstOrDefaultAsync();

			if (usuario == null)
				return NotFound("No pudo iniciar sesion");			

			//DEVOLVER UN TOKEN

			var token = GenerarTokenJWT(usuario);
			return Ok(token);
		}

		private string GenerarTokenJWT(Persona persona)
		{
			// CREAMOS EL HEADER
			var _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:ClaveSecreta"]));
			var _signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
			var _header = new JwtHeader(_signingCredentials);

			//CREAR LOS CLAIMS
			var _claims = new[]
			{
				 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				 new Claim("nombre", persona.Nombres),
				 new Claim("paterno", persona.Paterno),
				 new Claim("llave", "El valor que yo quiera"),
				 //new Claim(JwtRegisteredClaimNames.Email, usuarioInfo.Email),
				 new Claim(ClaimTypes.Role, "admin")
			};

			// CREAMOS EL PAYLOAD (CARGA UTIL)
			var _payload = new JwtPayload(
				issuer: _configuration["JWT:Issuer"],
				audience: _configuration["JWT:Audience"],
				claims: _claims,
				notBefore: DateTime.UtcNow,
				expires: DateTime.UtcNow.AddDays(1)
				);

			// GENERAR TOKEN
			var _token = new JwtSecurityToken(_header, _payload);

			return new JwtSecurityTokenHandler().WriteToken(_token);
		}

	}
}
