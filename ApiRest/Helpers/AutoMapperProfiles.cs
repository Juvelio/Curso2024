using AutoMapper;
using Entidades.DTOs;
using Entidades.Models;

namespace ApiRest.Helpers
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
			CreateMap<Cita, CitaDTO>().ReverseMap();
			CreateMap<Persona, PersonaDTO>().ReverseMap();
		}
	}
}
