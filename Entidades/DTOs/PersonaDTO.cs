using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOs
{
	public class PersonaDTO
	{
		public int DNI { get; set; }
		public string Nombres { get; set; }
		public string Paterno { get; set; }
		public string Materno { get; set; }
	}
}
