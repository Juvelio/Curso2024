using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Models
{
	public class Cita
	{
		[Key]
		public int Id { get; set; }
		public DateTime Fecha { get; set; }
		public string Observacion { get; set; }
		public bool Estado { get; set; }


		[ForeignKey("Medico")]
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }

		[ForeignKey("Persona")]
		public int PersonaId { get; set; }
		public Persona Persona { get; set; }
	}
}
