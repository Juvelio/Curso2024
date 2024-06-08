using Entidades.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOs
{
	public class CitaDTO
	{
		public DateTime Fecha { get; set; }
		public string Observacion { get; set; }
		public bool Estado { get; set; }

		public int MedicoId { get; set; }
		public int PersonaId { get; set; }
	}
}
